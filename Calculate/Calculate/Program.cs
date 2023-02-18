namespace Calculate;

public class Program
{
    public Func<string, string>? WriteLine
    {
        get
        {
            return WriteLine;
        }
        init
        {
            Console.WriteLine();
        } 
    }

    public Func<string, string>? ReadLine 
    {
        get
        {
            return ReadLine;
        }
        init
        {
            Console.ReadLine();
        }
    }

    public Program(Func<string, string>? writeLine, Func<string, string>? readLine)
    {
        WriteLine = writeLine;
        ReadLine = readLine;
    }

    public Program() { }
    public static void Main(string[] args)
    {

    }
}