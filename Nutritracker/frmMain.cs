using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            for (int i = j; i > 0; i--)
            {
                foreach (string st in substrings(s, i))
                {
                    if (int.TryParse(st, out g))
                        return g;
                }
            }
            return 0;
        }

        public int getBiggestInt(double d)
        {
            return Convert.ToInt32(d);
        }

        public string[] substrings(string s, int n)
        {
            string[] sr = new string[s.Length - n + 1];

            for (int i = 0; i < s.Length - n + 1; i++)
            {
                sr[i] = s.Substring(i, n).ToLower();
            }

            return sr;
        }

        public List<String> importArray(string filename)
        {
            list.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line); // Add to list.
                }
            }
            return list;
        }

        List<string> list = new List<string>();


        public static List<string> knownFields = new List<string> {
            "FoodName",
            "NDB",
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
            "CarbsTot",
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
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
        };

        public static int mealSpe;
        public static int mealIndex = 0;

        private void tabulateNutrientColumns()
        {
            int tDay1 = 6, tDay2 = 7;
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
            {
                try
                {
                    if (dataDay.Rows[i].Cells[0].Value.ToString() == "Totals")
                        tDay1 = i;
                    tDay2 = tDay1 + 1;
                }
                catch { }
            }


            for (int i = 1; i < dataDay.ColumnCount; i++)
            {
                double sum = 0;
                for (int m = 0; m < dataDay.RowCount - 3; m++)
                {
                    try { sum += Convert.ToDouble(dataDay.Rows[m].Cells[i].Value); }
                    catch { }
                }
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
            public string gender = "female";
            public int age = 23;
            public double bf = 17.0;
            public int wt = 115;
            public int ht = 63;
            public int actLvl = 2;
            public string goal = "Maintenance";
            public int index = 0; //the index among other profiles, beginning with 0
            public string root;
        }

        public class logItem
        {
            public int index = 0;
            public string _db = "USDAstock";
            public string primKeyNo;
            public double grams = 100;
        }

        List<logItem> bLog;
        List<logItem> lLog;
        List<logItem> dLog;
        logItem litm;
        public static _profile currentUser = new _profile();
        string userRoot;

        private void frmMain_Load(object sender, EventArgs e)
        {
            dte = DateTime.Today.ToString("MM-dd-yyyy");
            try { currentUser.index = Convert.ToInt32(Directory.GetFiles($"{Application.StartupPath}{slash}usr")[0].Split(new string[] { $"usr{slash}default" }, StringSplitOptions.None)[1]); }
            catch { }

            userRoot = $"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}";


            try
            {
                string[] daysLog = File.ReadAllText($"{userRoot}{slash}foodLog.TXT").Replace("\r", "").Split(new string[] { "===========\n" }, StringSplitOptions.RemoveEmptyEntries);

                List<string> dates = new List<string>();
                foreach (string s in daysLog)
                    dates.Add(s.Split('\n')[0]);
                foreach (string s in dates)                
                    comboLoggedDays.Items.Add(s);
                string _today = DateTime.Now.ToString().Split(' ')[0];
                if (!dates.Contains(_today))
                    comboLoggedDays.Items.Add(_today);
                

                bLog = new List<logItem>();
                lLog = new List<logItem>();
                dLog = new List<logItem>();
                foreach (string s in daysLog)
                {
                    string[] lines = s.Split(new string[] { "--Breakfast--" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "--Lunch--" }, StringSplitOptions.RemoveEmptyEntries)[0].Split('\n');
                    for (int i = 0; i < lines.Length;i++)
                    {
                        string st = lines[i];
                        if (st == "")
                            continue;
                        litm = new logItem();
                        litm._db = st.Split('|')[0];
                        litm.primKeyNo = st.Split('|')[1];
                        litm.grams = Convert.ToDouble(st.Split('|')[2]);
						bLog.Add(litm);
                    }
                    lines = s.Split(new string[] { "--Lunch--" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "--Dinner--" }, StringSplitOptions.RemoveEmptyEntries)[0].Split('\n');
                    for (int i = 0; i < lines.Length;i++)
                    {
                        string st = lines[i];
                        if (st == "")
                            continue;
                        litm = new logItem();
                        litm._db = st.Split('|')[0];
                        litm.primKeyNo = st.Split('|')[1];
                        litm.grams = Convert.ToDouble(st.Split('|')[2]);
						lLog.Add(litm);
                    }
                    lines = s.Split(new string[] { "--Dinner--" }, StringSplitOptions.RemoveEmptyEntries)[1].Split('\n');
                    for (int i = 0; i < lines.Length;i++)
                    {
                        string st = lines[i];
                        if (st == "")
                            continue;
                        litm = new logItem();
                        litm._db = st.Split('|')[0];
                        litm.primKeyNo = st.Split('|')[1];
                        litm.grams = Convert.ToDouble(st.Split('|')[2]);
						dLog.Add(litm);
                    }
                }
            }
            catch
            {
                if (MessageBox.Show("Warning: no data found for this user. Create some?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                else
                {
                    Directory.CreateDirectory($"{Application.StartupPath}{slash}usr");
                    frmProfile frmPr = new frmProfile();
                    frmPr.ShowDialog();
                    Directory.CreateDirectory($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}foodlog");
                }
            }


            string root = $"{Application.StartupPath}{slash}usr";
            foreach (string s in Directory.GetFiles(root))
                if (s.Split(Path.DirectorySeparatorChar)[s.Split(Path.DirectorySeparatorChar).Length - 1].StartsWith("profile"))
                {
                    try
                    {
                        currentUser.index = Convert.ToInt16(s.Replace("default", ""));
                    }
                    catch { }
                }
            string[] directs = Directory.GetDirectories(root);
            profDirects = new List<string>();
            frmProfile frmP = new frmProfile();
            for (int i = 0; i < directs.Length; i++)
                if (directs[i].EndsWith($"{slash}profile" + i.ToString()))
                    profDirects.Add(directs[i]);


            if (profDirects.Count == 0)
            {
                currentUser.index = 0;
                File.Create($"{Application.StartupPath}{slash}usr{slash}default0");
                if (frmP.ShowDialog() == DialogResult.Cancel)
                    Application.Exit();
            }


            currentUser.root = $"{root}{slash}profile{currentUser.index}{slash}";
            List<string> profData = importArray($"{currentUser.root}profile.TXT");
            currentUser.name = profData[0];
            currentUser.gender = profData[1];
            currentUser.age = Convert.ToInt16(profData[2]);
            currentUser.bf = Convert.ToDouble(profData[3]);
            currentUser.wt = Convert.ToInt16(profData[4]);
            currentUser.ht = Convert.ToInt16(profData[5]);
            currentUser.actLvl = Convert.ToInt16(profData[6]);
            currentUser.goal = profData[7];

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

            //MessageBox.Show(root + "\\usr\\profile" + loadIndex.ToString() + "\\foods\\names.txt");
            if (File.Exists($"{root}{slash}profile{currentUser.index}{slash}foods{slash}names.TXT"))
            {
                lstCustFoods = new List<string>();
                lstCustFoods = importArray($"{root}{slash}profile{currentUser.index}{slash}foods{slash}names.TXT");
                for (int i = 0; i < lstCustFoods.Count; i++)
                    lstBoxRecipes.Items.Add(lstCustFoods[i]);
            }

            comboLoggedDays.SelectedIndex = comboLoggedDays.Items.Count - 1;

            //loadup = false;
            //WORK HERE ARRGGH
            /*DataGridViewRow row = (DataGridViewRow)dataDay.Rows[0].Clone();
            row.Cells[0].Value = "Breakfast";
            dataDay.Rows.Add(row);
            //row.Cells[0].Value = "Lunch";
            //dataDay.Rows.Add(row);
            //row.Cells[0].Value = "Dinner";
            dataDay.Rows.Add(row);*/
        }

        List<string> lstCustFoods;
        private void comboExType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdvCalc.Enabled = false;
            int n = comboExType.SelectedIndex;
            if (n == 0)
                lblActType.Text = "Steps:";
            else if (n > 0 && n < 5)
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
            frmProfile frm = new frmProfile();
            frm.ShowDialog();

            comboLoggedDays.Items.Clear();
            foreach (string f in Directory.GetFiles($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}foodlog"))
                if (f.EndsWith(".TXT") && f.Contains("-"))
                    comboLoggedDays.Items.Add(f.Split(new char[] { '/', '\\' })[f.Split(new char[] { '/', '\\' }).Length - 1].Replace(".TXT", ""));
            try { comboLoggedDays.SelectedIndex = comboLoggedDays.Items.Count - 1; }
            catch { }
            this.Text = $"Nutritracker — {importArray($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.TXT")[0]}";

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

            if (!File.Exists($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}foodlog{slash}{dte}.TXT"))
            {
                MessageBox.Show("No food data found for this day, add something to create a log.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string breakfast = importArray($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}foodlog{slash}{dte}.TXT")[0];
            string lunch = importArray($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}foodlog{slash}{dte}.TXT")[1];
            string dinner = importArray($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}foodlog{slash}{dte}.TXT")[2];
            breakfast = breakfast.Replace("Breakfast|", "");
            lunch = lunch.Replace("Lunch|", "");
            dinner = dinner.Replace("Dinner|", "");


            int bDay = 1, lDay = 3, dDay = 5, tDay = 7;



            //breakfast
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Breakfast")
                {
                    bDay = i + 1;
                    break;
                }
            string[] breaks = breakfast.Split(new string[] { "||" }, StringSplitOptions.None);
            List<string> breaks2 = new List<string>();
            for (int k = 0; k < breaks.Length; k++)
            {
                if (breaks[k] == null || breaks[k] == "" || breaks[k].Length < 1)
                    continue;
                breaks2.Add(breaks[k]);
            }

            if (breaks2.Count < 1)
                goto Lunch;
            dataDay.Rows.Insert(bDay, breaks2.Count);
            for (int k = 0; k < breaks2.Count; k++)
            {
                breaks2[k] = breaks2[k].Replace("||", "");
                for (int i = 0; i < dataDay.ColumnCount; i++)
                    dataDay.Rows[bDay + k].Cells[i].Value = breaks2[k].Split('|')[i];
            }


        //lunch
        Lunch:
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Lunch")
                {
                    lDay = i + 1;
                    break;
                }
            string[] lunchs = lunch.Split(new string[] { "||" }, StringSplitOptions.None);
            List<string> lunchs2 = new List<string>();
            for (int k = 0; k < lunchs.Length; k++)
            {
                if (lunchs[k] == null || lunchs[k] == "" || lunchs[k].Length < 1)
                    continue;
                lunchs2.Add(lunchs[k]);
            }

            if (lunchs2.Count < 1)
                goto Dinner;
            dataDay.Rows.Insert(lDay, lunchs2.Count);
            for (int k = 0; k < lunchs2.Count; k++)
            {
                lunchs2[k] = lunchs2[k].Replace("||", "");
                for (int i = 0; i < dataDay.ColumnCount; i++)
                    dataDay.Rows[lDay + k].Cells[i].Value = lunchs2[k].Split('|')[i];
            }

        //dinner
        Dinner:
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
            {
                try
                {
                    if (dataDay.Rows[i].Cells[0].Value.ToString() == "Dinner")
                    {
                        dDay = i + 1;
                        break;
                    }
                }
                catch { }
            }
            string[] dins = dinner.Split(new string[] { "||" }, StringSplitOptions.None);
            List<string> dins2 = new List<string>();

            for (int k = 0; k < dins.Length; k++)
            {
                if (dins[k] == null || dins[k] == "" || dins[k].Length < 1)
                    continue;
                dins2.Add(dins[k]);
            }

            if (dins2.Count < 1)
                goto Total;
            dataDay.Rows.Insert(dDay, dins2.Count);
            for (int k = 0; k < dins2.Count; k++)
            {
                dins2[k] = dins2[k].Replace("||", "");
                for (int i = 0; i < dataDay.ColumnCount; i++)
                    dataDay.Rows[dDay + k].Cells[i].Value = dins2[k].Split('|')[i];
            }

        //totals
        Total:
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                try
                {
                    if (dataDay.Rows[i].Cells[0].Value.ToString() == "Totals")
                        tDay = i + 1;
                }
                catch { }

            tabulateNutrientColumns();



            //
            //
            //

            if (currentUser.actLvl == 0)
                mFactor = 1.2;
            else if (currentUser.actLvl == 1)
                mFactor = 1.375;
            else if (currentUser.actLvl == 2)
                mFactor = 1.55;
            else if (currentUser.actLvl == 3)
                mFactor = 1.725;
            else if (currentUser.actLvl == 4)
                mFactor = 1.9;
            if (currentUser.gender == "female")
                bmr = Convert.ToInt32(mFactor * (10 * 0.4536 * currentUser.wt + 6.25 * 2.54 * currentUser.ht - 5 * currentUser.age) + 5);
            else
                bmr = Convert.ToInt32(mFactor * (10 * 0.4536 * currentUser.wt + 6.25 * 2.54 * currentUser.ht - 5 * currentUser.age) - 161);


            int m = dataExercise.RowCount - 2;
            for (int i = 0; i < m; i++)
                if (dataExercise[0, i].Value == "Existing")
                {
                    dataExercise[2, i].Value = Math.Round(bmr / 1440.0, 2);
                    dataExercise[4, i].Value = bmr.ToString() + " kcal";
                }

            int sum = 0;
            for (int i = 0; i < m; i++)
            {
                try
                {
                    sum += getBiggestInt(dataExercise[4, i].Value.ToString());
                }

                catch { }
            }

            dataExercise[4, m].Value = sum.ToString() + " kcal";

            //add old exercise & meals
            //tabulate rows
            //reload list box
            //MessageBox.Show(loadIndex.ToString());
        }

        private void dataDay_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*
            try { label1.Text = dataDay.Rows[1].Cells["columnSrvngSze"].Value.ToString(); }
            catch{ }
            */
        }

        #region undo delete rows
        private DataGridViewRow row;
        private int n;
        private void button11_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dataDay.Rows[7].Cells[1].Value.ToString());
            //MessageBox.Show(dataDay.Rows.Count.ToString());
            try
            {
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
                n = dataDay.SelectedRows[0].Index;
                //MessageBox.Show(dataDay.Rows[0].Cells[0].Value.ToString());
                //MessageBox.Show(tDay.ToString());
                //MessageBox.Show(n.ToString());
                int o = dataDay.Rows.Count;
                row = dataDay.Rows[n];
                //MessageBox.Show(row.Cells[0].Value.ToString());
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

                string fp = $"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}foodlog{slash}{dte}.TXT";
                string textB = "";
                textB += dataDay.Rows[bDay - 1].Cells[0].Value.ToString() + "|";
                for (int m = bDay; m < lDay - 2; m++)
                {

                    for (int i = 0; i < dataDay.ColumnCount; i++)
                    {
                        try
                        {
                            if (dataDay.Rows[m].Cells[i].Value.ToString() == "")
                                textB += " ";
                            textB += dataDay.Rows[m].Cells[i].Value.ToString();
                        }
                        catch { textB += " "; }
                        textB += "|";
                    }
                    textB += "|";
                }
                string textL = "";
                textL += dataDay.Rows[lDay - 1].Cells[0].Value.ToString() + "|";
                for (int m = lDay; m < dDay - 2; m++)
                {

                    for (int i = 0; i < dataDay.ColumnCount; i++)
                    {
                        try
                        {
                            if (dataDay.Rows[m].Cells[i].Value.ToString() == "")
                                textL += " ";
                            textL += dataDay.Rows[m].Cells[i].Value.ToString();
                        }
                        catch { textL += " "; }
                        textL += "|";
                    }
                    textL += "|";
                }
                string textD = "";
                textD += dataDay.Rows[dDay - 1].Cells[0].Value.ToString() + "|";
                for (int m = dDay; m < tDay - 2; m++)
                {

                    for (int i = 0; i < dataDay.ColumnCount; i++)
                    {
                        try
                        {
                            if (dataDay.Rows[m].Cells[i].Value.ToString() == "")
                                textD += " ";
                            textD += dataDay.Rows[m].Cells[i].Value.ToString();
                        }
                        catch { textD += " "; }
                        textD += "|";
                    }
                    textD += "|";
                }
                string[] text = { textB, textL, textD };
                //MessageBox.Show("1");
                File.WriteAllLines(fp, text);
                tabulateNutrientColumns();
            }
            catch
            {
                try
                {
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
                    n = dataDay.CurrentCell.RowIndex;
                    //MessageBox.Show(dataDay.Rows[0].Cells[0].Value.ToString());
                    //MessageBox.Show(tDay.ToString());
                    //MessageBox.Show(n.ToString());
                    int o = dataDay.Rows.Count;
                    row = dataDay.Rows[n];
                    //MessageBox.Show(row.Cells[0].Value.ToString());
                    undoToolStripMenuItem.Enabled = true;
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

                    string fp = $"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}foodlog{slash}{dte}.TXT";
                    string textB = "";
                    textB += dataDay.Rows[bDay - 1].Cells[0].Value.ToString() + "|";
                    for (int m = bDay; m < lDay - 2; m++)
                    {

                        for (int i = 0; i < dataDay.ColumnCount; i++)
                        {
                            try
                            {
                                if (dataDay.Rows[m].Cells[i].Value.ToString() == "")
                                    textB += " ";
                                textB += dataDay.Rows[m].Cells[i].Value.ToString();
                            }
                            catch { textB += " "; }
                            textB += "|";
                        }
                        textB += "|";
                    }
                    string textL = "";
                    textL += dataDay.Rows[lDay - 1].Cells[0].Value.ToString() + "|";
                    for (int m = lDay; m < dDay - 2; m++)
                    {

                        for (int i = 0; i < dataDay.ColumnCount; i++)
                        {
                            try
                            {
                                if (dataDay.Rows[m].Cells[i].Value.ToString() == "")
                                    textL += " ";
                                textL += dataDay.Rows[m].Cells[i].Value.ToString();
                            }
                            catch { textL += " "; }
                            textL += "|";
                        }
                        textL += "|";
                    }
                    string textD = "";
                    textD += dataDay.Rows[dDay - 1].Cells[0].Value.ToString() + "|";
                    for (int m = dDay; m < tDay - 2; m++)
                    {

                        for (int i = 0; i < dataDay.ColumnCount; i++)
                        {
                            try
                            {
                                if (dataDay.Rows[m].Cells[i].Value.ToString() == "")
                                    textD += " ";
                                textD += dataDay.Rows[m].Cells[i].Value.ToString();
                            }
                            catch { textD += " "; }
                            textD += "|";
                        }
                        textD += "|";
                    }
                    //MessageBox.Show("2");
                    string[] text = { textB, textL, textD };
                    File.WriteAllLines(fp, text);
                    tabulateNutrientColumns();
                }
                catch { }
            }
            dataDay.Focus();
        }


        private void dataDay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Delete")
            {
                btnRemoveFood.PerformClick();
            }
        }
        #endregion

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = false;
            //MessageBox.Show("k");
            dataDay.Rows.Insert(n, 1);
            for (int i = 0; i < row.Cells.Count; i++)
                dataDay.Rows[n].Cells[i].Value = row.Cells[i].Value;
            int bDay = 11, lDay = 33, dDay = 55, tDay = 77;
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Breakfast")
                    bDay = i;
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Lunch")
                    lDay = i;

            string fp = $"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}foodlog{slash}{dte}.TXT";
            string textB = "";
            textB += dataDay.Rows[bDay].Cells[0].Value.ToString() + "|";
            for (int m = bDay + 1; m < lDay - 1; m++)
            {

                for (int i = 0; i < dataDay.ColumnCount; i++)
                {
                    try
                    {
                        if (dataDay.Rows[m].Cells[i].Value.ToString() == "")
                            textB += " ";
                        textB += dataDay.Rows[m].Cells[i].Value.ToString();
                    }
                    catch { textB += " "; }
                    textB += "|";
                }
                textB += "|";
            }

            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Lunch")
                    lDay = i;
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Dinner")
                    dDay = i;
            string textL = "";
            textL += dataDay.Rows[lDay].Cells[0].Value.ToString() + "|";
            //MessageBox.Show(textL);
            for (int m = lDay + 1; m < dDay - 1; m++)
            {

                for (int i = 0; i < dataDay.ColumnCount; i++)
                {
                    try
                    {
                        if (dataDay.Rows[m].Cells[i].Value.ToString() == "")
                            textL += " ";
                        textL += dataDay.Rows[m].Cells[i].Value.ToString();
                    }
                    catch { textL += " "; }
                    textL += "|";
                }
                textL += "|";
            }

            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Dinner")
                    dDay = i;
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Totals")
                    tDay = i;
            string textD = "";
            textD += dataDay.Rows[dDay].Cells[0].Value.ToString() + "|";
            for (int m = dDay + 1; m < tDay - 1; m++)
            {
                for (int i = 0; i < dataDay.ColumnCount; i++)
                {
                    try
                    {
                        if (dataDay.Rows[m].Cells[i].Value.ToString() == "")
                            textD += " ";
                        textD += dataDay.Rows[m].Cells[i].Value.ToString();
                    }
                    catch { textD += " "; }
                    textD += "|";
                }
                textD += "|";
            }
            //MessageBox.Show("2");
            string[] text = { textB, textL, textD };
            File.WriteAllLines(fp, text);


            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Totals")
                    tDay = i + 1;
            tabulateNutrientColumns();
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "-" || e.KeyChar.ToString() == ".")
                e.Handled = true;
        }




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
                if (dataExercise[0, y].Value == "Walking" && dataExercise[1, y].Value == "Steps")
                    dataExercise[3, y].Value = val.ToString() + " steps";
                else if (dataExercise[0, y].Value == "Walking" || dataExercise[0, y].Value == "Jogging" || dataExercise[0, y].Value == "Running" ||
                         dataExercise[0, y].Value == "Sprinting")
                    dataExercise[3, y].Value = val.ToString() + " min";
                else if (dataExercise[0, y].Value == "Other")
                    dataExercise[3, y].Value = val.ToString() + " kcal";
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

            if (dataExercise[0, y].Value == "Walking" && dataExercise[1, y].Value == "Steps")
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
            else if (dataExercise[0, y].Value == "Walking")
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
            else if (dataExercise[0, y].Value == "Jogging")
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
            else if (dataExercise[0, y].Value == "Running")
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
            else if (dataExercise[0, y].Value == "Sprinting")
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
            {
                try
                {
                    int q = getBiggestInt(dataExercise[4, i].Value.ToString());
                    //MessageBox.Show(q.ToString());
                    sum += q;
                }
                catch
                {
                }
            }
            //MessageBox.Show(m.ToString());
            dataExercise[4, m].Value = sum.ToString() + " kcal";

            bH = false;
        }

        string[] currentBasicFields;
        string[] basicFields ={
            "NDBNo",
            "FoodName",
            "Cals",
            "FatTot",
            "FatSat",
            "CarbsTot",
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
            "GL_Load",
            "GI_Rating",
            "IF_Rating",
            "ORAC"
        };
        
        
        private List<string> fetchLogsFields(List<logItem> nLog)
        {
            List<string> dbs = new List<string>();
            foreach (logItem litm in nLog)
                if (!dbs.Contains(litm._db))
                    dbs.Add(litm._db);

            string pubDbRoot = $"{Application.StartupPath}{slash}usr{slash}share{slash}DBs";
            List<string> lFields = new List<string>();
            foreach (string s in Directory.GetDirectories(pubDbRoot))
            {
                if (s.Split(Path.DirectorySeparatorChar)[s.Split(Path.DirectorySeparatorChar).Length - 1].StartsWith("_"))
                    continue;
                string[] nutKeylines = File.ReadAllLines($"{s}{slash}_nutKeyPairs.TXT");
                foreach (string st in nutKeylines)
                    if (basicFields.Contains(st.Split('|')[1]) && !lFields.Contains(st.Split('|')[1]))
                        lFields.Add(st.Split('|')[1]);                    
            }
            return lFields;
        }
        public class colObj
        {
            public string file;
            public string header;
            public string unit = "";
        }
        public static List<colObj> activeFieldsWithUnits;
        public List<colObj> fetchLogsFieldsWithUnits(List<logItem> nLog)
        {
            List<string> dbs = new List<string>();
            foreach (logItem litm in nLog)
                if (!dbs.Contains(litm._db))
                    dbs.Add(litm._db);

            string pubDbRoot = $"{Application.StartupPath}{slash}usr{slash}share{slash}DBs";
            List<colObj> lFields = new List<colObj>();
            foreach (string s in Directory.GetDirectories(pubDbRoot))
            {
                if (s.Split(Path.DirectorySeparatorChar)[s.Split(Path.DirectorySeparatorChar).Length - 1].StartsWith("_"))
                    continue;
                string[] nutKeylines = File.ReadAllLines($"{s}{slash}_nutKeyPairs.TXT");
                string[] unitKeyLines = File.ReadAllLines($"{s}{slash}_unitKeyPairs.TXT");
                foreach (string st in nutKeylines)
                    if (basicFields.Contains(st.Split('|')[1]))
                    {
                        bool dupe = false;
                        foreach (colObj _c in lFields)
                            if (_c.header == st.Split('|')[1])
                                dupe = true;
                        if (dupe)
                            continue;
                        colObj c = new colObj();
                        c.file = st.Split('|')[0];
                        c.header = st.Split('|')[1];
                        foreach (string str in unitKeyLines)
                            if (str.Split('|')[0] == c.file)
                                c.unit = str.Split('|')[1];
                        lFields.Add(c);
                    }

            }
            activeFieldsWithUnits = lFields;
            return lFields;
        }
        class fObj {
            public string file = "";
            public string field = "";
            public string nutVal = "";
            public string index = "";
            public string unit = "";
        };
        private string[] fetchNutValues(string[] fields, logItem l, bool includeUnits = false){
            //dataDay.Columns.Clear();
            //dataDay.Columns.Add("Spacer", "");
            List<fObj> fObjs = new List<fObj>();
            l.index = 0;
            if (l._db == "USDAstock")
            {
                string dbDir = $"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}{l._db}";
                string[] nkp = File.ReadAllLines($"{dbDir}{slash}_nutKeyPairs.TXT");
                foreach (string s in currentBasicFields)
                    foreach (string st in nkp)
                        if (st.Split('|')[1] == s)
                        {
                            fObj f = new fObj();
                            f.field = s;
                            //dataDay.Columns.Add(s, s);
                            f.file = st.Split('|')[0];
                            fObjs.Add(f);
                        }
                string[] nutVals = new string[fObjs.Count()];
                string[] lines = new string[0];
                for (int i = 0; i < fObjs.Count(); i++)
                    if (fObjs[i].field == "NDBNo")
                        lines = File.ReadAllLines($"{dbDir}{slash}{fObjs[i].file}");
                for (int i = 0; i < lines.Length; i++)
                    if (lines[i] == l.primKeyNo && l.index == 0)
                        l.index = i;                

                for (int i = 0; i < fObjs.Count(); i++)
                    foreach (string s in fields)
                        if (s == fObjs[i].field)
                            fObjs[i].nutVal = File.ReadAllLines($"{dbDir}{slash}{fObjs[i].file}")[l.index];

                string[] ukp = File.ReadAllLines($"{dbDir}{slash}_unitKeyPairs.TXT");
                for (int i = 0; i < fObjs.Count(); i++)
                    foreach (string s in ukp)
                        if (fObjs[i].file == s.Split('|')[0])
                            fObjs[i].unit = s.Split('|')[1];

                double conv = l.grams / 100;
                if (includeUnits)
                    for (int i = 0; i < fObjs.Count(); i++)
                        nutVals[i] = (fObjs[i].unit == "")?fObjs[i].nutVal:$"{fObjs[i].nutVal} ({fObjs[i].unit})";
                else
                    for (int i = 0; i < fObjs.Count(); i++)
                        nutVals[i] = fObjs[i].nutVal;
                return nutVals;
            }
            else
                return null;         
        }

        public static List<logItem> litms;
        private void comboLoggedDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataDay.Columns.Clear();
            dte = comboLoggedDays.SelectedItem.ToString();
            string[] daysLog = File.ReadAllText($"{userRoot}{slash}foodLog.TXT").Replace("\r", "").Split(new string[] { "===========\n" }, StringSplitOptions.RemoveEmptyEntries);


            bLog = new List<logItem>();
            lLog = new List<logItem>();
            dLog = new List<logItem>();
            foreach (string s in daysLog)
            {
                if (s.Split('\n')[0] != dte)
                    continue;
                string[] lines = s.Split(new string[] { "--Breakfast--" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "--Lunch--" }, StringSplitOptions.RemoveEmptyEntries)[0].Split('\n');
                foreach (string st in lines)
                {
                    if (st == "")
                        continue;
                    litm = new logItem();
                    litm._db = st.Split('|')[0];
                    litm.primKeyNo = st.Split('|')[1];
                    litm.grams = Convert.ToDouble(st.Split('|')[2]);
                    bLog.Add(litm);
                }
                lines = s.Split(new string[] { "--Lunch--" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "--Dinner--" }, StringSplitOptions.RemoveEmptyEntries)[0].Split('\n');
                foreach (string st in lines)
                {
                    if (st == "")
                        continue;
                    litm = new logItem();
                    litm._db = st.Split('|')[0];
                    litm.primKeyNo = st.Split('|')[1];
                    litm.grams = Convert.ToDouble(st.Split('|')[2]);
                    lLog.Add(litm);
                }
                lines = s.Split(new string[] { "--Dinner--" }, StringSplitOptions.RemoveEmptyEntries)[1].Split('\n');
                foreach (string st in lines)
                {
                    if (st == "")
                        continue;
                    litm = new logItem();
                    litm._db = st.Split('|')[0];
                    litm.primKeyNo = st.Split('|')[1];
                    litm.grams = Convert.ToDouble(st.Split('|')[2]);
                    dLog.Add(litm);
                }
            }

            litms = new List<logItem>();
            litms.AddRange(bLog);
            litms.AddRange(lLog);
            litms.AddRange(dLog);
            dataDay.Columns.Add("MealNo", "Meal No.");
            currentBasicFields = fetchLogsFields(litms).ToArray();
            foreach (colObj c in fetchLogsFieldsWithUnits(litms))
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
                col.Name = c.header;
                col.HeaderText = (c.unit == "") ? c.header : $"{c.header} ({c.unit})";
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
            dataDay.Rows.Insert(bDay, bLog.Count());
            for (int i = 0; i < bLog.Count(); i++)
            {
                string[] ingrieds = fetchNutValues(currentBasicFields, bLog[i]);//new string[currentBasicFields.Length];
                for (int j = 0; j < currentBasicFields.Length; j++)
                    dataDay.Rows[bDay + i].Cells[j + 1].Value = ingrieds[j];
            }

            //lunch
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value != null && dataDay.Rows[i].Cells[0].Value.ToString() == "Lunch")
                    lDay = i + 1;
            dataDay.Rows.Insert(lDay, lLog.Count());
            for (int i = 0; i < lLog.Count(); i++)
            {
                string[] ingrieds = fetchNutValues(currentBasicFields, lLog[i]);//new string[currentBasicFields.Length];
                for (int j = 0; j < currentBasicFields.Length; j++)
                    dataDay.Rows[lDay + i].Cells[j + 1].Value = ingrieds[j];
            }

            //dinner
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value != null && dataDay.Rows[i].Cells[0].Value.ToString() == "Dinner")
                    dDay = i + 1;
            dataDay.Rows.Insert(dDay, dLog.Count());
            for (int i = 0; i < dLog.Count(); i++)
            {
                string[] ingrieds = fetchNutValues(currentBasicFields, dLog[i]);//new string[currentBasicFields.Length];
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
            if (e.KeyCode.ToString() == "Delete")
                btnRemEx.PerformClick();
        }
        private void txtExerciseVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtExerciseVal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                btnAddEx.PerformClick();
                e.SuppressKeyPress = true;
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


            if (txtExerciseVal.Text.StartsWith("0") && txtExerciseVal.TextLength > 0 && !mH)
            {
                n = txtExerciseVal.SelectionStart - 1;
                mH = true;
                txtExerciseVal.Text = txtExerciseVal.Text.Remove(0, 1);
                mH = false;
                txtExerciseVal.SelectionStart = n;
                return;
            }

            if (digs == 4 && !mH)
            {
                int n = 0;
                if (!txtExerciseVal.Text.Contains(","))
                {
                    n = txtExerciseVal.SelectionStart + 1;
                    mH = true;
                    txtExerciseVal.Text = txtExerciseVal.Text.Insert(1, ",");
                    mH = false;
                    txtExerciseVal.SelectionStart = n;
                    return;
                }
                else if (txtExerciseVal.Text[2] == ',')
                {
                    n = txtExerciseVal.SelectionStart;
                    mH = true;
                    txtExerciseVal.Text = txtExerciseVal.Text.Replace(",", "");
                    txtExerciseVal.Text = txtExerciseVal.Text.Insert(1, ",");
                    mH = false;
                    txtExerciseVal.SelectionStart = n;
                    return;
                }

            }
            else if (digs == 5 && !mH)
            {
                //MessageBox.Show(digs.ToString());
                n = txtExerciseVal.SelectionStart;
                mH = true;
                txtExerciseVal.Text = txtExerciseVal.Text.Replace(",", "");
                txtExerciseVal.Text = txtExerciseVal.Text.Insert(2, ",");
                mH = false;
                txtExerciseVal.SelectionStart = n;
            }
            else if (digs < 4)
            {
                if (txtExerciseVal.Text.Contains(","))
                {
                    n = txtExerciseVal.SelectionStart - 1;
                    txtExerciseVal.Text = txtExerciseVal.Text.Replace(",", "");
                    txtExerciseVal.SelectionStart = n > 0 ? n : 0;
                }
            }

            if (ex > 0)
                btnAddEx.Enabled = true;
            else
                btnAddEx.Enabled = false;
        }
        //private static List<string> lstCustFood;
        private void customFoodEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEditCustFoods.PerformClick();
        }

        private void editProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnProfile.PerformClick();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmCustomFood frmCust = new Nutritracker.frmCustomFood();
            frmCust.Show(this);
        }

        private void btnDetailReport_Click(object sender, EventArgs e)
        {
            frmDetailReport frmDet = new frmDetailReport();
            frmDet.ShowDialog();
        }
        
        private void bodyFatCalcToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmBodyfatCalc.currentName = importArray($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}")[0];
            frmBodyfatCalc frmBFC = new Nutritracker.frmBodyfatCalc();
            frmBFC.gender = importArray($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.TXT")[1];
            frmBFC.age = Convert.ToInt32(importArray($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.TXT")[2]);
            frmBFC.wt = Convert.ToInt32(importArray($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.TXT")[4]);
            frmBFC.ht = Convert.ToInt32(importArray($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.TXT")[5]);
            frmBFC.ShowDialog();
        }

        private void viewDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDetailReport.PerformClick();
        }

        private void naturalPotentialCalcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLeanPotentialCalc.bodyfat = Convert.ToInt32(importArray($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.TXT")[3]);
            frmLeanPotentialCalc.weight = Convert.ToInt32(importArray($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.TXT")[4]);
            frmLeanPotentialCalc.height = Convert.ToInt32(importArray($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}profile.TXT")[5]);
            frmLeanPotentialCalc frmNatPot = new Nutritracker.frmLeanPotentialCalc();            
            frmNatPot.ShowDialog();
        }

        private void parseExcelSpreadsheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmParseCustomDatabase frmParse = new frmParseCustomDatabase();
            frmParse.Show(this);
        }

        private void btnSearchUserD_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs") && !Directory.Exists($"{Application.StartupPath}{slash}usr{slash}profile{currentUser.index}{slash}DBs"))
            {
                MessageBox.Show("There don't seem to be any shared OR user loaded databases.  Try going to the spreadsheet wizard (under tools) to import some, or manually copy some from another user.", "Nothing found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                frmSearchFoods frmAddSFood = new frmSearchFoods();
                frmAddSFood.Show(this);
            }
            //else if (importArray(Application.StartupPath + "\\usr\\share"))
        }

        private void addSearchCommonFoodsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            btnSearch.PerformClick();
        }

        private void manageCustomFieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageField frmMF = new frmManageField(this);
            frmMF.ShowDialog();
        }

        private void manageStandaloneDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDB frmMDB = new frmManageDB();
            frmMDB.ShowDialog();
        }

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
            this.Close();
        }

        private void manageRelativeDBPairsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPairRelDB frmGRDB = new frmPairRelDB();
            frmGRDB.ShowDialog();
        }
    }
}