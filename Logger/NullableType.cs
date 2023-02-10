namespace Logger;
public struct NullableInt
{
    public NullableInt(int value)
    {
        Value = value;
        HasValue = true;
    }
    public int Value { get; set; }
    public bool HasValue { get; }
}

public struct NullableDouble
{
    public int Value { get; set; }
    public bool HasValue { get; }
}

public struct CustomNullable<TValueType> where TValueType : struct
{
    public CustomNullable(TValueType value)
    {
        Value = value;
        HasValue = true;
    }
    public TValueType Value { get; set; }
    public bool HasValue { get; }
}

public struct CustomObject
{
    public CustomObject(object value)
    {
        Value = value;
    }
    public object Value { get; set; }
}
