namespace Calculate;

public class Program
{
    public Action<string>? WriteLine
    {
        //get; set;

        get
        {
            return WriteLine;
        }
        init
        {
            Console.WriteLine();
        }

    }

    public Func<string>? ReadLine
    {
        //get; set;
        get
        {
            return ReadLine;
        }
        init
        {
            Console.ReadLine();
        }

    }

    public Program() { }
    public static void Main(string[] args)
    {
        Calculator calc = new();
        double result;
        Console.WriteLine("Valid: " + calc.TryCalculate("2 + 3", out result) + ", Result: 2 + 3 = " + result);
        Console.WriteLine("Valid: " + calc.TryCalculate("2 - 3", out result) + ", Result: 2 - 3 = " + result);
        Console.WriteLine("Valid: " + calc.TryCalculate("2 * 3", out result) + ", Result: 2 * 3 = " + result);
        Console.WriteLine("Valid: " + calc.TryCalculate("2 / 3", out result) + ", Result: 2 / 3 = " + result);
        Console.WriteLine("Valid: " + calc.TryCalculate("2 k 3", out result) + ", Result: 2 k 3 = " + result);
    }
}