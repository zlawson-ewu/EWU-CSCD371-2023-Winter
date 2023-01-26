using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    readonly string testPath = Path.Combine(Directory.GetCurrentDirectory(), "testLog.txt");

    [TestMethod]
    public void FileLogger_OnLog_AppendsMessageToFile()
    {
        //Arrange
        string date = DateTime.Now.ToString();
        string testMessage = $"{date} {GetType().Name} {LogLevel.Information} : test";

        //Act
        LogFactory factory = new();
        factory.ConfigureFileLogger(testPath);
        BaseLogger logger = factory.CreateLogger(nameof(FileLoggerTests));
        logger.Log(LogLevel.Information, "test");
        string readLine = File.ReadLines(testPath).Last();

        //Assert
        Assert.AreEqual(testMessage, readLine);
    }
}
