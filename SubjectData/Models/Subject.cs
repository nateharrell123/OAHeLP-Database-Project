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

        public EthnicGroup EthnicGroup { get; }

        public string OAHeLPID { get; set; }

        public DateTime DOB { get; set; }

        public DOBSource DOBSource { get; set; }

        public char Sex { get; }

        public string ICNumber { get; set; }

        public string photoFileName { get; set; }

        public int MotherID { get; set; }

        public int FatherID { get; set; }
    
        public Subject(int id, EthnicGroup eg, string oaID, char sex)
        {
            SubjectID = id;
            EthnicGroup = eg;
            OAHeLPID = oaID;
            Sex = sex;
        }

        void SetNames(List<Name> n)
        {
            if (Names == null) Names = new List<Name>();
            foreach(Name nm in n)
            {
                Names.Add(nm);
            }
        }
    }
}
