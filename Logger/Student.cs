namespace Logger;

public record class Student( int SID, FullName FName) : Person(FName)
{
    public int SID { get; init; } = SID <= 0 ? throw new ArgumentException(nameof(SID)) : SID;

    public override string ToString()
    {
        return "Student ID: "+ SID + base.ToString();
    }
    public virtual bool Equals(Student? other)
    {   
        if( other is null) return false;
        return (Name, SID) == (other?.Name, other?.SID);
    }

    public override int GetHashCode() => HashCode.Combine(SID.GetHashCode(), base.GetHashCode());
}