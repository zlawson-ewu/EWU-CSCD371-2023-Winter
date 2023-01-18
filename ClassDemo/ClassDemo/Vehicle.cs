namespace ClassDemo;
public class Vehicle
{
    public Vehicle(string model)
    {
        Model = model;
    }

    private string? _Model;
    public string Model 
    {
        get 
        {
            return _Model!;
        }
        set 
        {
            ArgumentNullException.ThrowIfNull(value);
            ArgumentException.ThrowIfNullOrEmpty(value.Trim());
            _Model = value;
        }
    }
}