using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void Student_SetsProperties_Success()
    {
        FullName testName = new("Michael","Scott","Gary");
        Student testStudent = new(1, testName);

        Assert.AreEqual(testStudent.Name, "Michael Gary Scott");
        Assert.AreEqual(testStudent.SID, 1);
    }

    [TestMethod]
    public void Student_OverridenToStringFormat_Correct()
    {
        FullName testName = new("Michael", "Scott", "Gary");
        Student testStudent = new(1, testName);
        string expected = string.Format("Student ID: {0}, Full Name: {1}", testStudent.SID, testStudent.FName);  

        Assert.AreEqual(expected, testStudent.ToString());
    }

    [TestMethod]
    public void Student_ValueBasedEquality_True()
    {
        FullName testName = new("Michael", "Scott", "Gary");
        Student testStudent = new(1, testName);
        Student testStudent2 = new(1, testName);

        Assert.IsTrue(testStudent.Equals(testStudent2));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Student_InvalidSID_ThrowsException()
    {
        FullName testName = new("Michael", "Scott", "Gary");
        Student testStudent = new(-23, testName);
    }
}