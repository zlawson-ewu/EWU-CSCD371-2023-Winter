namespace Logger;

//Full names are strings which are immutable and likely to be more than 16 bytes, so a record class is chosen.

//The type is immutable because it is a class, which is a reference type.
public record class FullName(string FirstName, string LastName, string? MiddleName = null)
{
    public string FirstName { get; } = FirstName??throw new ArgumentNullException(nameof(FirstName));
    public string LastName { get; } = LastName??throw new ArgumentNullException(nameof(LastName));
    public string? MiddleName { get; } = MiddleName;
}
