using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAHeLP_Database_Project
{
    /// <summary>
    /// To model a person
    /// </summary>
    public class Person
    {
        public string FirstName { get; set; }
        public string MiddleNames { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public Person(string firstName, string middleNames, string lastName)
        {
            FirstName = firstName;
            MiddleNames = middleNames;
            LastName = lastName;
            //FullName = firstName + '\t' + middleNames + '\t' + lastName;
        }

        public override string ToString() { return $"{FirstName} \t {MiddleNames} \t {LastName}"; }
    }
}
