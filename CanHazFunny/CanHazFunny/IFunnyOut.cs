using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public interface IFunnyOut
{
    string Joke { get; set; }
    abstract void PrintJokeToConsole(string joke);
}