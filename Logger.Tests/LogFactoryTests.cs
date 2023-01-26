using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    readonly string testPath = Path.Combine(Directory.GetCurrentDirectory(), "testLog.txt");

    [TestMethod]
    public void LogFactory_CreateLogger_ReturnsLoggerIfConfigured()
    {
        //Arrange

        //Act
        LogFactory factory = new();
        factory.ConfigureFileLogger(testPath);
        BaseLogger logger = factory.CreateLogger(nameof(LogFactoryTests));

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
        Assert.AreEqual(null, factory.CreateLogger(nameof(LogFactoryTests)));
    }

    [TestMethod]
    public void FileLogger_OnCreation_SetsClassName()
    {
        //Arrange

        //Act
        LogFactory factory = new();
        factory.ConfigureFileLogger(testPath);
        BaseLogger logger = factory.CreateLogger(nameof(LogFactoryTests));
        string name = logger.ClassName!;

        //Assert
        Assert.AreEqual(name, nameof(LogFactoryTests));
    }

    [TestMethod]
    public void LogFactory_CreateConsoleLogger_ReturnsConsoleLogger()
    {
        //Arrange

        //Act
        LogFactory factory = new();
        BaseLogger logger = factory.CreateConsoleLogger(nameof(LogFactoryTests));

        //Assert
        Assert.IsNotNull(logger);
    }

    [TestMethod]
    public void ConsoleLogger_OnCreation_SetsClassName()
    {
        //Arrange

        //Act
        LogFactory factory = new();
        BaseLogger logger = factory.CreateConsoleLogger(nameof(LogFactoryTests));
        string name = logger.ClassName!;

        //Assert
        Assert.AreEqual(name, nameof(LogFactoryTests));
    }
}
