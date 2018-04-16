using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Nutritracker
{
    public partial class frmSearchFoods : Form
    {
        public frmSearchFoods()
        {
            InitializeComponent();
        }
        public string[] substrings(string s, int n)
        {
            string[] sr = new string[s.Length - n + 1];
            for (int i = 0; i < s.Length - n + 1; i++)
                sr[i] = s.Substring(i, n).ToLower();
            return sr;
        }

        public static void loadDB(string db, Form callingForm)
        {
            foreach (DB d in loadedDBs)
                if (d.name == db)
                    return;
            DB dB = new DB();
            dB.name = db;
            dB.fields = new List<string>();
            dB.columns = new List<string>();
            foreach (string s in File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}{db}{slash}_fieldInit.ini"))
                if (frmMain.currentBasicFields.Contains(s.Split('=')[1]))
                {
                    string f = s.Split('=')[1];
                    dB.fields.Add(f);
                    if (s.Split('=')[0].Contains("(") && s.Split('=')[0].Contains(")"))
                        dB.columns.Add($"{f} ({s.Split('(')[1].Split(')')[0]})");
                    else
                        dB.columns.Add(f);
                }
            string[] rawEntryKeyLang = File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}{db}{slash}_entryKeyLang.ini");
            dB.hashLang.fileNames = new List<string>();
            dB.hashLang.primKeys = new List<string>();
            dB.hashLang.foodNames = new List<string>();
            dB.hashLang.fileEntries = new List<string[]>();
            foreach (string s in rawEntryKeyLang)
            {
                dB.hashLang.fileNames.Add((s.Split('|')[0]));
                dB.hashLang.primKeys.Add((s.Split('|')[1]));
                dB.hashLang.foodNames.Add((s.Split('|')[2].ToUpper()));
            }
            dB.numOfEntries = rawEntryKeyLang.Length;
            rawEntryKeyLang = null;

            pbw = new progBarWait();

            Thread t = new Thread(() =>
            {
                pbw.ShowDialog();
                pbw.finished = true;
            });
            t.Start();
            while (!pbw.ready && !pbw.abort)
                Thread.Sleep(60);
            pbw.setTitle($"Reading in {db}...");
            pbw.setProgMax(dB.hashLang.foodNames.Count, 50);
            for (int i = 0; i < dB.hashLang.fileNames.Count; i++)
            {
                if (pbw.abort)
                    break;
                dB.hashLang.fileEntries.Add(File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}{db}{slash}{dB.hashLang.fileNames[i]}.TXT"));
                pbw.setLblCurObj(dB.hashLang.foodNames[i]);
            }
            if (!pbw.abort)
                loadedDBs.Add(dB);
            callingForm.Activate();
        }

        public static int searchWarnLimit = 400;
        string[] pubDBs;
        static string slash = Path.DirectorySeparatorChar.ToString();

        private void frmSearchFoods_Load(object sender, EventArgs e)
        {
            this.Text = $"Search and Add Foods to Log — [{frmMain.dte}]";
            try { comboMeal.SelectedIndex = frmMain.currentUser.lastMeal; }
            catch { }

            pubDBs = Directory.GetDirectories($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs");

            if (pubDBs.Length == 0)
            {
                MessageBox.Show("No databases found, try going to the spreadsheet wizard or reinstalling the program.");
                this.Close();
            }
            for (int i = 0; i < pubDBs.Length; i++)
            {
                pubDBs[i] = pubDBs[i].Replace($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}", "");
                if (!pubDBs[i].StartsWith("_") && !pubDBs[i].EndsWith("&"))
                    comboDBs.Items.Add(pubDBs[i]);
            }

            if (comboDBs.Items.Count > 0)
                comboDBs.SelectedIndex = frmMain.currentUser.lastDB;
            //int index = Convert.ToInt32(File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}Default.TXT")[0]);
            //comboDBs.SelectedIndex = index;
        }

        public static List<DB> loadedDBs = new List<DB>();
        public class DB
        {
            public string name;
            public List<string> fields;
            public List<string> columns;
            public int numOfEntries;
            public _hashLang hashLang = new _hashLang();
        }
        public class _hashLang
        {
            public List<string> fileNames;
            public List<string> primKeys;
            public List<string> foodNames;
            public List<string[]> fileEntries;
            public int[] wCount;
        }

        DB currentDB;
        string db;
        static progBarWait pbw;
        private void comboDBs_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmMain.currentUser.lastDB = comboDBs.SelectedIndex;
            db = comboDBs.Text;
            lstviewFoods.Clear();
            txtSrch.Clear();
            richTxtWarn.Text = "";
            //warning = true;
            foreach (DB d in loadedDBs)
                if (d.name == comboDBs.Text)
                    currentDB = d;
            //if (currentDB == null)
            foreach (string s in pubDBs)
                if (s == db)
                {
                    loadDB(db, this);
                    foreach (DB d in loadedDBs)
                        if (d.name == db)
                            currentDB = d;
                }
            if (currentDB == null)
                return;
            txtSrch.Enabled = true;

            foreach (string s in currentDB.columns)
                lstviewFoods.Columns.Add(s);
            for (int i = 0; i < lstviewFoods.Columns.Count; i++)
                lstviewFoods.Columns[i].Width = -2;

            if (currentDB.numOfEntries > searchWarnLimit)
            {
                richTxtWarn.Text = $"There are more than {searchWarnLimit} entries.\nPress enter to turn something up.";
                return;
            }

            itms = new List<ListViewItem>();
            for (int i = 0; i < currentDB.hashLang.fileNames.Count; i++)
            {
                itms.Add(getListItem(currentDB.hashLang.fileEntries[i]));
                _itm = null;
            }

            lstviewFoods.BeginUpdate();
            foreach (ListViewItem itm in itms)
                lstviewFoods.Items.Add(itm);
            lstviewFoods.EndUpdate();
            itms = null;
        }

        ListViewItem _itm;
        ListViewItem getListItem(string[] dbEntry)
        {
            //TODO: verify it loads foodname first? insert into needed places
            _itm = new ListViewItem();
            //TODO: for (int i) loop?  1-1 correspondence of fields to dbEntries?
            foreach (string s in dbEntry)
                if (currentDB.fields.Contains(s.Split(':')[0]))
                    if (s.StartsWith("FoodName:"))
                        _itm.Text = s.Split(':')[1];
                    else
                        _itm.SubItems.Add(s.Split(':')[1]);
            return _itm;
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void frmSearchFoods_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.profileWriter(frmMain.currentUser);

            //hashLang.fileNames = null;
            //hashLang.fileEntries = null;
            //hashLang.wCount = null;
            try { lstviewFoods.Dispose(); }
            catch { }
            lstviewFoods = null;
            bw = null;
        }

        private void txtSrch_TextChanged(object sender, EventArgs e)
        {
            srchTmout.Stop();
            srchTmout.Start();
            setWarningTextbox();
        }

        public void setWarningTextbox(string text = "")
        {
            if (richTxtWarn.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate { richTxtWarn.Text = text; }));
            else
                richTxtWarn.Text = text;
        }

        string lastQuery = "";
        BackgroundWorker bw = new BackgroundWorker();
        List<ListViewItem> itms;
        private void srchTmout_Tick(object sender, EventArgs e)
        {
            if (txtSrch.Text.Trim() == lastQuery)
                return;
            bw.WorkerSupportsCancellation = true;
            bw.CancelAsync();
            bw = new BackgroundWorker();

            bw.DoWork += delegate
            {
                search();
                //try { search(); }
                //catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            };
            try
            {
                bw.RunWorkerAsync();
                lastQuery = txtSrch.Text.Trim();
            }
            catch { }
            this.UseWaitCursor = false;
        }

        int n, q, z;
        private void search()
        {
            this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = true; }));
            string input = txtSrch.Text.ToUpper().Trim();
            if (input.Length < 2)
            {
                setWarningTextbox("Query too short...");
                this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = false; }));
                return;
            }
            warning = false;
            string[] words = input.Split(new char[] { ' ', ',', '/' });
            n = words.Length;
            currentDB.hashLang.wCount = new int[currentDB.hashLang.foodNames.Count];
            //MessageBox.Show(words.Length.ToString());
            lstviewFoods.Invoke(new MethodInvoker(delegate { lstviewFoods.Items.Clear(); }));
            for (int k = 0; k < n; k++)
                for (int i = 0; i < currentDB.hashLang.foodNames.Count; i++)
                    if (words[k].Length > 2 && currentDB.hashLang.foodNames[i].StartsWith(words[k]))
                        currentDB.hashLang.wCount[i] += Convert.ToInt32(1.5 * words[k].Length);
                    else if (words[k].Length > 2 && currentDB.hashLang.foodNames[i].Contains(words[k]))
                        currentDB.hashLang.wCount[i] += Convert.ToInt32(words[k].Length);

            //MessageBox.Show(n.ToString());
            //MessageBox.Show(words[n]);

            q = currentDB.hashLang.wCount.Max();
            //MessageBox.Show(q.ToString());
            if (q == 0)
            {
                setWarningTextbox("No matches found :(");
                this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = false; }));
                return;
            }
            z = 0;
            itms = new List<ListViewItem>();
            for (int i = q; i > (q == 1 ? 0 : q - 1); i--)
                for (int k = 0; k < currentDB.hashLang.foodNames.Count; k++)
                    if (currentDB.hashLang.wCount[k] == i)
                        itms.Add(getListItem(currentDB.hashLang.fileEntries[k]));
            _itm = null;
            z = itms.Count;
            if (z > 600 && !warn(z))
            {
                warning = true;
                this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = false; }));
                return;
            }

            lstviewFoods.Invoke(new MethodInvoker(delegate
            {
                lstviewFoods.BeginUpdate();
                foreach (ListViewItem itm in itms)
                    lstviewFoods.Items.Add(itm);
                lstviewFoods.EndUpdate();
                itms = null;
            }));
            for (int i = 0; i < lstviewFoods.Columns.Count; i++)
                if (lstviewFoods.Columns[i].Text == "FoodName")
                    lstviewFoods.Invoke(new MethodInvoker(delegate { lstviewFoods.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent); }));

            setWarningTextbox($"Finished — {z} results");
            this.Invoke(new MethodInvoker(delegate
            {
                //TODO: make settings for enter to tab to listviewfoods, w/ searchWarnTimeout
                //lstviewFoods.Focus();
                try
                {
                    //lstviewFoods.Items[0].Focused = true;
                    //lstviewFoods.Items[0].Selected = true;
                }
                catch { }
                this.UseWaitCursor = false;
            }));
        }

        private bool warn(int n2)
        {
            this.Invoke(new MethodInvoker(delegate { richTxtWarn.Text = $"Search for {n2} foods? It may go slow\nPress enter to continue.."; }));
            return false;
        }

        bool warning = false;
        private void txtSrch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && warning)
                if (warning)
                {
                    e.Handled = true;
                    ignoreWarn();
                }
                else
                {
                    this.Invoke(new MethodInvoker(delegate
                    {

                        lstviewFoods.Focus();
                        try
                        {
                            lstviewFoods.Items[0].Focused = true;
                            lstviewFoods.Items[0].Selected = true;
                        }
                        catch { }
                    }));
                }
        }

        private void richTxtWarn_MouseClick(object sender, MouseEventArgs e)
        {
            if (warning)
                ignoreWarn();
        }

        private void ignoreWarn()
        {
            //if (!richTxtWarn.Enabled)
            //return;
            richTxtWarn.Text = "searching...";
            lstviewFoods.Items.Clear();
            bw = new BackgroundWorker();
            bw.DoWork += delegate
            {
                this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = true; }));

                //TODO: populate itms
                lstviewFoods.Invoke(new MethodInvoker(delegate
                {
                    lstviewFoods.BeginUpdate();
                    foreach (ListViewItem itm in itms)
                        lstviewFoods.Items.Add(itm);
                    lstviewFoods.EndUpdate();
                    _itm = null;
                    itms = null;
                }));
                for (int i = 0; i < lstviewFoods.Columns.Count; i++)
                    if (lstviewFoods.Columns[i].Text == "FoodName")
                        lstviewFoods.Invoke(new MethodInvoker(delegate { lstviewFoods.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent); }));

                warning = false;
                this.Invoke(new MethodInvoker(delegate
                {
                    richTxtWarn.Text = "Finished!";
                    lstviewFoods.Focus();
                    try
                    {
                        lstviewFoods.Items[0].Focused = true;
                        lstviewFoods.Items[0].Selected = true;
                    }//lstviewFoods.SelectedIndices.Add(0); }
                    catch { }
                }));
                this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = false; }));
            };
            bw.RunWorkerAsync();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            try { grams = Convert.ToDouble(txtQty.Text); }
            catch
            { grams = 0; }
            selectCheck();
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && btnAdd.Enabled)
                btnAdd.PerformClick();
        }

        private void comboMeal_SelectedIndexChanged(object sender, EventArgs e)
        { frmMain.currentUser.lastMeal = comboMeal.SelectedIndex; }

        string ndbno = "";
        double grams = 0.0;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //TODO: make work again
            //db = comboDBs.Text.Split(' ')[0];
            grams = 0;
            try { grams = Convert.ToDouble(txtQty.Text); }
            catch
            {
                MessageBox.Show("Not a valid weight.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (lstviewFoods.SelectedItems.Count == 0)
            {
                MessageBox.Show("No food selected.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (grams == 0.0)
            {
                MessageBox.Show("Weight cannot be zero.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            ndbno = lstviewFoods.SelectedItems[0].SubItems[0].Text;
            string todaysLog = "";
            string[] bLogLines = new string[0], lLogLines = new string[0], dLogLines = new string[0];
            try
            {
                todaysLog = File.ReadAllText($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}log{slash}{frmMain.dte}.TXT").Replace("\r", "");
                bLogLines = todaysLog.Split(new string[] { "--Breakfast--" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new string[] { "--Lunch--" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                lLogLines = todaysLog.Split(new string[] { "--Lunch--" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "--Dinner--" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                dLogLines = todaysLog.Split(new string[] { "--Dinner--" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch //(Exception ex)
            { //MessageBox.Show(ex.ToString()); }

                List<string> output = new List<string>();
                output.Add("--Breakfast--");
                output.AddRange(bLogLines);
                if (comboMeal.SelectedIndex == 0)
                    output.Add($"{currentDB.name}|{ndbno}|{grams}");
                output.Add("--Lunch--");
                output.AddRange(lLogLines);
                if (comboMeal.SelectedIndex == 1)
                    output.Add($"{currentDB.name}|{ndbno}|{grams}");
                output.Add("--Dinner--");
                output.AddRange(dLogLines);
                if (comboMeal.SelectedIndex == 2)
                    output.Add($"{currentDB.name}|{ndbno}|{grams}");
                File.WriteAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}log{slash}{frmMain.dte}.TXT", output);
                this.Close();
            }
        }

        class dLogObj
        {
            //public string date;
            public List<string> bEntries = new List<string>();
            public List<string> lEntries = new List<string>();
            public List<string> dEntries = new List<string>();
        }
        private void lstviewFoods_Leave(object sender, EventArgs e)
        {
            try { ndbno = lstviewFoods.SelectedItems[0].SubItems[0].Text; }
            catch { }
            selectCheck();
        }

        private void selectCheck()
        {
            if (currentDB.name != "" && ndbno != "" && grams > 0)
                btnAdd.Enabled = true;
            else
                btnAdd.Enabled = false;
        }

        private void lstviewFoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ndbno = lstviewFoods.SelectedItems[0].SubItems[0].Text;
                lblCurrentFood.Text = "Selected food: " + ndbno;//lblCurrentFood.Text = "Selected food: " + lstviewFoods.SelectedItems[0].SubItems[1].Text.Substring(0, Math.Min(30, lstviewFoods.SelectedItems[0].SubItems[1].Text.Length));
            }
            catch { }
        }

        private void historyManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistoryMerger frmHM = new frmHistoryMerger();
            frmHM.ShowDialog();
            frmHM = null;
        }

        private void lstviewFoods_KeyDown(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Return) txtQty.Focus(); }

        private void lstviewFoods_MouseUp(object sender, MouseEventArgs e)
        { txtQty.Focus(); }
    }
}