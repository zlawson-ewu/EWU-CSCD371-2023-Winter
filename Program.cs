public interface IEntity
{
    string FullName { get; set; }
}
public class Person : IEntity
{

    public virtual string FullName { get; set; }
}
public class Employee : Person
{

    public Employee(string fullName)
    {
        FullName = fullName;
    }

    public override string FullName { get; set; }
    // The new keyword creates a new implementation fo fullName rather than Overriding the previous one
    // Instance of Employee cast to person 

}

public interface IStorage
{
    void Save(IEntity entity);

}

public class MockFile
{
    // Ctrl K & Ctrl D: Formats the entire document


}
// 2 Cases in which Keywords are required:
// Extension Methods
// Chaining constructors: calling a constructor from a constructor 
// Passing yourself as a param to a method

// Invalid, breaks variable naming conventions
// When the field name is equal to the parameter name