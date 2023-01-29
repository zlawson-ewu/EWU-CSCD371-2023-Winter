using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace CanHazFunny.Tests;

[TestClass]
public class FunnyOutTests
{
    readonly string testPath = Path.Combine(Directory.GetCurrentDirectory(), "funnyOutTest.txt");
    readonly string testMessage = "test";

    [TestMethod]
    public void FunnyOut_PrintJokeToConsole_PrintsMessageToConsole()
    {
        //Arrange
        StreamWriter writer = File.AppendText(testPath);
        Console.SetOut(writer);
        IFunnyOut funnyOut = new FunnyOut();
        funnyOut.PrintJokeToConsole(testMessage);

        //Act
        writer.Dispose();
        string readLine = File.ReadLines(testPath).Last();

        //Assert
        Assert.AreEqual(testMessage, readLine);

        //Cleanup
        File.Delete(testPath);
    }
}
