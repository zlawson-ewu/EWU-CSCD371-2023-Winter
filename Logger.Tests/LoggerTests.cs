using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;

[TestClass]
public class LoggerTests
{
    [TestMethod]
    public void CreateLogger_GivenFileLogger_Success()
    {
        FileLogger logger = FileLogger.CreateLogger("Logger.Tests", "log.txt");
    }

    [TestMethod]
    public void CreateLogger_GivenTestLoggerFactory_Success()
    {
        TestLoggerFactory factory = new();
    }

    [TestMethod]
    public void CreateFromFactory()
    {
        TestLoggerFactory testLoggerFactory = new TestLoggerFactory();
        TestLogger logger = new TestLogger(nameof(FileLoggerTests));
    }

    [TestMethod]
    public void Create_FileLogger()
    {
        // Pending configuration
        //ILogger logger =
        //    new LogFactory<FileLogger, FileLoggerFactory>().CreateLogger(nameof(FileLoggerTests));
    }
}
