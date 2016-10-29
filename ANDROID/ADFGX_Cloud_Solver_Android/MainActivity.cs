using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;
using System.Threading.Tasks;

namespace ADFGX_Cloud_Solver_Android
{
    [Activity(Label = "ADFGX Cloud Solver", MainLauncher = true, Icon = "@drawable/icon", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class MainActivity : Activity
    {
        public static com.fascinatinginformation.Service.Service ADFGXService = new com.fascinatinginformation.Service.Service();
        public static System.Timers.Timer UpdateUITimer = new System.Timers.Timer();
        public static ProgressDialog loading;
        public static string Cipher = "IXSODNOIINXXSNRSNRNSRASOWXPOKXNSQL";
        public static string ContributerName = "N/A";
        public static string GlobalUpdateString = "";
        public static double BestScore = -99999;
        public static string retVer = "";
        public int TotalCount = 0;
        public int GoodCount = 0;
        public bool CancelToken = false;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            GAService.GetGASInstance().Initialize_NativeGAS(this);

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                Exception ee = (Exception)e.ExceptionObject;
                string ip = "";
                string name = "";
                try { name = ContributerName; } catch { }
                try { ip = GetIP(); } catch { }
                bool t1;
                bool t2;
                ADFGXService.SetLog("EXCEPTION", ee.Message, ee.InnerException + System.Environment.NewLine + System.Environment.NewLine + ee.StackTrace, "ANDROID", ip, name, out t1,out t2);
                ShowAlert("A fatal error occured. Info sent to server, we will fix this ASAP!" + ee.Message);
            };

            AndroidEnvironment.UnhandledExceptionRaiser += (s, e) =>
            {
                string ip = "";
                string name = "";
                try { name = ContributerName; } catch { }
                try { ip = GetIP(); } catch { }
                bool t1;
                bool t2;
                ADFGXService.SetLog("EXCEPTION", e.Exception.Message, e.Exception.InnerException + System.Environment.NewLine + System.Environment.NewLine + e.Exception.StackTrace, "ANDROID", ip, name, out t1, out t2);
                ShowAlert("A fatal error occured. Info sent to server, we will fix this ASAP!" + e.Exception.Message);
            };

            this.Title = "ADFGX Cloud Solver";
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            //Init our Update UI Timer
            UpdateUITimer.Interval = 5000;
            UpdateUITimer.Elapsed += UpdateUIEvent;
            //Set Button Event
            Button startbutton = FindViewById<Button>(Resource.Id.StartButton);
            startbutton.Click += delegate { BruteForceEvent(startbutton); };
            Button topscoresbutton = FindViewById<Button>(Resource.Id.TopScoresButton);
            topscoresbutton.Click += delegate { TopScoresEvent(); };
            Button newsbutton = FindViewById<Button>(Resource.Id.NewsButton);
            newsbutton.Click += delegate { NewsEvent(); };
            ProgressBar Pbar = FindViewById<ProgressBar>(Resource.Id.Pbar);
            Pbar.Visibility = ViewStates.Invisible;


        }

        private void TopScoresEvent()
        {
            try { 
            var intent = new Intent(this, typeof(TopScoresActivity));
            intent.PutExtra("adfgx_type", "top");
            StartActivity(intent);
            }
            catch (Exception ex)
            {
                string ip = "";
                string name = "";
                try { name = ContributerName; } catch { }
                try { ip = GetIP(); } catch { }
                bool t1;
                bool t2;
                ADFGXService.SetLog("ERROR", ex.Message, ex.InnerException + System.Environment.NewLine + System.Environment.NewLine + ex.StackTrace, "ANDROID", ip, name, out t1, out t2);
                ShowAlert("A error occured. Info sent to server, we will fix this ASAP!" + ex.Message);
            }
        }

        private void NewsEvent()
        {
            try { 
            var intent = new Intent(this, typeof(TopScoresActivity));
            intent.PutExtra("adfgx_type", "news");
            StartActivity(intent);
            }
            catch (Exception ex)
            {
                string ip = "";
                string name = "";
                try { name = ContributerName; } catch { }
                try { ip = GetIP(); } catch { }
                bool t1;
                bool t2;
                ADFGXService.SetLog("ERROR", ex.Message, ex.InnerException + System.Environment.NewLine + System.Environment.NewLine + ex.StackTrace, "ANDROID", ip, name, out t1, out t2);
                ShowAlert("A error occured. Info sent to server, we will fix this ASAP!" + ex.Message);
            }
        }
        public void ShowAlert(string str)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle(str);
            alert.SetPositiveButton("OK", (senderAlert, args) => {
                // write your own set of instructions
            });

            //run the alert in UI thread to display in the screen
            RunOnUiThread(() => {
                alert.Show();
            });
        }

