using System;

namespace Calculate;

public class Calculator
{
    public static bool TryCalculate(string calculation, out double result)
    {
        bool validCalculationString = false;
        result = default;
        string[] tokens = calculation.Split(' ');
        if (tokens.Length == 3)
        {
            if (int.TryParse(tokens[0], out int x)
                && tokens[1].Any(x => MathematicalOperations.Keys.Contains(x))
                && char.TryParse(tokens[1], out char opChar)
                && int.TryParse(tokens[2], out int y))
            {
                validCalculationString = true;
                Func<int, int, double> mathOperation = MathematicalOperations[opChar];
                result = mathOperation(x, y);
            }
        }
        return validCalculationString;
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

    public static double Divide(int x, int y) => (double)x / y;

}
