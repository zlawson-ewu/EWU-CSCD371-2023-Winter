using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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