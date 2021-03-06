﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using static Nutritracker.pReader;

namespace Nutritracker
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public int getBiggestInt(string s)
        {
            int j = s.Length;
            int g = 0;
            List<int> gs = new List<int>();
            for (int i = j; i > 0; i--)
                foreach (string st in substrings(s, i))
                    if (int.TryParse(st, out g))
                        gs.Add(g);
            return gs.Max();
        }

        public int getBiggestInt(double d) => Convert.ToInt32(d);

        public string[] substrings(string s, int n)
        {
            string[] sr = new string[s.Length - n + 1];
            for (int i = 0; i < s.Length - n + 1; i++)
                sr[i] = s.Substring(i, n).ToLower();
            return sr;
        }

        public static List<string> knownFields = new List<string> {
            "FoodName",
            "NDBNo",
            "OthPrimKey",
            "OthPrimKey2",
            "OthPrimKey3",
            "Serv",
            "Serv2",
            "Weight",
            "Weight2",
            "ALA",
            "EpaDha",
            "Cals",
            "CalsFat",
            "FatTot",
            "FatSat",
            "FatTrans",
            "FatMono",
            "FatPoly",
            "Cholest",
            "Na",
            "K",
            "Carbs",
            "Fiber",
            "FiberSol",
            "Sugar",
            "Protein",
            "VitA",
            "VitC",
            "Ca",
            "Fe",
            "VitD",
            "VitE",
            "VitK",
            "B1",
            "B2",
            "B3",
            "B5",
            "B6",
            "B7",
            "B9",
            "B12",
            "Mg",
            "Zn",
            "Se",
            "B",
            "I",
            "P",
            "Mn",
            "F",
            "Cu",
            "Cr",
            "Mo",
            "Choline",
            "Inositol",
            "Carnitine",
            "Lipoic acid",
            "Aminos",
        };

        private void tabulateNutrientColumns()
        {
            int tDay1 = 6, tDay2 = 7;
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                try
                {
                    if (dataDay.Rows[i].Cells[0].Value.ToString() == "Totals")
                        tDay1 = i;
                    tDay2 = tDay1 + 1;
                }
                catch { }



            for (int i = 2; i < dataDay.ColumnCount; i++)
            {
                double sum = 0;
                for (int m = 0; m < dataDay.RowCount - 3; m++)
                    try { sum += Convert.ToDouble(dataDay.Rows[m].Cells[i].Value); }
                    catch { }

                dataDay.Rows[tDay1].Cells[i].Value = Math.Round(sum, 2);
            }
        }

        //DataGridViewRow row = (DataGridViewRow) dataDay.Rows[0].Clone();
        //row.Cells[0].Value = "XYZ";
        //row.Cells[1].Value = 50.2;
        //dataDay.Rows.Add(row);

        public static string[] addFood { get; set; }
        public static int bmr = 0;
        double mFactor = 1.2;
        //bool loadup = true;
        public static string dte;
        public static string slash = Path.DirectorySeparatorChar.ToString();

        List<string> profDirects;
        public class _profile
        {
            public string name = "";
            public string gender = "";
            public int age;
            public double bf;
            public int wt;
            public int ht;
            public int actLvl = 2;
            public int goal = 0;  //Maint, loss, gain, overall transformation {0, 1, 2, 3}
            public int index = 0; //the index among other profiles, beginning with 0
            public string root;
            public string _dte = "";
            public int lastDB;
            public int lastMeal;
            public bool license;
            public string[] __raw_settings;
        }
        public int defaultIndex = 0;

        public class logItem
        {
            public string _db = "USDAstock";
            public string primKeyNo;
            public string fileName;
            public double grams = 100;
        }

        List<logItem> bLog;
        List<logItem> lLog;
        List<logItem> dLog;
        logItem litm;
        //public static List<string> dbsToLoad;
        public static _profile currentUser = new _profile();

        public _profile profileParser(string[] input)
        {
            _profile p = new _profile();
            foreach (string s in input)
                if (s.StartsWith("Gender:"))
                    p.gender = s.Split(':')[1];
                else if (s.StartsWith("Name:"))
                    p.name = s.Split(':')[1];
                else if (s.StartsWith("Age:"))
                    p.age = Convert.ToInt32(s.Split(':')[1]);
                else if (s.StartsWith("Bodyfat:"))
                    p.bf = Convert.ToDouble(s.Split(':')[1]);
                else if (s.StartsWith("Weight:"))
                    p.wt = Convert.ToInt32(s.Split(':')[1]);
                else if (s.StartsWith("Height:"))
                    p.ht = Convert.ToInt32(s.Split(':')[1]);
                else if (s.StartsWith("ActLvl:"))
                    p.actLvl = Convert.ToInt32(s.Split(':')[1]);
                else if (s.StartsWith("LastDB:"))
                    p.lastDB = Convert.ToInt32(s.Split(':')[1]);
                else if (s.StartsWith("LastMeal:"))
                    p.lastMeal = Convert.ToInt32(s.Split(':')[1]);
                else if (s.StartsWith("Goal:"))
                    p.goal = Convert.ToInt32(s.Split(':')[1]);
                else if (s.StartsWith("Date:"))
                    p._dte = s.Split(':')[1];
                else if (s.StartsWith($"License]StallmanApproves_{p.name.GetHashCode()}"))
                    p.license = true;
            return p;
        }

        public static void profileWriter(_profile p)
        {
            //TODO: ??
            List<string> output = new List<string>();
            if (p.name != "")
                output.Add($"Name:{p.name}");
            if (p.gender != "")
                output.Add($"Gender:{p.gender}");
            if (p.age != 0)
                output.Add($"Age:{p.age}");
            if (p.bf != 0)
                output.Add($"Bodyfat:{p.bf}");
            if (p.wt != 0)
                output.Add($"Weight:{p.wt}");
            if (p.ht != 0)
                output.Add($"Height:{p.ht}");
            output.Add($"ActLvl:{p.actLvl}");
            output.Add($"Goal:{p.goal}");
            if (p._dte != "")
                output.Add($"Date:{p._dte}");
            output.Add($"LastDB:{p.lastDB}");
            output.Add($"LastMeal:{p.lastMeal}");
            if (p.license)
                output.Add($"License:StallmanApproves_{p.name.GetHashCode()}");

            if (p.root != "")
                File.WriteAllLines($"{p.root}{slash}profile.py", output);
            else
                MessageBox.Show("null user directory");
        }

        public static string osPlatform = "";

        public enum OS { Windows, macOS, Linux };
        public static OS os;

        private void frmMain_Load(object sender, EventArgs e)
        {
            //osPlatform = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            if (slash == "\\")
                os = OS.Windows;
            else if (exc("uname")[0] == "Darwin")
                os = OS.macOS;
            else
                os = OS.Linux;
            try { currentUser.index = Convert.ToInt32(Directory.GetFiles($"{Application.StartupPath}{slash}usr")[0].Split(new string[] { $"usr{slash}default" }, StringSplitOptions.None)[1]); }
            catch { }

            //currentUser.root = $"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}";
            string todaysLog = "";

            string root = $"{Application.StartupPath}{slash}usr";
            foreach (string s in Directory.GetFiles(root))
                if (s.Split(Path.DirectorySeparatorChar)[s.Split(Path.DirectorySeparatorChar).Length - 1].StartsWith("profile"))
                    try { currentUser.index = Convert.ToInt16(s.Replace("default", "")); }
                    catch { }

            string[] directs = Directory.GetDirectories(root);
            profDirects = new List<string>();
            profileMgr frmP = new profileMgr();
            for (int i = 0; i < directs.Length; i++)
                if (directs[i].EndsWith($"{slash}profile{i}"))
                    profDirects.Add(directs[i]);

            //grabs basic fields, IMPORTS DBs
            try
            {
                foreach (string s in File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.py"))
                    if (s.StartsWith("Date:"))
                        dte = s.Split(':')[1];
                string st = "";
                try
                {
                    foreach (string s in (currentUser.__raw_settings = File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}settings.py")))
                    {
                        if (String.IsNullOrEmpty(s) || s.StartsWith("#"))
                            continue;
                        st = s.Split('#')[0].Replace("\t", "");
                        if (st.StartsWith("[searchWarnLimit]"))
                            frmSearchFoods.searchWarnLimit = Convert.ToInt32(st.Replace("[searchWarnLimit]", ""));
                        //else if (st.StartsWith("[imptDB]") && Directory.Exists($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}{st.Replace("[imptDB]", "")}"))
                        //if (!String.IsNullOrEmpty(st.Replace("[imptDB]", "")))
                        //dbsToLoad.Add(st.Replace("[imptDB]", ""));
                        //DBsToLoad.Add(d);
                        //TODO: put this after we change the date combobox index, somehow
                        //frmSearchFoods.loadDB(st.Replace("[imptDB]", ""));
                    }
                }
                catch (Exception ex) { MessageBox.Show($"param: {st}\r\n\r\n{ex}"); }
            }
            catch { dte = DateTime.Today.ToString("MM-dd-yyyy"); }

            //TODO: use the profile parser?
            //sets the user
            string rt = $"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}";
            try
            {
                string[] sets = File.ReadAllLines($"{rt}profile.py");
                foreach (string s in sets)
                {
                    if (s.StartsWith("Gender:"))
                        currentUser.gender = s.Split(':')[1];
                    else if (s.StartsWith("Name:"))
                        currentUser.name = s.Split(':')[1];
                    else if (s.StartsWith("Age:"))
                        currentUser.age = Convert.ToInt32(s.Split(':')[1]);
                    else if (s.StartsWith("Bodyfat:"))
                        currentUser.bf = Convert.ToDouble(s.Split(':')[1]);
                    else if (s.StartsWith("Weight:"))
                        currentUser.wt = Convert.ToInt32(s.Split(':')[1]);
                    else if (s.StartsWith("Height:"))
                        currentUser.ht = Convert.ToInt32(s.Split(':')[1]);
                    else if (s.StartsWith("ActLvl:"))
                        currentUser.actLvl = Convert.ToInt32(s.Split(':')[1]);
                    else if (s.StartsWith("Goal:"))
                        currentUser.goal = Convert.ToInt32(s.Split(':')[1]);
                    else if (s.StartsWith("LastDB:"))
                        currentUser.lastDB = Convert.ToInt32(s.Split(':')[1]);
                    else if (s.StartsWith("LastMeal:"))
                        currentUser.lastMeal = Convert.ToInt32(s.Split(':')[1]);                        
                    else if (s.StartsWith("Date:"))
                        currentUser._dte = s.Split(':')[1];
                }
                foreach (string s in sets)
                    if (s == $"License:StallmanApproves_{currentUser.name.GetHashCode()}")
                        currentUser.license = true;

                currentUser.root = $"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                frmP.ShowDialog();
                if (currentUser.root == null)
                    Process.GetCurrentProcess().Kill();
            }

            try
            {
                if (!File.ReadAllLines($"{rt}profile.py").Contains($"License:StallmanApproves_{currentUser.name.GetHashCode()}"))
                {
                    licenseDialog frmli = new licenseDialog();
                    frmli.profData = File.ReadAllLines($"{rt}profile.py").ToList();
                    frmli.rt = rt;
                    frmli.ShowDialog();
                    if (!File.ReadAllLines($"{rt}profile.py").Contains($"License:StallmanApproves_{currentUser.name.GetHashCode()}"))
                        Process.GetCurrentProcess().Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Process.GetCurrentProcess().Kill();
            }

            try
            {
                foreach (string s in Directory.GetFiles($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}log"))
                    comboLoggedDays.Items.Add(s.Split(Path.DirectorySeparatorChar)[s.Split(Path.DirectorySeparatorChar).Length - 1].Replace(".TXT", ""));
                todaysLog = File.ReadAllText($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}log{slash}{dte}.TXT");
            }
            catch
            {
                Directory.CreateDirectory($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}log");
                if (MessageBox.Show("Warning: no foodlog found for this user today. Create one?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    File.Create($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}log{slash}{dte}.TXT").Close();
            }

            if (!comboLoggedDays.Items.Contains(DateTime.Today.ToString("MM-dd-yyyy")))
                comboLoggedDays.Items.Add(DateTime.Today.ToString("MM-dd-yyyy"));

            try
            {
                foreach (var c in comboLoggedDays.Items)
                    if (c.ToString() == dte)
                        comboLoggedDays.SelectedItem = c;
            }
            catch { comboLoggedDays.SelectedIndex = comboLoggedDays.Items.Count - 1; }


            if (profDirects.Count == 0)
            {
                currentUser.index = 0;
                File.Create($"{Application.StartupPath}{slash}usr{slash}default0").Close();
                if (frmP.ShowDialog() == DialogResult.Cancel)
                    Process.GetCurrentProcess().Kill();
            }


            this.Text = $"Nutritracker — {currentUser.name}";

            comboExType.SelectedIndex = 0;
            dataExercise.Rows.Add("Existing");
            dataExercise.Rows[0].Height = 50;
            string actLvl = "#NULL";
            switch (currentUser.actLvl)
            {
                case 0:
                    actLvl = "Sedentary";
                    break;
                case 1:
                    actLvl = "Moderate";
                    break;
                case 2:
                    actLvl = "Active";
                    break;
                case 3:
                    actLvl = "Intense";
                    break;
                case 4:
                    actLvl = "Extreme";
                    break;
                default:
                    break;
            }
            dataExercise.Rows[0].Cells[1].Value = actLvl;

            mFactor = 1.2 + 0.175 * currentUser.actLvl;
            if (currentUser.gender == "female")
                bmr = Convert.ToInt32(mFactor * (10 * 0.4536 * currentUser.wt + 6.25 * 2.54 * currentUser.ht - 5 * currentUser.age) + 5);
            else
                bmr = Convert.ToInt32(mFactor * (10 * 0.4536 * currentUser.wt + 6.25 * 2.54 * currentUser.ht - 5 * currentUser.age) - 161);


            dataExercise.Rows[0].Cells[2].Value = Math.Round(bmr / 1440.0, 2);
            dataExercise.Rows[0].Cells[3].Value = "1440 min";
            dataExercise.Rows[0].Cells[4].Value = bmr.ToString() + " kcal";
            dataExercise.Rows[0].ReadOnly = true;
            //dataExercise.Rows.Insert(1, "", "", "", "", "");
            dataExercise.Rows.Insert(1, "Totals", "", "", "", bmr.ToString() + " kcal");
            dataExercise.Rows[1].DefaultCellStyle.BackColor = Color.LightGray;
            //

            comboMeal.SelectedIndex = 0;
            if (File.Exists($"{root}{slash}profile{currentUser.index}{slash}DBs{slash}_foods{slash}names.TXT"))
            {
                lstCustFoods = File.ReadAllLines($"{root}{slash}profile{currentUser.index}{slash}DBs{slash}_foods{slash}names.TXT");
                for (int i = 0; i < lstCustFoods.Length; i++)
                    lstBoxFoods.Items.Add(lstCustFoods[i]);
            }
        }

        string[] lstCustFoods;
        private void comboExType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdvCalc.Enabled = false;
            int n2 = comboExType.SelectedIndex;
            if (n2 == 0)
                lblActType.Text = "Steps:";
            else if (n2 > 0 && n2 < 5)
                lblActType.Text = "Minutes:";
            else
            {
                lblActType.Text = "Calories:";
                btnAdvCalc.Enabled = true;
            }
            txtExerciseVal.SelectAll();
            txtExerciseVal.Focus();
        }

        private void btnAdvCalc_Click(object sender, EventArgs e)
        {
            //numericUpDown1.Enabled = false;
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }


        private void btnProfile_Click(object sender, EventArgs e)
        {
            profileMgr frm = new profileMgr();
            frm.ShowDialog();

            comboLoggedDays.Items.Clear();
            foreach (string f in Directory.GetFiles($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}log"))
                if (f.EndsWith(".TXT") && f.Contains("-"))
                    comboLoggedDays.Items.Add(f.Split(new char[] { '/', '\\' })[f.Split(new char[] { '/', '\\' }).Length - 1].Replace(".TXT", ""));
            try { comboLoggedDays.SelectedIndex = comboLoggedDays.Items.Count - 1; }
            catch { }
            //TODO: use RAM memory
            this.Text = $"Nutritracker — {File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.py")[0]}";

            refreshDataDay();


            mFactor = 1.2 + currentUser.actLvl * 0.175;

            if (currentUser.gender == "female")
                bmr = Convert.ToInt32(mFactor * (10 * 0.4536 * currentUser.wt + 6.25 * 2.54 * currentUser.ht - 5 * currentUser.age) + 5);
            else
                bmr = Convert.ToInt32(mFactor * (10 * 0.4536 * currentUser.wt + 6.25 * 2.54 * currentUser.ht - 5 * currentUser.age) - 161);


            int m = dataExercise.RowCount - 2;
            for (int i = 0; i < m; i++)
                if (dataExercise[0, i].Value.ToString() == "Existing")
                {
                    dataExercise[2, i].Value = Math.Round(bmr / 1440.0, 2);
                    dataExercise[4, i].Value = $"{bmr} kcal";
                }

            int sum = 0;
            for (int i = 0; i < m; i++)
                try
                {
                    sum += getBiggestInt(dataExercise[4, i].Value.ToString());
                }
                catch { }


            dataExercise[4, m].Value = $"{sum} kcal";

            //add old exercise & meals
            //tabulate rows
            //reload list box
            //MessageBox.Show(loadIndex.ToString());
        }

        #region undo delete rows
        private DataGridViewRow row;
        private int n;
        private void btnRemoveFood_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dataDay.Rows[7].Cells[1].Value.ToString());
            //MessageBox.Show(dataDay.Rows.Count.ToString());
            //try
            //{
            int bDay = 11, lDay = 33, dDay = 55, tDay = 77;
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Breakfast")
                    bDay = i;
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Lunch")
                    lDay = i;
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Dinner")
                    dDay = i;
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Totals")
                    tDay = i;
            try { n = dataDay.SelectedRows[0].Index; }
            catch { n = dataDay.CurrentCell.RowIndex; }
            //MessageBox.Show(dataDay.Rows[0].Cells[0].Value.ToString());
            //MessageBox.Show(tDay.ToString());
            //MessageBox.Show(n.ToString());
            int o = dataDay.Rows.Count;
            row = dataDay.Rows[n];
            //MessageBox.Show(row.Cells[0].Value.ToString());
            ///
            /// if ! i =0 && ! i = condition below
            ///     then reload row, else ignore.  then refresh whole datagrid!!
            if (!(n == bDay || n == lDay || n == lDay - 1 || n == dDay || n == dDay - 1 || n == tDay || n == tDay - 1 || n == o - 2))
                dataDay.Rows.RemoveAt(n);

            for (int i = 0; i < dataDay.Rows.Count - 1; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Breakfast")
                    bDay = i + 1;
            for (int i = 0; i < dataDay.Rows.Count - 1; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Lunch")
                    lDay = i + 1;
            for (int i = 0; i < dataDay.Rows.Count - 1; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Dinner")
                    dDay = i + 1;
            for (int i = 0; i < dataDay.Rows.Count - 1; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Totals")
                    tDay = i + 1;

            string fp = $"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}log{slash}{dte}.TXT";
            List<string> output = new List<string>();
            output.Add("--Breakfast--");
            for (int m = bDay; m < lDay - 2; m++)
                output.Add($"USDAstock|{dataDay.Rows[m].Cells[1].Value}|{dataDay.Rows[m].Cells[0].Value.ToString().Split(' ')[0]}");
            output.Add("--Lunch--");
            for (int m = lDay; m < dDay - 2; m++)
                output.Add($"USDAstock|{dataDay.Rows[m].Cells[1].Value}|{dataDay.Rows[m].Cells[0].Value.ToString().Split(' ')[0]}");
            output.Add("--Dinner--");
            for (int m = dDay; m < tDay - 2; m++)
                output.Add($"USDAstock|{dataDay.Rows[m].Cells[1].Value}|{dataDay.Rows[m].Cells[0].Value.ToString().Split(' ')[0]}");
            File.WriteAllLines(fp, output);
            //refreshDataDay();
            dataDay.Focus();
            tabulateNutrientColumns();
        }


        private void dataDay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                btnRemoveFood.PerformClick();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //undoToolStripMenuItem.Enabled = false;
            ////MessageBox.Show("k");
            //dataDay.Rows.Insert(n, 1);
            //for (int i = 0; i < row.Cells.Count; i++)
            //    dataDay.Rows[n].Cells[i].Value = row.Cells[i].Value;
            //int bDay = 11, lDay = 33, dDay = 55, tDay = 77;
            //for (int i = 0; i < dataDay.Rows.Count - 2; i++)
            //    if (dataDay.Rows[i].Cells[0].Value.ToString() == "Breakfast")
            //        bDay = i;
            //for (int i = 0; i < dataDay.Rows.Count - 2; i++)
            //    if (dataDay.Rows[i].Cells[0].Value.ToString() == "Lunch")
            //        lDay = i;

            //string fp = $"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}log{slash}{dte}.TXT";
            //string textB = "";
            //textB += dataDay.Rows[bDay].Cells[0].Value.ToString() + "|";
            //for (int m = bDay + 1; m < lDay - 1; m++)
            //{

            //    for (int i = 0; i < dataDay.ColumnCount; i++)
            //    {
            //        try
            //        {
            //            if (dataDay.Rows[m].Cells[i].Value.ToString() == "")
            //                textB += " ";
            //            textB += dataDay.Rows[m].Cells[i].Value.ToString();
            //        }
            //        catch { textB += " "; }
            //        textB += "|";
            //    }
            //    textB += "|";
            //}

            //for (int i = 0; i < dataDay.Rows.Count - 2; i++)
            //    if (dataDay.Rows[i].Cells[0].Value.ToString() == "Lunch")
            //        lDay = i;
            //for (int i = 0; i < dataDay.Rows.Count - 2; i++)
            //    if (dataDay.Rows[i].Cells[0].Value.ToString() == "Dinner")
            //        dDay = i;
            //string textL = "";
            //textL += dataDay.Rows[lDay].Cells[0].Value.ToString() + "|";
            ////MessageBox.Show(textL);
            //for (int m = lDay + 1; m < dDay - 1; m++)
            //{

            //    for (int i = 0; i < dataDay.ColumnCount; i++)
            //    {
            //        try
            //        {
            //            if (dataDay.Rows[m].Cells[i].Value.ToString() == "")
            //                textL += " ";
            //            textL += dataDay.Rows[m].Cells[i].Value.ToString();
            //        }
            //        catch { textL += " "; }
            //        textL += "|";
            //    }
            //    textL += "|";
            //}

            //for (int i = 0; i < dataDay.Rows.Count - 2; i++)
            //    if (dataDay.Rows[i].Cells[0].Value.ToString() == "Dinner")
            //        dDay = i;
            //for (int i = 0; i < dataDay.Rows.Count - 2; i++)
            //    if (dataDay.Rows[i].Cells[0].Value.ToString() == "Totals")
            //        tDay = i;
            //string textD = "";
            //textD += dataDay.Rows[dDay].Cells[0].Value.ToString() + "|";
            //for (int m = dDay + 1; m < tDay - 1; m++)
            //{
            //    for (int i = 0; i < dataDay.ColumnCount; i++)
            //    {
            //        try
            //        {
            //            if (dataDay.Rows[m].Cells[i].Value.ToString() == "")
            //                textD += " ";
            //            textD += dataDay.Rows[m].Cells[i].Value.ToString();
            //        }
            //        catch { textD += " "; }
            //        textD += "|";
            //    }
            //    textD += "|";
            //}
            ////MessageBox.Show("2");
            //string[] text = { textB, textL, textD };
            //File.WriteAllLines(fp, text);


            //for (int i = 0; i < dataDay.Rows.Count - 2; i++)
            //    if (dataDay.Rows[i].Cells[0].Value.ToString() == "Totals")
            //        tDay = i + 1;
            //tabulateNutrientColumns();
        }
        #endregion

        bool bH = false;
        private void dataExercise_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            y = e.RowIndex;
            x = e.ColumnIndex;

            if (bH || x != 3 || y < 0)
                return;
            int val = 0;
            bH = true;
            try
            {
                //MessageBox.Show(y.ToString());
                //MessageBox.Show(x.ToString());
                val = getBiggestInt(dataExercise[x, y].Value.ToString().Replace(",", ""));
                //MessageBox.Show(val.ToString());
                if (dataExercise[0, y].Value.ToString() == "Walking" && dataExercise[1, y].Value.ToString() == "Steps")
                    dataExercise[3, y].Value = $"{val} steps";
                else if (dataExercise[0, y].Value.ToString() == "Walking" || dataExercise[0, y].Value.ToString() == "Jogging" || dataExercise[0, y].Value.ToString() == "Running" ||
                         dataExercise[0, y].Value.ToString() == "Sprinting")
                    dataExercise[3, y].Value = $"{val} min";
                else if (dataExercise[0, y].Value.ToString() == "Other")
                    dataExercise[3, y].Value = $"{val} kcal";
            }
            catch
            {
                // if (dataExercise[0, x].Value == "Walking" || dataExercise[0, x].Value == "Jogging" || dataExercise[0, x].Value == "Running" ||dataExercise[0, x].Value == "Sprinting")
                //     dataExercise[3, x].Value = val.ToString() + " min";
                // else if (dataExercise[0, x].Value == "Other")
                //     dataExercise[3, x].Value = val.ToString() + " kcal";
            }

            //loadup = false;            
            //MessageBox.Show("K");

            if (dataExercise[0, y].Value.ToString() == "Walking" && dataExercise[1, y].Value.ToString() == "Steps")
            {
                if (val == 0)
                {
                    //dataExercise[y - 1, x].Value = "0.000";
                    dataExercise[x, y].Value = "0 steps";
                    dataExercise[x + 1, y].Value = "0 kcal";
                    goto skip;
                }
                double c = val * 0.001 * (28 + 0.27 * (currentUser.wt - 100));
                c = Math.Round(c, 1);
                //editing = true;
                //MessageBox.Show(dataExercise[y+1,x].Value.ToString());
                dataExercise[x + 1, y].Value = c.ToString() + " kcal";
            }
            else if (dataExercise[0, y].Value.ToString() == "Walking")
            {
                if (val == 0)
                {
                    dataExercise[x, y].Value = "0 min";
                    dataExercise[x + 1, y].Value = "0 kcal";
                    goto skip;
                }
                double d = val / 20.0;
                double cpm = 53 + 0.535 * (currentUser.wt - 100);
                dataExercise.Rows[y].Cells[2].Value = Math.Round(d * cpm / val, 3);
                dataExercise.Rows[y].Cells[4].Value = Math.Round(d * cpm, 1) + " kcal";
            }
            else if (dataExercise[0, y].Value.ToString() == "Jogging")
            {
                if (val == 0)
                {
                    dataExercise[x, y].Value = "0 min";
                    dataExercise[x + 1, y].Value = "0 kcal";
                    goto skip;
                }
                double d = val / 20.0;
                double cpm = 53 + 0.535 * (currentUser.wt - 100);
                cpm *= 1.36;
                dataExercise.Rows[y].Cells[2].Value = Math.Round(d * cpm / val, 3);
                //dataExercise.Rows[0].Cells[3].Value = txtExerciseVal.Text + " min";
                dataExercise.Rows[y].Cells[4].Value = Math.Round(d * cpm, 1) + " kcal";
            }
            else if (dataExercise[0, y].Value.ToString() == "Running")
            {
                if (val == 0)
                {
                    dataExercise[x, y].Value = "0 min";
                    dataExercise[x + 1, y].Value = "0 kcal";
                    goto skip;
                }
                double d = val / 20.0;
                double cpm = 53 + 0.535 * (currentUser.wt - 100);
                cpm *= 1.4;
                dataExercise.Rows[y].Cells[2].Value = Math.Round(d * cpm / val, 3);
                //dataExercise.Rows[0].Cells[3].Value = txtExerciseVal.Text + " min";
                dataExercise.Rows[y].Cells[4].Value = Math.Round(d * cpm, 1) + " kcal";
            }
            else if (dataExercise[0, y].Value.ToString() == "Sprinting")
            {
                if (val == 0)
                {
                    dataExercise[x, y].Value = "0 min";
                    dataExercise[x + 1, y].Value = "0 kcal";
                    goto skip;
                }
                double d = val / 20.0;
                double cpm = 53 + 0.535 * (currentUser.wt - 100);
                cpm *= 1.54;
                dataExercise.Rows[y].Cells[2].Value = Math.Round(d * cpm / val, 3);
                //dataExercise.Rows[0].Cells[3].Value = txtExerciseVal.Text + " min";
                dataExercise.Rows[y].Cells[4].Value = Math.Round(d * cpm, 1) + " kcal";
            }
            else
            {
                if (val == 0)
                {
                    dataExercise[x, y].Value = "0 min";
                    dataExercise[x + 1, y].Value = "0 kcal";
                    goto skip;
                }
                dataExercise[3, y].Value = val.ToString() + " min";
                dataExercise[4, y].Value = val.ToString() + " kcal";
            }

            skip:
            int sum = 0;
            int m = dataExercise.RowCount - 2;
            for (int i = 0; i < m; i++)
                try { sum += getBiggestInt(dataExercise[4, i].Value.ToString()); }
                catch { }

            //MessageBox.Show(m.ToString());
            dataExercise[4, m].Value = sum.ToString() + " kcal";

            bH = false;
        }

        public static string[] currentBasicFields;
        string[] basicFields ={
            "NDBNo",
            "FoodName",
            "Cals",
            "FatTot",
            "FatSat",
            "Carbs",
            "Sugar",
            "Fiber",
            "Protein",
            "Cholest",
            "Na",
            "K",
            "Fe",
            "Ca",
            "VitA",
            "VitC",
            "VitD",
            "VitE",
            "VitK",
            "B6",
            "B12",
            "Mg",
            "Zn",
            "Se",
            "Lycopene",
            "LutZea",
            "GL_Load",
            "GI_Rating",
            "IF_Rating",
            "ORAC"
        };

        string[] fieldInitLines;
        List<string> fetchLogsFields(List<logItem> nLog)
        {
            List<string> dbs = new List<string>();
            foreach (logItem _litm in nLog)
                if (!dbs.Contains(_litm._db))
                    dbs.Add(_litm._db);

            string pubDbRoot = $"{Application.StartupPath}{slash}usr{slash}share{slash}DBs";
            List<string> lFields = new List<string>();
            foreach (string s in Directory.GetDirectories(pubDbRoot))
            {
                string dir = s.Split(Path.DirectorySeparatorChar)[s.Split(Path.DirectorySeparatorChar).Length - 1];
                if (dir.StartsWith("_") || dir.EndsWith("&"))
                    continue;
                fieldInitLines = File.ReadAllLines($"{s}{slash}_fieldInit.ini");
                foreach (string st in fieldInitLines)
                    if (!st.Contains("NDBNo") && basicFields.Contains(st.Split('=')[1]) && !lFields.Contains(st.Split('=')[1]))
                        lFields.Add(st.Split('=')[1]);
            }
            return lFields;
        }

        public class colObj
        {
            public string field;
            public string unit = "";
        }
        public static List<colObj> activeFieldsWithUnits;
        public List<colObj> fetchLogsFieldsWithUnits(List<logItem> nLog)
        {
            List<string> dbs = new List<string>();
            foreach (logItem _litm in nLog)
                if (!dbs.Contains(_litm._db))
                    dbs.Add(_litm._db);

            string pubDbRoot = $"{Application.StartupPath}{slash}usr{slash}share{slash}DBs";
            List<colObj> lFields = new List<colObj>();
            foreach (string s in Directory.GetDirectories(pubDbRoot))
            {
                string dir = s.Split(Path.DirectorySeparatorChar)[s.Split(Path.DirectorySeparatorChar).Length - 1];
                if (dir.StartsWith("_") || dir.EndsWith("&"))
                    continue;
                foreach (string st in File.ReadAllLines($"{s}{slash}_fieldInit.ini"))
                    if (!st.Contains("NDBNo"))
                        if (basicFields.Contains(st.Split('=')[1]))
                        {
                            bool dupe = false;
                            foreach (colObj _c in lFields)
                                if (_c.field == st.Split('=')[1])
                                    dupe = true;
                            if (dupe)
                                continue;
                            colObj c = new colObj();
                            c.field = st.Split('=')[1];
                            if (st.Contains("(") && st.Contains(")"))
                                c.unit = st.Split('(')[1].Split(')')[0].Trim();
                            lFields.Add(c);
                        }
            }
            activeFieldsWithUnits = lFields;
            return lFields;
        }


        private string[] fetchNutValues(string[] fields, logItem l)
        {
            //dataDay.Columns.Clear();
            //dataDay.Columns.Add("Spacer", "");
            if (l._db == "USDAstock")
            {
                string dbDir = $"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}{l._db}";
                string[] rawItemData = File.ReadAllLines($"{dbDir}{slash}{l.fileName}");
                Dictionary<string, string> foodItemNutPairs = new Dictionary<string, string>();
                //List<string> _dbg = new List<string>();
                foreach (string s in fields)
                    if (s != "NDBNo")
                        foreach (string st in rawItemData)
                            if (st.StartsWith($"{s}:"))
                            {
                                foodItemNutPairs.Add(s, st.Split(':')[1]);
                                //_dbg.Add(st);
                                break;
                            }
                List<string> output = new List<string>();
                double conv = l.grams / 100;
                foreach (string s in foodItemNutPairs.Keys)
                    if (s != "FoodName" && s != "NDBNo")
                        output.Add(Math.Round(conv * Convert.ToDouble(foodItemNutPairs[s]), 2).ToString());
                    else
                        output.Add(foodItemNutPairs[s]);
                return output.ToArray();
            }
            else
                return null;
        }

        public static List<logItem> litms;
        private void comboLoggedDays_SelectedIndexChanged(object sender, EventArgs e) => refreshDataDay();

        private void refreshDataDay()
        {
            dataDay.DataSource = null;
            dataDay.Refresh();
            try { dataDay.Columns.Clear(); }
            catch { }
            try { dataDay.Rows.Clear(); }
            catch { }
            try { dte = comboLoggedDays.SelectedItem.ToString(); }
            catch { dte = DateTime.Today.ToString("MM-dd-yyyy").Replace("/", "-"); }

            //TODO: rework this
            //also make comboLogged days save to disk, so dte is remembered...
            string[] profData = File.ReadAllLines($"{currentUser.root}{slash}profile.py"); //root not defined yet
            //profData[8] = $"[Date]{dte}"; //8th index, really?

            File.WriteAllLines($"{currentUser.root}{slash}profile.py", profData);
            string todaysLog = "";
            try { todaysLog = File.ReadAllText($"{currentUser.root}{slash}log{slash}{dte}.TXT").Replace("\r", ""); }
            //TODO: file in use exception at file.create
            catch { File.Create($"{currentUser.root}{slash}log{slash}{dte}.TXT"); }
            if (!comboLoggedDays.Items.Contains(dte))
                comboLoggedDays.Items.Add(dte);

            bLog = new List<logItem>();
            lLog = new List<logItem>();
            dLog = new List<logItem>();
            //TODO: put this elsewhere?
            Dictionary<string, string[]> dbEntryLangKeys = new Dictionary<string, string[]>();
            foreach (string s in Directory.GetDirectories($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs"))
            {
                string _db = s.Split(Path.DirectorySeparatorChar)[s.Split(Path.DirectorySeparatorChar).Length - 1];
                if (!_db.StartsWith("_") && !_db.EndsWith("&"))
                    dbEntryLangKeys.Add(_db, File.ReadAllLines($"{s}{slash}_entryKeyLang.ini"));
            }

            try
            {
                //TODO: convert
                string[] lines = todaysLog.Split(new string[] { "--Breakfast--" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new string[] { "--Lunch--" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string st in lines)
                {
                    litm = new logItem();
                    litm._db = st.Split('|')[0];
                    litm.primKeyNo = st.Split('|')[1];
                    foreach (string str in dbEntryLangKeys[litm._db])
                        if (str.Split('|')[1] == litm.primKeyNo)
                        {
                            litm.fileName = $"{str.Split('|')[0]}.TXT";
                            break;
                        }
                    litm.grams = Convert.ToDouble(st.Split('|')[2]);
                    bLog.Add(litm);
                }
                lines = todaysLog.Split(new string[] { "--Lunch--" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "--Dinner--" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string st in lines)
                {
                    litm = new logItem();
                    litm._db = st.Split('|')[0];
                    litm.primKeyNo = st.Split('|')[1];
                    foreach (string str in dbEntryLangKeys[litm._db])
                        if (str.Split('|')[1] == litm.primKeyNo)
                        {
                            litm.fileName = $"{str.Split('|')[0]}.TXT";
                            break;
                        }
                    litm.grams = Convert.ToDouble(st.Split('|')[2]);
                    lLog.Add(litm);
                }
                lines = todaysLog.Split(new string[] { "--Dinner--" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string st in lines)
                {
                    litm = new logItem();
                    litm._db = st.Split('|')[0];
                    litm.primKeyNo = st.Split('|')[1];
                    foreach (string str in dbEntryLangKeys[litm._db])
                        if (str.Split('|')[1] == litm.primKeyNo)
                        {
                            litm.fileName = $"{str.Split('|')[0]}.TXT";
                            break;
                        }
                    litm.grams = Convert.ToDouble(st.Split('|')[2]);
                    dLog.Add(litm);
                }
            }
            catch { }

            litms = new List<logItem>();
            litms.AddRange(bLog);
            litms.AddRange(lLog);
            litms.AddRange(dLog);
            dataDay.Columns.Add("MealNo", "Meal No.");
            //TODO: place elsewhere
            currentBasicFields = fetchLogsFields(litms).ToArray();
            //foreach (string s in dbsToLoad)
            //{
            //    bool added = false;
            //    foreach (frmSearchFoods.DB d in frmSearchFoods.loadedDBs)
            //        if (d.name == s)
            //            added = true;
            //    if (!added)
            //        frmSearchFoods.loadDB(s);
            //}
            foreach (colObj c in fetchLogsFieldsWithUnits(litms))
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
                col.Name = c.field;
                col.HeaderText = (c.unit == "") ? c.field : $"{c.field} ({c.unit})";
                col.CellTemplate = new DataGridViewTextBoxCell();
                dataDay.Columns.Add(col);
            }


            dataDay.Rows.Clear();
            dataDay.Rows.Add("Breakfast");
            dataDay.Rows.Add("", "");
            dataDay.Rows.Add("Lunch");
            dataDay.Rows.Add("", "");
            dataDay.Rows.Add("Dinner");
            dataDay.Rows.Add("", "");
            dataDay.Rows.Add("Totals");
            dataDay.Rows.Add("", "");

            dataDay.Rows[0].DefaultCellStyle.BackColor = Color.LightGray;
            dataDay.Rows[0].ReadOnly = true;

            dataDay.Rows[2].DefaultCellStyle.BackColor = Color.LightGray;
            dataDay.Rows[2].ReadOnly = true;

            dataDay.Rows[4].DefaultCellStyle.BackColor = Color.LightGray;
            dataDay.Rows[4].ReadOnly = true;

            dataDay.Rows[6].DefaultCellStyle.BackColor = Color.LightGray;
            dataDay.Rows[6].ReadOnly = true;

            dataDay.Rows[7].DefaultCellStyle.BackColor = Color.LightGray;
            dataDay.Rows[7].ReadOnly = true;
            dataDay.Rows[8].ReadOnly = true;

            int bDay = 1, lDay = 3, dDay = 5, tDay = 7;

            //breakfast
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value != null && dataDay.Rows[i].Cells[0].Value.ToString() == "Breakfast")
                    bDay = i + 1;
            if (bLog.Count() > 0)
                dataDay.Rows.Insert(bDay, bLog.Count());
            for (int i = 0; i < bLog.Count(); i++)
            {
                string[] ingrieds = fetchNutValues(currentBasicFields, bLog[i]);
                dataDay.Rows[bDay + i].Cells[0].Value = $"{bLog[i].grams} g";
                for (int j = 0; j < currentBasicFields.Length; j++)
                    dataDay.Rows[bDay + i].Cells[j + 1].Value = ingrieds[j];
            }

            //lunch
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value != null && dataDay.Rows[i].Cells[0].Value.ToString() == "Lunch")
                    lDay = i + 1;
            if (lLog.Count() > 0)
                dataDay.Rows.Insert(lDay, lLog.Count());
            for (int i = 0; i < lLog.Count(); i++)
            {
                string[] ingrieds = fetchNutValues(currentBasicFields, lLog[i]);
                dataDay.Rows[lDay + i].Cells[0].Value = $"{lLog[i].grams} g";
                for (int j = 0; j < currentBasicFields.Length; j++)
                    dataDay.Rows[lDay + i].Cells[j + 1].Value = ingrieds[j];
            }

            //dinner
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value != null && dataDay.Rows[i].Cells[0].Value.ToString() == "Dinner")
                    dDay = i + 1;
            if (dLog.Count() > 0)
                dataDay.Rows.Insert(dDay, dLog.Count());
            for (int i = 0; i < dLog.Count(); i++)
            {
                string[] ingrieds = fetchNutValues(currentBasicFields, dLog[i]);
                dataDay.Rows[dDay + i].Cells[0].Value = $"{dLog[i].grams} g";
                for (int j = 0; j < currentBasicFields.Length; j++)
                    dataDay.Rows[dDay + i].Cells[j + 1].Value = ingrieds[j];
            }

            //totals
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value != null && dataDay.Rows[i].Cells[0].Value.ToString() == "Totals")
                    tDay = i + 1;
            tabulateNutrientColumns();
        }
        //private string oldval = "";
        private int x = 0;
        private int y = 0;
        //private bool editing = false;
        #region cell focus set x,y

        #endregion

        private void btnAddEx_Click(object sender, EventArgs e)
        {
            //editing = true;
            dataExercise.Rows.Insert(0);
            int j = comboExType.SelectedIndex;
            if (j == 0)
            {
                dataExercise.Rows[0].Cells[0].Value = "Walking";
                dataExercise.Rows[0].Cells[1].Value = "Steps";
                double c = ex * 0.001 * (28 + 0.27 * (currentUser.wt - 100));
                dataExercise.Rows[0].Cells[2].Value = Math.Round(c / ex, 3);//Math.Round(d * cpm / ex, 3);
                dataExercise.Rows[0].Cells[3].Value = txtExerciseVal.Text + " steps";
                c = Math.Round(c, 1);
                dataExercise.Rows[0].Cells[4].Value = c.ToString() + " kcal";
            }
            else if (j == 1)
            {
                dataExercise.Rows[0].Cells[0].Value = "Walking";
                dataExercise.Rows[0].Cells[1].Value = "Light";
                double d = ex / 20.0;
                double cpm = 53 + 0.535 * (currentUser.wt - 100);
                dataExercise.Rows[0].Cells[2].Value = Math.Round(d * cpm / ex, 3);
                dataExercise.Rows[0].Cells[3].Value = txtExerciseVal.Text + " min";
                dataExercise.Rows[0].Cells[4].Value = Math.Round(d * cpm, 1) + " kcal";
            }
            else if (j == 2)
            {
                dataExercise.Rows[0].Cells[0].Value = "Jogging";
                dataExercise.Rows[0].Cells[1].Value = "Brisk";
                double d = ex / 20.0;
                double cpm = 53 + 0.535 * (currentUser.wt - 100);
                cpm *= 1.36;
                dataExercise.Rows[0].Cells[2].Value = Math.Round(d * cpm / ex, 3);
                dataExercise.Rows[0].Cells[3].Value = txtExerciseVal.Text + " min";
                dataExercise.Rows[0].Cells[4].Value = Math.Round(d * cpm, 1) + " kcal";
            }
            else if (j == 3)
            {
                dataExercise.Rows[0].Cells[0].Value = "Running";
                dataExercise.Rows[0].Cells[1].Value = "Intense";
                double d = ex / 20.0;
                double cpm = 53 + 0.535 * (currentUser.wt - 100);
                cpm *= 1.4;
                dataExercise.Rows[0].Cells[2].Value = Math.Round(d * cpm / ex, 3);
                dataExercise.Rows[0].Cells[3].Value = txtExerciseVal.Text + " min";
                dataExercise.Rows[0].Cells[4].Value = Math.Round(d * cpm, 1) + " kcal";
            }
            else if (j == 4)
            {
                dataExercise.Rows[0].Cells[0].Value = "Sprinting";
                dataExercise.Rows[0].Cells[1].Value = "Extreme";
                double d = ex / 20.0;
                double cpm = 53 + 0.535 * (currentUser.wt - 100);
                cpm *= 1.54;
                dataExercise.Rows[0].Cells[2].Value = Math.Round(d * cpm / ex, 3);
                dataExercise.Rows[0].Cells[3].Value = txtExerciseVal.Text + " min";
                dataExercise.Rows[0].Cells[4].Value = Math.Round(d * cpm, 1) + " kcal";
            }
            else
            {
                dataExercise.Rows[0].Cells[0].Value = "Other";
                dataExercise.Rows[0].Cells[2].Value = "1";
                dataExercise.Rows[0].Cells[3].Value = ex.ToString() + " min";
                dataExercise.Rows[0].Cells[4].Value = ex.ToString() + " kcal";
            }
            int sum = 0;
            int m = dataExercise.RowCount - 2;
            for (int i = 0; i < m; i++)
            {
                try
                {
                    sum += getBiggestInt(dataExercise[4, i].Value.ToString());
                }
                catch { }
            }
            dataExercise[4, m].Value = sum.ToString() + " kcal";
            //editing = false;
        }

        private void btnRemEx_Click(object sender, EventArgs e)
        {
            try
            {
                string s = dataExercise.CurrentRow.Cells[0].Value.ToString();
                //if (s.Length == 0) //TRIGGERS VIRUS?? FALSE POSITIVE
                //return;
                if (s != "Totals" && s != "Existing" /*&&
                    dataExercise.CurrentRow.Cells[0].Value.ToString().Length > 0*/)
                {
                    dataExercise.Rows.Remove(dataExercise.CurrentRow);

                    //editing = true;
                    int sum = 0;
                    int m = dataExercise.RowCount - 2;
                    for (int i = 0; i < m; i++)
                    {
                        try
                        {
                            int q = getBiggestInt(dataExercise[4, i].Value.ToString());
                            //MessageBox.Show(q.ToString());
                            sum += q;
                        }
                        catch { }

                    }
                    //MessageBox.Show(m.ToString());
                    dataExercise[4, m].Value = sum.ToString() + " kcal";
                }
            }
            catch { }
        }

        //string[] rwEx = new string[5];
        private void dataExercise_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                btnRemEx.PerformClick();
        }
        private void txtExerciseVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtExerciseVal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true;
                btnAddEx.PerformClick();
            }
        }

        private int ex = 0;
        private bool mH = false;
        private void txtExerciseVal_TextChanged(object sender, EventArgs e)
        {
            if (txtExerciseVal.TextLength == 0)
            {
                mH = true;
                txtExerciseVal.Text = "0";
                mH = false;
                txtExerciseVal.SelectionStart = 1;
                return;
            }
            ex = Convert.ToInt32(txtExerciseVal.Text.Replace(",", ""));
            int digs = txtExerciseVal.Text.Replace(",", "").Length;

            int n2;
            if (txtExerciseVal.Text.StartsWith("0") && txtExerciseVal.TextLength > 0 && !mH)
            {
                n2 = txtExerciseVal.SelectionStart - 1;
                mH = true;
                txtExerciseVal.Text = txtExerciseVal.Text.Remove(0, 1);
                mH = false;
                txtExerciseVal.SelectionStart = n2;
                return;
            }

            if (digs == 4 && !mH)
            {
                n2 = 0;
                if (!txtExerciseVal.Text.Contains(","))
                {
                    n2 = txtExerciseVal.SelectionStart + 1;
                    mH = true;
                    txtExerciseVal.Text = txtExerciseVal.Text.Insert(1, ",");
                    mH = false;
                    txtExerciseVal.SelectionStart = n2;
                    return;
                }
                else if (txtExerciseVal.Text[2] == ',')
                {
                    n2 = txtExerciseVal.SelectionStart;
                    mH = true;
                    txtExerciseVal.Text = txtExerciseVal.Text.Replace(",", "");
                    txtExerciseVal.Text = txtExerciseVal.Text.Insert(1, ",");
                    mH = false;
                    txtExerciseVal.SelectionStart = n2;
                    return;
                }

            }
            else if (digs == 5 && !mH)
            {
                //MessageBox.Show(digs.ToString());
                n2 = txtExerciseVal.SelectionStart;
                mH = true;
                txtExerciseVal.Text = txtExerciseVal.Text.Replace(",", "");
                txtExerciseVal.Text = txtExerciseVal.Text.Insert(2, ",");
                mH = false;
                txtExerciseVal.SelectionStart = n2;
            }
            else if (digs < 4)
                if (txtExerciseVal.Text.Contains(","))
                {
                    n2 = txtExerciseVal.SelectionStart - 1;
                    txtExerciseVal.Text = txtExerciseVal.Text.Replace(",", "");
                    txtExerciseVal.SelectionStart = n2 > 0 ? n : 0;
                }


            if (ex > 0)
                btnAddEx.Enabled = true;
            else
                btnAddEx.Enabled = false;
        }

        private void editProfilesToolStripMenuItem_Click(object sender, EventArgs e) => btnProfile.PerformClick();

        private void btnDetailReport_Click(object sender, EventArgs e)
        {
            frmDetailReport frmDet = new frmDetailReport();
            frmDet.ShowDialog();
        }

        private void bodyFatCalcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfCalc.currentName = File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.py")[0];
            sfCalc frmBFC = new sfCalc();
            frmBFC.gender = File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.py")[1];
            frmBFC.age = Convert.ToInt32(File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.py")[2]);
            frmBFC.wt = Convert.ToInt32(File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.py")[4]);
            frmBFC.ht = Convert.ToInt32(File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.py")[5]);
            frmBFC.ShowDialog();
        }

        private void viewDetailReportToolStripMenuItem_Click(object sender, EventArgs e) => btnDetailReport.PerformClick();

        private void naturalPotentialCalcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lmCalc.bodyfat = Convert.ToInt32(File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.py")[3]);
            lmCalc.weight = Convert.ToInt32(File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.py")[4]);
            lmCalc.height = Convert.ToInt32(File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.py")[5]);
            lmCalc frmNatPot = new Nutritracker.lmCalc();
            frmNatPot.ShowDialog();
        }

        private void parseExcelSpreadsheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmParseCustomDatabase frmParse = new frmParseCustomDatabase();
            frmParse.Show(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs"))
            {
                MessageBox.Show("There don't seem to be any databases.  Try going to the spreadsheet wizard (under tools) to import some, or borrow copies from another user.", "Nothing found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                frmSearchFoods frmAddSFood = new frmSearchFoods();
                frmAddSFood.ShowDialog(this);
                refreshDataDay();
            }
        }

        private void addSearchCommonFoodsToolStripMenuItem1_Click(object sender, EventArgs e) => btnSearch.PerformClick();

        private void manageActiveFieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmActiveFields frmAF = new frmActiveFields();
            frmAF.ShowDialog();
        }

        private void analyzeIngriedientListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDecomposeRecipe frmDR = new frmDecomposeRecipe();
            frmDR.ShowDialog();
        }

        private void relationalDatabaseWizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewDBrel frmNDBr = new frmNewDBrel();
            frmNDBr.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //TODO: dispose garbage
            this.Close();
        }

        private void manageRelativeDBPairsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPairField frmGRDB = new frmPairField();
            frmGRDB.ShowDialog();
        }

        private void btnDeleteDay_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to archive this day?  You can undo this manually.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Directory.CreateDirectory($"{currentUser.root}{slash}log{slash}_arc");
                string file = $"{currentUser.root}{slash}log{slash}_arc{slash}{comboLoggedDays.Text}.TXT";
                int pn = 0;
                while (File.Exists(file = $"{currentUser.root}{slash}log{slash}_arc{slash}{comboLoggedDays.Text}_{pn}.TXT"))
                    pn++;
                try { File.Move($"{currentUser.root}{slash}log{slash}{comboLoggedDays.Text}.TXT", file); }
                catch (Exception ex) { MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                int n2 = comboLoggedDays.SelectedIndex;
                comboLoggedDays.SelectedIndex = 0;
                comboLoggedDays.Items.RemoveAt(n2);
            }
        }

        private void historyMergerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistoryMerger frmHM = new frmHistoryMerger();
            frmHM.ShowDialog();
            frmHM = null;
        }

        private void manageRecipesFoodsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}