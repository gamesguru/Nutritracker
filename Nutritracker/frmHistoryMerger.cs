using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nutritracker
{
    public partial class frmHistoryMerger : Form
    {
        public frmHistoryMerger()
        {
            InitializeComponent();
        }
        string slash = Path.DirectorySeparatorChar.ToString();

        private void frmHistoryMerger_Load(object sender, EventArgs e)
        {
            comboMeal.SelectedIndex = frmMain.currentUser.lastMeal;
            if (sl == "\\")
                adbLoc += ".exe";
        }

        string _db = "";
        List<string> _dbPrimKeys;
        private void button2_Click(object sender, EventArgs e)
        {
            if (chkLstBoxDBs.CheckedItems.Count != 1)
            {
                MessageBox.Show("Error, can only select one database to add from!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _db = chkLstBoxDBs.CheckedItems[0].ToString();
            _dbPrimKeys = new List<string>();
            foreach (string s in File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}_db{slash}_entryKeyLang.ini"))
                _dbPrimKeys.Add(s.Split('|')[1]);
            if (!_dbPrimKeys.Contains(primKeyToAdd))
            {
                MessageBox.Show($"Error, primary key '{primKeyToAdd}' not found in {_db} dictionary.  Please select a real entry.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (chkLstBoxDays.CheckedItems.Count == 0)
            {
                MessageBox.Show($"Error, please select at least one day to add", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show($"This will add {primKeyToAdd} from database '{_db}' to {comboMeal.Text} for the {chkLstBoxDays.CheckedItems.Count} marked days.", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
        }

        string primKeyToAdd = "";
        private void txtPrimKeyToAdd_TextChanged(object sender, EventArgs e) => primKeyToAdd = txtPrimKeyToAdd.Text;

        bool adbSuspended = true;
        private void txtConsole_MouseDown(object sender, MouseEventArgs e)
        {
            adbSuspended = true;
        }

        private void txtConsole_MouseUp(object sender, MouseEventArgs e)
        {
            adbSuspended = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
                adbSuspended = true;
            else
                adbSuspended = false;
        }

        static string sl = Path.DirectorySeparatorChar.ToString();
        string adbLoc = $"{Application.StartupPath}{sl}usr{sl}share{sl}res{sl}android{sl}adb";

        //string serial = "";
        private void timerAdbDevices_Tick(object sender, EventArgs e)
        {
            if (adbSuspended)
                return;

        }

        void Log(string line)
        {
            List<string> tmp = txtConsole.Lines.ToList();
            tmp.Add(line);
            string[] lines = tmp.ToArray();
            this.Invoke(new MethodInvoker(delegate
            {
                txtConsole.Lines = lines;
                txtConsole.SelectionStart = txtConsole.TextLength;
                txtConsole.ScrollToCaret();
            }));
        }

        List<string> adb(string args, bool skipLogging = false, bool skipStdErr = true)
        {
            List<string> stdOUT = new List<string>();
            List<string> stdERR = new List<string>();
            Process p;
            ProcessStartInfo s = new ProcessStartInfo(adbLoc);
            s.UseShellExecute = false;
            s.CreateNoWindow = true;
            s.RedirectStandardError = true;
            s.RedirectStandardOutput = true;
            s.Arguments = args;
            s.WorkingDirectory = $"{Application.StartupPath}{sl}usr{sl}share{sl}res{sl}android";
            Log($"adb {args}");

            bool finished = false;
            Thread t = new Thread(() =>
            {
                this.UseWaitCursor = true;
                p = Process.Start(s);
                string line;
                if (!skipStdErr)
                    while ((line = p.StandardError.ReadLine()) != null)
                        stdERR.Add(line);
                line = null;
                int n = 0;
                while ((line = p.StandardOutput.ReadLine()) != null)
                {
                    if (!skipLogging)
                        if (line.StartsWith("[") && ++n % 50 == 0)
                            Log($"\t{line}");
                        else if (!line.StartsWith("["))
                            Log($"\t{line}");
                    stdOUT.Add(line);
                }
                if (!skipLogging)
                {
                    foreach (string st in stdERR)
                        Log($"ERROR: {st}");
                    //int n = 0;
                    //foreach (string st in stdOUT)
                        //if (st.StartsWith("[") && ++n % 50 == 0)
                        //    Log($"\t{st}");
                        //else if (!st.StartsWith("["))
                            //Log($"\t{st}");
                }
                this.UseWaitCursor = false;
                finished = true;
            });
            t.Start();
            while (!finished)
                Application.DoEvents();
            return stdOUT;
        }

        static class device
        {
            public static string serial;
            public static string manu;
            public static string model;
            public static string droidVer;
            public static string firmware;
            public static string prodName;
            public static bool nutriInstalled = true;
            public static string version;
            public static string build;
            public static string __line_id = "";
        }
        string nutriPkg = "com.one.nutri1.nutritracker";

        private void btnAction_Click(object sender, EventArgs e)
        {

            btnAction.Enabled = false;
            if (btnAction.Text == "Install Nutritracker")
            {
                adb($"uninstall {nutriPkg}");
                adb($"install {nutriPkg}.apk", false, false);
                btnAction.Text = "Load Device";
            }
            else if (btnAction.Text == "Load Device")
            {
                if (String.IsNullOrEmpty(adbLoc))
                {
                    Log($"ERROR: adb doesn't exist at the specified location '/usr/share/res/android/adb.exe'");
                    btnAction.Enabled = true;
                    return;
                }
                List<string> devQuery = adb("devices");
                List<string> serials = new List<string>();
                foreach (string s in devQuery)
                    if (s.Contains("\tdevice"))
                        serials.Add(s.Replace("\tdevice", ""));
                if (serials.Count > 1)
                {
                    Log("ERROR: more than one device/emulator connection, can only deal with one at a time");
                    btnAction.Enabled = true;
                    return;
                }
                else if (serials.Count == 0)
                {
                    Log("ERROR: no devices detected");
                    btnAction.Enabled = true;
                    return;
                }
                //else
                //    serial = serials[0];
                setUpDevice(serials[0]);
            }
            btnAction.Enabled = true;
        }

        void setUpDevice(string serial)
        {
            device.serial = serial;
            List<string> lines = adb("shell getprop", true);
            for (int k = 0; k < lines.Count; k++)
                if (lines[k].Contains("[ro.product.manufacturer]"))
                    device.manu = lines[k].Split(':')[1].Replace("[", "").Replace("]", "").Trim();
                else if (lines[k].Contains("[ro.build.version.release]"))
                    device.droidVer = lines[k].Split(':')[1].Replace("[", "").Replace("]", "").Trim();
                else if (lines[k].Contains("[ro.product.model]"))
                    device.model = lines[k].Split(':')[1].Replace("[", "").Replace("]", "").Trim();
                else if (lines[k].Contains("[ro.build.product]"))
                    device.prodName = lines[k].Split(':')[1].Replace("[", "").Replace("]", "").Trim();
                else if (lines[k].Contains("[ro.build.display.id]"))
                    device.firmware = lines[k].Split(':')[1].Replace("OCTP_7_", "").Replace("OCTP_5_", "").Replace("[", "").Replace("]", "").Trim();
            if (device.droidVer.Length == 3)
                device.droidVer += ".0";

            if ((lines = adb($"shell dumpsys package {nutriPkg}", true)).Count < 5)
                device.nutriInstalled = false;
            else
                for (int k = 0; k < lines.Count; k++)
                    if (lines[k].Trim().StartsWith("versionName="))        //versionName=2.4
                        device.version = lines[k].Trim().Replace("versionName=", "");
                    else if (lines[k].Trim().StartsWith("versionCode="))   //versionCode=502 targetSdk=23
                        device.build = lines[k].Trim().Split(' ')[0].Replace("versionCode=", "");
            device.__line_id = $"{device.manu} {device.model} ({device.firmware} -- {device.prodName}), Android version: {device.droidVer}";
            Log("");
            Log("Your device:");
            Log($"\t{device.__line_id}");
            if (!device.nutriInstalled)
            {
                Log("");
                device.__line_id = $"{device.manu} {device.model} ({device.droidVer}) nutritracker NOT installed";
                Log(device.__line_id);
                Log("--> INFO: Nutritracker not installed on your android device, press the button to install it now!");
                btnAction.Text = "Install Nutritracker";
                return;
            }
            Log("");
            Log($"\tnutritracker-android:\tv{device.version} (build #{device.build})");
            Log("");
            if (device.droidVer.StartsWith("6"))
                Log("WARNING: on marshmallow (android version 6) you **MUST** go settings --> apps --> Nutritracker --> Enable device storage");
            Log("");
            List<string> localDump = adb("shell ls /storage/emulated/0", true, true);
            bool existingData = false;
            foreach (string s in localDump)
                if (s == "Nutritracker")
                    existingData = true;
            if (!existingData)
            {
                Log("INFO: no existing data on phone, preparing for first time use");
                adb($"push {Application.StartupPath}{sl}usr /storage/emulated/0/Nutritracker/usr");
                adb($"mkdir /storage/emulated/0/Nutritracker/usr/_db_upload_complete");
            }
            Thread.Sleep(200);
            localDump = adb("shell ls /storage/emulated/0/Nutritracker/usr/share/DBs");
        }
    }
}