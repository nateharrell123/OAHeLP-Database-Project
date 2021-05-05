using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Device.Location;


namespace OAHeLP_Database_Project
{

    public class SearchAndSort
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SearchAndSort(string connection)
        {
            this.connectionString = connection;
        }//searchandsort


        /// <summary>
        /// this dictionary tracks each subject's score compared to test data
        /// </summary>
        private Dictionary<int, int> subjectIDAndScores = new Dictionary<int, int>();

        private string connectionString;
        /// <summary>
        /// this is the amount that is added to a subjects score if they match the input ethnic group
        /// </summary>
        private int ethnicGroupRankWeight = 15;

        /// <summary>
        /// after the base weight is determined, the ethnicGroup score can be multiplied to make it more significant in the overall rank of the subject. 
        /// </summary>
        private int ethnicGroupRankMultiplier = 1;

        /// <summary>
        /// this is the amount that the base for the name match algorithm. 
        /// The name distance determined by name match will be subtracted from this number, meaning a higher distance results in a lower number being added to the rank
        /// if that subtraction would cause the score to go negative then nothing is added (but this could certainly be changed to add a negative value)
        /// </summary>
        private int nameMatchRankBaseWeight = 15;

        /// <summary>
        /// after the base weight is determined, the namematch score can be multiplied to make it more significant in the overall rank of the subject. 
        /// </summary>
        private int nameMatchRankMultiplier = 2;

        /// <summary>
        /// this is the maximum distance (in km) that a subjects residence can be from the clinic for them to have any score added for this distance. 
        /// the rank that is added is then (maxAcceptableDistance - distanceAway / (maxAcceptableDistance/10))
        /// </summary>
        private int maxAcceptableDistance = 2500;

        /// <summary>
        /// after the base weight is determined, the distance score can be multiplied to make it more significant in the overall rank of the subject. 
        /// </summary>
        private int distanceRankMultiplier = 1;

        /// <summary>
        /// this is whatever we want the maximum value in our set to normalize to. This is completely unnecessary, and the normalization process can be removed to just output the raw scores if desired. 
        /// </summary>
        private double maxNormalizedValue = 50;

        /// <summary>
        /// this is whatever we want the minimum value in our set to normalize to. This is completely unnecessary, and the normalization process can be removed to just output the raw scores if desired. 
        /// </summary>
        private double minNormalizedValue = 10;





