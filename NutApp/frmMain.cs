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

namespace NutApp
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




        public static int mealSpe;

        public static int mealIndex = 0;


        private void button1_Click(object sender, EventArgs e)
        {
            frmAddFood addF = new frmAddFood();
            addF.Show(this);

            int bDay = 1, lDay = 3, dDay = 5, tDay = 7;

            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Breakfast")
                    bDay = i + 1;
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Lunch")
                    lDay = i + 1;
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Dinner")
                    dDay = i + 1;
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Totals")
                    tDay = i + 1;


            addFood = addF.ingried;
            if (addF.ingried == null)
                return;

            if (mealSpe == 0)
            {
                dataDay.Rows.Insert(bDay, 1);
                for (int i = 0; i < addFood.Length; i++)
                    dataDay.Rows[bDay].Cells[i].Value = addFood[i];
            }
            else if (mealSpe == 1)
            {
                dataDay.Rows.Insert(lDay, 1);
                for (int i = 0; i < addFood.Length; i++)
                    dataDay.Rows[lDay].Cells[i].Value = addFood[i];
            }
            else
            {
                dataDay.Rows.Insert(dDay, 1);
                for (int i = 0; i < addFood.Length; i++)
                    dataDay.Rows[dDay].Cells[i].Value = addFood[i];
            }


            tabulateNutrientColumns();
            //
            //
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

            string fp = $"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}foodlog{slash}" + dte + ".TXT";
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
            File.WriteAllLines(fp, text);

            undoToolStripMenuItem.Enabled = false;
        }

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

        /*DataGridViewRow row = (DataGridViewRow) dataDay.Rows[0].Clone();
row.Cells[0].Value = "XYZ";
row.Cells[1].Value = 50.2;
dataDay.Rows.Add(row);*/

        public static string[] addFood { get; set; }
        public static int bmr = 0;
        double mFactor = 1.2;
        bool loadup = true;
        List<string> profDirects;
        public static int profIndex = 0;
        public static string dte;
        public static string slash = Path.DirectorySeparatorChar.ToString();
        #region profile info
        string name = "";
        bool gender = false;
        int age = 0;
        int bodyFat = 0;
        int wt = 0;
        int ht = 0;
        int activityLvl = 0;
        int overallGoal = 0;
        #endregion
        private void frmMain_Load(object sender, EventArgs e)
        {
            dte = DateTime.Today.ToString("MM-dd-yyyy");
            try
            {
                foreach (string f in Directory.GetFiles($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}foodlog"))
                    if (f.EndsWith(".TXT") && f.Contains("-"))
                        comboLoggedDays.Items.Add(f.Split(new char[] { '/', '\\' })[f.Split(new char[] { '/', '\\' }).Length - 1].Replace(".TXT", ""));

                //for (int i=0;i< comboLoggedDays.Items.Count;i++)
                //    if (comboLoggedDays.Items[)
                comboLoggedDays.SelectedIndex = comboLoggedDays.Items.Count - 1;

                foreach (string s in comboLoggedDays.Items)
                    if (s == dte)
                        comboLoggedDays.SelectedText = s;
            }
            catch { MessageBox.Show("Warning: no data found for this user.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            
            //dateTimePicker1.Text = dte.Replace("-", "/");

            //if (defaultIndex > -1)
            //    loadIndex = defaultIndex;

            string root = $"{Application.StartupPath}{slash}usr";
            profIndex = Convert.ToInt16(Directory.GetFiles(root)[0].Replace($"{root}{slash}default", ""));
            string[] directs = Directory.GetDirectories(root);
            profDirects = new List<string>();
            frmProfile frmP = new frmProfile();
            for (int i = 0; i < directs.Length; i++)
            {
                if (directs[i].EndsWith($"{slash}profile" + i.ToString()))
                    profDirects.Add(directs[i]);
            }

            if (profDirects.Count == 0)
            {
                profIndex = 0;
                Properties.Settings.Default.Save();
                if (frmP.ShowDialog() == DialogResult.Cancel)
                    Application.Exit();
            }

            List<string> profData = importArray($"{root}{slash}profile{profIndex}{slash}profile{profIndex}.TXT");

            name = profData[0];
            gender = profData[1] == "female";
            age = Convert.ToInt16(profData[2]);
            bodyFat = Convert.ToInt16(profData[3]);
            wt = Convert.ToInt16(profData[4]);
            ht = Convert.ToInt16(profData[5]);
            activityLvl = Convert.ToInt16(profData[6]);
            overallGoal = Convert.ToInt16(profData[7]);

            lblCurrentUser.Text = $"Current User: {name}";

            /*dataDay.Rows.Add("Breakfast");
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

            
            string breakfast = importArray(Application.StartupPath + "\\usr\\profile" + profIndex.ToString() + "\\foodlog\\" + dte + ".txt")[0];
            string lunch = importArray(Application.StartupPath + "\\usr\\profile" + profIndex.ToString() + "\\foodlog\\" + dte + ".txt")[1];
            string dinner = importArray(Application.StartupPath + "\\usr\\profile" + profIndex.ToString() + "\\foodlog\\" + dte + ".txt")[2];
            breakfast = breakfast.Replace("Breakfast|", "");
            lunch = lunch.Replace("Lunch|", "");
            dinner = dinner.Replace("Dinner|", "");


            int bDay = 1, lDay = 3, dDay = 5, tDay = 7;



            //breakfast
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Breakfast")
                    bDay = i + 1;
            string[] breaks = breakfast.Split(new string[] { "||" }, StringSplitOptions.None);
            List<string> breaks2 = new List<string>();
            for (int k = 0; k < breaks.Length; k++)
                if (breaks[k] != null && breaks[k] != "")
                    breaks2.Add(breaks[k]);

            dataDay.Rows.Insert(bDay, breaks2.Count);
            for (int k = 0; k < breaks2.Count; k++)
            {
                breaks2[k] = breaks2[k].Replace("||", "");
                for (int i = 0; i < dataDay.ColumnCount; i++)
                    dataDay.Rows[bDay + k].Cells[i].Value = breaks2[k].Split('|')[i];
            }

            //lunch
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Lunch")
                    lDay = i + 1;
            string[] lunchs = lunch.Split(new string[] { "||" }, StringSplitOptions.None);
            List<string> lunchs2 = new List<string>();
            for (int k = 0; k < lunchs.Length; k++)
                if (lunchs[k] != null && lunchs[k] != "")
                    lunchs2.Add(lunchs[k]);

            dataDay.Rows.Insert(lDay, lunchs2.Count);
            for (int k = 0; k < lunchs2.Count; k++)
            {
                lunchs2[k] = lunchs2[k].Replace("||", "");
                for (int i = 0; i < dataDay.ColumnCount; i++)
                    dataDay.Rows[lDay + k].Cells[i].Value = lunchs2[k].Split('|')[i];
            }

            //dinner
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
            {
                try
                {
                    if (dataDay.Rows[i].Cells[0].Value.ToString() == "Dinner")
                        dDay = i + 1;
                }
                catch{ }
            }
            string[] dins = dinner.Split(new string[] { "||" }, StringSplitOptions.None);
            List<string> dins2 = new List<string>();
            for (int k = 0; k < dins.Length; k++)
                if (dins[k] != null && dins[k] != "")
                    dins2.Add(dins[k]);

            dataDay.Rows.Insert(dDay, dins2.Count);
            for (int k = 0; k < dins2.Count; k++)
            {
                dins2[k] = dins2[k].Replace("||", "");
                for (int i = 0; i < dataDay.ColumnCount; i++)
                    dataDay.Rows[dDay + k].Cells[i].Value = dins2[k].Split('|')[i];
            }


            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                try
                {
                    if (dataDay.Rows[i].Cells[0].Value.ToString() == "Totals")
                        tDay = i + 1;
                }
                catch { }

            tabulateNutrientColumns();*/

            //
            //
            //

            comboExType.SelectedIndex = 0;
            dataExercise.Rows.Add("Existing");
            dataExercise.Rows[0].Height = 50;
            string actLvl = "#NULL";
			switch (activityLvl)
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
            if (activityLvl == 0)
                mFactor = 1.2;
            else if (activityLvl == 1)
                mFactor = 1.375;
            else if (activityLvl == 2)
                mFactor = 1.55;
            else if (activityLvl == 3)
                mFactor = 1.725;
            else if (activityLvl == 4)
                mFactor = 1.9;
            if (gender)
                bmr = Convert.ToInt32(mFactor * (10 * 0.4536 * wt + 6.25 * 2.54 * ht - 5 * age) + 5);
            else
                bmr = Convert.ToInt32(mFactor * (10 * 0.4536 * wt + 6.25 * 2.54 * ht - 5 * age) - 161);


            dataExercise.Rows[0].Cells[2].Value = Math.Round(bmr / 1440.0, 2);
            dataExercise.Rows[0].Cells[3].Value = "1440 min";
            dataExercise.Rows[0].Cells[4].Value = bmr.ToString() + " kcal";
            dataExercise.Rows[0].ReadOnly = true;
            //dataExercise.Rows.Insert(1, "", "", "", "", "");
            dataExercise.Rows.Insert(1, "Totals", "", "", "", bmr.ToString() + " kcal"); //virus shiet
            dataExercise.Rows[1].DefaultCellStyle.BackColor = Color.LightGray;
            //

            comboMeal.SelectedIndex = 0;

            //MessageBox.Show(root + "\\usr\\profile" + loadIndex.ToString() + "\\foods\\names.txt");
            if (File.Exists(root + $"{slash}profile{profIndex.ToString()}{slash}foods{slash}names.TXT"))
            {
                lstCustFoods = new List<string>();
                lstCustFoods = importArray(root + $"{slash}profile{profIndex.ToString()}{slash}foods{slash}names.TXT");
                for (int i = 0; i < lstCustFoods.Count; i++)
                    lstBoxRecipes.Items.Add(lstCustFoods[i]);
            }

            loadup = false;
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

        //static public int loadIndex = 0;

        private void btnProfile_Click(object sender, EventArgs e)
        {
            frmProfile frm = new frmProfile();
            frm.ShowDialog();

            comboLoggedDays.Items.Clear();
            foreach (string f in Directory.GetFiles($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}foodlog"))
                if (f.EndsWith(".TXT") && f.Contains("-"))
                    comboLoggedDays.Items.Add(f.Split(new char[] { '/', '\\' })[f.Split(new char[] { '/', '\\' }).Length - 1].Replace(".TXT", ""));

            lblCurrentUser.Text = "Current User: " +
                                  importArray($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}profile{profIndex.ToString()}.TXT")[0];
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

            if (!File.Exists($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}foodlog{slash}" + dte + ".TXT"))
            {
                MessageBox.Show("No food data found for this day, add something to create a log.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string breakfast = importArray($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}foodlog{slash}" + dte + ".TXT")[0];
            string lunch = importArray($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}foodlog{slash}" + dte + ".TXT")[1];
            string dinner = importArray($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}foodlog{slash}" + dte + ".TXT")[2];
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
                        
            if (activityLvl == 0)
                mFactor = 1.2;
            else if (activityLvl == 1)
                mFactor = 1.375;
            else if (activityLvl == 2)
                mFactor = 1.55;
            else if (activityLvl == 3)
                mFactor = 1.725;
            else if (activityLvl == 4)
                mFactor = 1.9;
            if (gender)
                bmr = Convert.ToInt32(mFactor * (10 * 0.4536 * wt + 6.25 * 2.54 * ht - 5 * age) + 5);
            else
                bmr = Convert.ToInt32(mFactor * (10 * 0.4536 * wt + 6.25 * 2.54 * ht - 5 * age) - 161);


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

        #region delete undo rows
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

                string fp = $"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}foodlog{slash}" + dte + ".TXT";
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

                    string fp = $"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}foodlog{slash}" + dte + ".TXT";
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

            string fp = $"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}foodlog{slash}" + dte + ".TXT";
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

        private void btnAddEx_Click(object sender, EventArgs e)
        {
            editing = true;
            dataExercise.Rows.Insert(0);
            int j = comboExType.SelectedIndex;
            if (j == 0)
            {
                dataExercise.Rows[0].Cells[0].Value = "Walking";
                dataExercise.Rows[0].Cells[1].Value = "Steps";
                double c = ex * 0.001 * (28 + 0.27 * (wt - 100));
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
                double cpm = 53 + 0.535 * (wt - 100);
                dataExercise.Rows[0].Cells[2].Value = Math.Round(d * cpm / ex, 3);
                dataExercise.Rows[0].Cells[3].Value = txtExerciseVal.Text + " min";
                dataExercise.Rows[0].Cells[4].Value = Math.Round(d * cpm, 1) + " kcal";
            }
            else if (j == 2)
            {
                dataExercise.Rows[0].Cells[0].Value = "Jogging";
                dataExercise.Rows[0].Cells[1].Value = "Brisk";
                double d = ex / 20.0;
                double cpm = 53 + 0.535 * (wt - 100);
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
                double cpm = 53 + 0.535 * (wt - 100);
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
                double cpm = 53 + 0.535 * (wt - 100);
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
            editing = false;
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
                /*if (dataExercise[0, x].Value == "Walking" || dataExercise[0, x].Value == "Jogging" || dataExercise[0, x].Value == "Running" ||
dataExercise[0, x].Value == "Sprinting")
                    dataExercise[3, x].Value = val.ToString() + " min";
                else if (dataExercise[0, x].Value == "Other")
                    dataExercise[3, x].Value = val.ToString() + " kcal";*/
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
                double c = val * 0.001 * (28 + 0.27 * (wt - 100));
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
                double cpm = 53 + 0.535 * (wt - 100);
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
                double cpm = 53 + 0.535 * (wt - 100);
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
                double cpm = 53 + 0.535 * (wt - 100);
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
                double cpm = 53 + 0.535 * (wt - 100);
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

        private string oldval = "";
        private int x = 0;
        private int y = 0;
        private bool editing = false;
        #region cell focus set x,y

        #endregion

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

                    editing = true;
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
        private void addSearchExtendedFoodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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
            frmCustomFood frmCust = new NutApp.frmCustomFood();
            frmCust.Show(this);
        }

        private void btnDetailReport_Click(object sender, EventArgs e)
        {
            frmDetailReport frmDet = new frmDetailReport();
            frmDet.ShowDialog();
        }
        
        private void bodyFatCalcToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmBodyfatCalc.currentName = importArray($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}profile" + profIndex.ToString() + ".TXT")[0];
            frmBodyfatCalc frmBFC = new NutApp.frmBodyfatCalc();
            frmBFC.gender = importArray($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}profile" + profIndex.ToString() + ".TXT")[1];
            frmBFC.age = Convert.ToInt32(importArray($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}profile" + profIndex.ToString() + ".TXT")[2]);
            frmBFC.wt = Convert.ToInt32(importArray($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}profile" + profIndex.ToString() + ".TXT")[4]);
            frmBFC.ht = Convert.ToInt32(importArray($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}profile" + profIndex.ToString() + ".TXT")[5]);
            frmBFC.ShowDialog();
        }

        private void viewDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDetailReport.PerformClick();
        }

        private void naturalPotentialCalcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLeanPotentialCalc.bodyfat = Convert.ToInt32(importArray($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}profile" + profIndex.ToString() + ".TXT")[3]);
            frmLeanPotentialCalc.weight = Convert.ToInt32(importArray($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}profile" + profIndex.ToString() + ".TXT")[4]);
            frmLeanPotentialCalc.height = Convert.ToInt32(importArray($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}profile" + profIndex.ToString() + ".TXT")[5]);
            frmLeanPotentialCalc frmNatPot = new NutApp.frmLeanPotentialCalc();            
            frmNatPot.ShowDialog();
        }

        private void parseExcelSpreadsheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmParseCustomDatabase frmParse = new frmParseCustomDatabase();
            frmParse.Show(this);
        }

        private void btnSearchUserD_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs") && !Directory.Exists($"{Application.StartupPath}{slash}usr{slash}profile" + profIndex.ToString() + "{slash}DBs"))
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

        private void decomposeRecipeToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void comboLoggedDays_SelectedIndexChanged(object sender, EventArgs e)
        {            
            dte = comboLoggedDays.SelectedItem.ToString();
            string breakfast = "";
            string lunch = "";
            string dinner = "";
            try
            {
                breakfast = importArray($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}foodlog{slash}{dte}.TXT")[0];
                lunch = importArray($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}foodlog{slash}{dte}.TXT")[1];
                dinner = importArray($"{Application.StartupPath}{slash}usr{slash}profile{profIndex.ToString()}{slash}foodlog{slash}{dte}.TXT")[2];
                breakfast = breakfast.Replace("Breakfast|", "");
                lunch = lunch.Replace("Lunch|", "");
                dinner = dinner.Replace("Dinner|", "");
            }
            catch
            {
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
                if (dataDay.Rows[i].Cells[0].Value.ToString() == "Breakfast")
                    bDay = i + 1;
            string[] breaks = breakfast.Split(new string[] { "||" }, StringSplitOptions.None);
            List<string> breaks2 = new List<string>();
            for (int k = 0; k < breaks.Length; k++)
                if (breaks[k] != null && breaks[k] != "")
                    breaks2.Add(breaks[k]);
            if (breaks2.Count == 0)
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
                    lDay = i + 1;
            string[] lunchs = lunch.Split(new string[] { "||" }, StringSplitOptions.None);
            List<string> lunchs2 = new List<string>();
            for (int k = 0; k < lunchs.Length; k++)
                if (lunchs[k] != null && lunchs[k] != "")
                    lunchs2.Add(lunchs[k]);
            if (lunchs2.Count == 0)
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
                        dDay = i + 1;
                }
                catch { }
            }
            string[] dins = dinner.Split(new string[] { "||" }, StringSplitOptions.None);
            List<string> dins2 = new List<string>();
            for (int k = 0; k < dins.Length; k++)
                if (dins[k] != null && dins[k] != "")
                    dins2.Add(dins[k]);
            if (dins2.Count == 0)
                goto Totes;
            dataDay.Rows.Insert(dDay, dins2.Count);
            for (int k = 0; k < dins2.Count; k++)
            {
                dins2[k] = dins2[k].Replace("||", "");
                for (int i = 0; i < dataDay.ColumnCount; i++)
                    dataDay.Rows[dDay + k].Cells[i].Value = dins2[k].Split('|')[i];
            }

            Totes:
            for (int i = 0; i < dataDay.Rows.Count - 2; i++)
                try
                {
                    if (dataDay.Rows[i].Cells[0].Value.ToString() == "Totals")
                        tDay = i + 1;
                }
                catch { }

            tabulateNutrientColumns();
        }
    }
}