namespace ClassDemo.Tests;

[TestClass]
public class VehicleTests
{
        [TestMethod]
        public void Model_GivenToyota_ReturnsToyota()
        {
            //Arrange
            Vehicle vehicle = new("Toyota");

            //Act
            string actual = vehicle.Model;

            //Assert
            Assert.AreEqual("Toyota", actual);
        }

        [TestMethod]
        public void Model_GivenNull_ThrowsException()
        {
            //Assert
            Vehicle vehicle = new("Toyota");

            ArgumentNullException? expectedException = null;

            //Act
            try
            {
                vehicle.Model = null!;
            }
            catch (ArgumentNullException ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.IsNotNull(expectedException);
        }

    [ExpectedException(typeof(ArgumentException))]
    [TestMethod]
    public void Model_GivenEmptyString_ThrowsException()
    {
        //Arrange
        Vehicle vehicle = new(string.Empty);

        //Act


        //Assert

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Model_GivenWhitespaceString_ThrowsException()
    {
        //Arrange
        Vehicle vehicle = new("    ");

        //Act

        //Assert

    }

    [TestMethod]
    public void Model_GivenStringsWithSpace_PreservesSpaces()
    {
        //Arrange
        Vehicle vehicle = new(" Toyota ");

        //Act

        //Assert
        Assert.AreEqual(" Toyota ", vehicle.Model);
    }

    [TestMethod]
    public void Create_ValidModel_Success()
    {
        //Arrange
        string model = "Crosstrek";
        Vehicle vehicle = new(model);

        //Act

        //Assert
    }
}