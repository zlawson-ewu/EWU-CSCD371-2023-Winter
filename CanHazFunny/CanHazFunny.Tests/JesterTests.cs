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

    [TestMethod]
    public void Jester_GivenChuckNorrisJoke_ReturnTrue()
    {
        //Arrange
        string containsNorris = "Hi, I'm Chuck Norris";
        
        //Act
        bool isChuck = Jester.CheckForChuckNorris(containsNorris);

        //Assert
        Assert.IsTrue(isChuck);
    }

    [TestMethod]
    public void Jester_GivenNotChuckNorrisJoke_ReturnFalse()
    {
        //Arrange
        string containsNorris = "Hi, I'm not that guy with all the jokes written about him";

        //Act
        bool isChuck = Jester.CheckForChuckNorris(containsNorris);

        //Assert
        Assert.IsFalse(isChuck);
    }
}
