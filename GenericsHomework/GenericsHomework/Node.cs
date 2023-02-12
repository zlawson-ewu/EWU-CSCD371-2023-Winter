namespace GenericsHomework;

public class Node<TValue>
{
    public TValue? Value { get; set; }
    public Node<TValue> Next { get; private set; }
    public Node(TValue? value)
    {
        Value = value;
        Next = this;
    }

    public void Append(TValue value)
    {
        Node<TValue> temp = Next;
        Next = new(value) { Next = temp };
    }

    public void Clear()
    {

    }

    public override string? ToString()
    {
        return Value!.ToString();
    }
}