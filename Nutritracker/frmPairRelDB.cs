using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    comboBox1.Items.Add(s.Split(new string[] { $"{slash}f_user_" },StringSplitOptions.None)[1]);
            if (comboBox1.Items.Count == 0)
            {
                MessageBox.Show("Please create some fields before using this form.");
                this.Close();
            }
            comboBox1.SelectedIndex = 0;
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
        private void btnBegin_Click(object sender, EventArgs e)
        {
            btnBegin.Enabled = false;
            comboBox1.Enabled = false;
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
            usdaDB.wMatch = new int[usdaDB.names.Length];
            usdaDB.joinedMatches = new string[usdaDB.names.Length];
            foreach (string s in foodNamesToPair[0].Split(_delims))
                for (int i=0;i<usdaDB.names.Length;i++)
                    if (s.Length > 2 && usdaDB.names[i].ToUpper().Contains(s.ToUpper())){
						usdaDB.wMatch[i]++;
                        usdaDB.joinedMatches[i] += s + ", ";              
                    }

            int m = usdaDB.wMatch.Max();
            int q = 0;
            for (int i = m; i > 0; i--)
            {
                for (int j = 0; j < usdaDB.names.Length; j++)
                    if (usdaDB.wMatch[j] == i)
                    {
                        string itm = $"{usdaDB.ndbs[j]}--{usdaDB.names[j]}-[{usdaDB.wMatch[j]}]-({usdaDB.joinedMatches[j]})";
                        checkedListBox1.Items.Add(itm);
                        q++;
                    }
            }
            groupBox1.Text = $"{q} Possible Matches (1 of {n})  — {foodNamesToPair[0]}";
        }

        public static class usdaDB
        {
            public static string[] ndbs;
            public static string[] names;
            public static int[] wMatch;
            public static string[] joinedMatches;
        }
        private class fObj
        {
            public int index = 0;
            public string value;
            public string[] ndbnos;
        }
        private class vObj
        {
            public string val;
            public string name;
        }

        List<string> metricsToTrack;
        fObj[] fieldObjs = new fObj[0];
        List<vObj> valNamePairs;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ndbs = new List<string>();
            this.Text = $"Pair {comboBox1.Text} with USDA";
            string fieldRoot = $"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}f_user_{comboBox1.Text}{slash}";
            dbInitKeys = new List<dbi>();
            dbConfigKeys = new List<dbc>();
            string[] dbInitItems = File.ReadAllText(fieldRoot + "_dbInit.TXT").Split(new string[] { "[File]" }, StringSplitOptions.None);
            string[] dbConfigItems = File.ReadAllText(fieldRoot + "_dbConfig.TXT").Split(new string[] { "[File]" }, StringSplitOptions.None);

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

            valNamePairs = new List<vObj>();
            foreach (dbc d in dbConfigKeys)            
                if (d.field == "FoodName")
                {
                    foodNamesToPair = File.ReadAllLines(fieldRoot + d.file);
                    string[] valsToPair = new string[0];
                    foreach (dbc d2 in dbConfigKeys)
                        if (d2.field=="Value1")
                            valsToPair = File.ReadAllLines(fieldRoot + d2.file);
                    for (int i = 0; i < foodNamesToPair.Length; i++)
                    {
                        vObj v = new vObj();
                        v.name = foodNamesToPair[i];
                        v.val = valsToPair[i];
                        valNamePairs.Add(v);
                    } 
                }
                            

            metricsToTrack = new List<string>();
            foreach (dbc d in dbConfigKeys)
            {
                if (d.metric != null && d.metric != "" && !metricsToTrack.Contains(d.metric))
                    metricsToTrack.Add(d.metric);
                if (d.metric != null && d.metric != "" && d.field == "Value1")
                    metricName = d.metric;
            }

            n = foodNamesToPair.Length;
            fieldObjs = new fObj[n];
            for (int i=0;i<fieldObjs.Length;i++)
                fieldObjs[i] = new fObj();
            numUpDownIndex.Value = 1;
            numUpDownIndex.Minimum = 1;
            numUpDownIndex.Maximum = n;
            groupBox1.Text = $"Possible Matches (1 of {n})  — {foodNamesToPair[0]}";
            this.Text = $"Pair {n} items for {comboBox1.Text} with USDA";
            foreach (vObj v in valNamePairs)
                if (v.name == foodNamesToPair[0])
                    lblFieldVal.Text = $"{metricName} value: {v.val}";
            mH = true;
            numUpDownIndex.Value = 1;
            txtTweak.Text = foodNamesToPair[0];
            mH = false;
        }
        List<string> ndbs;
        int _n = 0;
        private void checkedListBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)            
                nextEntry();            
        }

        private void nextEntry()
        {
            if (btnBegin.Enabled)
            {
                MessageBox.Show("Please press begin!!");
                return;
            }
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                if (MessageBox.Show("Really skip this entry?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }
            foreach (var c in checkedListBox1.CheckedItems)
                ndbs.Add(c.ToString().Split(new string[] { "--" }, StringSplitOptions.None)[0]);

            string dir = $"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}_par_f{slash}{comboBox1.Text}";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            File.WriteAllLines($"{dir}{slash}metrics.TXT", metricsToTrack);
            File.WriteAllLines($"{dir}{slash}ndbs.TXT", ndbs);
            File.WriteAllText($"{dir}{slash}progress.TXT", _n.ToString());

            _n++;
            checkedListBox1.Items.Clear();
            usdaDB.wMatch = new int[usdaDB.names.Length];
            foreach (string s in foodNamesToPair[_n].Split(_delims))
                for (int i = 0; i < usdaDB.names.Length; i++)
                    if (s.Length > 2 && usdaDB.names[i].ToUpper().Contains(s.ToUpper()))
                    {
                        usdaDB.wMatch[i]++;
                        usdaDB.joinedMatches[i] += s + ", ";
                    }

            int m = usdaDB.wMatch.Max();
            int q = 0;
            for (int i = m; i > 0; i--)
                for (int j = 0; j < usdaDB.names.Length; j++)
                    if (usdaDB.wMatch[j] == i)
                    {
                        string itm = $"{usdaDB.ndbs[j]}--{usdaDB.names[j]}-[{usdaDB.wMatch[j]}]-({usdaDB.joinedMatches[j]})";
                        checkedListBox1.Items.Add(itm);
                        q++;
                    }

            n = foodNamesToPair.Length;
            groupBox1.Text = $"{q} Possible Matches ({_n} of {n})  — {foodNamesToPair[_n]}";
            foreach (vObj v in valNamePairs)
                if (v.name == foodNamesToPair[_n])
                    lblFieldVal.Text = $"{metricName} value: {v.val}";
            mH = true;
            numUpDownIndex.Value = _n;
            txtTweak.Text = foodNamesToPair[_n];
            mH = false;
        }

        bool mH = false;
        char[] _delims = new char[] { '/', ',', ' ' };
        private void txtTweak_TextChanged(object sender, EventArgs e)
        {
            if (mH)
                return;
            checkedListBox1.Items.Clear();
            //int[] wordMatch = new int[usdaDB.names.Length];
            usdaDB.wMatch = new int[usdaDB.names.Length];
            usdaDB.joinedMatches = new string[usdaDB.names.Length];
			string[] words;

            if (txtTweak.TextLength < 4)
                return;
            else if (txtTweak.Text.Split(' ').Length < 2)
                words = new string[] { txtTweak.Text };
            else
                words = txtTweak.Text.Split(_delims);
            
            foreach (string s in words)
                for (int i = 0; i < usdaDB.names.Length; i++)
                    if (s.Length > 2 && usdaDB.names[i].ToUpper()/*.Split(_delims)*/.Contains(s.ToUpper()))                     
                        usdaDB.wMatch[i]++; //usdaDB.joinedMatches[i] += s + ", ";                       
                    

            int m = usdaDB.wMatch.Max();
            int q = 0;
            List<string> itms = new List<string>();
            for (int i = m; i > 0; i--)
                for (int j = 0; j < usdaDB.names.Length; j++)
                    if (usdaDB.wMatch[j] == i && q++ > 0)
                        itms.Add($"{usdaDB.ndbs[j]}--{usdaDB.names[j]}-[{usdaDB.wMatch[j]}]-({usdaDB.joinedMatches[j]})");                     
            
            n = foodNamesToPair.Length; 
            groupBox1.Text = $"{q} Possible Matches ({_n} of {n})  — {foodNamesToPair[_n]}";
            foreach (vObj v in valNamePairs)
                if (v.name == foodNamesToPair[_n])
                    lblFieldVal.Text = $"{metricName} value: {v.val}";
            checkedListBox1.BeginUpdate();
            for (int i = 0; i < itms.Count;i++)
                checkedListBox1.Items.Add(itms[i]);            
            checkedListBox1.EndUpdate();
        }

        string metricName = "";
        private void numUpDownIndex_ValueChanged(object sender, EventArgs e)
        {
            _n = Convert.ToInt32(numUpDownIndex.Value);
            checkedListBox1.Items.Clear();
            usdaDB.wMatch = new int[usdaDB.names.Length];
            foreach (string s in foodNamesToPair[_n].Split(_delims))
                for (int i = 0; i < usdaDB.names.Length; i++)
                    if (s.Length > 2 && usdaDB.names[i].ToUpper().Contains(s.ToUpper()))
                    {
                        usdaDB.wMatch[i]++;
                        usdaDB.joinedMatches[i] += s + ", ";
                    }

            int m = usdaDB.wMatch.Max();
            int q = 0;
            for (int i = m; i > 0; i--)
                for (int j = 0; j < usdaDB.names.Length; j++)
                    if (usdaDB.wMatch[j] == i)
                    {
                        string itm = $"{usdaDB.ndbs[j]}--{usdaDB.names[j]}-[{usdaDB.wMatch[j]}]-({usdaDB.joinedMatches[j]})";
                        checkedListBox1.Items.Add(itm);
                        q++;
                    }

            n = foodNamesToPair.Length;
            groupBox1.Text = $"{q} Possible Matches ({_n} of {n})  — {foodNamesToPair[_n]}";
            foreach (vObj v in valNamePairs)
                if (v.name == foodNamesToPair[_n])
                    lblFieldVal.Text = $"{metricName} value: {v.val}";
            mH = true;
            txtTweak.Text = foodNamesToPair[_n];
            mH = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTweak_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                checkedListBox1.Focus();
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }
    }
}
