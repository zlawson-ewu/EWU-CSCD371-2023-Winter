namespace CanHazFunny;

public interface IJokeService
{
    bool CheckForChuckNorris(string joke)
    {
        if (joke.Contains("Chuck") || joke.Contains("Norris") || joke.Contains("Walker"))
        {
            return true;
        }
        else return false;
    }
    abstract string GetJoke();
}