namespace ClassDemo.Tests;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void GetName_InigoMontoya_InigoMontoya()
    {
        string actual = Program.GetName("Inigo", "Montoya");
        Assert.AreEqual<string>("Inigo Montoya", actual);
    }

    string? Text = "Inigo Montoya";
    void Method(string text)
    {
        if (Text is not null)
        {
            Text.Replace("n", "l");
        }
        //string text = Text?.Replace("n", "l");

        // Text = text;
    }

    [TestMethod]
    public void PlayingWithIntegers()
    {
        int number = 42;
        Assert.AreEqual("System.Int32", number.GetType().FullName);
    }
    
    [TestMethod]
    public void PlagigWithString()
    {
        string number = "forty-two";

        Assert.AreEqual("System.String", number.GetType().FullName);
    }
}