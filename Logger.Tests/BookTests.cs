using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class BookTests
{
    private readonly string testTitle = "Of Mice and Men";
    private readonly FullName testAuthor = new(FirstName: "John", LastName: "Steinbeck", MiddleName: "Ernst");
    private readonly int testYearPublished = 1937;

    [TestMethod]
    public void Book_SetsProperties_Success()
    {
        Book testBook = new(testTitle, testAuthor, testYearPublished);

        Assert.AreEqual(testBook.Title, "Of Mice and Men");
        Assert.AreEqual(testBook.Author.ToString(), "John Ernst Steinbeck");
        Assert.AreEqual(testBook.YearPublished, 1937);
    }

    [TestMethod]
    public void Book_ValueBasedEquality_True()
    {
        Book testBook = new(testTitle, testAuthor, testYearPublished);
        Book testBook2 = new(testTitle, testAuthor, testYearPublished);

        Assert.IsTrue(testBook.Equals(testBook2));
    }

    [TestMethod]
    public void Book_ToStringOverridenToStringFormat_Correct()
    {
        Book testBook = new(testTitle, testAuthor, testYearPublished);

        Assert.AreEqual(testBook.ToString(), "TITLE: Of Mice and Men, AUTHOR: John Ernst Steinbeck, PUBLISHED: 1937");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Book_NullTitle_ThrowsException() 
    {
        Book testBook = new(null!, testAuthor, testYearPublished);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Book_NullAuthor_ThrowsException()
    {
        Book testBook = new(testTitle, null!, testYearPublished);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Book_InvalidYear_ThrowsException()
    {
        Book testBook = new(testTitle, null!, -2000);
    }
}