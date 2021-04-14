using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectData.Models
{
    public class Subject
    {
        public int SubjectID { get; }

        public List<Name> Names { get; private set; }

        public EthnicGroup EthnicGroup { get; } //does this need to be nullable?

        public string OAHeLPID { get; set; }

        public DateTimeOffset? DOB { get; set; }

        public DOBSource? DOBSource { get; set; }

        public char Sex { get; }

        public string ICNumber { get; set; }

        public string photoFileName { get; set; }

        public int? MotherID { get; set; }

        public int? FatherID { get; set; }
    
        public Subject(
            int id, 
            EthnicGroup eg, 
            string oaID, 
            char sex, 
            DateTime? dob, 
            DOBSource? dobSource, 
            string ic, 
            int? mother, 
            int? father,
            string photo)
        {
            SubjectID = id;
            EthnicGroup = eg;
            OAHeLPID = oaID;
            Sex = sex;
            DOB = dob;
            DOBSource = dobSource;
            ICNumber = ic;
            MotherID = mother;
            FatherID = father;
            photoFileName = photo;
        }
        /*
        public Subject(int id, EthnicGroup eg, string oaID, char sex)
        {
            SubjectID = id;
            EthnicGroup = eg;
            OAHeLPID = oaID;
            Sex = sex;
        }
        */

        public void SetNames(List<Name> n)
        {
            if (Names == null) Names = new List<Name>();
            foreach(Name nm in n)
            {
                Names.Add(nm);
            }
        }
    }
}
