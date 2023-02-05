using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public class Student : Person
{
    public Student(string firstName, string? middleName, string lastName, int studentId) : base(firstName, lastName, middleName)
    {
        StudentId = studentId;
    }

    public int StudentId { get; }
}