        /// <summary>
        /// This function searches the database given the input parameters. It then returns a dictionary with all people with a >30% match to the test data
        /// </summary>
        /// <param name="name">Input name. This may not be an exact match, but it can be close</param>
        /// <param name="ethnicGroup">This needs to be an exact match</param>
        /// <param name="villageID">The village that the patient currently says that they are from. The search algorithm compares this to other villages at varying ranges</param>
        /// <param name="DOB">DOB is unreliable, but the search algorithm still makes minor use of it</param>
        /// <returns></returns>
        public Dictionary<int, int> SearchDB(string inputName, string inputEthnicGroup, string inputVillageName, string inputSex)
        {
            SqlConnection connection;
            string queryString;
            SqlCommand command;
            SqlDataReader reader;

            //alright, the very first thing we need to do is normalize our data
            {
                //the database stores sex as either M or F, so if it's any version of male/female we need to normalize it to M or F

                if (inputSex.Equals("Male"))
                {
                    inputSex = "M";
                }//if
                else if (inputSex.Equals("Female"))
                {
                    inputSex = "F";
                }//else
            }//input data checking and normalization
            string inputPhone = PhonemeGenerator.GetPronunciationFromText(inputName);
            using (connection = new SqlConnection(connectionString))
            {
                //firstly this we need to grab the long and lat info for the inputVillage, so we'll run a quick query for that. 
                List<string[]> queryResultsListInputVillageGPS;
                {

                    queryString = $"SELECT V.[Name],V.GPSLatitude,V.GPSLongitude FROM [Subject].Village V WHERE V.[Name] = '{inputVillageName}'";


                    command = new SqlCommand(queryString, connection);
                    connection.Open();

                    reader = command.ExecuteReader();

                    //now this is going into a list array so that I don't pull out my hair trying to work with it
                    //it's going to be a list array of strings, that's the easiest to parse into other types if need be
                    queryResultsListInputVillageGPS = new List<string[]>();

                    if (reader.HasRows)
                    {
                        //The while loop iterates through the rows
                        while (reader.Read())
                        {
                            //string array to represent the row
                            string[] row = new string[reader.FieldCount];

                            row[0] = reader.GetValue(0).ToString();
                            row[1] = reader.GetValue(1).ToString();
                            row[2] = reader.GetValue(2).ToString();

                            //this should only have one row, but better safe than sorry
                            queryResultsListInputVillageGPS.Add(row);

                        }//while
                    }//if

                    else
                    {
                        Console.WriteLine("No rows found.");
                    }//else

                    reader.Close();
                }//village query


                //alright, we're going to make a giant query so that we don't have to do a bunch of seperate ones. Then, we'll store the info and filter through it as needed
                //also, eventually this should probably be some sort of string builder (or probably even more ideally a stored procedure) but I'm just hardcoding this for now to make everything clear

                {
                    queryString = "SELECT S.SubjectID, S.Sex, EG.Name, N.NameID, N.FirstName, N.MiddleNames, N.LastName, V.VillageID, V.GPSLatitude, V.GPSLongitude " +
                        "FROM [Subject].[Subject] S " +
                            "LEFT JOIN [Subject].[SubjectName] SN ON S.SubjectID = SN.SubjectID " +
                            "LEFT JOIN [Subject].[Name] N ON SN.NameID = N.NameID " +
                            "LEFT JOIN [Subject].Residence R ON S.SubjectID = R.SubjectID " +
                            "LEFT JOIN [Subject].Village V ON V.VillageID = R.VillageID " +
                            "LEFT JOIN [Subject].EthnicGroup EG ON EG.EthnicGroupID = S.EthnicGroupID " +
                        $"WHERE Sex = '{inputSex}'" +
                        " ORDER BY S.SubjectID";

                    //and that should be the entire query!

                    //for reference, this query will output a table that looks like this (as of 1.0 release)

                    //     0          1            2                3             4             5             6             7              8               9      
                    //S.SubjectID | S.Sex | EG.EthnicGroupName | N.NameID | N.FirstName | N.MiddleNames | N.LastName | V.VillageID | V.GPSLatitude | V.GPSLongitude


                    command = new SqlCommand(queryString, connection);


                    reader = command.ExecuteReader();
                }//getting the larger query


                //organizing the data so that it's easier to work with
                //this section takes the reader data and turns it into a 2-d array.
                //everything from here on assumes that the data is stored in a 2-d array that can be easily imagined as rows and columns. 
                //Looking at data structures that would provide better performance definitely should be on the future dev docket, but it's not at the moment
                List<string[]> queryResultsList;
                string[,] queryResultsArray;
                int counter;
                {

                    //now this is going into a list array so that I don't pull out my hair trying to work with it
                    //it's going to be a list array of strings, that's the easiest to parse into other types if need be
                    int readerCount;
                    {
                        queryResultsList = new List<string[]>();

                        if (reader.HasRows)
                        {

                            int i = 0;//I mostly have th counter here just in case I need it. I don't actually think you do, but it's still decent to have

                            //The while loop iterates through the rows
                            while (reader.Read())
                            {

                                //string array to represent the row
                                string[] row = new string[reader.FieldCount];

                                //fieldcount returns the number of rows

                                for (int j = 0; j < reader.FieldCount; j++)
                                {
                                    row[j] = reader.GetValue(j).ToString();
                                }//for

                                //now that we have the row stored in the array, we can add it to the list
                                queryResultsList.Add(row);

                                //enter their subjectIDs into the dict and start at a base score of 0
                                subjectIDAndScores[reader.GetInt32(0)] = 0;

                                i++;//iterate the counter
                            }//while
                        }//if

                        else
                        {
                            Console.WriteLine("No rows found.");
                        }//else
                        readerCount = reader.FieldCount;
                        reader.Close();
                    }//listarray

                    //oooookay. Now we have a list of arrays with all of the info in them. I'm going to turn this into a 2d array mostly because I just sort of want to.
                    queryResultsArray = new string[queryResultsList.Count, readerCount];
                    counter = 0;
                    foreach (string[] SA in queryResultsList)
                    {
                        //string array to represent the row

                        for (int j = 0; j < readerCount; j++)
                        {
                            queryResultsArray[counter, j] = SA[j];
                        }//for

                        counter++;
                    }//foreach

                    //cool, now we have a 2d array with all of the data points we need!
                    //our dictionary is full of only subjects with the perscribed sex. This should help narrow future searches since we are very confident that sex will be correct

                }//organization


                //this section adds all of the raw score to each subject's rank. The rest of the method after this loop revolves around organizing the data
                {
                    for (int i = 0; i < counter - 1; i++)
                    {

                        //each row is one subject, but one subject may be on multiple rows if they have multiple names associated with the subject.
                        { //ethnic group
                          //check to see if this is the last entry for the given subject
                          //it doesn't actually matter which entry it is, just matters that we only consider one of them
                            if (!(queryResultsArray[i, 0].Equals(queryResultsArray[i + 1, 0])))
                            {
                                //if this is the last record for that subject, we will look at the ethnic group compared to the input ethnic group
                                if (queryResultsArray[i, 2].Equals(inputEthnicGroup))
                                {

                                    subjectIDAndScores[int.Parse(queryResultsArray[i, 0])] += ethnicGroupRankWeight * ethnicGroupRankMultiplier;
                                }//if
                            }//if for ethnic group

                        }//ethnic group

                        ///////////////////////////
                        //next, we run our nameMatch method.

                        {//namematching
                         //first, we have to check if the given subject has more than one name, which would result in their ID being listed more than once
                         //if that is the case, then we need to figure out how many names they have, represented by nameCount (default 0)
                            int nameCount = 0;
                            while (queryResultsArray[i, 0].Equals(queryResultsArray[i + 1, 0]))
                            {
                                nameCount++;
                                i++;
                            }//if

                            //now we can check nameCount and run our name match a corrasponding number of times
                            //we will take the lowest result from the series of runs
                            int lowestResult = Int32.MaxValue;
                            for (int j = 0; j <= nameCount; j++)
                            {
                                //the weird arithmetic in that box is because of:
                                //i is the row we are on assuming that there was only one name
                                //we subtract by namecount to take us back to the first entry (which is subtracting by 0 if there was only 1 name, and then subtracting by an additional 1 per name over 1 name)
                                //we then add j, which will iterate a number of times = to the ammount of names
                                //this is all because we don't actually want to manipulate i anymore since it's in the right place for the next subject
                                //string[] row = queryResultsArray[i-nameCount+j];

                                //we will now create a single string that is the first, all middles, and last name of the subject
                                //string databaseRowName = row[4] + " " + row[5] + " " + row[6];
                                string databaseRowName = queryResultsArray[i - nameCount + j, 4] + " " + queryResultsArray[i - nameCount + j, 5] + " " + queryResultsArray[i - nameCount + j, 6];

                                //then we run nameMatch!
                                int distance = nameMatch( inputPhone, databaseRowName);

                                //next, compare the result to the lowest result and bing bang boom we got it
                                if (distance < lowestResult)
                                {
                                    lowestResult = distance;
                                }//if

                            }//for

                            //now we take our lowest result and compare it to our weights
                            if (lowestResult < nameMatchRankBaseWeight)
                            {
                                //multiplying the raw score by 2 to give a bit more weight to the namematch
                                int scoreAdd = (nameMatchRankBaseWeight - lowestResult) * nameMatchRankMultiplier;
                                subjectIDAndScores[int.Parse(queryResultsArray[i - nameCount, 0])] += scoreAdd;
                            }//if
                            else
                            {
                                //nothing
                            }//else

                        }//namematching

                        /////////////////////////////
                        //next, check the given villageID compared to the current village. 

                        {//village distance
                         //check to see if this is the last entry for the given subject
                         //it doesn't actually matter which entry it is, just matters that we only consider one of them
                            if (!(queryResultsArray[i, 0].Equals(queryResultsArray[i + 1, 0])))
                            {

                                //if this is the last record, then we can look at the village
                                //string[] row = queryResultsArray[i];

                                //lets get the lat and long
                                //not every subject has a res, so we just skip the ones that don't. 
                                if (!queryResultsArray[i, 8].Equals(""))
                                {
                                    double lat = double.Parse(queryResultsArray[i, 8]);
                                    double lon = double.Parse(queryResultsArray[i, 9]);

                                    //string[] inputRecordRow = queryResultsListInputVillageGPS.GetValue(0);
                                    double inputLat = 0;
                                    double inputLon = 0;

                                    foreach (string[] SA in queryResultsListInputVillageGPS)
                                    {
                                        inputLat = double.Parse(SA[1]);
                                        inputLon = double.Parse(SA[2]);
                                    }//foreach


                                    //now we get to do a distance analysis!

                                    var sCoord = new GeoCoordinate(lat, lon);
                                    var eCoord = new GeoCoordinate(inputLat, inputLon);

                                    //this method returns the distance in meters
                                    double physicalDistance = sCoord.GetDistanceTo(eCoord);
                                    //now in km
                                    physicalDistance = physicalDistance / 1000;


                                    if (physicalDistance < maxAcceptableDistance)
                                    {
                                        //In this calculation, the highest value (where physicalDistance is 0) is 10, and the lowest value is 0
                                        int distanceRank = (maxAcceptableDistance - Convert.ToInt32(physicalDistance)) / (maxAcceptableDistance / 10);
                                        if (!(distanceRank < 0))
                                        {
                                            subjectIDAndScores[int.Parse(queryResultsArray[i, 0])] += distanceRank * distanceRankMultiplier;
                                        }//if
                                    }//if
                                    else
                                    {

                                    }//else if
                                }//if
                            }//if
                        }//village distance

                        //if the subject has gone through all of the filters and has a score of 0, they are immedietly removed from the library
                        if (subjectIDAndScores[int.Parse(queryResultsArray[i, 0])] == 0)
                        {
                            subjectIDAndScores.Remove(int.Parse(queryResultsArray[i, 0]));
                        }//if

                    }//for for ranking all of the subjects

                    //this next bit would be CRAZY cool, it's on the future dev docket
                    {
                        //after this, I would want to get a bit creative. We want both a time analysis on the given location and time analysis for all nearby locations. 
                        //first, we look at if any of the subjects in the dictionary have been at this location and assign varying scores depending on how long it's been. These scores in particular could be a bit tricky, as I'm not sure whether it should be better or worse if they had been there they day before. Either way, we assign the scores. 
                        //next, we do the same analysis if they have been at any other location within 50 miles, assigning varying points depending on how recently. 
                    }//future dev

                }//determining raw rank


                //last thing I'm going to do is normalize the values a bit
                {
                    double maxValueInSet = subjectIDAndScores.Values.Max();
                    double minValueInSet = subjectIDAndScores.Values.Min();



                    //getting the keys 
                    List<int> subjectIDs = subjectIDAndScores.Keys.ToList<int>();

                    //trasnforming the values
                    foreach (int i in subjectIDs)
                    {
                        double oldVal = subjectIDAndScores[i];
                        double newI = scaleBetween(oldVal, minNormalizedValue, maxNormalizedValue, minValueInSet, maxValueInSet);
                        subjectIDAndScores[i] = Convert.ToInt32(newI);
                    }//foreach

                }//normalization


                //after that we return the dictionary! This can then be used by the UI to display relative confidences.
            }//opening connection

            connection.Close();
            return subjectIDAndScores;
        }//SearchDB

