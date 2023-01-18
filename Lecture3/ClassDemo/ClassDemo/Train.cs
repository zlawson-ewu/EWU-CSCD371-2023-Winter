namespace ClassDemo;

public class Train : Vehicle
{
    public int Carriages { get; set; }

    public Train(string model, int carriages = 42) : base(model)
    {
        Carriages = carriages;
    }
}