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
    public void CreateLogger_GivenTestLogger_Success()
    {
        TestLogger logger = TestLogger.CreateLogger<TestLogger>("Logger.Tests", "log.txt");
    }
}
