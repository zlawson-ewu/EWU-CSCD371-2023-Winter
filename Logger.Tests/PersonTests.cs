using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class PersonTests
{
    FullName testFullName = new(FirstName:"Tom", LastName:"Rohr", MiddleName: "Stephen");
    
    [TestMethod]
    public void Person_SetsName_Correct()
    {
        Person testPerson = new(testFullName);

        Assert.AreEqual(testPerson.FName.ToString(), "Tom Stephen Rohr");
    }

    [TestMethod]
    public void Person_ValueBasedEquality_True() 
    {
        Person testPerson = new(testFullName);
        Person testPerson2 = new(testFullName);

        Assert.IsTrue(testPerson.Equals(testPerson2));
    }
}
