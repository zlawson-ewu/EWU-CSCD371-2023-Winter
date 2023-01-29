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
        IJokeService jokeService = new JokeService();
        IFunnyOut jokeWriter = new FunnyOut();

        //Act
        Jester jester = new(jokeService, jokeWriter);

        //Assert
        Assert.AreEqual<IJokeService>(jester.JokeService, jokeService);
    }

    [TestMethod]
    public void Jester_Contains_JokeWriter()
    {
        //Arrange
        IJokeService jokeService = new JokeService();
        IFunnyOut jokeWriter = new FunnyOut();

        //Act
        Jester jester = new(jokeService, jokeWriter);

        //Assert
        Assert.AreEqual<IFunnyOut>(jester.JokeWriter, jokeWriter);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Jester_GivenNullJokeService_ThrowsNullException()
    {
        //Arrange
        IFunnyOut jokeWriter = new FunnyOut();

        //Act
        new Jester(null!, jokeWriter);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Jester_GivenNullJokeWriter_ThrowsNullException()
    {
        //Arrange
        IJokeService jokeService = new JokeService();

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
        string doesntContainNorris = "Hi, I'm not that guy with all those jokes written about him";

        //Act
        bool isChuck = Jester.CheckForChuckNorris(doesntContainNorris);

        //Assert
        Assert.IsFalse(isChuck);
    }

    [TestMethod]
    public void Jester_TellJoke_SkipsChuckNorris()
    {
        var mockService = new Mock<IJokeService>();
        mockService.SetupSequence(x => x.GetJoke())
            .Returns("Chuck Norris")
            .Returns("Norris the man")
            .Returns("test")
            .Returns("Chuck the myth")
            .Returns("Walker Texas Ranger");
        IJokeService jokeService = mockService.Object;

        var mockWriter = new Mock<IFunnyOut>();
        mockWriter.Setup(x => x.PrintJokeToConsole("test")).Verifiable();
        IFunnyOut jokeWriter = mockWriter.Object;

        Jester jester = new(jokeService, jokeWriter);

        jester.TellJoke();
        mockWriter.Verify(x => x.PrintJokeToConsole("test"), Times.Once);
    }
}
