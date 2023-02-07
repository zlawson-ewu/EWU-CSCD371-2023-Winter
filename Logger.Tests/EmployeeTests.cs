using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class EmployeeTests
{
    [TestMethod]
    public void Employee_SetsProperties_Success()
    {
        FullName testName = new("Michael", "Scott", "Gary");
        Employee testEmployee = new(1, testName);

        Assert.AreEqual(testEmployee.FName.ToString(), ("Michael Gary Scott"));
        Assert.AreEqual(testEmployee.EID, 1);
    }

    [TestMethod]
    public void Employee_OverridenToStringFormat_Correct()
    {
        FullName testName = new("Michael", "Scott", "Gary");
        Employee testEmployee = new(1, testName);
        string expected = string.Format("Employee ID: {0}, Full Name: {1}", testEmployee.EID, testEmployee.FName);

        Assert.AreEqual(expected, testEmployee.ToString());
    }

    [TestMethod]
    public void Employee_ValueBasedEquality_True()
    {
        FullName testName = new("Michael", "Scott", "Gary");
        Employee testEmployee = new(1, testName);
        Employee testEmployee2 = new(1, testName);

        Assert.IsTrue(testEmployee.Equals(testEmployee2));
    }

    [TestMethod]
    public void Employee_ValueBasedEquality_False()
    {
        FullName testName = new("Michael", "Scott", "Gary");
        Employee testEmployee = new(1, testName);
        Employee testEmployee2 = new(2, testName);

        Assert.IsFalse(testEmployee.Equals(testEmployee2));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Employee_InvalidEID_ThrowsException()
    {
        FullName testName = new("Michael", "Scott", "Gary");
        Employee testEmployee = new(-23, testName);
    }
}