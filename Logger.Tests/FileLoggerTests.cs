using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_OnCreation_HasClassName()
        {
            string testPath = "C:\\Users\\zachl\\Source\\Repos\\EWU-CSCD371-2023-Winter\\Logger.Tests\\Logger.Tests.csproj";
            LogFactory factory = new();
            factory.ConfigureFileLogger(testPath);
            BaseLogger logger = factory.CreateLogger(this.GetType().Name);
            string name = logger.ClassName;
            logger.Log(LogLevel.Information, name);
            Assert.AreEqual(name, this.GetType().Name);
        }
        
    }
}