        /// <summary>
        /// An algorithm for seeing how close of a match the name is
        /// </summary>
        /// <param name="inputName">the name that was entered as part of the input parameters</param>
        /// <param name="dbName">the current name from the database that we are comparing</param>
        /// <returns>Returns an int based on how close the match is. 3 = exact, 2 = Close Partial, 1 = Not very close partial, 0 = nothing</returns>
        private int nameMatch(string inputPhone, string dbName)
        {

            //make this compatible with all character types? I think it currently is, but more testing is necessary to be entirely sure

            //first step is to pheoneticise the names
            

            //string inputPhone = PhonemeGenerator.GetPronunciationFromText(inputName);
            string dbPhone = PhonemeGenerator.GetPronunciationFromText(dbName);


            //next is to find the Levenshtein distance between the names

            int distance = levenshteinDistance(inputPhone, dbPhone);

            //then we return that distance!
            return distance;
        }

        /// <summary>
        /// This function scales a function in a certain range
        /// </summary>
        /// <param name="unscaledNum"></param>
        /// <param name="newMin">the minimum value that w want our scaled values to be</param>
        /// <param name="newMax">the maximum value that w want our scaled values to be</param>
        /// <param name="previousMin">the minumum value in our data set</param>
        /// <param name="previousMax">the maximum value in our data set</param>
        /// <returns></returns>
        private double scaleBetween(double unscaledNum, double newMin, double newMax, double previousMin, double previousMax)
        {
            return (newMax - newMin) * (unscaledNum - previousMin) / (previousMax - previousMin) + newMin;
        }

        /// <summary>
        /// This method computes the levenshteinDistance between two strings
        /// </summary>
        /// <param name="s">string 1</param>
        /// <param name="t">string 2</param>
        /// <returns>The levenshtein distance value</returns>
        private int levenshteinDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            //the first two steps create a matrix with steadily incrementing values on the x and y axis
            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            //the last 4 steps fill in that matrix
            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }//distance method

        


        
    }//class



}//namespace
