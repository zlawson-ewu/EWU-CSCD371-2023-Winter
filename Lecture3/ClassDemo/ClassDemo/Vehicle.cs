/*
  ctrl+shift+a will add a class (file) to your project
  ctrl+r+g will remove/sort using statements
  testm tab tab will create a test
  ctrl+r t will run a focused test
  ctrl+r a will run all tests
  Make sure your classes are public to run tests against it
  Use [TestClass] to create a test class
  
 */
namespace ClassDemo;

public class Vehicle
{
    public Vehicle(string model)
    {
        // Make = make;
        Model = model;
    }

    // public string Make { get; set; }

    // Guideline: Never access fields from outside their wrapping properties
    private string? _Model;
    public string Model
    {
        get
        {
            return _Model!;
        }
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            ArgumentException.ThrowIfNullOrEmpty(value.Trim());
            _Model = value;
        }
    }
}