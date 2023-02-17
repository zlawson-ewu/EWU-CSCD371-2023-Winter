using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace LambdaExpressions;

[TestClass]
public class PatternMatchingTests
{
    
    [TestMethod]
    public void SetName_InigoMontoya_Success()
    {
        FullName testName = new FullName("Inigo Montoya");
        (string FirstName, string LastName) actual1 = (testName.FirstName, testName.LastName);
        var actual = (testName.FirstName, testName.LastName);
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

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Create_EmptyStrings_Fails()
    {
        _ = new FullName("", "");
    }

    [TestMethod]
    public void MyTestMethod()
    {
        FullName name = new FullName("Inigo Montoya");
        _ = name switch
        {
            (string { Length: >0 and < 10 }, string { Length: >0 and < 10 }) => true,
        };
    }

    [TestMethod]
    public void LINQ_Where()
    {
        string name = "Inigo Montoya";
        IEnumerable<char> oCharacters = name.Where(c => 
            c == 'o');

        int count = 0;
        List<int> indiciesWitho = name.Where(c =>
        {
            count++;
            return c=='o';
        }).Select(c =>
            count++).ToList();
        Assert.IsTrue(indiciesWitho is [4, 7, 10]);
    }

    
}