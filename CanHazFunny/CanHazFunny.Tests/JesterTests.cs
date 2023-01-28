using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.Metrics;

namespace CanHazFunny.Tests;

[TestClass]
public class JesterTests
{
    [ClassInitialize]
    public void TestSetup(TestContext testcontext)
    {
        JokeService jokeService = new();
        FunnyOut jokeWriter = new();
        Jester jester = new(jokeService, jokeWriter);
    }

    /*[TestMethod]
    public void Jester_Contains_JokeService()
    {
    }*/
}
