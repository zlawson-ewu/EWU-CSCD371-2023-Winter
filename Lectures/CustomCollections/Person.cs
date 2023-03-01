namespace Week08.CustomCollections;
public record class Person(string FirstName, string LastName, DateTime? dateOfBirth)
{
    public Person(string firstName, string lastName) : this(firstName, lastName, null)
    {
    }

    public string Name { get => $"{FirstName} {LastName}"; }
}
