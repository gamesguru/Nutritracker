using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Nutritracker
{
    public partial class frmPairRelDB : Form
    {
        public frmPairRelDB()
        {
            InitializeComponent();
        }

        static string slash;
        private void frmPairRelDB_Load(object sender, EventArgs e)
        {
            slash = Path.DirectorySeparatorChar.ToString();
            usdaRoot = $"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}USDAstock";
            string[] dbs = Directory.GetDirectories($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs");
            foreach (string s in dbs)
                if (s.Contains("f_user_"))
                    comboFields.Items.Add(s.Split(new string[] { $"{slash}f_user_" }, StringSplitOptions.None)[1]);
            if (comboFields.Items.Count == 0)
            {
                MessageBox.Show("Please create some fields before using this form.");
                this.Close();
            }
            comboFields.SelectedIndex = 0;
        }

        class dbi
        {
            public string file;
            public string header;
            public string unit;
        }
        class dbc
        {
            public string file;
            public string field;
            public string metric;
        }
        int n = 0;
        int _n = 0;
        List<dbi> dbInitKeys;
        List<dbc> dbConfigKeys;
        string usdaRoot = "";
        List<string> diskContents;

        private void btnBegin_Click(object sender, EventArgs e)
        {
            btnBegin.Enabled = false;
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
        }

        private class _fObj
        {
			public int index; // among, say, the 34 foods in the field
            //public List<string> metricsToTrack;
            public string mainMetric;
            public string foodName;
			public string value;
			public List<string> ndbnos = new List<string>();
        }
        List<_fObj> fobjs;

        public static class usdaDB
        {
            public static string[] ndbs;
            public static string[] names;
            public static int[] wMatch;
            public static string[] joinedMatches;
        }

        private class _diskEntry
        {
            public string ndb;
            public string value;
            public int fIndex;
        }

        List<_diskEntry> diskEntries;

        //private class fObj
        //{
        //    public int index = 0;
        //    //public string name;
        //    public string value;
        //    public string[] ndbnos;
        //}
        //private class vObj
        //{
        //    public string val;
        //    public string name;
        //    public int index;
        //}
        //List<string> metricsToTrack;
        //_fObj[] fieldObjs = new _fObj[0];
        private void comboFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = $"Pair {comboFields.Text} with USDA";
            string fieldRoot = $"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}f_user_{comboFields.Text}{slash}";
            storLoc = $"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}_par_f{slash}{comboFields.Text}.TXT";
            dbInitKeys = new List<dbi>();
            dbConfigKeys = new List<dbc>();
            string[] dbInitItems = File.ReadAllText(fieldRoot + "_dbInit.TXT").Split(new string[] { "[File]" }, StringSplitOptions.None);
            string[] dbConfigItems = File.ReadAllText(fieldRoot + "_dbConfig.TXT").Split(new string[] { "[File]" }, StringSplitOptions.None);
            string[] fieldInfo = new string[0];
            try { fieldInfo = File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}_par_f{slash}{comboFields.Text}.TXT"); }
            catch{}

            foreach (string s in dbInitItems)
            {
                dbi d = new dbi();
                string[] lines = s.Replace("\r", "").Split('\n');
                d.file = lines[0];
                foreach (string st in lines)
                    if (st.StartsWith("[Header]"))
                        d.header = st.Replace("[Header]", "");
                    else if (st.StartsWith("[Unit]"))
                        d.unit = st.Replace("[Unit]", "");
                dbInitKeys.Add(d);
            }
            foreach (string s in dbConfigItems)
            {
                dbc d = new dbc();
                string[] lines = s.Replace("\r", "").Split('\n');
                d.file = lines[0];
                foreach (string st in lines)
                    if (st.StartsWith("[Field]"))
                        d.field = st.Replace("[Field]", "");
                    else if (st.StartsWith("[MetricName]"))
                        d.metric = st.Replace("[MetricName]", "");
                dbConfigKeys.Add(d);
            }

            //loads in data for all field entries
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
                                _fObj f = new _fObj();
                                f.index = i;
                                f.foodName = names[i];
                                f.value = vals[i];
                                foreach (string s in fieldInfo)
                                    try
                                    {
                                        if (Convert.ToInt32(s.Split('|')[2]) == f.index && !f.ndbnos.Contains(s.Split('|')[1]))
                                            f.ndbnos.Add(s.Split('|')[1]);
                                    }
                                    catch { }
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
            try { 
                diskContents = File.ReadAllLines(storLoc).ToList();

				foreach (string s in diskContents)
					if (s.StartsWith("[Progress]"))
						_n = Convert.ToInt32(s.Replace("[Progress]", ""));
                
                diskEntries = new List<_diskEntry>();
                foreach (string s in diskContents){
                    if (s.StartsWith("[Pair]"))
                    {
                        string st = s.Replace("[Pair]");
                        _diskEntry d = new _diskEntry();
                        d.ndb = st.Split('|')[0];
                        d.value = Convert.ToInt32(st.Split('|')[1]);
                        d.fIndex = Convert.ToInt32(st.Split('|')[2]);
                        diskEntries.Add(d);
                    }
                }
            }
            catch{}

            mH = true;
            numUpDownIndex.Minimum = 1;
            numUpDownIndex.Maximum = n;
            numUpDownIndex.Value = _n + 1;
            mH = false;
            groupBox1.Text = $"Possible Matches ({_n + 1} of {n})  — {fobjs[_n].foodName}";
            this.Text = $"Pair {n} items for {comboFields.Text} with USDA";
            foreach (_fObj f in fobjs)
                if (f.foodName == fobjs[_n].foodName)
                    lblFieldVal.Text = $"{f.mainMetric} value: {f.value}";


            for (int i = 0; i < fobjs.Count; i++)
            {
                List<string> ns = new List<string>();
                foreach (var c in chkLstBoxUSDAresults.CheckedItems)
                    ns.Add(c.ToString().Split(new string[] { "--" }, StringSplitOptions.None)[0]);
                fobjs[i].ndbnos = ns;
            }
            mH = true;
            numUpDownIndex.Value = _n + 1;
            mH = false;
        }

        private void chkLstBoxUSDAresults_KeyDown(object sender, KeyEventArgs e)
        {
            //triggers numUpDown++
            //if (e.KeyCode == Keys.Return)
            //{
            //    if (btnBegin.Enabled)
            //    {
            //        MessageBox.Show("Please press begin!!");
            //        return;
            //    }
            //    if (chkLstBoxUSDAresults.CheckedItems.Count == 0)
            //    {
            //        if (MessageBox.Show("Really skip this entry?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //            return;
            //    }
            //    foreach (var c in chkLstBoxUSDAresults.CheckedItems)
            //        ndbs.Add(c.ToString().Split(new string[] { "--" }, StringSplitOptions.None)[0]);
            //    _n++;
            //    numUpDownIndex.Value = _n;
            //}
        }

        string storLoc = "";
        bool mH = false;
        char[] _delims = new char[] { '/', ',', ' ', '-', ';', '(', ')' };
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
            ////int[] wordMatch = new int[usdaDB.names.Length];
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
                        itms.Add($"{usdaDB.ndbs[j]} -- {usdaDB.names[j]} -- {usdaDB.wMatch[j]}"); //-({usdaDB.joinedMatches[j]})");                     

            n = fobjs.Count();
            groupBox1.Text = $"{q} Possible Matches ({_n + 1} of {n})  — {f.foodName}";
            lblFieldVal.Text = $"{f.mainMetric} value: {f.value}";

            chkLstBoxUSDAresults.BeginUpdate();
            for (int i = 0; i < itms.Count; i++)
                chkLstBoxUSDAresults.Items.Add(itms[i]);
            chkLstBoxUSDAresults.EndUpdate();



            ///????????????????????????????????????????????
            //List<string> ns = new List<string>();
            //foreach (var c in chkLstBoxUSDAresults.CheckedItems)
            //    ns.Add(c.ToString().Split(new string[] { "--" }, StringSplitOptions.None)[0]);
            //f.ndbnos = ns.ToArray();
        }

        //string metricName = "";
        //static fObj f;
        private void numUpDownIndex_ValueChanged(object sender, EventArgs e)
        {
            if (mH)
                return;
            //
            //refresh listview, groupbox, lblVal, and txtTweak
            //use numIndex and fieldObjs
            //
            _n = Convert.ToInt32(numUpDownIndex.Value) - 1;
            _fObj f = fobjs[_n];
            lblFieldVal.Text = $"{f.mainMetric} value: {f.value}";
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

        private void chkLstBoxUSDAresults_Leave(object sender, EventArgs eventArgs){
            //f.ndbnos = new List<string>();
            //foreach (var c in checkedListBox1.CheckedItems)
                //f.ndbnos.Add(c.ToString().Split(new string[] { "--" }, StringSplitOptions.None)[0]);
        }
    }
}