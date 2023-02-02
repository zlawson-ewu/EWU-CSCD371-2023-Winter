namespace Logger;
public record class Product(string Name, double Price, string? Description)
{
    public string Name { get; } = Name ?? throw new ArgumentNullException(nameof(Name));
    public double Price { get; set; } = Price;
}

public record class SuperProduct(string Name, double Price, string? Description, double Discount) : 
    Product(Name, Price, Description)
{
}




