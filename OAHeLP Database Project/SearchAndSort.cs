using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAHeLP_Database_Project
{
    class SearchAndSort
    {

        /// <summary>
        /// this dictionary tracks each subject's score compared to test data
        /// </summary>
        Dictionary<int, int> subjectIDAndScores = new Dictionary<int, int>();

        /// <summary>
        /// Constructor
        /// </summary>
        public SearchAndSort()
        {

        }//searchandsort

        /// <summary>
        /// This function searches the database given the input parameters. It then returns a dictionary with all people with a >30% match to the test data
        /// </summary>
        /// <param name="name">Input name. This may not be an exact match, but it can be close</param>
        /// <param name="ethnicGroup">This needs to be an exact match</param>
        /// <param name="villageID">The village that the patient currently says that they are from. The search algorithm compares this to other villages at varying ranges</param>
        /// <param name="DOB">DOB is unreliable, but the search algorithm still makes minor use of it</param>
        /// <returns></returns>
        public Dictionary<int,int> SearchDB(string name, string ethnicGroup, string villageID, DateTime DOB)
        {


            return subjectIDAndScores;
        }//SearchDB

        /// <summary>
        /// An algorithm for seeing how close of a match the name is
        /// </summary>
        /// <param name="inputName">the name that was entered as part of the input parameters</param>
        /// <param name="dbName">the current name from the database that we are comparing</param>
        /// <returns>Returns an int based on how close the match is. 3 = exact, 2 = Close Partial, 1 = Not very close partial, 0 = nothing</returns>
        public int nameMatch(string inputName,string dbName)
        {

            //this will need to get changed
            return 0;
        }


    }
}
