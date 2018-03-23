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
        private class nutEntry
        {
            public string fileName;
            public List<string> nuts = new List<string>();
            public List<string> vals = new List<string>();
            public List<string> conts = new List<string>();
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
            int tmax = 0;
            foreach (string s in arr)
                if (s.Length > tmax)
                    tmax = s.Length;
            for (int i = 0; i < arr.Count; i++)
                tmp.Add($"{arr[i].PadRight(tmax, ' ')}=");        
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

            if (txtName.TextLength > 2)//////////////// && nameColumn > -1)
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

            List<int> colInts = new List<int>();
            for (int i = 0; i < arr.Count; i++)
                foreach (string s in activeNutes)
                    foreach (string st in txtConfig.Lines)
                        if (st.Replace(" ", "") == $"{arr[i]}={s}")
                            colInts.Add(i);
            
            List<string> itmsOut = new List<string>();
            List<string> hashLangOut = new List<string>();
            List<string> hashKeyOut = new List<string>();
            string langColumnStr = "", keyColumnStr = "";
            int langColumn = 0, keyColumn = 0;
            foreach (nutNameKey na in nutNameKeys)
                if (na.nutrient == "FoodName")
                    langColumnStr = na.columnHeader;
                else if (na.nutrient == "NDBNo")
                    keyColumnStr = na.columnHeader;
            for (int i = 0; i < arr.Count; i++)
                if (arr[i] == keyColumnStr)
                    keyColumn = i;
                else if (arr[i] == langColumnStr)
                    langColumn = i;
            List<nutEntry> nutEntries = new List<nutEntry>();
            nutEntry nu;
            for (int i = 0; i < n; i++) //loop over each ENTRY in the database, e.g. 8760 for USDA
            {
                nu = new nutEntry();
                bool prevMatch = false;
                string title = mainForm.getVal(i, langColumn).Substring(0, 3);
                foreach (nutEntry nut in nutEntries)
                    if (nut.fileName.ToUpper() == title.ToUpper())
                        prevMatch = true;

                nu.fileName = prevMatch ? $"{title}{i}" : title;
                string[] res = { "CON", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9" };
                foreach (string s in res)
                    if (nu.fileName == s)
                        nu.fileName += "_WX";
                foreach (int j in colInts)
                {
                    string nutrient = "";
                    string val = mainForm.getVal(i, j);
                    foreach (nutNameKey nut in nutNameKeys)
                        if (nut.columnHeader == arr[j])
                            nutrient = nut.nutrient;
                    nu.conts.Add($"[{nutrient}]{val}");

                    if (j == langColumn)
                        hashLangOut.Add($"{nu.fileName}|{val}");
                    else if (j == keyColumn)
                        hashKeyOut.Add($"{nu.fileName}|{val}");
                }
                nutEntries.Add(nu);
                nu = null;
            }
            
			File.WriteAllLines($"{fp}{slash}_hashInfo.ini", txtConfig.Lines);
			File.WriteAllLines($"{fp}{slash}_hashLang.ini", hashLangOut);
			File.WriteAllLines($"{fp}{slash}_hashKey.ini", hashKeyOut);

            foreach (nutEntry nut in nutEntries)
                File.WriteAllLines($"{fp}{slash}{nut.fileName}.TXT", nut.conts);

            MessageBox.Show("Database created successfully.  Please use the search function on the main page to try it out.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void txtConfig_TextChanged(object sender, EventArgs e)
        {
            //re-tallies the active nutrients
            p = 0;
            nutNameKeys = new List<nutNameKey>();
            foreach (string s in txtConfig.Lines)
                if (arr.Contains(s.Split('=')[0].Replace(" ", "")))
                {
                    p++;
                    nutNameKey nm = new nutNameKey();
                    nm.columnHeader = s.Split('=')[0].Replace(" ", "");
                    try
                    {
                        nm.nutrient = s.Split('=')[1].Replace(" ", "");
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
                //int n = txtConfig.Lines[0].Length;
                string updated = txtConfig.Text.Substring(0, txtConfig.SelectionStart);
                updated += lstBoxNutes.Text;
                updated += txtConfig.Text.Substring(txtConfig.SelectionStart, txtConfig.TextLength - txtConfig.SelectionStart - 1);
                txtConfig.Text = updated;
                //txtConfig.SelectionStart += n + lstBoxNutes.Text.Length;
            }
            catch { }
        }
    }
}