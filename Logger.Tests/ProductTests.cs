using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;

[TestClass]
public class ProductTests
{
    [TestMethod]
    public void ReadOnly_Property_Set()
    {
        Product product = new Product(
            Id: 42,
            Name: "AirJordan", 
            Price: 1000, 
            Description: "Really Expensive");
        Assert.AreEqual(1000, product.Price);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Name_AssignNullInConstructor_ThrowException()
    {
        Product product = new Product(
            Id: 42,
            Name: null!,
            Price: 1000,
            Description: "Really Expensive");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Name_AssignNullInInitializer_ThrowException()
    {
        Product product = new Product(
            Id: 42,
            Name: "Reebok",
            Price: 1000,
            Description: "Really Expensive")
        { Description = "These are not as good as AirJordans" };
        //{ Name = null! };

    }

    [TestMethod]
    public void Equals_TwoReferences_True()
    {
        Product product1 = new Product(
            Id: 42,
            Name: "Reebok",
            Price: 1000,
            Description: "Really Expensive");

        Product product2 = product1;

        Assert.IsTrue(ReferenceEquals(product1, product2));
    }

    [TestMethod]
    public void Equals_TwoInstancesWithDifferentId_True()
    {
        Product product1 = new Product(
            Id: 42,
            Name: "Reebok",
            Price: 1000,
            Description: "Really Expensive");

        Product product2 = product1 with { Id = 490, Price = 2000 };

        Assert.IsFalse(ReferenceEquals(product1, product2));
        Assert.IsTrue(product1.Equals(product2));
        Assert.IsTrue(product1== product2);
    }
}


