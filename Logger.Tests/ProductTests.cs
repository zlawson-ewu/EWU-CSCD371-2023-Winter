using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;

[TestClass]
public class ProductTests
{
    [TestMethod]
    public void ReadOnly_Property_Set()
    {
        Product product = new Product(
            42, Name: "AirJordan",
            Price: 1000.00,
            Description: "Really expensive shoes - but they are just shoes.");
        Assert.AreEqual(1000, product.Price);
        // product.Price = 2000.00;
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Name_AssignNullInConstructor_ThrowException()
    {
        Product product = new Product(
            42, Name: null!,
            Price: 1000.00,
            Description: "Really expensive shoes - but they are just shoes.");
        // Assert.AreEqual(1000, product.Price);
        // product.Price = 2000.00;
    }

    [TestMethod]
    public void Name_AssignNullInInitializer_ThrowException()
    {
        Product product = new Product(
            42, Name: "Reebok",
            Price: 1000.00,
            Description: "Really expensive shoes - but they are just shoes.")
        { Description = "These are not quite as good as AirJordans" };
        /*{ Name = null! }*/
        // product.Description = "These are NOT quite as good as AirJordans ";

        ;
    }

    [TestMethod]
    public void Equals_TwoReferences_True()
    {
        Product product1 = new Product(
            42, Name: "AirJordan",
            Price: 1000.00,
            Description: "Really expensive shoes - but they are just shoes.");
        Product product2 = product1;
        Assert.IsTrue(ReferenceEquals(product1, product2));
    }

    [TestMethod]
    public void Equals_TwoInstances_True()
    {
        Product product1 = new Product(
            42, Name: "AirJordan",
            Price: 1000.00,
            Description: "Really expensive shoes - but they are just shoes.");
        Product product2 = product1 with { /*Name = "Something",*/ Price = 2000.00 };

        Assert.IsFalse(ReferenceEquals(product1, product2));
        Assert.IsTrue(product1.Equals(product2));
        Assert.IsTrue(product1 == product2);

    }

    [TestMethod]
    public void Equals_TwoInstancesWithDifferentId_True()
    {
        Product product1 = new Product(
            42, Name: "AirJordan",
            Price: 1000.00,
            Description: "Really expensive shoes - but they are just shoes.");
        Product product2 = product1 with {Id = 42, Price = 0 };

        Assert.IsFalse(ReferenceEquals(product1, product2));
        Assert.IsTrue(product1.Equals(product2));
        Assert.IsTrue(product1 == product2);

    }
}


