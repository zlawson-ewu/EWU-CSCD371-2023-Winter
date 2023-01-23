using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    string testPath = Path.Combine(Directory.GetCurrentDirectory(), "testLog.txt");

    [TestMethod]
    public void LogFactory_CreateLogger_ReturnsLoggerIfConfigured()
    {
        //Arrange
        //Act
        LogFactory factory = new();
        factory.ConfigureFileLogger(testPath);
        BaseLogger logger = factory.CreateLogger(GetType().Name);
        //Assert
        Assert.IsNotNull(logger);
    }
    [TestMethod]
    public void LogFactory_CreateLogger_ReturnsNullIfNotConfigured()
    {
        //Arrange
        //Act
        LogFactory factory = new();
        //Assert
        Assert.AreEqual(null, factory.CreateLogger(GetType().Name));
    }
}
