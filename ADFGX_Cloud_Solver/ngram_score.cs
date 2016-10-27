using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericScoring
{
    /// <summary>
    /// This Class can get used to score a given string (Typically a known cipher result) with a Ngram Frequency file. (Example files can be found in the root of GIT.)
    /// </summary>
    public class ngram_score
    {
        // Holds all Ngrams and Frequency values in the supplied file.
        public static Dictionary<string, double> ngrams = new Dictionary<string, double>(StringComparer.InvariantCultureIgnoreCase);
        public static Dictionary<string, double> trigrams = new Dictionary<string, double>(StringComparer.InvariantCultureIgnoreCase);
        public static Dictionary<string, double> quadgrams = new Dictionary<string, double>(StringComparer.InvariantCultureIgnoreCase);
        // Length of the Ngram (Bigram, Trigram, Quadgram, etc.)
        public static int L = 0;
        // Total Sum of all the Frequency values in the supplied file.
        public static double N = 0;
        // Floor score to use when a Ngram doesn't exist.
        public static double Floor = 0;

        // Length of the Ngram (Bigram, Trigram, Quadgram, etc.)
        public static int L_quad = 0;
        // Total Sum of all the Frequency values in the supplied file.
        public static double N_quad = 0;
        // Floor score to use when a Ngram doesn't exist.
        public static double Floor_quad = 0;

        // Length of the Ngram (Bigram, Trigram, Quadgram, etc.)
        public static int L_tri = 0;
        // Total Sum of all the Frequency values in the supplied file.
        public static double N_tri = 0;
        // Floor score to use when a Ngram doesn't exist.
        public static double Floor_tri = 0;

        /// <summary>
        /// This function Loads the required Ngram file needed to score.
        /// </summary>
        /// <param name="File">
        /// Parameter ngramfile requires an string argument containing the path to a Ngram file.
        /// </param>
        /// <param name="sep">
        /// Parameter sep is an optional parameter, used to tell the class what seperator in the file seperates the Ngram from the Frequency Count.
        /// </param>
        /// <param name="gramType">
        /// Parameter sep is an optional parameter, used to tell the class what type of ngram to use.
        /// </param>
        /// <returns>
        /// The method returns a boolean based on if the file was successfully loaded or not.
        /// </returns>
        public static bool LoadNgarmFile(string NgramDump, int gramType = 3, char sep = ' ')
        {
            ngrams.Clear();
            L = 0;
            N = 0;
            Floor = 0;

            string[] lines = NgramDump.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            try
            {
                foreach (string line in lines)
                {
                    string key = "";
                    int count = 0;
                    string[] split = line.Split(sep);
                    key = split[0];
                    count = Convert.ToInt32(split[1]);
                    ngrams.Add(key, count);
                }

                L = gramType;
                N = ngrams.Sum(x => x.Value);

                foreach (var key in ngrams.Keys.ToArray())
                {
                    double d = ngrams[key] / N;
                    ngrams[key] = Math.Log10(d);
                }
                Floor = Math.Log10(0.01 / N);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool LoadNgarmDoubleFile(string TrigramDump, string QuadgramDump, char sep = ' ')
        {
            trigrams.Clear();
            L_tri = 0;
            N_tri = 0;
            Floor_tri = 0;

            quadgrams.Clear();
            L_quad = 0;
            N_quad = 0;
            Floor_quad = 0;

            string[] lines = TrigramDump.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            string[] lines2 = QuadgramDump.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            try
            {
                foreach (string line in lines)
                {
                    string key = "";
                    int count = 0;
                    string[] split = line.Split(sep);
                    key = split[0];
                    count = Convert.ToInt32(split[1]);
                    trigrams.Add(key, count);
                }

                L_tri = 3;
                N_tri = trigrams.Sum(x => x.Value);

                foreach (var key in trigrams.Keys.ToArray())
                {
                    double d = trigrams[key] / N_tri;
                    trigrams[key] = Math.Log10(d);
                }
                Floor = Math.Log10(0.01 / N_tri);



                    foreach (string line in lines2)
                    {
                        string key = "";
                        int count = 0;
                        string[] split = line.Split(sep);
                        key = split[0];
                        count = Convert.ToInt32(split[1]);
                        quadgrams.Add(key, count);
                    }

                    L_quad = 4;
                    N_quad = quadgrams.Sum(x => x.Value);

                    foreach (var key in quadgrams.Keys.ToArray())
                    {
                        double d = quadgrams[key] / N_quad;
                        quadgrams[key] = Math.Log10(d);
                    }
                    Floor = Math.Log10(0.01 / N_quad);


                }
                catch
                {
                    return false;
                }

            return true;
        }

        /// <summary>
        /// This function scores the supplied 'str' parameter against the Ngram file provided on the ngram_score Class init.
        /// </summary>
        /// <param name="str">
        /// Parameter str requires an string argument, typically containing the result from a cipher decrypt test.
        /// </param>
        /// <returns>
        /// The method returns a score based on the frequency of Ngrams in the given 'str' parameter.
        /// </returns>
        public static double Score(string str)
        {
            double Score = 0;


            foreach (var i in Xrange(str.Length - L + 1))
            {
                string s = str.Substring((int)i, L).ToUpper();
                if (ngrams.ContainsKey(s))
                {
                    Score += ngrams[s];
                }
                else
                {
                    Score += Floor;
                }
            }
            return Score;
        }

        public static double ScoreDouble(string str)
        {
            double TriScore = 0;
            double QuadScore = 0;

            foreach (var i in Xrange(str.Length - L_tri + 1))
            {
                string s = str.Substring((int)i, L_tri).ToUpper();
                if (trigrams.ContainsKey(s))
                {
                    TriScore += trigrams[s];
                }
                else
                {
                    TriScore += Floor;
                }
            }

            foreach (var i in Xrange(str.Length - L_quad + 1))
            {
                string s = str.Substring((int)i, L_quad).ToUpper();
                if (quadgrams.ContainsKey(s))
                {
                    QuadScore += quadgrams[s];
                }
                else
                {
                    QuadScore += Floor;
                }
            }


            return QuadScore + TriScore;
        }

        //A simple helper function, Xrange, which is normally a default Python function i converted to C#.
        public static System.Collections.IEnumerable Xrange(int stop)
        {
            for (int i = 0; i < stop; i++)
            {
                yield return i;
            }
        }


    }
}
