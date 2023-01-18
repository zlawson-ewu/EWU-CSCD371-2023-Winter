namespace ClassDemo.Tests;

[TestClass]
public class TrainTests
{
    [TestMethod]
    public void Create_TrainWith5Carriages_Success()
    {
        Train train = new(model: "Train");
        Assert.AreEqual(5, train.Carriages);
    }

    [TestMethod]
    public void GivenTrain_IsVehicle()
    {
        Train train = new("Train");
        Assert.IsTrue(train is Vehicle);
    }
}
