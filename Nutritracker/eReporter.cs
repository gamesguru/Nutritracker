using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Nutritracker
{
    class eReporter
    {
        public void catchEx(Exception e, string callingClass, string callingMethod, List<string> extraInfo = null)
        {
            List<string> output = new List<string>();
            output.Add($"##EXCEPTION in {callingClass} @ {DateTime.Now}");
            output.Add($"\t{callingMethod}:");
            output.Add($"\t{e}");
            if (extraInfo != null)
                output.AddRange(extraInfo);
            output.Add("");
            File.AppendAllLines($"{Application.StartupPath}{Path.DirectorySeparatorChar}exceptions.txt", output);
        }
    }
}
