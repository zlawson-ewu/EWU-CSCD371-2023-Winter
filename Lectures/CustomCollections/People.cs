using System.Collections;
using Week_07_LINQ;

namespace Week08.CustomCollections;
public class People : IEnumerable<Person>
{
    private List<Person> InternalCollection { get; set; }

    public People(IEnumerable<Person> people)
    {
        InternalCollection = new List<Person>(people);
    }

    public IEnumerator<Person> GetEnumerator()
    {
        foreach (Person item in InternalCollection)
        {
            yield return item;
        }
    }

    public IEnumerable<string> GetNames()
    {
        //InternalCollection.ForEach(item =>
        //{
        //    yield return item;
        //});
        foreach (Person item in InternalCollection)
        {
            yield return item.Name;
        }
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
