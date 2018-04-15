using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static Nutritracker.pReader;

namespace Nutritracker
{
    public partial class frmHistoryMerger : Form
    {
        public frmHistoryMerger()
        {
            InitializeComponent();
        }
        string sl = Path.DirectorySeparatorChar.ToString();
        string adbLoc = "";
        private void frmHistoryMerger_Load(object sender, EventArgs e)
        {
            if (frmMain.os == frmMain.OS.Windows)
                adbLoc = $"{Application.StartupPath}{sl}lib{sl}android{sl}win{sl}adb.exe";
            else if (frmMain.os == frmMain.OS.macOS)
                adbLoc = $"{Application.StartupPath}{sl}lib{sl}android{sl}mac{sl}adb";
            else
                adbLoc = $"{Application.StartupPath}{sl}lib{sl}android{sl}linux{sl}adb";

            tabControl1.SelectedIndex = 1;
            comboMeal.SelectedIndex = frmMain.currentUser.lastMeal;
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
            foreach (string s in File.ReadAllLines($"{Application.StartupPath}{sl}usr{sl}share{sl}DBs{sl}_db{sl}_entryKeyLang.ini"))
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


        private void txtConsole_MouseDown(object sender, MouseEventArgs e)
        {
            //adbSuspended = true;
        }

        private void txtConsole_MouseUp(object sender, MouseEventArgs e)
        {
            //adbSuspended = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setup = false;
            if (tabControl1.SelectedIndex == 1)
            {
                //adbSuspended = true;
            }
            else
            {
                //adbSuspended = false;
            }
        }


        string nutriPkg = "com.nutri1.nutritracker";

        public void Log() => Log(" ");
        public void Log(string line)
        {
            List<string> tmp = new List<string>();
            try { tmp = txtConsole.Lines.ToList(); }
            catch { }
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

        public static bool busy = false;
        public List<string> adb(string args, bool skipLogging = false, bool skipStdErr = true)
        {
            if (busy)
                return new List<string>();
            busy = true;
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
                finished = false;
                //this.UseWaitCursor = true;
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
                //this.UseWaitCursor = false;
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
            busy = false;
            return stdOUT;
        }

        public static class device
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

        private void btnExit_Click(object sender, EventArgs e) => this.Close();
        private void btnExit2_Click(object sender, EventArgs e) => this.Close();

        private void btnSetReminder_Click(object sender, EventArgs e)
        {
            setReminder sr = new setReminder();
            sr.ShowDialog();
        }

        private void btnRemoveData(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?  This will uninstall the app from you phone, and remove user data.  Next you will be asked if you wish to delete system data (databases) as well.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Log("This will take a moment... please be patient");
                adb($"shell uninstall {nutriPkg}");
            }

            if (MessageBox.Show("Do you wish to delete system data (databases)?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Log("This will take a moment... please be patient");
                adb("shell rm -r /storage/emulated/0/Nutritracker");
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            btnAction.Enabled = false;
            if (btnAction.Text == "Sync")
            {
                if (String.IsNullOrEmpty(adbLoc) || !File.Exists(adbLoc))
                {
                    Log($"DEBUG: adb doesn't exist at the specified location '{adbLoc}'");
                    btnAction.Enabled = true;
                    return;
                }
                if (!setup)
                {
                    Log("*** INITIALIZING ANDROID DEBUG BRIDGE ***");
                    List<string> devQuery = adb("devices");
                    List<string> serials = new List<string>();
                    foreach (string s in devQuery)
                        if (s.Contains("\tdevice"))
                            serials.Add(s.Replace("\tdevice", ""));
                    if (serials.Count > 1)
                    {
                        Log("DEBUG: more than one device/emulator connection, can only deal with one at a time");
                        btnAction.Enabled = true;
                        return;
                    }
                    else if (serials.Count == 0)
                    {
                        Log("DEBUG: no devices detected");
                        btnAction.Enabled = true;
                        return;
                    }
                    if (string.IsNullOrEmpty(device.serial) || device.serial == serials[0])
                    {
                        Log("*** CHECKING IN DEVICE ***");
                        setUpDevice(serials[0]);
                    }
                    else if (serials[0] != device.serial)
                    {
                        Log($"DEBUG: device '{device.serial}' disconnected, please restart");
                        serials.Clear();
                        setup = false;
                        btnAction.Enabled = true;
                    }
                }
            }
            else if (btnAction.Text == "Merge")
            {                
                if (txtCompCat.Lines.Count ()!= txtPhoneCat.Lines.Count())
                {
                    MessageBox.Show("Phone and computer entries must be identical.  Set a reminder to resolve this later.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnAction.Enabled = true;
                    return;
                }

                for (int i = 0; i < txtCompCat.Lines.Count(); i++)
                    if (txtPhoneCat.Lines[i] != txtCompCat.Lines[i])
                    {
                        MessageBox.Show($"Phone and computer entries must be identical.  Set a reminder to resolve this later.\n\nERROR: \"{txtCompCat.Lines[i]}\"", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnAction.Enabled = true;
                        return;
                    }

                bool _legal = true;
                string cur = "";
                try
                {
                    foreach (string s in txtCompCat.Lines)
                    {
                        cur = s;
                        string st = s;
                        if (s.StartsWith(">> "))
                            st = s.Remove(0, 3);
                        if (st != "--Breakfast--" && st != "--Lunch--" && st != "--Dinner--")
                        {
                            string[] splits = st.Split('|');
                            if (!dbs.Contains(splits[0]))
                            {
                                MessageBox.Show($"Line entries must conform to proper syntax. <db name>|<food id>|<grams>, or --<Meal name>--\n\nERROR: \"{cur}\"", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                _legal = false;
                                break;
                            }
                            int g = Convert.ToInt32(splits[1]);
                            g = Convert.ToInt32(splits[2]);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show($"Line entries must conform to proper syntax. <db name>|<food id>|<grams>, or --<Meal name>--\n\nERROR: \"{cur}\"", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _legal = false;
                }
                if (!_legal)
                {
                    btnAction.Enabled = true;
                    return;
                }
                txtCompCat.Text = txtCompCat.Text.Replace(">> ", "");
                txtPhoneCat.Text = txtPhoneCat.Text.Replace(">> ", "");
                //TODO: work here
                //File.WriteAllLines(txtCompCat.Lines)
                    //mergeNextobj?
            }
        }



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
                device.__line_id = $"{device.manu} {device.model} ({device.firmware} -- {device.prodName}), Android version: {device.droidVer}";
                //device.__line_id = $"{device.manu} {device.model} ({device.droidVer}) nutritracker **NOT** installed";
                //Log(device.__line_id);
                if (MessageBox.Show("Nutritracker not installed on android phone.  Install it now?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Log("--> INSTALLING nutritracker-android... one moment");
                    adb($"uninstall {nutriPkg}");
                    adb($"install {nutriPkg}.apk", false, false);
                    Log("\tINSTALLED!!");
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
                            dbs.Add(s);
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
            setup = true;
            mergeFoodLog();
        }

        List<string> dbs;
        List<string> phoneQueue;
        List<string> compQueue;
        void mergeFoodLog()
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
                string st = s.Split(Path.DirectorySeparatorChar)[s.Split(Path.DirectorySeparatorChar).Length - 1];
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
            mergeQueue = new List<mergeObj>();
            foreach (string s in allDates.ToArray())
            {
                string[] compCat;
                List<string> tmp = new List<string>();
                if (phoneDates.Contains(s))
                    tmp = adb($"shell cat /storage/emulated/0/Nutritracker/usr/profile{frmMain.currentUser.index}/log/{s}", true);
                List<string> phoneCat = new List<string>();
                bool _identical = true;
                if (!phoneDates.Contains(s))
                {
                    phoneQueue.Add(s);
                    continue;
                }
                if (!compDates.Contains(s))
                {
                    compQueue.Add(s);
                    continue;
                }
                foreach (string str in tmp)
                    if (!string.IsNullOrWhiteSpace(str))
                        phoneCat.Add(str);
                compCat = File.ReadAllLines($"{Application.StartupPath}{sl}usr{sl}profile{frmMain.currentUser.index}{sl}log{sl}{s}");
                if (phoneCat.Count == compCat.Length)
                {
                    for (int i = 0; i < compCat.Length; i++)
                        if (phoneCat[i] != compCat[i])
                        {
                            phoneCat[i] = $">> {phoneCat[i]}";
                            compCat[i] = $">> {compCat[i]}";
                            _identical = false;
                        }
                }
                else
                    _identical = false;
                if (!_identical)
                {
                    string compFullPath = $"{Application.StartupPath}{sl}usr{sl}profile{frmMain.currentUser.index}{sl}log{sl}{s}";
                    string phoneFullPath = $"/storage/emulated/0/Nutritracker/usr/profile{frmMain.currentUser.index}/log/{s}";
                    string file = compFullPath.Split(Path.DirectorySeparatorChar)[compFullPath.Split(Path.DirectorySeparatorChar).Length - 1];
                    Log($"--> Merge conflicts for '{file}'");
                    mergeQueue.Add(new mergeObj { _compFullPath = compFullPath, _phoneFullPath = phoneFullPath, _compCat = compCat.ToList(), _phoneCat = phoneCat });
                    //mergeFiles($"{Application.StartupPath}{sl}usr{sl}profile{frmMain.currentUser.index}{sl}log{sl}{s}", $"/storage/emulated/0/Nutritracker/usr/profile{frmMain.currentUser.index}/log/{s}", compCat.ToList(), phoneCat);
                }
            }
            if (mergeQueue.Count > 0)
            {
                string file = mergeQueue[0]._compFullPath.Split(Path.DirectorySeparatorChar)[mergeQueue[0]._compFullPath.Split(Path.DirectorySeparatorChar).Length - 1];
                btnAction.Text = "Merge";
                btnAction.Enabled = true;
                btnSetReminder.Enabled = true;
                lblStatus.Text = $"Merging {file}\n1 of {mergeQueue.Count}";
                txtCompCat.Lines = mergeQueue[0]._compCat.ToArray();
                txtPhoneCat.Lines = mergeQueue[0]._phoneCat.ToArray();
            }
            else
                ;//MergeFields();
        }

        public static List<mergeObj> mergeQueue;
        public class mergeObj
        {
            public string _compFullPath;
            public string _phoneFullPath;
            public List<string> _compCat = new List<string>();
            public List<string> _phoneCat = new List<string>();
        }
        //void mergeFiles(string compFullPath, string phoneFullPath, List<string> compCat, List<string> phoneCat)
        //{
        //    Log($"--> Merge conflicts for '{file}'");
        //    lblStatus.Text = $"Merging {file}";
        //    txtCompCat.Lines = compCat.ToArray();
        //    txtPhoneCat.Lines = phoneCat.ToArray();
        //}

        private void txtCommand_Enter(object sender, EventArgs e)
        {
            txtCommand.SelectAll();
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }
    }
}