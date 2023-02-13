namespace GenericsHomework.Test;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void Node_SingleNodeConfiguration_IsCorrect()
    {
        Node<string> firstNode = new("First node");
        Assert.AreEqual<Node<string>>(firstNode, firstNode.Next);
    }

    [TestMethod]
    public void Node_ToStringOverride_works()
    {
        Node<string> node = new("I hope this works...");
        Assert.AreEqual<string>("I hope this works...", node.ToString()!);
    }

    [TestMethod]
    public void Node_ToStringOverride_HandlesNull()
    {
        Node<string> node = new(null);
        Assert.AreEqual<string>("null", node.ToString()!);
    }

    [TestMethod]
    public void Append_AddsNewNode_Success()
    {
        Node<int> list = new(1);
        list.Append(2);

        Assert.AreEqual<int>(2, list.Next.Value);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Append_PreventsDuplicateEntries_True()
    {
        Node<string> firstNode = new("First node");
        firstNode.Append("Second node");
        firstNode.Append("Third node");
        firstNode.Append("Fourth node");

        firstNode.Append("Fourth node");
    }

    [TestMethod]
    public void Node_ListHeadPointsToTail_True()
    {
        Node<string> list = new("First node");
        list.Append("Second node");
        list.Append("Third node");
        list.Append("Fourth node");

        Assert.AreEqual<string>("Fourth node", list.Next.Value!);
    }

    [TestMethod]
    public void Exists_IsInList_ReturnsTrue()
    {
        Node<string> list = new("First node");
        list.Append("Second node");
        list.Append("Third node");
        list.Append("Fourth node");

        Assert.IsTrue(list.Exists("Second node"));
    }

    [TestMethod]
    public void Exists_NotInList_ReturnsFalse()
    {
        Node<int> list = new(1);
        list.Append(2);
        list.Append(3);
        list.Append(4);

        Assert.IsFalse(list.Exists(5));
    }

    [TestMethod]
    public void Clear_RemovesAllOthers_Success()
    {
        Node<int> list = new(1);
        list.Append(2);
        list.Append(3);
        list.Append(4);

        list.Clear();

        Assert.AreEqual<Node<int>>(list, list.Next);
    }
}