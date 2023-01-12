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
}