using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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