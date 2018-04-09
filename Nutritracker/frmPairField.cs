using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Nutritracker
{
    public partial class frmPairField : Form
    {
        public frmPairField()
        {
            InitializeComponent();
        }

        static string slash;
        private void frmPairRelDB_Load(object sender, EventArgs e)
        {
            itmL = new itemListerDialog(this);
            slash = Path.DirectorySeparatorChar.ToString();
            usdaRoot = $"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}USDAstock";
            string[] dbs = Directory.GetDirectories($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}lib{slash}fields");
            foreach (string s in dbs)
            {
                string db = s.Split(Path.DirectorySeparatorChar)[s.Split(Path.DirectorySeparatorChar).Length - 1];
                if (!db.StartsWith("_"))
                    comboFields.Items.Add(db);
            }
            if (comboFields.Items.Count == 0)
            {
                MessageBox.Show("Please create some fields before using this form.");
                this.Close();
            }
            comboFields.SelectedIndex = 0;
        }

        //
        //database key structs
        //
        class dbi
        {
            public string file;
            public string header;
            public string unit = "";
        }
        class dbc
        {
            public string file;
            public string field;
            public string metric = "";
        }


        int n = 0;
        int _n = 0;
        List<dbi> dbInitKeys;
        List<dbc> dbConfigKeys;
        string usdaRoot = "";
        List<string> diskContents;
        itemListerDialog itmL;
        private void btnBegin_Click(object sender, EventArgs e)
        {
            if (btnBegin.Text == "Begin")
            {
                btnBegin.Visible = false;
                comboFields.Enabled = false;
                lblTweak.Visible = true;
                txtTweak.Visible = true;
                lblNum.Visible = true;
                numUpDownIndex.Visible = true;
                lblFieldVal.Visible = true;

                string[] usdaNutKeyPairLines = File.ReadAllLines($"{usdaRoot}{slash}_nutKeyPairs.TXT");
                foreach (string s in usdaNutKeyPairLines)
                    if (s.Split('|')[1] == "FoodName")
                        usdaDB.names = File.ReadAllLines($"{usdaRoot}{slash}{s.Split('|')[0]}");
                    else if (s.Split('|')[1] == "NDBNo")
                        usdaDB.ndbs = File.ReadAllLines($"{usdaRoot}{slash}{s.Split('|')[0]}");

                storLoc = $"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}_par_f{slash}{comboFields.Text}.TXT";
                txtTweak.Text = fobjs[_n].foodName;
                itmL.items = new List<string>();
                foreach (_diskEntry d in diskEntries)
                    if (d.fIndex == _n)
                        for (int i = 0; i < usdaDB.ndbs.Length; i++)
                            if (d.ndb == usdaDB.ndbs[i])
                                itmL.items.Add($"{d.ndb} -- {usdaDB.names[i]}");
                btnBegin.Text = $"List {itmL.items.Count} Pairs";
                btnBegin.Visible = true;
            }
            else if (itmL.items.Count > 0)
            {
                itmL = new itemListerDialog(this);
                itmL.items = new List<string>();
                foreach (_diskEntry d in diskEntries)
                    if (d.fIndex == _n)
                        for (int i = 0; i < usdaDB.ndbs.Length; i++)
                            if (d.ndb == usdaDB.ndbs[i])
                                itmL.items.Add($"{d.ndb} -- {usdaDB.names[i]}");
                itmL.Show();
            }
        }

        //
        //general classes
        //
        public static class usdaDB
        {
            public static string[] ndbs;
            public static string[] names;
            public static int[] wMatch;
            public static string[] joinedMatches;
        }

        private class _fObj
        {
            public int index; // among, say, the 34 foods in the field
            //public List<string> metricsToTrack;
            public string mainMetric;
            public string foodName;
            public string value;
        }
        List<_fObj> fobjs;

        private class _diskEntry
        {
            public string ndb;
            public string value;
            public int fIndex;
        }

        List<_diskEntry> diskEntries;
        private void writeDisk(List<_diskEntry> dEntries)
        {
            List<string> output = new List<string>();
            output.Add($"[Progress]{_n}");
            foreach (_diskEntry d in dEntries)
                output.Add($"{d.ndb}|{d.value}|{d.fIndex}");
            File.WriteAllLines(storLoc, output);
        }

        string _db = "";
        private void comboFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            //changes the field objects
            //loads other things behind the scenes
            //

            _db = this.Text;
            this.Text = $"Pair {_db} with USDA";
            string fieldRoot = $"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}lib{slash}{_db}{slash}";
            storLoc = $"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}lib{slash}_pairings{slash}{_db}.TXT";
            dbInitKeys = new List<dbi>();
            dbConfigKeys = new List<dbc>();
            string[] dbInitLines = File.ReadAllLines($"{fieldRoot}_dbInit.TXT");
            string[] dbConfigLines = File.ReadAllLines($"{fieldRoot}_dbConfig.TXT");
            string[] fieldInfo;
            try { fieldInfo = File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}lib{slash}_pairings{slash}{comboFields.Text}.TXT"); }
            catch { }

            foreach (string s in dbInitLines)
            {
                if (s.StartsWith("#") || string.IsNullOrWhiteSpace(s))
                    continue;
                string[] _params = s.Split(':');
                dbInitKeys.Add(new dbi { file = _params[0], header = _params[1], unit = _params[2] });
            }
            foreach (string s in dbConfigLines)
            {
                if (s.StartsWith("#") || string.IsNullOrWhiteSpace(s))
                    continue;
                string[] _params = s.Split(':');
                dbConfigKeys.Add(new dbc { file = _params[0], field = _params[1], metric = _params[2] });
            }

            //
            //loads in data for all field entries
            //
            fobjs = new List<_fObj>();
            foreach (dbc d in dbConfigKeys)
            {
                string[] names;
                string[] vals;
                if (d.field == "FoodName")
                {
                    names = File.ReadAllLines(fieldRoot + d.file);
                    n = names.Length;
                    foreach (dbc d2 in dbConfigKeys)
                        if (d2.field == "Value1")
                        {
                            vals = File.ReadAllLines(fieldRoot + d2.file);
                            for (int i = 0; i < names.Length; i++)
                            {
                                _fObj f = new _fObj { index = i, foodName = names[i], value = vals[i] };
                                //if (!string.IsNullOrEmpty(d.metric) && !f.metricsToTrack.Contains(d.metric))
                                    //f.metricsToTrack.Add(d.metric);
                                if (!string.IsNullOrEmpty(d.metric) && d.field == "Value1")
                                    f.mainMetric = d.metric;
                                fobjs.Add(f);
                            }
                        }
                }
            }

			_n = 0;
            try
            {
                diskContents = File.ReadAllLines(storLoc).ToList();

                foreach (string s in diskContents)
                    if (s.StartsWith("[Progress]"))
                    {
                        _n = Convert.ToInt32(s.Replace("[Progress]", ""));
                        break;
                    }

                diskEntries = new List<_diskEntry>();
                foreach (string s in diskContents)
                    if (!s.StartsWith("["))
                        diskEntries.Add(new _diskEntry { ndb = s.Split('|')[0], value = s.Split('|')[1], fIndex = Convert.ToInt32(s.Split('|')[2]) });
            }
            catch { }

            mH = true;
            numUpDownIndex.Minimum = 1;
            numUpDownIndex.Maximum = n;
            numUpDownIndex.Value = _n + 1;
            mH = false;
            groupBox1.Text = $"Possible Matches ({_n + 1} of {n}) — {fobjs[_n].foodName}";
            this.Text = $"Pair {n} items for {comboFields.Text} with USDA";
            foreach (_fObj f in fobjs)
                if (f.foodName == fobjs[_n].foodName)
                    lblFieldVal.Text = $"{f.mainMetric} value: {f.value}";
            mH = true;
            numUpDownIndex.Value = _n + 1;
            mH = false;
        }

        private void chkLstBoxUSDAresults_KeyDown(object sender, KeyEventArgs e)
        {
            //
            //triggers numUpDown++
            //            

            if (e.KeyCode == Keys.Return)
            {
               if (btnBegin.Enabled)
               {
                   MessageBox.Show("Please press begin!!");
                   return;
               }
                if (chkLstBoxUSDAresults.CheckedItems.Count == 0 && MessageBox.Show("Really skip this entry?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
               
               _n++;
               numUpDownIndex.Value = _n;
               txtTweak.Focus();
            }
        }

        string storLoc = "";
        bool mH = false;
        char[] _delims = { '/', ',', ' ', '-', ';', '(', ')' };
        private void txtTweak_TextChanged(object sender, EventArgs e)
        {
            //
            //refresh listview
            //search over fieldObjs
            //

            if (mH)
                return;
            _fObj f = fobjs[_n];
            chkLstBoxUSDAresults.Items.Clear();
            usdaDB.wMatch = new int[usdaDB.names.Length];
            usdaDB.joinedMatches = new string[usdaDB.names.Length];
            string[] words;

            if (txtTweak.TextLength < 4)
                return;
            else if (txtTweak.Text.Split(' ').Length < 2)
                words = new string[] { txtTweak.Text };
            else
                words = txtTweak.Text.Split(' '); //(_delims);

            foreach (string s in words)
                for (int i = 0; i < usdaDB.names.Length; i++)
                    if (s.Length > 2 && usdaDB.names[i].ToUpper()/*.Split(_delims)*/.Contains(s.ToUpper()))
                        usdaDB.wMatch[i]++; //usdaDB.joinedMatches[i] += s + ", ";                       


            int m = usdaDB.wMatch.Max();
            int q = 0;
            List<string> itms = new List<string>();
            for (int i = m; i > 0; i--)
                for (int j = 0; j < usdaDB.names.Length; j++)
                    if (usdaDB.wMatch[j] == i && ++q > 0)
                        itms.Add($"{usdaDB.ndbs[j]} -- {usdaDB.names[j]}"); // -- {usdaDB.wMatch[j]}"); //-({usdaDB.joinedMatches[j]})");                     

            n = fobjs.Count();
            groupBox1.Text = $"{q} Possible Matches ({_n + 1} of {n}) — {f.foodName}";
            lblFieldVal.Text = $"{f.mainMetric} value: {f.value}";

            chkLstBoxUSDAresults.BeginUpdate();
            for (int i = 0; i < itms.Count; i++)
            {
			chkLstBoxUSDAresults.Items.Add(itms[i]);
                foreach (_diskEntry d in diskEntries)
                    if (d.ndb == itms[i].Split(new string[] { " -- " }, StringSplitOptions.None)[0])
                        chkLstBoxUSDAresults.SetItemChecked(i, true);
            }
            chkLstBoxUSDAresults.EndUpdate();
        }


        private void numUpDownIndex_ValueChanged(object sender, EventArgs e)
        {
            //
            //refresh listview, groupbox, lblVal, and txtTweak
            //use numIndex and fieldObjs
            //
            if (mH)
                return;
            _n = Convert.ToInt32(numUpDownIndex.Value) - 1;
            _fObj f = fobjs[_n];
            lblFieldVal.Text = $"{f.mainMetric} value: {f.value}";
            int x = 0;
            foreach (_diskEntry d in diskEntries)
                if (d.fIndex == _n)
                    x++;
            btnBegin.Text = $"List {x} Pairs";
            txtTweak.Text = f.foodName;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void txtTweak_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                chkLstBoxUSDAresults.Focus();
            }
        }

        private void chkLstBoxUSDAresults_Leave(object sender, EventArgs eventArgs)
        {
            foreach (var c in chkLstBoxUSDAresults.CheckedItems)
            {
                bool dupe = false;
                foreach (_diskEntry d in diskEntries)
                    if (d.ndb == c.ToString().Split(new string[] { " -- " }, StringSplitOptions.None)[0])
                        dupe = true;
                if (!dupe)
                {
                    _diskEntry d = new _diskEntry();
                    d.ndb = c.ToString().Split(new string[] { " -- " }, StringSplitOptions.None)[0];
                    d.fIndex = _n;
                    d.value = fobjs[_n].value;
                    diskEntries.Add(d);
                }
            }

            for (int i = 0; i < diskEntries.Count; i++)
                for (int j = 0; j < chkLstBoxUSDAresults.Items.Count; j++)
                    try
                    {
                        if (diskEntries[i].ndb == chkLstBoxUSDAresults.Items[j].ToString().Split(new string[] { " -- " }, StringSplitOptions.None)[0] && !chkLstBoxUSDAresults.GetItemChecked(j))
                            diskEntries.RemoveAt(i);
                    }
                    catch { }
            writeDisk(diskEntries);
        }
    }
}