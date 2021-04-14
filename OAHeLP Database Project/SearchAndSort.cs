using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
//using Microsoft.AspNet.SignalR.Infrastructure;
using System.Data.SqlClient;
using System.Configuration;

namespace OAHeLP_Database_Project
{
    class SearchAndSort
    {

        /// <summary>
        /// this dictionary tracks each subject's score compared to test data
        /// </summary>
        Dictionary<int, int> subjectIDAndScores = new Dictionary<int, int>();
        Dictionary<int, string> subjectIDAndNames = new Dictionary<int, string>(); 

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
        public Dictionary<int,int> SearchDB(string inputName, string inputEthnicGroup, string inputVillageID, string inputSex)
        {
            SqlConnection connection;
            string connectionString;

            connectionString = ConfigurationManager.ConnectionStrings["OAHeLP_Database_Project.Properties.Settings.Database1ConnectionString"].ConnectionString;


            using (connection = new SqlConnection(connectionString))
            {
                

                //firstly this we need to grab the long and lat info for the inputVillage, so we'll run a quick query for that. 
                
                string queryString;
                queryString = "SELECT V.VillageID,V.GPSLatitude,V.GPSLongitude FROM Village V WHERE V.VillageID = " + inputVillageID;


                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                //you can access data through the following syntax:

                //now this is going into a list array so that I don't pull out my hair trying to work with it
                //it's going to be a list array of strings, that's the easiest to parse into other types if need be
                List<string>[] queryResultsListInputVillageGPS = new List<string>[reader.FieldCount]

                if (reader.HasRows)
                {
                    
                    //The while loop iterates through the rows
                    while (reader.Read())
                    {
                        
                        //string array to represent the row
                        string[] row = new string[reader.FieldCount];

                        row[0] = reader.GetValue(0);
                        row[1] = reader.GetValue(1);
                        row[2] = reader.GetValue(2);

                        //this should only have one row, but better safe than sorry
                        queryResultsListVillageGPS.Append(row);
                        
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

                /*
                //First we do sex
                queryString = "SELECT DISTINCT S.SubjectID, S.Sex, FROM Subject S WHERE Sex = " + sex; //this will probably need to be edited depending on the exact makeup of our db, but that should be easy

                //then, we need ethnic group
                queryString = "SELECT DISTINCT S.SubjectID, S.Sex, S.EthnicGroup FROM Subject S WHERE Sex = " + sex;

                //now we need the name(s) of the the SubjectIDs. This will involve a join based on the SubjectName table
                queryString = "SELECT DISTINCT S.SubjectID, S.Sex, S.EthnicGroup, N.NameID, N.FirstName, N.MiddleNames, N.LastName" + 
                    "FROM Subject S " + 
                        "LEFT JOIN SubjectName SN ON S.SubjectID = SN.SubjectID " + 
                        "LEFT JOIN Name N ON SN.NameID = N.NameID " + 
                    "WHERE Sex = " + sex;
                

                //next we need to get the VillageID of their Residence, also taking out distinct because I'm unsure if it's needed
                //also added the ordering to the query
                queryString = "SELECT S.SubjectID, S.Sex, S.EthnicGroup, N.NameID, N.FirstName, N.MiddleNames, N.LastName, V.VillageID" + 
                    "FROM Subject S " + 
                        "LEFT JOIN SubjectName SN ON S.SubjectID = SN.SubjectID " + 
                        "LEFT JOIN Name N ON SN.NameID = N.NameID " + 
                        "LEFT JOIN Residence R ON S.SubjectID = R.SubjectID " +
                        "LEFT JOIN Village V ON V.VillageID = R.VillageID" +
                    "WHERE Sex = " + inputSex +
                    " ORDER BY S.SubjectID";
                */
                //finally, we'll also query the lat and long of that village
                queryString = "SELECT S.SubjectID, S.Sex, S.EthnicGroup, N.NameID, N.FirstName, N.MiddleNames, N.LastName, V.VillageID, V.GPSLatitude, V.GPSLongitude" + 
                    "FROM Subject S " + 
                        "LEFT JOIN SubjectName SN ON S.SubjectID = SN.SubjectID " + 
                        "LEFT JOIN Name N ON SN.NameID = N.NameID " + 
                        "LEFT JOIN Residence R ON S.SubjectID = R.SubjectID " +
                        "LEFT JOIN Village V ON V.VillageID = R.VillageID" +
                    "WHERE Sex = " + inputSex +
                    " ORDER BY S.SubjectID";

                //and that should be the entire query!

                //for reference, this query will output a table that looks like this
                
                //     0          1           2            3             4               5           6             7              8               9      
                //S.SubjectID | S.Sex | S.EthnicGroup | N.NameID | N.FirstName | N.MiddleNames | N.LastName | V.VillageID | V.GPSLatitude | V.GPSLongitude
                

                

                command = new SqlCommand(queryString, connection);
                connection.Open();

                reader = command.ExecuteReader();
                //you can access data through the following syntax:

                //now this is going into a list array so that I don't pull out my hair trying to work with it
                //it's going to be a list array of strings, that's the easiest to parse into other types if need be
                List<string>[] queryResultsList = new List<string>[reader.FieldCount]

                if (reader.HasRows)
                {
                    
                    int i = 0;//I mostly have th counter here just in case I need it. I don't actually think you do, but it's still decent to have

                    //The while loop iterates through the rows
                    while (reader.Read())
                    {
                        
                        //string array to represent the row
                        string[] row = new string[reader.FieldCount];

                        //fieldcount returns the number of rows
                        
                        for(int j = 0;j < reader.FieldCount; j++)
                        {
                            row[j] = ToString(reader.GetValue(j));
                        }//for
                        
                        //now that we have the row stored in the array, we can add it to the list
                        queryResultsList.Append(row);

                        //enter their subjectIDs into the dict and start at a base score of 0
                        subjectIDAndScores[reader.GetInt32(0)] = 0;
                        
                        i++;//iterate the counter
                    }//while
                }//if

                else
                {
                    Console.WriteLine("No rows found.");
                }//else

                reader.Close();


                //oooookay. Now we have a list of arrays with all of the info in them. I'm going to turn this into a 2d array mostly because I just sort of want to. We'll look at possible performance differences later
                string[][] queryResultsArray = new string[queryResultsList.Length][reader.FieldCount];

                for(int i = 0 ; i < queryResultsList.Length ; i++)
                {
                    //string array to represent the row
                    string[] row = queryResultsList.GetValue(i);

                    for(int j = 0; j<reader.FieldCount; j++)
                    {
                        queryResultsArray[i][j] = row[j];
                    }//for
                }//for

                //cool, now we have a 2d array with all of the data points we need!
                //our dictionary is full of only subjects with the perscribed sex. This should help narrow future searches since we are very confident that sex will be correct

                //next, we need to filter through the Database for all of the subjects we already have that match the given ethnic group
                //these individuals then get a +10 to their score

                //each row is one subject, but one subject may be on multiple rows if they have multiple names associated with the subject. 
                for (int i = 0; i < queryResultsArray.Length; i++)
                {
                    //check to see if this is the last entry for the given subject
                    //it doesn't actually matter which entry it is, just matters that we only consider one of them
                    if(!(queryResultsArray[i][0].Equals(queryResultsArray[i+1][0])))
                    {
                        //if this is the last record for that subject, we will look at the ethnic group compared to the input ethnic group
                        if (queryResultsArray[i][2].Equals(inputEthnicGroup))
                        {
                            subjectIDAndScores[queryResultsArray[i][0]] += 10
                        }//if
                    }//if
                }//for


                //next, in a loop, we run our nameMatch method. for an exact match (return of 0), the subject in the dictionary gets +10. For a close partial(return < 5), they get +5, (return < 9)for a not so close partial, they get +2, and no match gets +0

                for (int i = 0; i < queryResultsArray.Length; i++)
                {
                    
                    //first, we have to check if the given subject has more than one name, which would result in their ID being listed more than once
                    //if that is the case, then we need to figure out how many names they have, represented by nameCount (default 0)
                    int nameCount = 0;
                    while (queryResultsArray[i][0].Equals(queryResultsArray[i + 1][0]))
                    {
                        nameCount++;
                        i++;
                    }//if
                    
                    //now we can check nameCount and run our name match a corrasponding number of times
                    //we will take the lowest result from the series of runs
                    int lowestResult = Int32.MaxValue;
                    for(int j = 0; j <= nameCount; j++)
                    {
                        //the weird arithmetic in that box is because of:
                        //i is the row we are on assuming that there was only one name
                        //we subtract by namecount to take us back to the first entry (which is subtracting by 0 if there was only 1 name, and then subtracting by an additional 1 per name over 1 name)
                        //we then add j, which will iterate a number of times = to the ammount of names
                        //this is all because we don't actually want to manipulate i anymore since it's in the right place for the next subject
                        string[] row = queryResultsArray[i-nameCount+j];

                        //we will now create a single string that is the first, all middles, and last name of the subject
                        string databaseRowName = row[4] + " " + row[5] + " " + row[6];

                        //then we run nameMatch!
                        int distance = nameMatch(inputName,databaseRowName);

                        //next, compare the result to the lowest result and bing bang boom we got it
                        if (distance < lowestResult)
                        {
                            lowestResult = distance;
                        }//if

                    }//for

                    //now we take our lowest result and compare it to our weights
                    if(lowestResult == 0)
                    {
                        subjectIDAndScores[queryResultsArray[i-nameCount][0]] += 10
                    }//if
                    else if(lowestResult < 5)
                    {
                        subjectIDAndScores[queryResultsArray[i-nameCount][0]] += 5;
                    }//else if
                    else if(lowestResult < 9)
                    {
                        subjectIDAndScores[queryResultsArray[i-nameCount][0]] += 2;
                    }//else if
                    else
                    {
                        //nothing
                    }//else


                }//for



                //next, we loop and check the given villageID compared to the current village. I'm hoping that we can get some geo-data and do a range analysis here
                //(I think we should be able to given the long and lati properties in that table). The villages being within 10m is +10, within 50m is +5, within 100m is +2

                for (int i = 0; i < queryResultsArray.Length; i++)
                {
                    //check to see if this is the last entry for the given subject
                    //it doesn't actually matter which entry it is, just matters that we only consider one of them
                    if(!(queryResultsArray[i][0].Equals(queryResultsArray[i+1][0])))
                    {
                        
                        //if this is the last record, then we can look at the village
                        string[] row = queryResultsArray[i];

                        //lets get the lat and long
                        int lat = int.Parse(row[8]);
                        int long = int.Parse(row[9]);

                        string[] inputRecordRow = queryResultsListInputVillageGPS.GetValue(0);
                        int inputLat = int.Parse(inputRecordRow[1]);
                        int inputLong = int.Parse(inputRecordRow[2]);

                        //now we get to do a distance analysis!


                    }//if
                }//for



                //after this, I would want to get a bit creative. We want both a time analysis on the given location and time analysis for all nearby locations. 
                //first, we look at if any of the subjects in the dictionary have been at this location and assign varying scores depending on how long it's been. These scores in particular could be a bit tricky, as I'm not sure whether it should be better or worse if they had been there they day before. Either way, we assign the scores. 
                //next, we do the same analysis if they have been at any other location within 50 miles, assigning varying points depending on how recently. 


                //after that we return the dictionary! This can then be used by the UI to display relative confidences. We can also do some normalization of the data before returning
            }//opening connection
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

            //make this compatible with all character types? I think it currently is, but I'm not sure yet

            //first step is to pheoneticise the names

            string inputPhone = GetPronunciationFromText(inputName);
            string dbPhone = GetPronunciationFromText(dbName);

            Console.WriteLine("Input Phone: " + inputPhone);
            Console.WriteLine("DB Phone: " + dbPhone);


            //next is to find the Levenshtein distance between the names

            int distance = levenshteinDistance(inputPhone, dbPhone);

            //then we return that distance!
            return distance;
        }


        /// <summary>
        /// This method computes the levenshteinDistance between two strings
        /// </summary>
        /// <param name="s">string 1</param>
        /// <param name="t">string 2</param>
        /// <returns>The levenshtein distance value</returns>
        public int levenshteinDistance(string s, string t)
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

        public static string recoPhonemes;

        /// <summary>
        /// This method is for getting the word phones from a given string
        /// </summary>
        /// <param name="MyWord">The word (string) that needs to be phoeneticised</param>
        /// <returns>the phones for the given input</returns>
        public static string GetPronunciationFromText(string MyWord)
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
        public static string StringFromWordArray(ReadOnlyCollection<RecognizedWordUnit> words, WordType type)
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
        public static void reco_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            recoPhonemes = StringFromWordArray(e.Result.Words, WordType.Pronunciation);
        }

        /// <summary>
        /// Event for when the recognition engine regects the given wav (default error message produced)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void reco_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
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
}//namespace
