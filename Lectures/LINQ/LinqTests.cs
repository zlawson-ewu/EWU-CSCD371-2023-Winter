using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Week_07_LINQ;

[TestClass]
public class LinqTests
{
    private readonly static IReadOnlyCollection<MemberInfo> StringMembers = typeof(string).GetMembers();
    [TestMethod]
    public void ListItems()
    {
        foreach (string item in StringMembers.Select(item=>item.Name).Distinct())
        {
            Console.WriteLine(item);
        }
    }
    
    [TestMethod]
    public void Select()
    {
        IReadOnlyCollection<MemberInfo> members = StringMembers;
        IEnumerable<string> names = members.Select(member => member.Name); // use singular or item
        Assert.IsTrue(names.Contains(nameof(Enumerable.Count)));
        Assert.IsTrue(names.Any(name => name.StartsWith(nameof(Enumerable.Count)[0])));
        // Assert.AreEqual<int>(42, names.Count());
        Assert.AreEqual<int>(2, names.Where(name => name == nameof(Enumerable.Count)).Count());

        IEnumerable<string> distinctNames = names.Distinct();
        Assert.AreEqual<int>(1, distinctNames.Where(name => name == nameof(Enumerable.Count)).Count());
    }

    [TestMethod]
    public void Distinct_GivenTypeOfString_AllItemsAreUnique()
    {
        IEnumerable<IGrouping<string, string>> expected = 
            StringMembers.Select(item => item.Name).Distinct().GroupBy(item => item);
        Assert.IsFalse(expected.Any(item => item.Count()>1));
        var actual = StringMembers.Select(member => member.Name).Distinct();
    }
}
