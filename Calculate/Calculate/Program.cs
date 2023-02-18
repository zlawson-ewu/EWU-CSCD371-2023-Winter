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
        //test stuff, erase later
        string test = "53 + 32";
        string test2 = "53 % 32";
        bool hasKeys = test.Any(x => MathematicalOperations.Keys.Contains(x));
        bool hasNoKeys = test2.Any(x => MathematicalOperations.Keys.Contains(x));
        Console.WriteLine(hasKeys + " " + hasNoKeys);
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