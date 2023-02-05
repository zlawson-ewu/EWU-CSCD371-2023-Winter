namespace Logger;

public class Student : Person
{
    public Student(string firstName, string? middleName, string lastName, int studentId) : base(firstName, lastName, middleName)
    {
        StudentId = studentId;
    }

    public int StudentId { get; }
}
