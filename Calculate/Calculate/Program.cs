using ConsoleUtilities;
namespace Calculate;

public class Program : ProgramBase
{
    public static void Main()
    {
        Program prog = new();
        Calculator calc = new();
        do
        {
            prog.WriteLine("Enter a simple two-integer-operand calculation using +, -, *, or / as the operator.");
            prog.WriteLine("Surround the operator with whitespace. Ex: \"2 + 2\", \"29 * 32\"");
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