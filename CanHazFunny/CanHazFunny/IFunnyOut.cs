namespace CanHazFunny;

public interface IFunnyOut
{
    string Joke { get; set; }
    abstract void PrintJokeToConsole(string joke);
}