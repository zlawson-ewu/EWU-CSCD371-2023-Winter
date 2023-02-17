using System.Reflection.Metadata.Ecma335;

namespace LambdaExpressions;
public record FullName(string FirstName, string LastName)
{
    public FullName(string fullName): this(null!, null!)
    {

        if (fullName.Split(" ") is [string { Length: >0 } firstName, string { Length: >0 } lastName])
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    // Use pattern matching to return the initials of the FullName
    // Implement a Name property or override ToString() to return the full name.
    // Hints:
    //      Using multiple list patterns
    //      User recursion pattern matching


    public string Initials 
    { 
        get
        {
            
            string result;
            result = $"{FirstName[0]}{LastName[0]}";
            if ((FirstName.First(), LastName.First()) is (char firstInitial, char secondInitial))
                result = new string(new char[] { firstInitial, secondInitial });
            int[] numbers = new int[] { };
            List<double> doubleNumbers = null;
            if (Name.Split(" ") is [[char firstIntial,.. ], [char lastIntial, ..]])
            {
                result = $"{firstInitial}{lastIntial}";
            }
            return result;
        }
    }
    public string Name => $"{FirstName} {LastName}";
}
