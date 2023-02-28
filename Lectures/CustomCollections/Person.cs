namespace Week_07_LINQ;
public record class Person(string FirstName, string LastName, DateTime? dateOfBirth)
{
    public Person(string firstName, string lastName) : this(firstName, lastName, null)
    {
    }
}
