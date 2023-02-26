using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    readonly SampleData data = new();

    readonly List<Address> spokaneAddresses = new()
    {
        new Address("507 N Howard St", "Spokane", "WA", "99201"),     //River Front Park
        new Address("803 W Mallon Ave","Spokane", "WA", "99201"),     //David's Pizza
        new Address("1702 S Grand Blvd", "Spokane", "WA", "99203"),   //Manito Park
        new Address("101 W 8th Ave", "Spokane", "WA", "99204"),       //Sacred Heart Hospital
        new Address("601 E Riverside Ave", "Spokane", "WA", "99202"), //Catalyst Building
        new Address("916 W 2nd Ave", "Spokane", "WA", "99201"),       //Wild Sage Bistro
        new Address("501 W Park Pl", "Spokane", "WA", "99205"),       //Corbin Park
        new Address("1810 N Greene St", "Spokane", "WA", "99217")     //Spokane Community College
    };

    [TestMethod]
    public void SampleData_FillsListFromCSVRows_Success()
    {
        IEnumerable<string> items = data.CsvRows;

        Assert.AreEqual<int>(50, items.Count());
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_IsSorted()
    {
        List<string> uniqueStates = data.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
        bool nextElementAscendsPrevious = true;
        for (int i = 0; i < uniqueStates.Count - 1; i++)
        {
            if (StringComparer.Ordinal.Compare(uniqueStates[i], uniqueStates[i + 1]) > 0)
                nextElementAscendsPrevious = false;
        }
        Assert.IsTrue(nextElementAscendsPrevious);
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_FillsUniqueStates()
    {
        IEnumerable<string> uniqueStates = data.GetUniqueSortedListOfStatesGivenCsvRows();
        Assert.IsTrue(uniqueStates.Distinct().Count() == uniqueStates.Count());
    }

    [TestMethod]
    public void SpokaneAddresses_YieldOneDistinctState_True()
    {
        List<string> uniqueStates = new();
        foreach (Address address in spokaneAddresses) 
        {
            if (!uniqueStates.Contains(address.State))
            {
                uniqueStates.Add(address.State);
            }
        }
        Assert.AreEqual<int>(1, uniqueStates.Count);
    }

    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsListAsSingleString()
    {
        string uniqueStatesSorted = data.GetAggregateSortedListOfStatesUsingCsvRows();
        string[] testArray = uniqueStatesSorted.Split(',');
        int count = 0;
        bool sameElements = true;
        List<string> uniqueStates = data.GetUniqueSortedListOfStatesGivenCsvRows().ToList();

        foreach(string state in uniqueStates)
        {
            if (testArray[count] != state) sameElements = false;
            count++;
        }
        Assert.IsTrue(sameElements);
    }

    [TestMethod]
    public void ParsePersonFromRow_GivenValidString_CreatesPerson()
    {
        // Arrange
        string testCsvRow = "1337, Tom, Rohr, trohr@ewu.edu, 4127 S. Sullivan Rd, Veradale, WA, 99037";

        // Act
        Person testPerson = SampleData.ParsePersonFromRow(testCsvRow);

        // Assert
        Assert.AreEqual<string>("Tom", testPerson.FirstName);
        Assert.AreEqual<string>("Rohr", testPerson.LastName);
        Assert.AreEqual<string>("trohr@ewu.edu", testPerson.EmailAddress);
        Assert.AreEqual<string>("4127 S. Sullivan Rd, Veradale WA, 99037", testPerson.Address.ToString()!);
    }

    [TestMethod]
    public void People_PopulatesWithOrderedPeopleObjects_Success()
    {
        // Arrange
        List<IPerson> people = new();
        List<string> csvRows = data.CsvRows.ToList();
        foreach (string line in csvRows)
        {
            people.Add(SampleData.ParsePersonFromRow(line));
        }
        people = people.OrderBy(x => x.Address.ToString())
            .ThenBy(x => x.Address.State)
            .ThenBy(x => x.Address.City)
            .ThenBy(x => x.Address.Zip).ToList();

        // Act
        List<IPerson> peopleProperty = data.People.ToList();

        // Assert
        int count = 0;
        foreach (IPerson item in people)
        {
            Assert.AreEqual<string>(item.FirstName, peopleProperty[count].FirstName);
            Assert.AreEqual<string>(item.LastName, peopleProperty[count].LastName);
            Assert.AreEqual<string>(item.Address.ToString()!, peopleProperty[count].Address.ToString()!);
            Assert.AreEqual<string>(item.EmailAddress, peopleProperty[count].EmailAddress);
            Console.WriteLine(string.Format("{0, 15} {1, 15} {2, 50} {3, 30}", 
                peopleProperty[count].FirstName, 
                peopleProperty[count].LastName, 
                peopleProperty[count].Address.ToString(), 
                peopleProperty[count].EmailAddress));
            count++;
        }
        Assert.AreEqual<int>(csvRows.Count, count);
    }

    [DataTestMethod]
    [DataRow("smahonyg@stanford.edu", "Sancho", "Mahony")]
    [DataRow("mthurnhamr@live.com", "Mayor", "Thurnham")]
    [DataRow("wmesnard10@amazonaws.com", "Westley", "Mesnard")]
    [DataRow("jmullany16@eepurl.com", "Joellen", "Mullany")]
    [DataRow("cstennine2@wired.com", "Chadd", "Stennine")]
    public void FilterByEmailAddress_GivenFilter_ReturnsTuple(string testEmail, string testFirst, string testLast)
    {
        // Arrange
        bool EmailPredicate(string email) => email.Equals(testEmail);
        List<IPerson> people = data.People.ToList();

        // Act
        List<(string, string)> matches = data.FilterByEmailAddress(EmailPredicate).ToList(); 

        // Assert
        foreach ((string, string) item in matches)
        {
            Console.WriteLine($"{testEmail} => {item}");
            Assert.AreEqual<(string, string)>((testFirst, testLast), item);
        }
    }
}