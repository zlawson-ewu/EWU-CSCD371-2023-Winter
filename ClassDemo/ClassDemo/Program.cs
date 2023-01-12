namespace ClassDemo;

public class Program
{
    public static string GetName(string firstName, string lastName)
    {
        return $"{firstName} {lastName}";
    }

    static void Main(string[] args)
    {
        string name = "Inigo Montoya";
        Console.WriteLine($"Hello, {name}");
    }
}
