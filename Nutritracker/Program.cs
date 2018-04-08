using System;
using System.Windows.Forms;

namespace Nutritracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
            //try { Application.Run(new frmMain()); }
            //catch (Exception e) { eReporter.catchEx(e, nameof(progBarWait), nameof(Main), null, true); }
        }
    }
}