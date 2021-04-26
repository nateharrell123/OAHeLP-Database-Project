using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
//using Microsoft.AspNet.SignalR.Infrastructure;
using System.Data.SqlClient;
using System.Configuration;
using System.Device.Location;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Collections.Generic;

namespace OAHeLP_Database_Project
{
    //merging was being odd, so copy and pasting from John branch

    public class SearchAndSort
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
        public Dictionary<int, int> SearchDB(string inputName, string inputEthnicGroup, string inputVillageName, string inputSex)
        {
            SqlConnection connection;
            string connectionString;


            //alright, the very first thing we need to do is normalize our data
            //the database stores sex as either M or F, so if it's any version of male/female we need to normalize it to M or F

            if (inputSex.Equals("Male"))
            {
                inputSex = "M";
            }//if
            else if(inputSex.Equals("Female"))
            {
                inputSex = "F";
            }//else

            connectionString = ConfigurationManager.ConnectionStrings["OAHeLP_Database_Project.Properties.Settings.Database1ConnectionString"].ConnectionString;

            using (connection = new SqlConnection(connectionString))
            {
                //firstly this we need to grab the long and lat info for the inputVillage, so we'll run a quick query for that. 

                string queryString;
                queryString = $"SELECT V.[Name],V.GPSLatitude,V.GPSLongitude FROM [Subject].Village V WHERE V.[Name] = '{inputVillageName}'";


                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                //you can access data through the following syntax:

                //now this is going into a list array so that I don't pull out my hair trying to work with it
                //it's going to be a list array of strings, that's the easiest to parse into other types if need be
                List<string[]> queryResultsListInputVillageGPS = new List<string[]>();

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

                //alright, we're going to make a giant query so that we don't have to do a bunch of seperate ones. Then, we'll store the info and filter through it as needed
                //so the question is, what all do we need?

                //also, eventually this should probably be some sort of string builder, but I'm just hardcoding this for now to make everything clear

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

                //for reference, this query will output a table that looks like this

                //     0          1            2                3             4             5             6             7              8               9      
                //S.SubjectID | S.Sex | EG.EthnicGroupName | N.NameID | N.FirstName | N.MiddleNames | N.LastName | V.VillageID | V.GPSLatitude | V.GPSLongitude


                command = new SqlCommand(queryString, connection);
                

                reader = command.ExecuteReader();
                //you can access data through the following syntax:

                //now this is going into a list array so that I don't pull out my hair trying to work with it
                //it's going to be a list array of strings, that's the easiest to parse into other types if need be
                List<string[]> queryResultsList = new List<string[]>();

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
                int readerCount = reader.FieldCount;
                reader.Close();


                //oooookay. Now we have a list of arrays with all of the info in them. I'm going to turn this into a 2d array mostly because I just sort of want to. We'll look at possible performance differences later
                string[,] queryResultsArray = new string[queryResultsList.Count, readerCount];

                int counter = 0;
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

                //next, we need to filter through the Database for all of the subjects we already have that match the given ethnic group
                //these individuals then get a +10 to their score

                //each row is one subject, but one subject may be on multiple rows if they have multiple names associated with the subject. 
                for (int i = 0; i < counter - 1; i++)
                {
                    //check to see if this is the last entry for the given subject
                    //it doesn't actually matter which entry it is, just matters that we only consider one of them
                    if (!(queryResultsArray[i, 0].Equals(queryResultsArray[i + 1, 0])))
                    {
                        //if this is the last record for that subject, we will look at the ethnic group compared to the input ethnic group
                        if (queryResultsArray[i, 2].Equals(inputEthnicGroup))
                        {

                            subjectIDAndScores[int.Parse(queryResultsArray[i, 0])] += 15;
                        }//if
                    }//if
                }//for


                //next, in a loop, we run our nameMatch method. This will add 10-distance as long as distance is < 10

                for (int i = 0; i < counter - 1; i++)
                {

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
                        int distance = nameMatch(inputName, databaseRowName);

                        //next, compare the result to the lowest result and bing bang boom we got it
                        if (distance < lowestResult)
                        {
                            lowestResult = distance;
                        }//if

                    }//for

                    //now we take our lowest result and compare it to our weights
                    if (lowestResult < 15)
                    {
                        //multiplying the raw score by 2 to give a bit more weight to the namematch
                        int scoreAdd = (15 - lowestResult) * 2;
                        subjectIDAndScores[int.Parse(queryResultsArray[i - nameCount, 0])] += scoreAdd;
                    }//if
                    else
                    {
                        //nothing
                    }//else


                }//for



                //next, we loop and check the given villageID compared to the current village. 

                for (int i = 0; i < counter - 1; i++)
                {
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

                            //The villages being within 100km is +10, within 500km is +5, within 2500km is +2
                            if (physicalDistance < 2500)
                            {
                                //In this calculation, the highest value (where physicalDistance is 0) is 10, and the lowest value is 0
                                int distanceWeight = (2500 - Convert.ToInt32(physicalDistance)) / 250;
                                if (!(distanceWeight < 0))
                                {
                                    subjectIDAndScores[int.Parse(queryResultsArray[i, 0])] += distanceWeight;
                                }//if
                            }//if
                            else
                            {

                            }//else if
                        }//if
                    }//if
                }//for

                List<int> subjectsToRemove = new List<int>();
                //Now we're going to filter out all of the zeroes
                //we have to get all of the keys first before actually modifying the dictionary
                foreach(KeyValuePair<int,int> i in subjectIDAndScores)
                {
                    if(i.Value == 0)
                    {
                        subjectsToRemove.Add(i.Key);
                    }//if
                }//foreach

                //then we can go through and remove the subjects
                foreach(int i in subjectsToRemove)
                {
                    subjectIDAndScores.Remove(i);
                }//foreach


                //last thing I'm going to do is normalize the values a bit
                
                double maxValueInSet = subjectIDAndScores.Values.Max();
                double minValueInSet = subjectIDAndScores.Values.Min();

                //this can be whatever we want them to be
                double maxNormalizedValue = 50;
                double minNormalizedValue = 10;

                //getting the keys 
                List<int> subjectIDs = subjectIDAndScores.Keys.ToList<int>();

                //trasnforming the values
                foreach(int i in subjectIDs)
                {
                    double oldVal = subjectIDAndScores[i];
                    double newI = scaleBetween(oldVal, minNormalizedValue, maxNormalizedValue, minValueInSet, maxValueInSet);
                    subjectIDAndScores[i] = Convert.ToInt32(newI);
                }//foreach

                


                //then we're done!!!!
                //////////////////////////////////////////////////////////////////////////////////////////////////////

                //this next bit would be CRAZY cool, but I don't think I have time

                //after this, I would want to get a bit creative. We want both a time analysis on the given location and time analysis for all nearby locations. 
                //first, we look at if any of the subjects in the dictionary have been at this location and assign varying scores depending on how long it's been. These scores in particular could be a bit tricky, as I'm not sure whether it should be better or worse if they had been there they day before. Either way, we assign the scores. 
                //next, we do the same analysis if they have been at any other location within 50 miles, assigning varying points depending on how recently. 


                //after that we return the dictionary! This can then be used by the UI to display relative confidences. We can also do some normalization of the data before returning
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
        private int nameMatch(string inputName, string dbName)
        {

            //make this compatible with all character types? I think it currently is, but I'm not sure yet

            //first step is to pheoneticise the names

            string inputPhone = GetPronunciationFromText(inputName);
            string dbPhone = GetPronunciationFromText(dbName);


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

        // Credit for method of retrieving IPA pronunciation from a string goes to Casey Chesnut (http://www.mperfect.net/speechSamples/)

        private static string recoPhonemes;

        /// <summary>
        /// This method is for getting the word phones from a given string
        /// </summary>
        /// <param name="MyWord">The word (string) that needs to be phoeneticised</param>
        /// <returns>the phones for the given input</returns>
        private static string GetPronunciationFromText(string MyWord)
        {
            //this is a trick to figure out phonemes used by synthesis engine

            //txt to wav
            using (MemoryStream audioStream = new MemoryStream())
            {
                using (SpeechSynthesizer synth = new SpeechSynthesizer())
                {
                    synth.SetOutputToWaveStream(audioStream);
                    synth.Speak(MyWord);
                    synth.SetOutputToNull();
                    audioStream.Position = 0;

                    //now wav to txt (for reco phonemes)
                    recoPhonemes = String.Empty;
                    GrammarBuilder gb = new GrammarBuilder(MyWord);
                    Grammar g = new Grammar(gb); //TODO the hard letters to recognize are 'g' and 'e'
                    SpeechRecognitionEngine reco = new SpeechRecognitionEngine();
                    reco.SpeechHypothesized += new EventHandler<SpeechHypothesizedEventArgs>(reco_SpeechHypothesized);
                    reco.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(reco_SpeechRecognitionRejected);
                    reco.UnloadAllGrammars();
                    reco.LoadGrammar(g);
                    reco.SetInputToWaveStream(audioStream);
                    RecognitionResult rr = reco.Recognize();
                    reco.SetInputToNull();
                    if (rr != null)
                    {
                        recoPhonemes = StringFromWordArray(rr.Words, WordType.Pronunciation);
                    }
                    return recoPhonemes;
                }
            }
        }

        /// <summary>
        /// Creates a string given an array of word units
        /// </summary>
        /// <param name="words"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string StringFromWordArray(ReadOnlyCollection<RecognizedWordUnit> words, WordType type)
        {
            string text = "";
            foreach (RecognizedWordUnit word in words)
            {
                string wordText = "";
                if (type == WordType.Text || type == WordType.Normalized)
                {
                    wordText = word.Text;
                }
                else if (type == WordType.Lexical)
                {
                    wordText = word.LexicalForm;
                }
                else if (type == WordType.Pronunciation)
                {
                    wordText = word.Pronunciation;
                }
                else
                {
                    throw new InvalidEnumArgumentException(String.Format("[0}: is not a valid input", type));
                }
                //Use display attribute

                if ((word.DisplayAttributes & DisplayAttributes.OneTrailingSpace) != 0)
                {
                    wordText += " ";
                }
                if ((word.DisplayAttributes & DisplayAttributes.TwoTrailingSpaces) != 0)
                {
                    wordText += "  ";
                }
                if ((word.DisplayAttributes & DisplayAttributes.ConsumeLeadingSpaces) != 0)
                {
                    wordText = wordText.TrimStart();
                }
                if ((word.DisplayAttributes & DisplayAttributes.ZeroTrailingSpaces) != 0)
                {
                    wordText = wordText.TrimEnd();
                }

                text += wordText;

            }
            return text;
        }

        /// <summary>
        /// Event for when the recognition engine has a guess as to the phonemes for a word
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void reco_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            recoPhonemes = StringFromWordArray(e.Result.Words, WordType.Pronunciation);
        }

        /// <summary>
        /// Event for when the recognition engine regects the given wav (default error message produced)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void reco_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            recoPhonemes = StringFromWordArray(e.Result.Words, WordType.Pronunciation);
        }

    }//class


    public enum WordType
    {
        Text,
        Normalized = Text,
        Lexical,
        Pronunciation
    }






    /*

    /// <summary>
    /// Property of John Solomon
    /// </summary>
    public class SearchAndSort
    {
        public Dictionary<int, int> SearchDB(string inputName, string inputEthnicGroup, string inputVillageID, string inputSex)
        {
            Dictionary<int, int> asdf = new Dictionary<int, int>();
            return asdf;
        }
    }

    */
}
