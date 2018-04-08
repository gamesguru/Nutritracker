using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Nutritracker
{
    class eReporter
    {
        public static void catchEx(Exception e, string callingClass, string callingMethod, List<string> extraInfo = null, bool fatal = false)
        {
            List<string> output = new List<string>();
            output.Add($"##EXCEPTION in {callingClass} @ {DateTime.Now} v{FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion}");
            output.Add($"\t{callingMethod}:");
            output.Add($"\t{e}");
            if (extraInfo != null)
                output.AddRange(extraInfo);
            output.Add("");
            File.AppendAllLines($"{Application.StartupPath}{Path.DirectorySeparatorChar}exceptions.txt", output);
            if (fatal)
                MessageBox.Show($"A bug occured. We took a record of it in 'exceptions.txt'.  Application may now exit.\r\n{e.Message}\r\n\r\n{e.StackTrace}");
        }
    }
}