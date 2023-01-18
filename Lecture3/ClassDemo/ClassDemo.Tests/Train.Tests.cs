using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ClassDemo.Tests;

[TestClass]
public class TrainTests
{
    [TestMethod]
    public void Create_TrainWith5Carriages_Success()
    {
        // Act
        Train train = new(model: "Steam", carriages: 5);

        // Assert
        Assert.AreEqual(5, train.Carriages);
    }

    [TestMethod]
    public void Create_GivenTrain_IsVehicle()
    {
        // Arrange
        Train train = new("Steam", 6);

        // Assert
        Assert.IsTrue(train is Vehicle);
    }

    [TestMethod]
    public void Create_GivenCarriageAndModel_Success()
    {
        // Arrange
        Train train = new("Bullet", 6);

        // Assert
        Assert.AreEqual("Bullet", train.Model);
    }

    [TestMethod]
    public void Create_GivenNoCarriage_CarriagesEquals42()
    {
        // Arrange
        Train train = new("Bullet");

        // Assert
        Assert.AreEqual(42, train.Carriages);
    }
}
