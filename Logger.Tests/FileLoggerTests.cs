using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_OnCreation_HasCallingClassName()
        {
            string testPath = "C:\\Users\\zachl\\Desktop\\test.txt";
            LogFactory factory = new();
            factory.ConfigureFileLogger(testPath);
            BaseLogger logger = factory.CreateLogger(GetType().Name);
            string name = logger.ClassName;
            logger.Log(LogLevel.Information, "This is a test message.");
            Assert.AreEqual(name, GetType().Name);
        }
        
    }
}