        private async void BruteForceEvent(Button Sbutton)
        {
            try
            {
                if (Sbutton.Text.ToUpper() == "START")
                {
                    Sbutton.Text = "STOP";
                    EditText ContribText = FindViewById<EditText>(Resource.Id.NameText);
                    ProgressBar Pbar = FindViewById<ProgressBar>(Resource.Id.Pbar);
                    TextView statuslbl = FindViewById<TextView>(Resource.Id.StatusText);
                    CancelToken = false;
                    if (ContribText.Text == "UrRedditName")
                        ContributerName = "N/A";
                    else
                        ContributerName = ContribText.Text;

                    System.Threading.ThreadPool.QueueUserWorkItem(o => BruteForceWorker());

                    Pbar.Visibility = ViewStates.Visible;
                    UpdateUITimer.Enabled = true;
                    statuslbl.SetTextColor(Android.Graphics.Color.ParseColor("#3333ff"));
                    statuslbl.Text = "Loading Ngrams (May Take Some Time)...";

                }
                else
                {
                    Sbutton.Text = "START";
                    TextView statuslbl = FindViewById<TextView>(Resource.Id.StatusText);
                    CancelToken = true;

                    statuslbl.SetTextColor(Android.Graphics.Color.ParseColor("#ff3300"));
                    statuslbl.Text = "STOPPING...";
                    await Task.Delay(2000);

                    UpdateUITimer.Enabled = false;
                    ProgressBar Pbar = FindViewById<ProgressBar>(Resource.Id.Pbar);
                    TextView logtext = FindViewById<TextView>(Resource.Id.LogText);
                    TextView goodtext = FindViewById<TextView>(Resource.Id.GoodText);
                    TextView triedtext = FindViewById<TextView>(Resource.Id.TriedText);
                    Pbar.Visibility = ViewStates.Invisible;
                    statuslbl.SetTextColor(Android.Graphics.Color.ParseColor("#e6e6e6"));
                    statuslbl.Text = "IDLE";
                    logtext.Text = "No Logs to display...";
                    goodtext.Text = "0";
                    triedtext.Text = "0";
                    GoodCount = 0;
                    TotalCount = 0;
                    GlobalUpdateString = "";

                }
            }
            catch(Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void BruteForceWorker()
        {
            Cipher = ADFGXService.GetAndroidCipher();
            
            TextView statuslbl = FindViewById<TextView>(Resource.Id.StatusText);
            //Alphabet to start with when Brute Forcing
            string Alpha = new string(new[] { 'Z', 'O', 'M', 'B', 'I', 'E', 'F', 'G', 'H', 'K', 'L', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'A', 'C', 'D' });
            //Load Ngrams
            string tgrams = GetResourceString("english_trigrams.txt");
            string qgrams = GetResourceString("english_quadgrams.txt");
            GenericScoring.ngram_score.LoadNgarmDoubleFile(tgrams, qgrams);

            RunOnUiThread(() => statuslbl.SetTextColor(Android.Graphics.Color.ParseColor("#33cc33")));
            RunOnUiThread(() => statuslbl.Text = "Working...");

            //Start the Brute Forcing Loop
            try
            {
                do
                {
                    if (CancelToken == true)
                        break;
                    if (CancelToken == true)
                        throw new Exception();
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
                        try
                        {
                            ADFGXService.SetData(ret, C_Aplha, Convert.ToInt32(Sscore), true, ContributerName); //FIND A BETTER WAY!
                        }
                        catch (Exception)
                        {
                        }

                    }
                    //Log best score so far for UI log
                    if (Sscore > BestScore)
                    {
                        BestScore = Sscore;
                        GlobalUpdateString = "Your Best Score So Far: " + System.Environment.NewLine + "Key: " + C_Aplha + System.Environment.NewLine + "Result: " + ret + System.Environment.NewLine + "Score: " + Sscore;
                    }
                    TotalCount++;
                } while (true);
            }//Catch when user cancels the process by hitting the stop button.
            catch (Exception ex)
            {
            }


        }

        private void UpdateUIEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            TextView logtext = FindViewById<TextView>(Resource.Id.LogText);
            TextView goodtext = FindViewById<TextView>(Resource.Id.GoodText);
            TextView triedtext = FindViewById<TextView>(Resource.Id.TriedText);
            RunOnUiThread(() => logtext.Text = GlobalUpdateString);
            RunOnUiThread(() => goodtext.Text = GoodCount.ToString());
            RunOnUiThread(() => triedtext.Text = TotalCount.ToString());
        }

        private string GetResourceString(string ResourceName)
        {
            try
            {
                string content;
                Android.Content.Res.AssetManager assets = this.Assets;
                using (System.IO.StreamReader sr = new System.IO.StreamReader(assets.Open(ResourceName)))
                {
                    content = sr.ReadToEnd();
                }
                return content;
            }
            catch
            {
                throw new Exception("Could not read Resource file!");
            }
        }

        public static string GetIP()
        {
            return new System.Net.WebClient().DownloadString("http://bot.whatismyipaddress.com");
        }

        /// <summary>
        /// This function simply proves a Infinite IEnumerable to make the later used Parallel Threading Loop Infinite.
        /// </summary>
        private static System.Collections.Generic.IEnumerable<bool> Infinite()
        {
            while (true)
            {
                yield return true;
            }
        }
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

    public interface IGAService
    {
        void Track_App_Page(String PageNameToTrack);
        void Track_App_Event(String GAEventCategory, String EventToTrack);

        void Track_App_Exception(String ExceptionMessageToTrack, Boolean isFatalException);
    }
}

