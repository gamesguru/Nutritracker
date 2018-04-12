using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
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
            setup = false;
            if (tabControl1.SelectedIndex == 1)
            {
                timerAdbDevices.Enabled = true;
                adbSuspended = true;
            }
            else
            {
                timerAdbDevices.Enabled = false;
                adbSuspended = false;
            }
        }

        static string sl = Path.DirectorySeparatorChar.ToString();
        string adbLoc = $"{Application.StartupPath}{sl}lib{sl}android{sl}adb";

        void Log() => Log(" ");
        void Log(string line)
        {
            List<string> tmp = txtConsole.Lines.ToList();
            tmp.Add(line);
            string[] lines = tmp.ToArray();
            try
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    txtConsole.Lines = lines;
                    txtConsole.SelectionStart = txtConsole.TextLength;
                    txtConsole.ScrollToCaret();

                }));
            }
            catch { }
        }

        List<string> adb(string args, bool skipLogging = false, bool skipStdErr = true)
        {
            List<string> stdOUT = new List<string>();
            Process p = null;
            ProcessStartInfo s = new ProcessStartInfo(adbLoc);
            s.UseShellExecute = false;
            s.CreateNoWindow = true;
            s.RedirectStandardError = true;
            s.RedirectStandardOutput = true;
            if (!string.IsNullOrEmpty(device.serial))
                s.Arguments = $"-s {device.serial} {args}";
            else
                s.Arguments = args;
            s.WorkingDirectory = $"{Application.StartupPath}{sl}lib{sl}android";
            Log($"adb {args}");

            bool finished = false;
            Thread t = new Thread(() =>
            {
                this.UseWaitCursor = true;
                p = Process.Start(s);
                string line;
                if (!skipStdErr)
                    while ((line = p.StandardError.ReadLine()) != null)
                        Log($"ERROR: {line}");
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
                this.UseWaitCursor = false;
                finished = true;
            });
            if (!File.Exists(adbLoc))
            {
                Log($"ERROR: adb **NOT** found at '{adbLoc}'");
                return stdOUT;
            }
            t.Start();
            while (!finished)
                Application.DoEvents();
            try { p.Close(); }
            catch { }
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
        string nutriPkg = "com.nutri1.nutritracker";

        //private void btnAction_Click(object sender, EventArgs e)
        //{
        //btnAction.Enabled = false;
        //if (btnAction.Text == "Install Nutritracker")
        //{
        //    adb($"uninstall {nutriPkg}");
        //    adb($"install {nutriPkg}.apk", false, false);
        //    btnAction.Text = "Load Device";
        //}
        //else if (btnAction.Text == "Load Device")
        //{
        //    refresh();
        //}
        //btnAction.Enabled = true;
        //}

        //remove database: adb("shell rm -r /storage/emulated/0/Nutritracker")
        bool setup = false;
        void setUpDevice(string serial)
        {
            Top:
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
            if ((lines = adb($"shell dumpsys package {nutriPkg}", true)).Count < 5)
                device.nutriInstalled = false;
            else
            {
                device.nutriInstalled = true;
                for (int k = 0; k < lines.Count; k++)
                    if (lines[k].Trim().StartsWith("versionName="))        //versionName=2.4
                        device.version = lines[k].Trim().Replace("versionName=", "");
                    else if (lines[k].Trim().StartsWith("versionCode="))   //versionCode=502 targetSdk=23
                        device.build = lines[k].Trim().Split(' ')[0].Replace("versionCode=", "");                
            }
            device.__line_id = $"{device.manu} {device.model} ({device.firmware} -- {device.prodName}), Android version: {device.droidVer}";
            Log();
            Log("Your device:");
            Log($"\t{device.__line_id}");
            if (!device.nutriInstalled)
            {
                Log();
                device.__line_id = $"{device.manu} {device.model} ({device.droidVer}) nutritracker **NOT** installed";
                //Log(device.__line_id);
                if (MessageBox.Show("Nutritracker not installed on android phone.  Install it now?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Log("--> INSTALLING nutritracker-android");
                    adb($"uninstall {nutriPkg}");
                    adb($"install {nutriPkg}.apk", false, false);
                    goto Top;
                }
                else
                {
                    tabControl1.SelectedIndex = 0;
                    return;
                }
            }
            Log();
            Log($"\tnutritracker-android:  v{device.version} (build #{device.build})");
            Log();
            if (device.droidVer.StartsWith("6"))
            {
                Log("WARNING: on marshmallow (android version 6) you **MUST** go settings --> apps --> Nutritracker\r\n\t --> Permissions --> Enable device storage");
                //Log("Launching settings activity on your phone, please goto \"Apps\"");
                //adb ("shell am start com.android.settings/com.android.settings.Settings");
            }
            Log();
            List<string> localDump = adb("shell ls /storage/emulated/0/Nutritracker/usr/share/DBs");
            bool existingData = false;
            dbs = new List<string>();
            foreach (string s in localDump)
                if (!string.IsNullOrWhiteSpace(s))
                    foreach (string st in localDump)
                        if ($"{s}&" == st)
                        {
                            dbs.Add(st);
                            existingData = true;
                        }
            if (!existingData)
            {
                Log("INFO: no existing data on phone, preparing for first time use");
                if (MessageBox.Show("No data detected on phone, would you like to set it up for first-time use?  (This may take 5-10 minutes)", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                adb($"push {Application.StartupPath}{sl}usr /storage/emulated/0/Nutritracker/usr");
                adb($"shell mkdir /storage/emulated/0/Nutritracker/_db_upload_complete");
                Thread.Sleep(200);
            }
            //setup = true
            mergeDevice();
        }

        List<string> dbs;
        List<string> phoneQueue;
        List<string> compQueue;
        void mergeDevice()
        {
            Log("*** VERIFYING FOOD LOG ***");
            List<string> localDump = adb($"shell ls  /storage/emulated/0/Nutritracker/usr/profile{frmMain.currentUser.index}/log");
            List<string> phoneDates = new List<string>();
            foreach (string s in localDump)
                if (s.Contains("-") && s.EndsWith(".TXT") && !phoneDates.Contains(s))
                    phoneDates.Add(s);

            localDump = Directory.GetFiles($"{Application.StartupPath}{sl}usr{sl}profile{frmMain.currentUser.index}/log").ToList();
            List<string> compDates = new List<string>();
            foreach (string s in localDump)
            {
                string st = s.Split(Path.DirectorySeparatorChar)[s.Split(Path.DirectorySeparatorChar).Length- 1];
                if (st.Contains("-") && st.EndsWith(".TXT") && !compDates.Contains(st))
                    compDates.Add(st);
            }
            List<string> allDates = new List<string>();
            allDates.AddRange(phoneDates);
            foreach (string s in compDates)
                if (!allDates.Contains(s))
                    allDates.Add(s);

            phoneQueue = new List<string>();
            compQueue = new List<string>();
            foreach (string s in allDates.ToArray())
            {
                string[] compCat;
                List<string> tmp = new List<string>();
                if (phoneDates.Contains(s))
                    tmp = adb($"shell cat /storage/emulated/0/Nutritracker/usr/profile{frmMain.currentUser.index}/log/{s}", true);
                List<string> phoneCat = new List<string>();
                bool _new = false;
                bool _identical = true;
                if (!phoneDates.Contains(s))
                {
                    phoneQueue.Add(s);
                    _new = true;
                }
                if (!compDates.Contains(s))
                {
                    compQueue.Add(s);
                    _new = true;
                }
                if (!_new)
                {
                    foreach (string str in tmp)
                        if (!string.IsNullOrWhiteSpace(str))
                            phoneCat.Add(str);
                    compCat = File.ReadAllLines($"{Application.StartupPath}{sl}usr{sl}profile{frmMain.currentUser.index}/log/{s}");
                    if (phoneCat.Count == compCat.Length)
                        for (int i = 0; i < compCat.Length; i++)
                            if (phoneCat[i] != compCat[i])
                                _identical = false;
                    if (!_identical)
                        ; //merge date
                }
            }
        }

        private void timerAdbDevices_Tick(object sender, EventArgs e)
        {
            refresh();
        }

        void refresh()
        {
            if (String.IsNullOrEmpty(adbLoc))
            {
                Log($"DEBUG: adb doesn't exist at the specified location '/lib/android/adb'");
                //btnAction.Enabled = true;
                return;
            }
            if (!setup)
            {
                Log("*** CHECKING IN DEVICE ***");
                List<string> devQuery = adb("devices");
                List<string> serials = new List<string>();
                foreach (string s in devQuery)
                    if (s.Contains("\tdevice"))
                        serials.Add(s.Replace("\tdevice", ""));
                if (serials.Count > 1)
                {
                    Log("DEBUG: more than one device/emulator connection, can only deal with one at a time");
                    //btnAction.Enabled = true;
                    return;
                }
                else if (serials.Count == 0)
                {
                    Log("DEBUG: no devices detected");
                    //btnAction.Enabled = true;
                    return;
                }
                if (string.IsNullOrEmpty(device.serial) || device.serial == serials[0])
                {
                    timerAdbDevices.Enabled = false;
                    setUpDevice(serials[0]);
                }
                else if (serials[0] != device.serial)
                {
                    Log($"DEBUG: device '{device.serial}' disconnected, please restart");
                    setup = false;
                    timerAdbDevices.Enabled = true;
                }
            }
        }

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    if (chkLstBoxSyncDBs.SelectedItems.Count == 0)
        //    {
        //        MessageBox.Show("No databases selected...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    if (MessageBox.Show("Are you sure you want to remove these database(s) from your phone?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
        //    {
        //        Log("This will take a moment... please by patient");
        //        foreach (var v in chkLstBoxSyncDBs.CheckedItems)
        //        {
        //            adb($"shell rm -r /storage/emulated/0/Nutritracker/usr/share/DBs/{v}");
        //            adb($"shell rm -r \"/storage/emulated/0/Nutritracker/usr/share/DBs/{v}\\&\"");
        //            Log($"--> {v} removed!!");
        //        }
        //        refresh();
        //    }
        //}

        private void removeSystemDataFromPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?  This will remove system data (databases).  To remove user data (logs, profile data, and custom fields) please uninstall the app on your phone.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Log("This will take a moment... please be patient");
                adb($"shell rm -r /storage/emulated/0/Nutritracker");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemoveUserData_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveSystemData_Click(object sender, EventArgs e)
        {

        }

        private void btnCommit_Click(object sender, EventArgs e)
        {

        }
    }
}
