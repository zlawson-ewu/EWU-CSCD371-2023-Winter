using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests : FileLoggerTestsBase
{
    [TestMethod]
    public void ConfigureFileLogger_GivenFilePath_ReturnsFileLoggerWithSetFilePath()
    {
        LogFactory<TestLogger, TestLoggerFactory> logFactory = new();
        TestLogger logger = logFactory.CreateLogger(nameof(LogFactoryTests));
        //logFactory.ConfigureFileLogger(FilePath);
    }
}
