namespace Calculate;

public class Program
{
    public Action<string> WriteLine { get; init; } = Console.WriteLine;

    public Func<string?> ReadLine { get; init; } = Console.ReadLine;

    public Program() { }

    public static void Main()
    {
        Program prog = new();
        Calculator calc = new();
        do
        {
            prog.WriteLine("Enter a simple two-integer-operand calculation using +, -, *, or / as the operator.");
            if (calc.TryCalculate(prog.ReadLine()!, out double result))
            {
                prog.WriteLine("The result is " + result);
            }
            else
            {
                prog.WriteLine("Invalid operation format.");
            }
            prog.WriteLine("Continue? Enter the 'Y' key to run again, enter anything else to quit.");
        }
        while (prog.ReadLine() == "Y");
    }
}