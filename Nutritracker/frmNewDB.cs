using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

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
        List<string> configuredFields;
        List<string> primKeys;
        string slash = Path.DirectorySeparatorChar.ToString();
        public List<string> arr = new List<string>();
        public int n = 0;
        int p;
        progBarWait pbw;
        private void frmNewDB_Load(object sender, EventArgs e)
        {
            txtLoc.Text = $"{slash}usr{slash}share{slash}DBs{slash}";

            //gather active nutrients, TODO: work this into frmMain as it is with logRunner
            configuredFields = new List<string>();
            configuredFields.Add("NDBNo");
            configuredFields.Add("FoodName");
            foreach (string s in File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}configured_fields.py"))
                if (!s.StartsWith("#") && s.Contains("|"))
                    configuredFields.Add(s.Split('#')[0].Split('|')[0]);
            foreach (string s in configuredFields)
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
            tmp = null;


            //adds the primary keys
            pbw = new progBarWait();
            Thread t = new Thread(() =>
            {
                pbw.ShowDialog();
                pbw.finished = true;
            });
            t.Start();
            while (!pbw.ready)
                Thread.Sleep(60);

            pbw.setTitle($"Identifying possible primary keys...");
            pbw.setProgMax(frmParseCustomDatabase.columns.Length, 1);
            List<string> _isUniqueList;
            primKeys = new List<string>();
            int _z = 0;
            foreach (frmParseCustomDatabase.Column c in frmParseCustomDatabase.columns)
            {
                if (pbw.abort)
                    break;
                _z++;
                pbw.setLblCurObj(c.header);
                bool unique = true;
                _isUniqueList = new List<string>();
                foreach (string s in c.items)
                {
                    _isUniqueList.Add(s);
                    if (_isUniqueList.Distinct().Count() != _isUniqueList.Count)
                    {
                        unique = false;
                        break;
                    }
                }
                _isUniqueList = null;
                if (unique)
                    primKeys.Add(c.header);
            }
            if (pbw.abort)
                this.Close();
            this.Activate();
            if (primKeys.Count == 0)
            {
                //TODO: make generate extra column
                chkGeneratePrimKey.Checked = true;
                chkGeneratePrimKey.Enabled = false;
            }
            foreach (string s in primKeys)
                comboPrimKey.Items.Add(s);
            comboPrimKey.SelectedIndex = 0;
            lblStatus.Text = $"You have {n} entries — {arr.Count} properties (0 configured)";
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtLoc.Text = $"{slash}usr{slash}share{slash}DBs{slash}{txtName.Text}";

            if (txtName.TextLength > 2)
                btnCreate.Enabled = true;

            if (txtName.TextLength < 2)
                btnCreate.Enabled = false;
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsSeparator(e.KeyChar) && e.KeyChar != ',')
                e.Handled = true;
        }

        List<string> entryKeyLang;
        List<nutEntry> nutEntries;
        List<string> itmsOut;
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
                foreach (string s in configuredFields)
                    foreach (string st in txtConfig.Lines)
                        if (st.Replace(" ", "") == $"{arr[i]}={s}")
                            colInts.Add(i);

            itmsOut = new List<string>();
            entryKeyLang = new List<string>();

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
            nutEntries = new List<nutEntry>();
            nutEntry nu;
            pbw = new progBarWait();
            Thread t = new Thread(() =>
               {
                   pbw.ShowDialog();
                   pbw.finished = true;
               });
            t.Start();
            while (!pbw.ready)
                Thread.Sleep(60);
            pbw.setTitle("Pairing the keys...");
            pbw.setProgMax(n, 50);
            for (int i = 0; i < n; i++) //loop over each ENTRY in the database, e.g. 8760 for USDA
            {
                nu = new nutEntry();
                bool prevMatch = false;
                string title = mainForm.getVal(i, langColumn).Substring(0, 3);
                pbw.setLblCurObj(title);
                foreach (nutEntry nut in nutEntries)
                    if (nut.fileName.ToUpper() == title.ToUpper())
                        prevMatch = true;

                nu.fileName = prevMatch ? $"{title}{i}" : title;
                string[] res = { "CON", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9" };
                foreach (string s in res)
                    if (nu.fileName == s)
                        nu.fileName += "_WX";
                string lang = "", key = "";
                foreach (int j in colInts)
                {
                    string nutrient = "";
                    string val = mainForm.getVal(i, j);
                    foreach (nutNameKey nut in nutNameKeys)
                        if (nut.columnHeader == arr[j])
                            nutrient = nut.nutrient;
                    nu.conts.Add($"[{nutrient}]{val}");

                    if (j == langColumn)
                        lang = val; //hashLangOut.Add($"{nu.fileName}|{val}");
                    else if (j == keyColumn)
                        key = val; //hashKeyOut.Add($"{nu.fileName}|{val}");
                }
                entryKeyLang.Add($"{nu.fileName}|{key}|{lang}");
                nutEntries.Add(nu);
                nu = null;
            }

            File.WriteAllLines($"{fp}{slash}_fieldInit.ini", txtConfig.Lines);
            File.WriteAllLines($"{fp}{slash}_entryKeyLang.ini", entryKeyLang);
            //File.WriteAllLines($"{fp}{slash}_hashLang.ini", hashLangOut);
            //File.WriteAllLines($"{fp}{slash}_hashKey.ini", hashKeyOut);
            pbw = new progBarWait();
            t = new Thread(() =>
               {
                   pbw.ShowDialog();
                   pbw.finished = true;
                   pbw = null;
               });
            t.Start();
            while (!pbw.ready)
                Thread.Sleep(60);
            pbw.setTitle("Writing the entries...");
            n = nutEntries.Count;
            pbw.setProgMax(n, 50);
            for (int i = 0; i < n; i++)
            {
                pbw.setLblCurObj(nutEntries[i].fileName);
                File.WriteAllLines($"{fp}{slash}{nutEntries[i].fileName}.TXT", nutEntries[i].conts);
            }
            entryKeyLang = null;
            nutEntries = null;
            itmsOut = null;
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
                        if (configuredFields.Contains(nm.nutrient))
                            nutNameKeys.Add(nm);
                    }
                    catch { }
                }

            //updates label and listBox
            lblStatus.Text = $"You have {n} entries — {p} properties ({nutNameKeys.Count} configured)";
            lstBoxNutes.Items.Clear();
            foreach (string s in configuredFields)
                if (!txtConfig.Text.Contains($"={s}"))
                    lstBoxNutes.Items.Add(s);
        }

        private void lstBoxNutes_MouseClick(object sender, MouseEventArgs e)
        {
            //copies over to txtConfig
            try
            {
                //int n = txtConfig.Lines[0].Length;
                string updated = txtConfig.Text.Substring(0, txtConfig.SelectionStart);
                updated += lstBoxNutes.Text;
                updated += txtConfig.Text.Substring(txtConfig.SelectionStart, txtConfig.TextLength - txtConfig.SelectionStart - 1);
                txtConfig.Text = updated;
                //txtConfig.SelectionStart += n + lstBoxNutes.Text.Length;
            }
            catch { }
        }

        private void chkGeneratePrimKey_CheckedChanged(object sender, EventArgs e)
        {
            comboPrimKey.Items.Clear();
            if (chkGeneratePrimKey.Checked)
                comboPrimKey.Items.Add("primKey");
            foreach (string s in primKeys)
                comboPrimKey.Items.Add(s);
            comboPrimKey.SelectedIndex = 0;
        }
    }
}