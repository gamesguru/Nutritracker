﻿using System;
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
        List<dbi> dbInitKeys;
        List<dbc> dbConfigKeys;
        string[] foodNamesToPair;
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

            //work here
            //storDir = $"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}_par_f{slash}{comboFields.Text}";
            //storLoc = $"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}_par_f{slash}{comboFields.Text}.TXT";

            ////new work
            //diskContents = File.ReadAllLines(storLoc).ToList();
            //foreach (string s in diskContents)
            //    if (s.StartsWith("[Progress]"))
            //        _n = Convert.ToInt32(s.Replace("[Progress]", ""));

            //numUpDownIndex.Maximum = n;
            //numUpDownIndex.Value = _n + 1;
            //numUpDownIndex.Minimum = 1;
        }

        private class _fObj
        {
			public int index; // among, say, the 34 foods in the field
            public List<string> metricsToTrack;
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
            dbInitKeys = new List<dbi>();
            dbConfigKeys = new List<dbc>();
            string[] dbInitItems = File.ReadAllText(fieldRoot + "_dbInit.TXT").Split(new string[] { "[File]" }, StringSplitOptions.None);
            string[] dbConfigItems = File.ReadAllText(fieldRoot + "_dbConfig.TXT").Split(new string[] { "[File]" }, StringSplitOptions.None);
            string[] fieldInfo = File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}_par_f{slash}{comboFields.Text}.TXT");

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
                    foreach (dbc d2 in dbConfigKeys)
                        if (d2.field == "Value1")
                        {
                            vals = File.ReadAllLines(fieldRoot + d.file);
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
							if (d.metric != null && d.metric != "" && !f.metricsToTrack.Contains(d.metric))
								f.metricsToTrack.Add(d.metric);
							if (d.metric != null && d.metric != "" && d.field == "Value1")
                                f.mainMetric = d.metric;
                            }
                        }
                }
            }

            //valNamePairs = new List<vObj>();
            //foreach (dbc d in dbConfigKeys)
            //    if (d.field == "FoodName")
            //    {
            //        foodNamesToPair = File.ReadAllLines(fieldRoot + d.file);
            //        string[] valsToPair = new string[0];
            //        foreach (dbc d2 in dbConfigKeys)
            //            if (d2.field == "Value1")
            //                valsToPair = File.ReadAllLines(fieldRoot + d2.file);
            //        for (int i = 0; i < foodNamesToPair.Length; i++)
            //        {
            //            vObj v = new vObj();
            //            v.name = foodNamesToPair[i];
            //            v.val = valsToPair[i];
            //            v.index = i;
            //            valNamePairs.Add(v);
            //        }
            //    }


            //metricsToTrack = new List<string>();
            //foreach (dbc d in dbConfigKeys)
            //{
            //    if (d.metric != null && d.metric != "" && !metricsToTrack.Contains(d.metric))
            //        metricsToTrack.Add(d.metric);
            //    if (d.metric != null && d.metric != "" && d.field == "Value1")
            //        metricName = d.metric;
            //}

            //n = foodNamesToPair.Length;
            //string[] rawOldData = File.ReadAllLines(storLoc);
            //foreach (string s in rawOldData)
            //    if (s.StartsWith("[Progress]"))
            //        _n = Convert.ToInt32(s.Replace("[Progress]", ""));

            //mH = true;
            //numUpDownIndex.Minimum = 1;
            //numUpDownIndex.Maximum = n;
            //numUpDownIndex.Value = _n + 1;
            //mH = false;
            //groupBox1.Text = $"Possible Matches ({_n + 1} of {n})  — {foodNamesToPair[_n]}";
            //this.Text = $"Pair {n} items for {comboFields.Text} with USDA";
            //foreach (vObj v in valNamePairs)
            //    if (v.name == foodNamesToPair[_n])
            //    {
            //        lblFieldVal.Text = $"{metricName} value: {v.val}";
            //        value = v.val;
            //    }
            //fieldObjs = new fObj[n];
            //for (int i = 0; i < fieldObjs.Length; i++)
            //{
            //    fieldObjs[i] = new fObj();
            //    fieldObjs[i].index = i;
            //    fieldObjs[i].value = value;
            //    List<string> ns = new List<string>();
            //    foreach (var c in chkLstBoxUSDAresults.CheckedItems)
            //        ns.Add(c.ToString().Split(new string[] { "--" }, StringSplitOptions.None)[0]);
            //    fieldObjs[i].ndbnos = ns.ToArray();
            //}
            //mH = true;
            //numUpDownIndex.Value = _n + 1;
            //txtTweak.Text = foodNamesToPair[_n];
            //mH = false;
        }
        List<string> selectedNdbs;
        //int _n = 0;
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
            //fObj f = fieldObjs[_n];
            //chkLstBoxUSDAresults.Items.Clear();
            ////int[] wordMatch = new int[usdaDB.names.Length];
            //usdaDB.wMatch = new int[usdaDB.names.Length];
            //usdaDB.joinedMatches = new string[usdaDB.names.Length];
            //string[] words;

            //if (txtTweak.TextLength < 4)
            //    return;
            //else if (txtTweak.Text.Split(' ').Length < 2)
            //    words = new string[] { txtTweak.Text };
            //else
            //    words = txtTweak.Text.Split(' '); //(_delims);

            //foreach (string s in words)
            //    for (int i = 0; i < usdaDB.names.Length; i++)
            //        if (s.Length > 2 && usdaDB.names[i].ToUpper()/*.Split(_delims)*/.Contains(s.ToUpper()))
            //            usdaDB.wMatch[i]++; //usdaDB.joinedMatches[i] += s + ", ";                       


            //int m = usdaDB.wMatch.Max();
            //int q = 0;
            //List<string> itms = new List<string>();
            //for (int i = m; i > 0; i--)
            //    for (int j = 0; j < usdaDB.names.Length; j++)
            //        if (usdaDB.wMatch[j] == i && q++ > 0)
            //            itms.Add($"{usdaDB.ndbs[j]}--{usdaDB.names[j]}-[{usdaDB.wMatch[j]}]"); //-({usdaDB.joinedMatches[j]})");                     

            //n = foodNamesToPair.Length;
            //groupBox1.Text = $"{q} Possible Matches ({_n + 1} of {n})  — {foodNamesToPair[_n]}";
            //foreach (vObj v in valNamePairs)
            //    if (v.name == foodNamesToPair[_n])
            //    {
            //        lblFieldVal.Text = $"{metricName} value: {v.val}";
            //        value = v.val;
            //    }


            //chkLstBoxUSDAresults.BeginUpdate();
            //for (int i = 0; i < itms.Count; i++)
            //    chkLstBoxUSDAresults.Items.Add(itms[i]);
            //chkLstBoxUSDAresults.EndUpdate();
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
            //_n = Convert.ToInt32(numUpDownIndex.Value) - 1;
            //f = fieldObjs[_n];
            //foreach (vObj v in valNamePairs)
            //    if (v.name == foodNamesToPair[_n])
            //    {
            //        lblFieldVal.Text = $"{metricName} value: {v.val}";
            //        value = v.val;
            //        //MessageBox.Show(value);
            //    }
            //chkLstBoxUSDAresults.Items.Clear();
            //usdaDB.wMatch = new int[usdaDB.names.Length];
            //foreach (string s in foodNamesToPair[_n].Split(_delims))
            //    for (int i = 0; i < usdaDB.names.Length; i++)
            //        if (s.Length > 2 && usdaDB.names[i].ToUpper().Contains(s.ToUpper()))
            //            usdaDB.wMatch[i]++; //usdaDB.joinedMatches[i] += s + ", ";
            //List<string> ns = new List<string>();
            //foreach (var c in chkLstBoxUSDAresults.CheckedItems)
            //    ns.Add(c.ToString().Split(new string[] { "--" }, StringSplitOptions.None)[0]);
            //f.ndbnos = ns.ToArray();
            //int m = usdaDB.wMatch.Max();
            //int q = 0;
            //for (int i = m; i > 0; i--)
            //    for (int j = 0; j < usdaDB.names.Length; j++)
            //        if (usdaDB.wMatch[j] == i)
            //        {
            //            if (q == 30)
            //                goto next;
            //            string itm = $"{usdaDB.ndbs[j]}--{usdaDB.names[j]}-[{usdaDB.wMatch[j]}]"; //-({usdaDB.joinedMatches[j]})";
            //            chkLstBoxUSDAresults.Items.Add(itm);
            //            q++;
            //        }
            //    next:
            //n = foodNamesToPair.Length;
            //groupBox1.Text = $"{q} Possible Matches ({_n + 1} of {n})  — {foodNamesToPair[_n]}";
            //mH = true;
            //txtTweak.Text = foodNamesToPair[_n];
            //mH = false;
            //checkItemsFromDisk();
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
        string value = "";
        //List<string> chkNdbnos;
        private void chkLstBoxUSDAresults_Leave(object sender, EventArgs eventArgs){
            //f.ndbnos = new List<string>();
            //foreach (var c in checkedListBox1.CheckedItems)
                //f.ndbnos.Add(c.ToString().Split(new string[] { "--" }, StringSplitOptions.None)[0]);
        }
    }
}