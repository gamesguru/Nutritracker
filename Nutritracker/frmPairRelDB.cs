﻿using System;
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
        private void frmGenerateRelDBpair_Load(object sender, EventArgs e)
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
            btnGoBack.Enabled = true;
            comboBox1.Enabled = false;
            
            string[] usdaNutKeyPairLines = File.ReadAllLines($"{usdaRoot}{slash}_nutKeyPairs.TXT");
            foreach (string s in usdaNutKeyPairLines)
                if (s.Split('|')[1] == "FoodName")
                    usdaDB.names = File.ReadAllLines($"{usdaRoot}{slash}{s.Split('|')[0]}");
            else if (s.Split('|')[1] == "NDBNo")
                    usdaDB.ndbs = File.ReadAllLines($"{usdaRoot}{slash}{s.Split('|')[0]}");

            //work here
            int[] wordMatch = new int[usdaDB.names.Length];
            foreach (string s in foodNamesToPair[0].Replace(",", "").Split(' '))
                for (int i=0;i<usdaDB.names.Length;i++)
                    if (usdaDB.names[i].ToUpper().Contains(s.ToUpper()))
                        wordMatch[i]++;

            int m = wordMatch.Max();
            int q = 0;
            for (int i = m; i > 0; i--)
            {
                for (int j = 0; j < usdaDB.names.Length; j++)
                    if (wordMatch[j] == i)
                    {
                        string itm = $"{usdaDB.ndbs[j]}--{usdaDB.names[j]}";
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                {
                    if (st.StartsWith("[Header]"))
                        d.header = st.Replace("[Header]", "");
                    else if (st.StartsWith("[Unit]"))
                        d.unit = st.Replace("[Unit]", "");
                }
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

            foreach (dbc d in dbConfigKeys)
                if (d.field == "FoodName")
                    foodNamesToPair = File.ReadAllLines(fieldRoot + d.file);

            n = foodNamesToPair.Length;
            groupBox1.Text = $"Possible Matches (1 of {n})  — {foodNamesToPair[0]}";//"Current Item 1 of " + n;
        }

        private void checkedListBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (btnBegin.Enabled)
                {
                    MessageBox.Show("Please press begin!!");
                    return;
                }
                if (checkedListBox1.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please select something!!");
                    return;
                }
                foreach (var c in checkedListBox1.CheckedItems)
                {
                    MessageBox.Show(c.ToString());
                }
            }
        }
    }
}