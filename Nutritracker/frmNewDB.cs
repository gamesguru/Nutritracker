using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Nutritracker
{
    public partial class frmNewDB : Form
    {
        private frmParseCustomDatabase mainForm = null;
        public frmNewDB(Form callingForm)
        {
            mainForm = callingForm as frmParseCustomDatabase;
            InitializeComponent();
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

        private class nutNameKey
        {
            public string columnHeader;
            public string nutrient;
        }
        List<nutNameKey> nutNameKeys;
        List<string> activeNutes;
        string slash = Path.DirectorySeparatorChar.ToString();
        public List<string> arr = new List<string>();
        public int n = 0;
        int p;
        private void frmNewDB_Load(object sender, EventArgs e)
        {
            txtLoc.Text = $"{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}";
            /////////////////////////////////////////////////lblRowCount.Text = $"Your database will have {n} entries and {m} columns";
            List<string> tmp = new List<string>();
            for (int i=0;i<arr.Count;i++)
                tmp.Add($"{arr[i]}=");            
            txtConfig.Lines = tmp.ToArray();

            //gather active nutrients, work this into frmMain as it is with logRunner
            activeNutes = new List<string>();
            foreach (string s in File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}activeFields.TXT"))
                if (!s.StartsWith("#") && s.Contains("|"))
                    activeNutes.Add(s.Split('#')[0].Split('|')[0]);
            foreach (string s in activeNutes)
                lstBoxNutes.Items.Add(s);
            //

            p = 0;
            nutNameKeys = new List<nutNameKey>();
            foreach (string s in txtConfig.Lines)
                if (arr.Contains(s.Split('=')[0]))
                {
                    p++;
                    nutNameKey nm = new nutNameKey();
                    nm.columnHeader = s.Split('=')[0];
                    try
                    {
                        nm.nutrient = s.Split('=')[1];
                        if (activeNutes.Contains(nm.nutrient))
                            nutNameKeys.Add(nm);
                    }
                    catch { }
                }

            lblStatus.Text = $"You have {n} entries — {p} properties ({nutNameKeys.Count} configured)";
            //for (int i = 0; i < arr.Count; i++)
            //{
            //    string s = arr[i];
            //    listBox1.Items.Add(s);
            //    string s2 = "";
            //    try {  s2 = s.Substring(0, 3); }
            //    catch {  s2 = s.Substring(0, 2); }

            //    char[] iC = new char[] {'/', '\\', ':', '*', '?', '"', '<', '>', '|', ' '};
            //    foreach (char c in iC)
            //        if (s2.Contains(c))
            //            s2 = s2.Replace(c, 'X');
                

            //    s2 = s2.Replace("(", i.ToString()).Replace(" ", "X");

            //    if (!listBox2.Items.Contains(s2.ToUpper()))
            //        listBox2.Items.Add(s2.ToUpper());
            //    else { listBox2.Items.Add(s2.ToUpper() + i.ToString()); }
            //}
            //nameKeyPairs = new List<string>();
            //for (int i = 0; i < listBox1.Items.Count; i++)            
            //    nameKeyPairs.Add(listBox1.Items[i].ToString() + "|" + listBox2.Items[i].ToString());

            
            //lblColumnCount.Text = $"Your {listBox1.Items.Count} columns";
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (radioShared.Checked)            
                txtLoc.Text = $"{slash}usr{slash}share{slash}DBs{slash}{txtName.Text}";            
            else            
                txtLoc.Text = $"{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}{txtName.Text}";

            if (txtName.TextLength > 2 && nameColumn > -1)
                btnCreate.Enabled = true;

            if (txtName.TextLength < 2)
                btnCreate.Enabled = false;

        }
        private void radioShared_CheckedChanged(object sender, EventArgs e)
        {
            if (radioShared.Checked)
                txtLoc.Text = $"{slash}usr{slash}share{slash}DBs{slash}{txtName.Text}";
            else
                txtLoc.Text = $"{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}{txtName.Text}";
        }


        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsSeparator(e.KeyChar) && e.KeyChar != ',')
                e.Handled = true;
        }

        private void btnClearChoices_Click(object sender, EventArgs e)
        {
            //lblSearchField.Text = "N/A";
            //lblCalories.Text = "N/A";
            searchKey = "";
            calorieKey = "";
            btnCreate.Enabled = false;
        }

        int nameColumn = -1;
        string searchKey = "";
        string calorieKey = "";
        List<string> nameKeyPairs;
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //if (nameColumn > -1 && MessageBox.Show($"About to set {listBox1.Text} as the name column.  After this you will be able to press 'Create'", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //{
            //    nameColumn = listBox1.SelectedIndex;
            //    btnCreate.Enabled = true;
            //}
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string fp = Application.StartupPath + txtLoc.Text;
            if (Directory.Exists(fp))
            {
                DialogResult dRG = MessageBox.Show("A directory with this name was already found, are you sure you want to overwrite it?", "Overwrite database?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dRG == DialogResult.No)
                    return;
                string[] st = Directory.GetFiles(fp);
                for (int i = 0; i < st.Length; i++)
                    File.Delete(st[i]);
                goto nxt;
            }
            Directory.CreateDirectory(fp);
            nxt:
            //for (int i = 0; i < listBox1.Items.Count; i++)
            //{
            //    string[] colVal = new string[n];
            //    for (int j = 0; j < n; j++)
            //        colVal[j] = mainForm.getVal(j, i);
            //    File.WriteAllLines($"{fp}{slash}{listBox2.Items[i]}.TXT", colVal); //writes the stores for each unit
            //}
            //File.WriteAllLines(fp + $"{slash}_nameKeyPairs.txt", nameKeyPairs);
            string[] firstCommit = { searchKey + "|FoodName", calorieKey + "|Calories" };
            File.WriteAllLines($"{fp}{slash}_nutKeyPairs.TXT", firstCommit); //writes the initial key pairs for nutrients and txt files

			List<string> nameKeyPairs = new List<string>();
			List<string> unitKeyPairs = new List<string>();

            //for (int i = 0; i < listBox2.Items.Count; i++){
            //    string header = frmParseCustomDatabase.columns[i].header;
            //    nameKeyPairs.Add(listBox2.Items[i].ToString() + ".TXT|" + header);

            //    string unit = "";
            //    try{
            //        unit = header.Split('[')[1].Split(']')[0].ToLower().Replace(" ", "");
            //    }
            //    catch{
            //        try{
            //            unit = header.Split('(')[1].Split(')')[0].ToLower().Replace(" ", "");
            //        }
            //        catch{
            //            unit = "per " + header.Split(new string[] { " per " }, StringSplitOptions.None)[1].Trim();
            //        }
            //    }

            //    if (unit.Length > 0)
            //        unitKeyPairs.Add($"{listBox2.Items[i]}.TXT|" + unit);
            //}
            File.WriteAllLines($"{fp}{slash}_nameKeyPairs.TXT", nameKeyPairs); //writes the names (and often) the units
            if (unitKeyPairs.Count() > 0)
                File.WriteAllLines($"{fp}{slash}_unitKeyPairs.TXT", unitKeyPairs);

            MessageBox.Show("Database created successfully.  Please use the search function on the main page to try it out.  Your first time using it, you will be asked to assign real nutrient names to the imported fields.  The software isn't able to do that yet.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void txtConfig_TextChanged(object sender, EventArgs e)
        {
            activeNutes = new List<string>();
            activeNutes.Add("FoodName");
            activeNutes.Add("NDBNo");
            foreach (string s in File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}activeFields.TXT"))
                if (!s.StartsWith("#") && s.Contains("|"))
                    activeNutes.Add(s.Split('#')[0].Split('|')[0]);
            //

            p = 0;
            nutNameKeys = new List<nutNameKey>();
            foreach (string s in txtConfig.Lines)
                if (arr.Contains(s.Split('=')[0]))
                {
                    p++;
                    nutNameKey nm = new nutNameKey();
                    nm.columnHeader = s.Split('=')[0];
                    try
                    {
                        nm.nutrient = s.Split('=')[1];
                        if (activeNutes.Contains(nm.nutrient))
                            nutNameKeys.Add(nm);
                    }
                    catch { }
                }

            lblStatus.Text = $"You have {n} entries — {p} properties ({nutNameKeys.Count} configured)";
            lstBoxNutes.Items.Clear();
            foreach (string s in activeNutes)
                if (!txtConfig.Text.Contains($"={s}"))
                    lstBoxNutes.Items.Add(s);
        }

        private void lstBoxNutes_MouseClick(object sender, MouseEventArgs e)
        {
            try {
                string updated = txtConfig.Text.Substring(0, txtConfig.SelectionStart);
                updated += lstBoxNutes.Text;
                updated += txtConfig.Text.Substring(txtConfig.SelectionStart, txtConfig.TextLength - txtConfig.SelectionStart - 1);
                txtConfig.Text = updated;
            }
            catch { }
        }
    }
}