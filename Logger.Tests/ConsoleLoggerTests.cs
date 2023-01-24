using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace Logger.Tests;

[TestClass]
public class ConsoleLoggerTests
{
    readonly string testPath = Path.Combine(Directory.GetCurrentDirectory(), "consoleTestLog.txt");

    [TestMethod]
    public void ConsoleLogger_OnLog_PrintsMessageToConsole()
    {
        //Arrange
        string date = DateTime.Now.ToString();
        string testMessage = $" {date} {GetType().Name} {LogLevel.Information} : test";
        StreamWriter writer = File.AppendText(testPath);
        Console.SetOut(writer);
        //Act
        LogFactory factory = new LogFactory();
        BaseLogger consoleLogger = factory.CreateConsoleLogger(GetType().Name);
        consoleLogger.Log(LogLevel.Information, "test");
        writer.Dispose();
        string readLine = File.ReadLines(testPath).Last();
        //Assert
        Assert.AreEqual(testMessage, readLine);
    }
}
