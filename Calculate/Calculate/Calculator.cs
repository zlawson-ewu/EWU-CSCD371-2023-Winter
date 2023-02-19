using System;

namespace Calculate;

public class Calculator
{
    public static bool TryCalculate(string calculation)
    {
        bool result = false;
        string[] tokens = calculation.Split(' ');
        if (tokens.Length == 3)
        {
            int x, y;
            if (int.TryParse(tokens[0], out x) 
                && tokens[1].Any(x => MathematicalOperations.Keys.Contains(x)) 
                && int.TryParse(tokens[2], out y))
            {
                result = true;
            }
        }
        return result;
    }

    public static IReadOnlyDictionary<char, Func<int, int, double>> MathematicalOperations { get; }
        = new Dictionary<char, Func<int, int, double>>()
        {
            ['+'] = Add,
            ['-'] = Subtract,
            ['*'] = Multiply,
            ['/'] = Divide
        };

    public static double Add(int x, int y) => x + y;

    public static double Subtract(int x, int y) => x - y;

    public static double Multiply(int x, int y) => x * y;

    public static double Divide(int x, int y) => x / y;

}
