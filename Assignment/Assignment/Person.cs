using System.Linq;
using System.Collections.Generic;

namespace Assignment
{
    public class Person : IPerson
    {
        public Person(string firstName, string lastName, IAddress address, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            EmailAddress = emailAddress;
        }

        public static Person ParseRow(string row)
        {
            string[] attributes = row.Split(',');
            Address address = new(attributes[4].Trim(), attributes[5].Trim(), attributes[6].Trim(), attributes[7].Trim());

            return new Person(attributes[1].Trim(), attributes[2].Trim(), address, attributes[3].Trim());
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAddress Address { get;set; }
        public string EmailAddress { get; set; }
    }
}
