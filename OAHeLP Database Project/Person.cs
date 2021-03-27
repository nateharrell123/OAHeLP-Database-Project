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
        public uint ProjectID { get; set; } // probably this one too
        public string VillageLastSeen { get; set; } // change this for sure

        public Person(string fn, uint pd, string vls)
        {
            FirstName = fn;
            ProjectID = pd;
            VillageLastSeen = vls;
        }
    }
}
