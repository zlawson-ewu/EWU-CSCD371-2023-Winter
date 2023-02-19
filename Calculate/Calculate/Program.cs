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

    }
}