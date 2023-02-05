namespace Logger;
public sealed record class Product(int Id, string Name, double Price, string? Description)
{
    public string Name { get; } = Name ?? throw new ArgumentNullException(nameof(Name));
    public double Price { get; set; } = Price;

    public bool Equals(Product? other)
    {
        if (other is null) return false;
        return (Id, Name) == (other.Id, other.Name);
    }

    public override int GetHashCode()
    {
        return (Id, Name).GetHashCode();
    }
}
