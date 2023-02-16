namespace LambdaExpressions;

[TestClass]
public class PatternMatchingTests
{
    
    [TestMethod]
    public void SetName_InigoMontoya_Success()
    {
        FullName testName = new FullName("Inigo Montoya");
        (string, string) actual = (testName.FirstName, testName.LastName);
        Assert.AreEqual<(string, string)>(("Inigo","Montoya"), actual);
        Assert.IsTrue(testName.FirstName is "Inigo");
    }

    [TestMethod]
    public void UsingSwitch_InitialsInigoMontoya_Success()
    {
        FullName testName = new FullName("Inigo Montoya");
        string actuals = testName.Initials;
        Assert.AreEqual<string>("IM", actuals);
    }
}