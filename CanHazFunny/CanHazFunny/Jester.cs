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
        this.JokeService = jokeService;
        if (jokeWriter is null)
        {
            throw new ArgumentNullException(jokeWriter + "cannot be null.");
        }
        JokeWriter = jokeWriter;
    }

    public void TellJoke()
    {
        JokeWriter.Joke = JokeService.GetJoke();
        JokeWriter.PrintJokeToConsole(JokeWriter.Joke);
    }
}