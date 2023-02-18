using System;

namespace Calculate;

public class Calculator
{
    public static bool TryCalculate(string calculation)
    {
        bool result = false;
        if (calculation.Contains(" " + calculation.Any(x => MathematicalOperations.Keys.Contains(x)) + " "))
        {

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
