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

            //first, we need to filter the Database for all subjects matching the given ethnic group
            //these individuals then get added to the dictionary in a loop and get a +10 to their score
            
            //next, in a loop, we run our nameMatch method. for an exact match, the subject in the dictionary gets +10. For a close partial, they get +5, for a not so close partial, they get +2, and no match gets +0

            //next, we loop through our dictionary and filter out any names that have not already gained >10 score. This should help cut down runtime (although it's already going to be a bit of a beast on those first two)

            //next, we loop and check the given villageID compared to the current village. I'm hoping that we can get some geo-data and do a range analysis here (I think we should be able to given the long and lati properties in that table). The villages being within 10m is +10, within 50m is +5, within 100m is +2

            //after this, I would want to get a bit creative. We want both a time analysis on the given location and time analysis for all nearby locations. 
            //first, we look at if any of the subjects in the dictionary have been at this location and assign varying scores depending on how long it's been. These scores in particular could be a bit tricky, as I'm not sure whether it should be better or worse if they had been there they day before. Either way, we assign the scores. 
            //next, we do the same analysis if they have been at any other location within 50 miles, assigning varying points depending on how recently. 

            //finally, we do a really easy DOB check. If the DOB is within 1 mo +10, 1 yr +5, 5 yrs +3, something like that

            //after that we return the dictionary! This can then be used by the UI to display relative confidences. We can also do some normalization of the data before returning

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
