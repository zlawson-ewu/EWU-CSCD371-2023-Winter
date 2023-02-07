namespace Logger;

//A.)Creating a 'record class' to define a custom value type as opposed to a 'record struct' because...
/////1.) FullNameRecord logically represents up to three values.
/////2.) It will be immutable.
/////3.) It is possible/likely a full name will be greater than 16-bytes of data.
/////4.) It will be boxed frequently by the Storage class, so memory overhead will be less than using a value type.
/////5.) Nothing should need to inherit from this record.

//B.)The Type is immutable because the property declarations are decorated with the 'init' modifier, meaning
/////the positional parameters can only be set in the constructor or object initializers during initialization and cannot be changed after.
public record class FullName(string FirstName, string LastName, string? MiddleName = null)
{
    public string FirstName { get; init; } = FirstName??throw new ArgumentNullException(nameof(FirstName));
    public string LastName { get; init; } = LastName??throw new ArgumentNullException(nameof(LastName));
    public string? MiddleName { get; init; } = MiddleName;

    public override string ToString()
    {
        if (MiddleName == null) return FirstName + " " + LastName;
        return FirstName + " " + MiddleName + " " + LastName;
    }
}
