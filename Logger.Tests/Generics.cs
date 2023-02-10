using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;

[TestClass]
public class GenericsTests
{
    [TestMethod]
    [ExpectedException(typeof(InvalidCastException))]
    public void CreateNullableObject_Success()
    {
        CustomObject number = new("text");
        _  = (int)number.Value;
    }    
    
    [TestMethod]
    public void CreateNullableInt_Success()
    {
        NullableInt number = new();
        Assert.IsFalse(number.HasValue);
    }

    [TestMethod]
    public void Create_Success()
    {
        CustomNullable<int> nullableNumber = new(42);
        nullableNumber.Value = 5;
        int integer = nullableNumber.Value;

        Assert.IsTrue(nullableNumber.HasValue);
        AreEqual(5, integer);

    }

    public static void AreEqual<T>(T expected, T actual)
    {
        Assert.AreEqual(expected, actual);
    }
    
    
    [TestMethod]
    public void Create_Object_Success()
    {
        // TypeParameter can't be a reference type.
        // CustomNullable<object> thing = new(1);

    }

}
