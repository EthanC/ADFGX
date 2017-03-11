using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADFGX_Cloud_Solver
{
    public partial class Form1 : Form
    {
        public static string Cipher = "IXSODNOIINXXSNRSNRNSRASOWXPOKXNSQL";
        public static string ContributerName = "N/A";
        public static string GlobalUpdateString = "";
        public static double BestScore = -99999;
        public static string CPUperc = "HIGH";
        public static string retVer = "";
        public int TotalCount = 0;
        public int GoodCount = 0;
        public static System.Threading.CancellationTokenSource cts = new System.Threading.CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
            Pbar.Visible = false;
            CPUlevel.SelectedIndex = 0;
        }

        /// <summary>
        /// The Loading function that starts as soon as the application loads.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            //Start Inital BackgroundWorker Thread and call to Server
            InitServerWorker.RunWorkerAsync();
        }

        /// <summary>
        /// The BackgroundWorker Function responsible for checking Versions and Populating inital data on the application from the server.
        /// </summary>
        private void InitServerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //init's class to communicate with external server
            ADFGXService.ServiceClient ADFGXserv = new ADFGXService.ServiceClient();

            //Gets the News Information from Server and populates the News Textbox
            var retNews = ADFGXserv.GetNews();
            if (retNews.Contains("ERROR:"))
                this.newsText.Invoke(new MethodInvoker(delegate () { this.newsText.Text = "An error occured while attempting to contact server! Please contact TheRealDecrypterfixer@gmail.com to report the below error..." + Environment.NewLine + Environment.NewLine + retNews; }));
            else
                this.newsText.Invoke(new MethodInvoker(delegate () { this.newsText.Text = retNews; }));

            //Gets the Top20 results from Server and populates the Results Textbox
            var retTop = ADFGXserv.GetTop20();
            if (retTop.Contains("ERROR:"))
                this.resultsText.Invoke(new MethodInvoker(delegate () { this.resultsText.Text = "An error occured while attempting to contact server! Please contact TheRealDecrypterfixer@gmail.com to report the below error..." + Environment.NewLine + Environment.NewLine + retTop; }));
            else
                this.resultsText.Invoke(new MethodInvoker(delegate () { this.resultsText.Text = retTop; }));

            //Gets the currently being worked on Cipher
            var retCipher = ADFGXserv.GetCipher();
            if (retTop.Contains("ERROR:"))
            {
                MessageBox.Show("An error occured while attempting to obtain the cipher to work on from the server. This is commonly because of a lack of internet connection. This application needs the internet to run. If this error continues after being connected, please ensure you can view the site http://fascinatinginformation.com/ and contact TheRealDecrypterFixer@gmail.com" + Environment.NewLine + Environment.NewLine + retCipher, "ADFGX Cloud Factoring App");
            }
            else
                Cipher = retCipher;

            //Gets the Version information from Server and exits if the Version is incorrect
            retVer = ADFGXserv.GetVersion();
            if (retVer.Contains("ERROR:"))
            {
                MessageBox.Show("An error occured while attempting to check the version of the application with the server. This is commonly because of a lack of internet connection. This application needs the internet to run. If this error continues after being connected, please ensure you can view the site http://fascinatinginformation.com/ and contact TheRealDecrypterFixer@gmail.com" + Environment.NewLine + Environment.NewLine + retVer, "ADFGX Cloud Factoring App");
                Environment.Exit(0);
            }
            else if (retVer == "")
            {
                MessageBox.Show("An error occured while attempting to check the version of the application with the server. This is commonly because of a lack of internet connection. This application needs the internet to run. If this error continues after being connected, please ensure you can view the site http://fascinatinginformation.com/ and contact TheRealDecrypterFixer@gmail.com . Exiting application to avoid wasting resources.", "ADFGX Cloud Factoring App");
                Environment.Exit(0);
            }
            else
            {
                if (retVer != "3")
                {
                    MessageBox.Show("A new version of the application has been released, thus running this version would be a waste. When exiting this messagebox the new version will be downloaded and ran.", "ADFGX Cloud Factoring App");
                    System.Net.WebClient myWebClient = new System.Net.WebClient();
                    myWebClient.DownloadFile("http://fascinatinginformation.com/ADFGX_Cloud_Solver.exe", "ADFGX_Cloud_Solver_" + retVer + ".exe");
                    System.Diagnostics.Process.Start("ADFGX_Cloud_Solver_" + retVer + ".exe");
                    Environment.Exit(0);
                }
            }
        }


        /// <summary>
        /// The BackgroundWorker Function responsible for Brute Forcing the cipher. This is the 'Bread and Butter' of the app
        /// </summary>
        private void BruteForceWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //init's class to communicate with external server
            ADFGXService.ServiceClient ADFGXserv = new ADFGXService.ServiceClient();
            //Alphabet to start with when Brute Forcing
            string Alpha = new string(new[] { 'Z', 'O', 'M', 'B', 'I', 'E', 'F', 'G', 'H', 'K', 'L', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'A', 'C', 'D' });
            //Set Max CPU usage
            var opts = new ParallelOptions();
            if (CPUperc == "LOW")
                opts.MaxDegreeOfParallelism = 4;
            //Set Cancel Token for Brute Force Thread
            opts.CancellationToken = cts.Token;
            //Load Ngrams
            GenericScoring.ngram_score.LoadNgarmDoubleFile(Properties.Resources.english_trigrams, Properties.Resources.english_quadgrams);
            //Start the Brute Forcing Loop
            try
            {
                Parallel.ForEach(Infinite(), opts, new Action<bool>((val) =>
                {
                    opts.CancellationToken.ThrowIfCancellationRequested();
                //Shuffle the Alphabet and get a random Cipher Key
                string C_Aplha = Alpha.Shuffle();
                //Decipher the ciphertext by Substitution
                var ret = Cipher.Substitute(C_Aplha);
                        //------var ret = SubstitutionSolve(Cipher, C_Aplha);---//
                //Get Score of the return by calculating the English Ngram Frequencies in it
                var Sscore = GenericScoring.ngram_score.ScoreDouble(ret);
                //If the Score in above -120 (Average English Ngram Score for a 34 length Sentence), send to server
                if (Sscore > -280)
                    {
                        GoodCount++;
                        ADFGXserv.SetData(ret, C_Aplha, Convert.ToInt32(Sscore), ContributerName);
                    }
                //Log best score so far for UI log
                if (Sscore > BestScore)
                    {
                        BestScore = Sscore;
                        GlobalUpdateString = "Your Best Score So Far: " + Environment.NewLine + "Key: " + C_Aplha + Environment.NewLine + "Result: " + ret + Environment.NewLine + "Score: " + Sscore;
                    }
                    TotalCount++;
                }));
            }//Catch when user cancels the process by hitting the stop button.
            catch (OperationCanceledException ex)
            {
            }
            finally
            {
                cts.Dispose();
            }
        }

        /// <summary>
        /// The Timer Function responsible for updating Top Results and News data on the application from the server. (Enabled when application starts automatically)
        /// </summary>
        private void UpdateServerInfoTimer_Tick(object sender, EventArgs e)
        {
            //init's class to communicate with external server
            ADFGXService.ServiceClient ADFGXserv = new ADFGXService.ServiceClient();

            //Gets the News Information from Server and populates the News Textbox
            var retNews = ADFGXserv.GetNews();
            if (retNews.Contains("ERROR:"))
                this.newsText.Invoke(new MethodInvoker(delegate () { this.newsText.Text = "An error occured while attempting to contact server! Please contact TheRealDecrypterfixer@gmail.com to report the below error..." + Environment.NewLine + Environment.NewLine + retNews; }));
            else
                this.newsText.Invoke(new MethodInvoker(delegate () { this.newsText.Text = retNews; }));

            //Gets the Top20 results from Server and populates the Results Textbox
            var retTop = ADFGXserv.GetTop20();
            if (retTop.Contains("ERROR:"))
                this.resultsText.Invoke(new MethodInvoker(delegate () { this.resultsText.Text = "An error occured while attempting to contact server! Please contact TheRealDecrypterfixer@gmail.com to report the below error..." + Environment.NewLine + Environment.NewLine + retTop; }));
            else
                this.resultsText.Invoke(new MethodInvoker(delegate () { this.resultsText.Text = retTop; }));

            //Gets the Version information from Server and exits if the Version is incorrect
            retVer = ADFGXserv.GetVersion();
            if (retVer.Contains("ERROR:"))
            {
                MessageBox.Show("An error occured while attempting to check the version of the application with the server. This is commonly because of a lack of internet connection. This application needs the internet to run. If this error continues after being connected, please ensure you can view the site http://fascinatinginformation.com/ and contact TheRealDecrypterFixer@gmail.com" + Environment.NewLine + Environment.NewLine + retVer, "ADFGX Cloud Factoring App");
                Environment.Exit(0);
            }
            else if (retVer == "")
            {
                MessageBox.Show("An error occured while attempting to check the version of the application with the server. This is commonly because of a lack of internet connection. This application needs the internet to run. If this error continues after being connected, please ensure you can view the site http://fascinatinginformation.com/ and contact TheRealDecrypterFixer@gmail.com . Exiting application to avoid wasting resources.", "ADFGX Cloud Factoring App");
                Environment.Exit(0);
            }
            else
            {
                if (retVer != "3")
                {
                    cts.Cancel();
                    MessageBox.Show("A new version of the application has been released, thus running this version would be a waste. When exiting this messagebox the new version will be downloaded and ran.", "ADFGX Cloud Factoring App");
                    System.Net.WebClient myWebClient = new System.Net.WebClient();
                    myWebClient.DownloadFile("http://fascinatinginformation.com/ADFGX_Cloud_Solver.exe", "ADFGX_Cloud_Solver_" + retVer + ".exe");
                    System.Diagnostics.Process.Start("ADFGX_Cloud_Solver_" + retVer + ".exe");
                    Environment.Exit(0);
                }
            }

        }

        /// <summary>
        /// The Timer Function responsible for updating UI Log.
        /// </summary>
        private void UpdateLogTimer_Tick(object sender, EventArgs e)
        {
            this.LogText.Invoke(new MethodInvoker(delegate () { this.LogText.Text = GlobalUpdateString; }));
            this.statusStrip1.Invoke(new MethodInvoker(delegate () { this.GoodKeys.Text = GoodCount.ToString(); }));
            this.statusStrip1.Invoke(new MethodInvoker(delegate () { this.KeysTried.Text = TotalCount.ToString(); }));
        }

        /// <summary>
        /// The Click command for the Credits Label that is used to show the Credits and Thanks form.
        /// </summary>
        private void cmdCredit_Click(object sender, EventArgs e)
        {
            Credits Cwin = new Credits();
            Cwin.ShowDialog();
        }

        /// <summary>
        /// The Click command for the Start button that is used to start the Premutation Brute Forcing.
        /// </summary>
        private void cmdStart_Click(object sender, EventArgs e)
        {
            cts = new System.Threading.CancellationTokenSource();
            CPUperc = CPUlevel.Text;
            if (ContribText.Text == "UrRedditName")
                ContributerName = "N/A";
            else
                ContributerName = ContribText.Text;
            //Start the Main Brute Forcing Method
            BruteForceWorker.RunWorkerAsync();
            Pbar.Visible = true;
            UpdateLogTimer.Start();
            statuslbl.ForeColor = Color.LimeGreen;
            statuslbl.Text = "Working...";
        }
        /// <summary>
        /// The Click command for the Stop button that is used to stop the Premutation Brute Forcing.
        /// </summary>
        private void cmdQuit_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            statuslbl.ForeColor = Color.Red;
            statuslbl.Text = "STOPPING...";
            do
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
            } while (BruteForceWorker.IsBusy);
            Pbar.Visible = false;
            UpdateLogTimer.Stop();
            statuslbl.ForeColor = Color.Black;
            statuslbl.Text = "IDLE";
        }



        #region Helper Functions

        /// <summary>
        /// This function takes a Cipher Key and a Cipher Text and Deciphers with Substitution
        /// </summary>
        /// <param name="ciphertext">
        /// Parameter ciphertext requires an string argument containing a Substitution Cipher Text.
        /// </param>
        /// <param name="CTalphabet">
        /// Parameter CTalphabet requires a string argument containing the Alphabet Key.
        /// </param>
        /// <param name="alphabet">
        /// Parameter alphabet is an optional parameter, used to set the plain Alphabet.
        /// </param>
        /// <returns>
        /// The method returns a string containing the deciphered Substitution Cipher Text (Plain Text)
        /// </returns>
        public static string SubstitutionSolve(string ciphertext, string CTalphabet, string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ")
        {
            string lowerCT = ciphertext.ToLower();
            string lowerAlpha = CTalphabet.ToLower();
            StringBuilder plaintext = new StringBuilder();

            for (int i = 0; i < lowerCT.Length; ++i)
            {
                int index = lowerAlpha.IndexOf(lowerCT[i]);
                if (index < 0)
                {
                    plaintext.Append(lowerCT[i]);
                }
                else
                {
                    plaintext.Append(alphabet[index]);
                }
            }

            return plaintext.ToString();
        }

        /// <summary>
        /// This function simply proves a Infinite IEnumerable to make the later used Parallel Threading Loop Infinite.
        /// </summary>
        private static IEnumerable<bool> Infinite()
        {
            while (true)
            {
                yield return true;
            }
        }

        #endregion

    }

    /// <summary>
    /// A class containing custom extentions needed throughout the application
    /// </summary>
    public static class CustomExtensions
    {
        /// <summary>
        /// This Extention Function takes a string (Ex. ABCDEF..) and randomly shuffles it.
        /// </summary>
        public static string Shuffle(this string str)
        {
            char[] array = str.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }

        public static string Substitute(this string s, string newAlphabet, string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ")
        {
            char[] result = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                result[i] = newAlphabet[alphabet.IndexOf(s[i])];
            }
            return new string(result);
        }
    }
}
