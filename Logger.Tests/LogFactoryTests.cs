using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void LogFactory_ConfigureFileLogger_testLogFilePathValid()
    {
        string testPath = Path.Combine(Directory.GetCurrentDirectory(), "testLog.txt");

        LogFactory factory = new();
        factory.ConfigureFileLogger(testPath);

        Assert.AreEqual(true, Path.Exists(testPath));
    }
    [TestMethod]
    public void LogFactory_ConfigureFileLogger_testLogFilePathInvalid()
    {
        string testPath = Path.Combine(Directory.GetCurrentDirectory(), "nonExistantFile.txt");

        LogFactory factory = new();
        factory.ConfigureFileLogger(testPath);

        Assert.AreEqual(false, Path.Exists(testPath));
    }
    [TestMethod]
    public void LogFactory_CreateLogger_ReturnsLoggerIfConfigured()
    {
        string testPath = Path.Combine(Directory.GetCurrentDirectory(), "testLog.txt");

        LogFactory factory = new();
        factory.ConfigureFileLogger(testPath);
        BaseLogger logger = factory.CreateLogger("FileLogger");

        Assert.IsNotNull(logger);
        Assert.AreEqual(logger.ClassName, "FileLogger");
    }
    [TestMethod]
    public void LogFactory_CreateLogger_ReturnsNullIfNotConfigured()
    {
        LogFactory factory = new();

        Assert.AreEqual(null, factory.CreateLogger("FileLogger"));
    }
}
