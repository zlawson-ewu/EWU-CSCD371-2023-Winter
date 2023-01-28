using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new ArgumentNullException("jokeService passed to Jester contructor cannot be null.");
        }
        this.JokeService = jokeService;
        if (jokeWriter is null)
        {
            throw new ArgumentNullException("joke passed to Jester constructor cannot be null.");
        }
        this.JokeWriter = jokeWriter;
    }

    public void TellJoke()
    {
        this.JokeWriter.Joke = JokeService.GetJoke();
        this.JokeWriter.PrintJokeToConsole(this.JokeWriter.Joke);
    }
}