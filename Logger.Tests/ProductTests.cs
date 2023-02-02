using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;

[TestClass]
public class ProductTests
{
    [TestMethod]
    public void ReadOnly_Property_Set()
    {
        Product product = new Product(
            Name: "AirJordan", 
            Price: 1000.00, 
            Description:"Really expensive shoes - but they are just shoes.");
        Assert.AreEqual(1000, product.Price);
        // product.Price = 2000.00;
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Name_AssignNullInConstructor_ThrowException()
    {
        Product product = new Product(
            Name: null!,
            Price: 1000.00,
            Description: "Really expensive shoes - but they are just shoes.");
        // Assert.AreEqual(1000, product.Price);
        // product.Price = 2000.00;
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Name_AssignNullInInitializer_ThrowException()
    {
        Product product = new Product(
            Name: "Reebok",
            Price: 1000.00,
            Description: "Really expensive shoes - but they are just shoes.")
        { Description = "These are not quite as good as AirJordans" };
        /*{ Name = null! }*/
        product.Description = "These are NOT quite as good as AirJordans ";
        ;
    }

}


