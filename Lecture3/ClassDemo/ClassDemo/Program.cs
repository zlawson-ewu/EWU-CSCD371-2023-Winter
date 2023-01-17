namespace ClassDemo;

/*
 * To attend Thursday’s event, you must register TODAY. 
 * Space is limited and first come first served.
 * Go to bit.ly/spodotnet2023, under ‘Promo Code’ put 
 * EWUfree and reveal free ticket (if any remain). 
*/



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

    public static (int, string) ImplicitTypes()
    {
        string text = new('a', 10);
        return (42, text);
    }
}
