using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;

namespace ADFGX_Cloud_Solver_Android
{
    [Activity(Label = "Top Scores")]
    public class TopScoresActivity : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var type = Intent.Extras.GetString("adfgx_type") ?? "";
            if (type == "top")
            {
                this.Window.SetTitle("Top Scores");
                var progressDialog = ProgressDialog.Show(this, "Loading", "Please Wait...", true);
                new Thread(new ThreadStart(delegate
                {
                    com.fascinatinginformation.Service.Service ADFGXService = new com.fascinatinginformation.Service.Service();
                    var info = ADFGXService.GetTopAndroid();
                //LOAD METHOD TO GET ACCOUNT INFO
                RunOnUiThread(() => this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, info));
                //HIDE PROGRESS DIALOG
                RunOnUiThread(() => progressDialog.Hide());
                })).Start();
            }
            else if(type == "news")
            {
                this.Window.SetTitle("News");
                var progressDialog = ProgressDialog.Show(this, "Loading", "Please Wait...", true);
                new Thread(new ThreadStart(delegate
                {
                    com.fascinatinginformation.Service.Service ADFGXService = new com.fascinatinginformation.Service.Service();
                    var info = ADFGXService.GetNews();
                    var infonews = new string[] { info };
                    //LOAD METHOD TO GET ACCOUNT INFO
                    RunOnUiThread(() => this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, infonews));
                    //HIDE PROGRESS DIALOG
                    RunOnUiThread(() => progressDialog.Hide());
                })).Start();
            }
            else
            {
                var progressDialog = ProgressDialog.Show(this, "Loading", "Please Wait...", true);
                new Thread(new ThreadStart(delegate
                {
                    com.fascinatinginformation.Service.Service ADFGXService = new com.fascinatinginformation.Service.Service();
                    var info = ADFGXService.GetTopAndroid();
                    //LOAD METHOD TO GET ACCOUNT INFO
                    RunOnUiThread(() => this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, info));
                    //HIDE PROGRESS DIALOG
                    RunOnUiThread(() => progressDialog.Hide());
                })).Start();
            }
            
        }
    }
}