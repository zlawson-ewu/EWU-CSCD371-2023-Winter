namespace Week_07_LINQ;
[TestClass]
public class DeferredExecution
{
    [TestMethod]
    public void MyTestMethod()
    {
        int count = 0;
        List<int> numbers = Enumerable.Range(1, 10).ToList();

        Assert.AreEqual<int>(10, numbers.Count);
        IEnumerable<int> evens = numbers.Where(item =>
        {
            count++;
            return item % 2 == 0;
        });
        List<int> evens2 = evens.ToList();
        Assert.AreEqual<int>(10, count);
        Assert.AreEqual<int>(5, evens2.Count());
        Assert.AreEqual<int>(10, count);
        IEnumerable<int> triples = evens2.Where(item =>
        {
            count++;
            return item % 3 == 0;
        }); // returns the query, not the results
        Assert.AreEqual<int>(1, triples.Count());

        Assert.AreEqual<int>(15, count);
        foreach (int item in evens)
        {
            Console.WriteLine(item);
        }
        Assert.AreEqual<int>(25, count);
        foreach (int item in evens)
        {
            Console.WriteLine(item);
        }
        Assert.AreEqual<int>(35, count);
        
        // Look at Enumerable class and linq methods *** 
        
    }
}