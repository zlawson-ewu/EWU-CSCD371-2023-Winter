namespace LambdaExpressions;
public record FullName(string FirstName, string LastName)
{
    public FullName(string fullName): this(null!, null!)
    {
        if (fullName.Split(" ") is [string firstName, string lastName ])
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
            return null;
        }
    }
}
