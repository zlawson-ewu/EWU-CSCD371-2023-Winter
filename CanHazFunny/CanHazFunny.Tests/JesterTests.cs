using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

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
    public void Jester_TellJoke_SkipsChuckNorris()
    {
        //Arrange
        var mockService = new Mock<IJokeService>();
        mockService.SetupSequence(x => x.GetJoke())
            .Returns("Chuck Norris")
            .Returns("test");
        IJokeService jokeService = mockService.Object;

        var mockWriter = new Mock<IFunnyOut>();
        mockWriter.Setup(x => x.PrintJokeToConsole("test")).Verifiable();
        IFunnyOut jokeWriter = mockWriter.Object;

        Jester jester = new(jokeService, jokeWriter);

        //Act
        jester.TellJoke();

        //Assert
        mockWriter.Verify(x => x.PrintJokeToConsole("test"), Times.Once);
    }
}
