using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectData
{
    public class Name
    {
        public string FirstName { get; }
        public string MiddleNames { get; }
        public string LastName { get; }

        Name(string f, string m, string l)
        {
            FirstName = f;
            MiddleNames = m;
            LastName = l;
        }
    }
}
