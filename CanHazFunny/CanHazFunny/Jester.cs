using System;

namespace CanHazFunny;

public class Jester
{
    public IJokeService JokeService
    {
        get { return _JokeService!; }
        set { _JokeService = value; }
    }
    private IJokeService? _JokeService;
    public IFunnyOut JokeWriter
    {
        get { return _JokeWriter!; }
        set { _JokeWriter = value; }
    }
    private IFunnyOut? _JokeWriter;

    public Jester(IJokeService jokeService, IFunnyOut jokeWriter)
    {
        if (jokeService is null)
        {
            throw new ArgumentNullException(jokeService + "cannot be null.");
        }
        JokeService = jokeService;
        if (jokeWriter is null)
        {
            throw new ArgumentNullException(jokeWriter + "cannot be null.");
        }
        JokeWriter = jokeWriter;
    }

    public void TellJoke()
    {
        string joke;
        do
        {
            joke = JokeService.GetJoke();
        } while (joke.Contains("Chuck Norris") is true);
        JokeWriter.PrintJokeToConsole(joke);
    }
}