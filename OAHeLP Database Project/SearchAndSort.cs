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
        public Dictionary<int,int> SearchDB(string name, string ethnicGroup, string villageID, string sex)
        {
            SqlConnection connection;
            string connectionString;

            connectionString = ConfigurationManager.ConnectionStrings["OAHeLP_Database_Project.Properties.Settings.Database1ConnectionString"].ConnectionString;


            using (connection = new SqlConnection(connectionString))
            {
                //first we do a sex check, this will straight filter people out rather than contribute to the score

                //This will be the general format, but I want the query string to be much more complicated to hopefully cut down on the amount of commands we send
                string queryString;
                queryString = "SELECT DISTINCT SubjectID, Sex FROM Subject WHERE Sex = " + sex; //this will probably need to be edited depending on the exact makeup of our db, but that should be easy

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                //you can access data through the following syntax:
                if (reader.HasRows)
                {
                    //this could be used to keep track of the row that you are on, but it isn't necessary here
                    //int i = 0;

                    //The while loop iterates through the rows
                    while (reader.Read())
                    {
                        //i++;

                        //fieldcount returns the number of rows
                        //this could be used to pull multiple data points, but we only want their subject ID, so this is unnecessary
                        /*
                        for(int j = 0;j < reader.FieldCount; j++)
                        {
                            
                        }//for
                        */

                        //enter their subjectIDs into the dict and start at a base score of 0
                        subjectIDAndScores[reader.GetInt32(0)] = 0;
                    }//while
                }//if
                else
                {
                    Console.WriteLine("No rows found.");
                }//else
                reader.Close();

                //now our dictionary is full of only subjects with the perscribed sex. This should help narrow future searches since we are very confident that sex will be correct

                //next, we need to filter the Database for all of the subjects we already have that match the given ethnic group
                //these individuals then get a +10 to their score



                //next, in a loop, we run our nameMatch method. for an exact match (return of 0), the subject in the dictionary gets +10. For a close partial(return < 5), they get +5, (return < 9)for a not so close partial, they get +2, and no match gets +0

                //next, we loop through our dictionary and filter out any names that have not already gained >10 score. This should help cut down runtime (although it's already going to be a bit of a beast on those first two)

                //next, we loop and check the given villageID compared to the current village. I'm hoping that we can get some geo-data and do a range analysis here (I think we should be able to given the long and lati properties in that table). The villages being within 10m is +10, within 50m is +5, within 100m is +2

                //after this, I would want to get a bit creative. We want both a time analysis on the given location and time analysis for all nearby locations. 
                //first, we look at if any of the subjects in the dictionary have been at this location and assign varying scores depending on how long it's been. These scores in particular could be a bit tricky, as I'm not sure whether it should be better or worse if they had been there they day before. Either way, we assign the scores. 
                //next, we do the same analysis if they have been at any other location within 50 miles, assigning varying points depending on how recently. 


                //after that we return the dictionary! This can then be used by the UI to display relative confidences. We can also do some normalization of the data before returning
            }
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
