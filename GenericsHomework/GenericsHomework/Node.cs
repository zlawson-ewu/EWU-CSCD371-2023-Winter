using System.Reflection.Metadata.Ecma335;

namespace GenericsHomework;

public class Node<TValue>
{
    public TValue Value { get; init; }
    public Node<TValue> Next { get; private set; }

    public Node(TValue value)
    {
        Value = value;//?? throw new ArgumentNullException(nameof(value));
        Next = this ?? throw new ArgumentNullException(nameof(value));//Initially points to itself, cannot be null per instructions
    }

    public void Append(TValue value)
    {

    }

    public void Clear(Node<TValue> node)
    {

    }

    public override string? ToString()
    {
        return Value!.ToString(); //Better way to handle than using '!'?
    }
}