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

            //gather active nutrients, TODO: work this into frmMain as it is with logRunner
            activeNutes = new List<string>();
            activeNutes.Add("NDBNo");
            activeNutes.Add("FoodName");
            foreach (string s in File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}activeFields.TXT"))
                if (!s.StartsWith("#") && s.Contains("|"))
                    activeNutes.Add(s.Split('#')[0].Split('|')[0]);
            foreach (string s in activeNutes)
                lstBoxNutes.Items.Add(s);

            //populate txtConfig box
            List<string> tmp = new List<string>();
            for (int i = 0; i < arr.Count; i++)
                tmp.Add($"{arr[i]}=");        
            txtConfig.Lines = tmp.ToArray();

            //loads the columnHeader-nutrientName key-val pairs
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

        int nameColumn = -1;
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
            }
            else
                Directory.CreateDirectory(fp);

            List<string> itmsOut = new List<string>();
            List<string> hashMapOut = new List<string>();
            for (int i = 0; i < n; i++) //loop over each ENTRY in the database, e.g. 8760 for USDA
            {
                itmsOut.Add()
                //////////////////////////??????????????????
            }

            
            
            File.WriteAllLines($"{fp}{slash}_hashInfo.ini", txtConfig.Lines);
            File.WriteAllLines($"{fp}{slash}_hashMap.ini", hashMapOut);
            //for (int i = 0; i < listBox1.Items.Count; i++)
            //{
            //    string[] colVal = new string[n];
            //    for (int j = 0; j < n; j++)
            //        colVal[j] = mainForm.getVal(j, i);
            //    File.WriteAllLines($"{fp}{slash}{listBox2.Items[i]}.TXT", colVal); //writes the stores for each unit
            //}
            //File.WriteAllLines(fp + $"{slash}_nameKeyPairs.txt", nameKeyPairs);
            //         string[] firstCommit = { searchKey + "|FoodName", calorieKey + "|Calories" };
            //         File.WriteAllLines($"{fp}{slash}_nutKeyPairs.TXT", firstCommit); //writes the initial key pairs for nutrients and txt files

            //List<string> nameKeyPairs = new List<string>();
            //List<string> unitKeyPairs = new List<string>();

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
            //File.WriteAllLines($"{fp}{slash}_nameKeyPairs.TXT", nameKeyPairs); //writes the names (and often) the units
            //if (unitKeyPairs.Count() > 0)
            //    File.WriteAllLines($"{fp}{slash}_unitKeyPairs.TXT", unitKeyPairs);

            MessageBox.Show("Database created successfully.  Please use the search function on the main page to try it out.  Your first time using it, you will be asked to assign real nutrient names to the imported fields.  The software isn't able to do that yet.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void txtConfig_TextChanged(object sender, EventArgs e)
        {
            //re-tallies the active nutrients
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

            //updates label and listBox
            lblStatus.Text = $"You have {n} entries — {p} properties ({nutNameKeys.Count} configured)";
            lstBoxNutes.Items.Clear();
            foreach (string s in activeNutes)
                if (!txtConfig.Text.Contains($"={s}"))
                    lstBoxNutes.Items.Add(s);
        }

        private void lstBoxNutes_MouseClick(object sender, MouseEventArgs e)
        {
            //copies over to txtConfig
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