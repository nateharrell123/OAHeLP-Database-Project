using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace OAHeLP_Database_Project
{

    /// <summary>
    /// This class is designed to generate a set of phonemes for any given string.
    /// It has one public method that takes the string that needs to be phoneticized
    /// </summary>
    public static class PhonemeGenerator
    {
        
        /// <summary>
        /// the preliminary phonemes that have been generated, they need to be checked
        /// </summary>
        private static string recoPhonemes;

        // Credit for method of retrieving IPA pronunciation from a string goes to Casey Chesnut (http://www.mperfect.net/speechSamples/)

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
                    //text to wav
                    synth.SetOutputToWaveStream(audioStream);
                    synth.Speak(MyWord);
                    synth.SetOutputToNull();
                    audioStream.Position = 0;


                    //now wav to txt (for reco phonemes)
                    recoPhonemes = String.Empty;
                    GrammarBuilder gb = new GrammarBuilder(MyWord);
                    Grammar g = new Grammar(gb); //TODO the hard letters to recognize are 'g' and 'e', but it gets them a large majority of the time, at least 90%
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

    /// <summary>
    /// enum for use in the Phoneme Generator class
    /// </summary>
    public enum WordType
    {
        Text,
        Normalized = Text,
        Lexical,
        Pronunciation
    }

}//namespace
