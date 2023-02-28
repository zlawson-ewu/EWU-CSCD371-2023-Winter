namespace Week_07_LINQ;

public class CollectionTests<TCollection, TInterface, TConstructor>
    where TCollection : IEnumerable<TCollection>, TInterface
    where TInterface : IEnumerable<TInterface>
    // where TConstructor : Func<TCollection>, new()
{
    
}


[TestClass]
public class DictionaryTests
{
    Dictionary<string, Person> People = new Dictionary<string, Person>();

    [TestInitialize]
    public void Setup()
    {
        People = new Dictionary<string, Person>() {
            { "1001",  
                new Person("John", "Doe", new DateTime(1980, 1, 1)) },
            { "2002",  
                new Person("Jane", "Doe", new DateTime(1981, 1, 1)) },
            { "3003",  
                new Person("John", "Smith", new DateTime(1982, 1, 1)) },
            { "4004",  
                new Person("Jane", "Smith", new DateTime(1983, 1, 1)) }
        };
    }

    // [TestInitialize]
    public void SetupAlternative()
    {
        People = new Dictionary<string, Person>() {
            ["1001"] = 
                new Person("John", "Doe", new DateTime(1980, 1, 1)),
            ["2002"] = 
                new Person("Jane", "Smith", new DateTime(1981, 1, 1)),
            ["3003"] = 
                new Person("John", "Smith", new DateTime(1982, 1, 1)),
            ["4004"] = 
                new Person("Jane", "Doe", new DateTime(1983, 1, 1)),
        };
    }

    [TestMethod]
    public void Add()
    {
        Person person = new Person("John", "Doe", null);
        People.Add("NegativeOne", person);
        Assert.IsTrue(People.ContainsKey("NegativeOne"));
        Assert.IsTrue(People.ContainsValue(person));
    }

    [TestMethod]
    public void Contains()
    {
        Person person = new Person("John", "Rockman", null);
        Assert.IsFalse(People.ContainsKey("NegativeOne"));
        People.Add("NegativeOne", person);
        Assert.IsTrue(People.ContainsKey("NegativeOne"));
    }

    [TestMethod]
    public void Remove()
    {
        People.Remove("1001");
        Assert.IsFalse(People.ContainsKey("1001"));
    }

    [TestMethod]
    public void Upsert()
    {
        if (People.ContainsKey("1001"))
        {
            People["1001"] = new Person("John", "Doe", new DateTime(1980, 1, 1));
        }
        else
        {
            People.Add("1001", new Person("John", "Doe", new DateTime(1980, 1, 1)));
        }
    }
}