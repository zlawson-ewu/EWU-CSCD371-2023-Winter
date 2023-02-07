namespace Logger
{
    public record class Person(FullName FName) : Entity
    {
        public override string Name { get; init; } = FName.ToString() ?? throw new ArgumentNullException(nameof(FName));

        public override string ToString()
        {
            return string.Format(", Full Name: " + Name);
        }
        public virtual bool Equals(Person? other)
        {
            if (other is null) return false;
            return Name == other.Name;
        }
        public override int GetHashCode() => HashCode.Combine(Id.GetHashCode(), Name.GetHashCode());

    }
}
