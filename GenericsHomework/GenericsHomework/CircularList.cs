namespace GenericsHomework;

public class CircularList<TValue>
{
    private class Node
    {
        public TValue Value { get; set; }
        public Node Next { get; private set; }

        public Node(TValue value)
        {
            Value = value;
            Next = this;
        }
        public override string? ToString()
        {
            return Value!.ToString(); //usage of !, fix
        }
    }

    private Node Head { get; set; }

    public CircularList(TValue value)
    {
        Head = new(value);
    }

    public void Append(TValue value)
    {

    }

    public void Clear()
    {

    }
}