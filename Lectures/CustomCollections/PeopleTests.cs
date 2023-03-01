namespace Week08.CustomCollections;
[TestClass]
public class PeopleTests
{
    [TestMethod]
    public void Create()
    {
        People people = new People(new List<Person>());
        Assert.AreEqual(0, people.Count());
    }

    [TestMethod]
    public void Foreach()
    {
        People people = CreatePeopleInstance();

        int count = 0;
        foreach (var person in people)
        {
            count++;
        }
        Assert.AreEqual<int>(3, count);
    }

    private static People CreatePeopleInstance()
    {
        return new People(new List<Person>(
            new Person[]
            {
                new("Inigo", "Montoya"),
                new("Fezzik", "The Giant"),
                new("Vizzini", "The Sicilian")
            }));
    }

    [TestMethod]
    public void GetNames()
    {
        IEnumerable<string> names = CreatePeopleInstance().GetNames();
        Assert.AreEqual<string>("Inigo Montoya", names.First());
    }
}