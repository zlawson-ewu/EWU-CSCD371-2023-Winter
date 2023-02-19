namespace Calculate;

public class Program
{
    public Action<string> WriteLine { get; init; } = Console.WriteLine;

    public Func<string?> ReadLine { get; init; } = Console.ReadLine;

    public Program() { }

    public static void Main(string[] args)
    {
        Program prog = new();
        Calculator calc = new();
        double result;

        prog.WriteLine("Valid: " + calc.TryCalculate("2 + 3", out result) + ", Result: 2 + 3 = " + result);
        prog.WriteLine("Valid: " + calc.TryCalculate("22 - 33", out result) + ", Result: 22 - 33 = " + result);
        prog.WriteLine("Valid: " + calc.TryCalculate("2 * 3", out result) + ", Result: 2 * 3 = " + result);
        prog.WriteLine("Valid: " + calc.TryCalculate("2 / 3", out result) + ", Result: 2 / 3 = " + result);
        
        prog.WriteLine("Valid: " + calc.TryCalculate("2 k 3", out result) + ", Result: 2 k 3 = " + result);
        prog.WriteLine("Valid: " + calc.TryCalculate("2.2 / 3.3", out result) + ", Result: 2.2 / 3.3 = " + result);
    }
}