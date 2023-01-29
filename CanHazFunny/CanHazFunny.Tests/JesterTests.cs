using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Diagnostics.Metrics;

namespace CanHazFunny.Tests;

[TestClass]
public class JesterTests
{
    [TestMethod]
    public void Jester_Contains_JokeService()
    {
        //Arrange
        JokeService jokeService = new();
        FunnyOut jokeWriter = new();

        //Act
        Jester jester = new(jokeService, jokeWriter);

        //Assert
        Assert.AreEqual<JokeService>(jester.JokeService, jokeService);
    }

    [TestMethod]
    public void Jester_Contains_JokeWriter()
    {
        //Arrange
        JokeService jokeService = new();
        FunnyOut jokeWriter = new();

        //Act
        Jester jester = new(jokeService, jokeWriter);

        //Assert
        Assert.AreEqual<FunnyOut>(jester.JokeWriter, jokeWriter);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Jester_GivenNullJokeService_ThrowsNullException()
    {
        //Arrange
        FunnyOut jokeWriter = new();

        //Act
        new Jester(null!, jokeWriter);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Jester_GivenNullJokeWriter_ThrowsNullException()
    {
        //Arrange
        JokeService jokeService = new();

        //Act
        new Jester(jokeService, null!);
    }
}
