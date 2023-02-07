using System.Security.Cryptography;

namespace Logger;

public record class Employee(int EID, FullName FName) : Person(FName)
{
    public int EID { get; init; } = EID <= 0 ? throw new ArgumentException(nameof(EID)) : EID;

    public override string ToString() => "Employee ID: " + EID + base.ToString();

    public virtual bool Equals(Employee? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return (Name, EID) == (other?.Name, other?.EID);
    }
  
    public override int GetHashCode() => HashCode.Combine(EID.GetHashCode(), base.GetHashCode());
}