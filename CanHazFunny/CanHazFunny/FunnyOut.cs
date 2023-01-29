using System;

namespace CanHazFunny;

public class FunnyOut : IFunnyOut
{
    public string Joke
    {
        get => _Joke!;
        set => _Joke = value;
    }
    private string? _Joke;

    public void PrintJokeToConsole(string joke)
    {
        Console.WriteLine(joke);
    }
}