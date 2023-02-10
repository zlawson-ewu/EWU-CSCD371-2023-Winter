using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests : FileLoggerTestsBase
{
    [TestMethod]
    public void CreateLogger_ReturnsTestLoggerWithSetFilePath()
    {
        LogFactory<TestLogger, TestLoggerFactory> logFactory = new();
        TestLogger logger = logFactory.CreateLogger(nameof(LogFactoryTests));
    }

    [TestMethod]
    public void ConfigureFileLogger_GivenFilePath_ReturnsFileLoggerWithSetFilePath()
    {
        //LogFactory<FileLogger, FileLoggerFactory> logFactory = new();
        //TestLogger logger = logFactory.CreateLogger(nameof(LogFactoryTests));
    }
}
