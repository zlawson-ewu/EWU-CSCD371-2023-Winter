using IntelliTect.TestTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment.Tests;

[TestClass]
public class PingProcessTests
{
    PingProcess Sut { get; set; } = new();

    [TestInitialize]
    public void TestInitialize()
    {
        Sut = new();
    }

    [TestMethod]
    public void Start_PingProcess_Success()
    {
        // Arrange
        // Act
        Process process = Process.Start("ping", "localhost");
        process.WaitForExit();

        // Assert
        Assert.AreEqual<int>(0, process.ExitCode);
    }

    [TestMethod]
    public void Run_GoogleDotCom_Success()
    {
        // Arrange
        // Act
        int exitCode = Sut.Run("google.com").ExitCode;

        // Assert
        Assert.AreEqual<int>(0, exitCode);
    }


    [TestMethod]
    public void Run_InvalidAddressOutput_Success()
    {
        // Arrange
        // Act
        (int exitCode, string? stdOutput) = Sut.Run("badaddress.king[");

        // Assert
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.AreEqual<string?>(
            "Ping request could not find host badaddress.king[. Please check the name and try again.".Trim(),
            stdOutput,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(1, exitCode);
    }

    [TestMethod]
    public void Run_CaptureStdOutput_Success()
    {
        // Arrange
        // Act
        PingResult result = Sut.Run("localhost");

        // Assert
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void RunTaskAsync_Success()
    {
        // Arrange
        // Act
        Task<PingResult> task = Sut.RunTaskAsync("localhost");
        PingResult result = task.Result;
        task.Wait();

        // Assert
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        // Arrange
        // Act
        Task<PingResult> task = Sut.RunAsync("localhost");
        PingResult result = task.Result;
        task.Wait();

        // Assert
        AssertValidPingOutput(result);
    }

    [TestMethod]
    async public Task RunAsync_UsingTpl_Success()
    {
        // DO use async/await in this test.
        // Arrange
        // Act
        PingResult result = await Sut.RunAsync("localhost");

        // Assert
        AssertValidPingOutput(result);
    }


    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        // Arrange
        CancellationTokenSource tokenSource = new();

        // Act
        Task<PingResult> result = Task.Run(() => Sut.RunAsync("localhost", tokenSource.Token));
        tokenSource.Cancel();
        result.Wait();

        // Assert
    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        // Arrange
        CancellationTokenSource tokenSource = new();

        // Act
        try
        {
            Task<PingResult> result = Task.Run(() => Sut.RunAsync("localhost", tokenSource.Token));
            tokenSource.Cancel();
            result.Wait();
        }
        catch (AggregateException exception)
        {
            exception.Flatten();
            foreach (Exception inner in exception.InnerExceptions)
            {
                throw inner;
            }
        }
        // Assert
    }

    [TestMethod]
    async public Task RunAsync_MultipleHostAddresses_True()
    {
        // Arrange
        string[] hostNames = new string[] { "localhost", "localhost", "localhost", "localhost" };
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length * hostNames.Length;

        // Act
        PingResult result = await Sut.RunAsync(hostNames);

        // Assert
        int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;
        Assert.AreEqual<int?>(expectedLineCount, lineCount);
    }

    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_MultipleHostAddresses_CancelsWhenRequested()
    {
        // Arrange
        CancellationTokenSource tokenSource = new();
        string[] hostNames = new string[] { "google.com", "reddit.com", "netflix.com", "wikipedia.com" };

        // Act
        Task<PingResult> result = Task.Run(() => Sut.RunAsync(hostNames, tokenSource.Token));
        tokenSource.Cancel();
        result.Wait();

        // Assert
    }

    [TestMethod]
    async public Task RunLongRunningAsync_UsingTpl_Success()
    {
        // Arrange
        // Act
        PingResult result = await Sut.RunLongRunningAsync("localhost");

        // Assert
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        // Arrange
        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        System.Text.StringBuilder stringBuilder = new();

        // Act
        numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
        int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;

        // Assert
        Assert.AreNotEqual<int>(lineCount, numbers.Count() + 1);
    }

    readonly string PingOutputLikeExpression = @"
Pinging * with 32 bytes of data:
Reply from ::1: time<*
Reply from ::1: time<*
Reply from ::1: time<*
Reply from ::1: time<*

Ping statistics for ::1:
    Packets: Sent = *, Received = *, Lost = 0 (0% loss),
Approximate round trip times in milli-seconds:
    Minimum = *, Maximum = *, Average = *".Trim();
    private void AssertValidPingOutput(int exitCode, string? stdOutput)
    {
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression) ?? false,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);
}
