namespace GenericsHomework;

public class Node<TItem>
{
    public TItem Item { get; init; }
    public Node<TItem> Next { get; private set; }

    public Node(TItem item)
    {
        Item = item ?? throw new ArgumentNullException(nameof(item));
        Next = this ?? throw new ArgumentNullException(nameof(item));//Initially points to itself, cannot be null per instructions
    }

    public void Append(Node<TItem> list)
    {
        Next = list.Next!;
        list.Next!.Next = list.Next!;
    }

    public override string? ToString()
    {
        return Item!.ToString(); //Better way to handle than using '!'?
    }
}