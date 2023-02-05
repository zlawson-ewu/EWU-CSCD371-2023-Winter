using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logger;

public class Person : Entity
{
    FullName FullName { get; }
    public Person(string firstName, string lastName, string? middleName)
    {
        FullName = new FullName(firstName, lastName, middleName);
    }

    public override string Name { get => $"{FullName.FirstName} {FullName.LastName}"; }
}
