using System;

namespace CanHazFunny;

public class FunnyOut : IFunnyOut
{
    public void PrintJokeToConsole(string joke)
    {
        Console.WriteLine(joke);
    }
}