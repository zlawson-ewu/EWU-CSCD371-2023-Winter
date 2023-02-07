using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FullNameTests
{
    [TestMethod]
    public void CreateRecord_SetsCorrectly()
    {
        FullName testRecord = new FullName(FirstName:"Thomas", LastName:"Rohr", MiddleName:"Stephen");

        Assert.AreEqual(testRecord.ToString(), "Thomas Stephen Rohr");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void FullName_NullFirstName_ThrowsException()
    {
        FullName testRecord = new FullName(FirstName: null!, LastName: "Rohr", MiddleName: "Stephen");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void FullName_NullLastName_ThrowsException()
    {
        FullName testRecord = new FullName(FirstName: "Thomas", LastName: null!, MiddleName: "Stephen");
    }

    [TestMethod]
    public void FullName_NullMiddleName_AllowsNull()
    {
        FullName testRecord = new FullName(FirstName: "Thomas", LastName: "Rohr", MiddleName: null);

        Assert.AreEqual(testRecord.ToString(), "Thomas Rohr");
    }
}