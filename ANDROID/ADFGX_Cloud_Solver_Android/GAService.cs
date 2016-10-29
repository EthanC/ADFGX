using System;
using Android.Content;
using Android.Gms.Analytics;
namespace ADFGX_Cloud_Solver_Android
{
    public class GAService : IGAService
    {
        //replace with your tracking id https://analytics.google.com/
        public string TrackingId = "UA-86486676-1";

        private static GoogleAnalytics GAInstance;
        private static Tracker GATracker;

        #region Instantiation ...
        private static GAService thisRef;
        public GAService()
        {
            // no code req'd
        }

        public static GAService GetGASInstance()
        {
            if (thisRef == null)
                // it's ok, we can call this constructor
                thisRef = new GAService();
            return thisRef;
        }
        #endregion

        public void Initialize_NativeGAS(Context AppContext = null)
        {
            GAInstance = GoogleAnalytics.GetInstance(AppContext.ApplicationContext);
            GAInstance.SetLocalDispatchPeriod(10);
            GATracker = GAInstance.NewTracker(TrackingId);
            GATracker.EnableExceptionReporting(true);
            //GATracker.EnableAdvertisingIdCollection(true);
            GATracker.EnableAutoActivityTracking(true);
        }

        public void Track_App_Page(String PageNameToTrack)
        {
            GATracker.SetScreenName(PageNameToTrack);
            GATracker.Send(new HitBuilders.ScreenViewBuilder().Build());
        }

        public void Track_App_Event(String GAEventCategory, String EventToTrack)
        {
            HitBuilders.EventBuilder builder = new HitBuilders.EventBuilder();
            builder.SetCategory(GAEventCategory);
            builder.SetAction(EventToTrack);
            builder.SetLabel("AppEvent");
            GATracker.Send(builder.Build());
        }

        public void Track_App_Exception(String ExceptionMessageToTrack, Boolean isFatalException)
        {
            HitBuilders.ExceptionBuilder builder = new HitBuilders.ExceptionBuilder();
            builder.SetDescription(ExceptionMessageToTrack);
            builder.SetFatal(isFatalException);
            GATracker.Send(builder.Build());
        }
    }

}