using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADFGX_Cloud_Solver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
		{
            if (!System.IO.File.Exists("ADFGX_Cloud_Solver.exe.config"))

			#if __MonoCS__
			//DO nothing
			#else
			if (!IsRunningOnMono())
            {
                if (Environment.OSVersion.Version.Major >= 6)
                    SetProcessDPIAware();
            }
			#endif

            System.IO.File.WriteAllText("ADFGX_Cloud_Solver.exe.config", Properties.Resources.ADFGX_Cloud_Solver_exe);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static bool IsRunningOnMono()
        {
            return Type.GetType("Mono.Runtime") != null;
        }

#if __MonoCS__
 //mono specific code

		//private static bool SetProcessDPIAware(){return true;}
#else
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
#endif

    }


}
