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
        double result;
        Calculator.TryCalculate("2 + 3", out result);
        Console.WriteLine(result);
        Calculator.TryCalculate("2 - 3", out result);
        Console.WriteLine(result);
        Calculator.TryCalculate("2 * 3", out result);
        Console.WriteLine(result);
        Calculator.TryCalculate("2 / 3", out result);
        Console.WriteLine(result);
        Console.WriteLine(Calculator.TryCalculate("2 k 3", out _));
    }
}