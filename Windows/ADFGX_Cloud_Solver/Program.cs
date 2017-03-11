using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADFGX_Cloud_Solver
{
    static class Program
    {
        public static ServiceClient GlobalClient;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!IsRunningOnMono())
            {
                if (Environment.OSVersion.Version.Major >= 6)
                    SetProcessDPIAware();
            }
            System.ServiceModel.BasicHttpBinding Globalbinding = new System.ServiceModel.BasicHttpBinding();
            System.ServiceModel.EndpointAddress Globaladdress = new System.ServiceModel.EndpointAddress("http://fascinatinginformation.com/ADFGXService/Service.svc");

            GlobalClient = new ServiceClient(Globalbinding, Globaladdress);

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string ip = "";
            string name = "";
            try { name = Form1.ContributerName; } catch { }
            try {name = Form1.ContributerName; } catch { }
            try { ip = GetIP(); } catch { }
            GlobalClient.SetLog("EXCEPTION", e.Exception.Message, e.Exception.InnerException + Environment.NewLine + Environment.NewLine + e.Exception.StackTrace, "PC", ip, name);
            MessageBox.Show("The application has experienced a fatal error. The telemetry in the application has sent the needed information to the server. We will get this fixed ASAP!" + Environment.NewLine + "ERROR:" + Environment.NewLine + e.Exception.Message, "Unhandled Thread Exception");
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs ee)
        {
            Exception e = (ee.ExceptionObject as Exception);
            string ip = "";
            string name = "";
            try { name = Form1.ContributerName; } catch { }
            try { ip = GetIP(); } catch { }
            GlobalClient.SetLog("EXCEPTION", e.Message, e.InnerException + Environment.NewLine + Environment.NewLine + e.StackTrace, "PC", ip, name);
            MessageBox.Show("The application has experienced a fatal error. The telemetry in the application has sent the needed information to the server. We will get this fixed ASAP!" + Environment.NewLine + "ERROR:" + Environment.NewLine + e.Message, "Unhandled UI Exception");
        }

        public static bool IsRunningOnMono()
        {
            return Type.GetType("Mono.Runtime") != null;
        }

        public static string GetIP()
        {
            return new System.Net.WebClient().DownloadString("http://bot.whatismyipaddress.com");
        }

#if __MonoCS__
 //mono specific code
#else
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
#endif

    }


}
