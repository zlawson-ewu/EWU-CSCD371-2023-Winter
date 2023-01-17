﻿namespace ClassDemo.Tests;

[TestClass]
public class VehicleTests
{
        [TestMethod]
        public void Model_GivenToyota_ReturnsToyota()
        {
            //Arrange
            Vehicle vehicle = new();
            vehicle.Model = "Toyota";

            //Act
            string actual = vehicle.Model;

            //Assert
            Assert.AreEqual("Toyota", actual);
        }

        [TestMethod]
        public void Model_GivenNull_ThrowsException()
        {
            //Assert
            Vehicle vehicle = new();

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
        Vehicle vehicle = new();
        vehicle.Model = string.Empty;

        //Act


        //Assert

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Model_GivenWhitespaceString_ThrowsException()
    {
        //Arrange
        Vehicle vehicle = new();

        //Act
        vehicle.Model = "    ";

        //Assert

    }

    [TestMethod]
    public void MyTestMethod()
    {
        //Arrange
        Vehicle vehicle = new();

        //Act
        vehicle.Model = " Toyota ";

        //Assert
        Assert.AreEqual(" Toyota ", vehicle.Model);
    }
}
