using System;

namespace Calculate;

public class Calculator
{
    public delegate void Calculation(string lineIn);

    public IReadOnlyDictionary<char, Func<double, double, double>> MathematicalOperations { get; }
        = new Dictionary<char, Func<double, double, double>>()
        {
            ['+'] = Add,
            ['-'] = Subtract,
            ['*'] = Multiply,
            ['/'] = Divide
        };

    public static double Add(double x, double y)
    {
        return x + y;
    }

    public static double Subtract(double x, double y)
    {
        return x - y;
    }

    public static double Multiply(double x, double y) 
    { 
        return x * y;
    }

    public static double Divide(double x, double y)
    {
        return x / y;
    }

}
