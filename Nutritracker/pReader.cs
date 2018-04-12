using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Nutritracker
{
    public class pReader
    {
        public static List<string> exc(string procName, string args = "")
        {
            List<string> output = new List<string>();
            ProcessStartInfo s = new ProcessStartInfo(procName);
            s.UseShellExecute = false;
            s.CreateNoWindow = true;
            s.RedirectStandardOutput = true;
            s.Arguments = args;
            Process p = Process.Start(s);
            string line;
            while ((line = p.StandardOutput.ReadLine()) != null)
                output.Add(line);
            return output;
        }
    }
}
