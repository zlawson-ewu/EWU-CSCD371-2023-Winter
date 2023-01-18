namespace ClassDemo.Tests;

[TestClass]
public class StringHelper
{
    [TestMethod]
    public void Given_YouKilledMyFather_SuffixDotDotDot()
    {
        string text = "You killed my father";
        Assert.AreEqual("You killed my father...", text.AppendEllipses());
    }
}