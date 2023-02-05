using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public class Employee : Person
{
    public Employee(string firstName, string? middleName, string lastName, int employeeId) : base(firstName, lastName, middleName)
    {
        EmployeeId = employeeId;
    }

    public int EmployeeId { get; }
}
