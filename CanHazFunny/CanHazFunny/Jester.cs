using System;

namespace CanHazFunny;

public class Jester
{
    public JokeService JokeService
    {
        get { return _JokeService!; }
        set { _JokeService = value; }
    }
    private JokeService? _JokeService;
    public FunnyOut JokeWriter
    {
        get { return _JokeWriter!; }
        set { _JokeWriter = value; }
    }
    private FunnyOut? _JokeWriter;

    public Jester(JokeService jokeService, FunnyOut jokeWriter)
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

    public void TellJoke(out string joke)
    {
        do
        {
            joke = JokeService.GetJoke();
        } while (CheckForChuckNorris(joke) is true);
        JokeWriter.PrintJokeToConsole(joke);
    }

    public static bool CheckForChuckNorris(string joke)
    {
        return (joke.Contains("Chuck") || joke.Contains("Norris") || joke.Contains("Walker"));
    }
}