using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Nutritracker
{
    public partial class frmSearchFoods : Form
    {
        public frmSearchFoods()
        {
            InitializeComponent();
        }
        public string[] substrings(string s, int n)
        {
            string[] sr = new string[s.Length - n + 1];
            for (int i = 0; i < s.Length - n + 1; i++)
                sr[i] = s.Substring(i, n).ToLower();

            return sr;
        }

        string[] pubDBs;
        string[] userDBs;
        string slash = Path.DirectorySeparatorChar.ToString();


        private void frmSearchFoods_Load(object sender, EventArgs e)
        {
            this.Text = $"Search and Add Foods to Log — [{frmMain.dte}]";
            try
            {
                comboMeal.SelectedIndex = Convert.ToInt32(File.ReadAllText($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}Meal.TXT"));
            }
            catch { }

            pubDBs = Directory.GetDirectories($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs");
            userDBs = Directory.GetDirectories($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs");

            if (pubDBs.Length == 0 && userDBs.Length == 0)
            {
                MessageBox.Show("No databases found, try going to the spreadsheet wizard or reinstalling the program.");
                this.Close();
            }

            for (int i = 0; i < userDBs.Length; i++)
            {
                userDBs[i] = userDBs[i].Replace($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}", "");
                if (!userDBs[i].StartsWith("f_user") && !userDBs[i].StartsWith("_"))
                    comboDBs.Items.Add(userDBs[i] + " (user)");
            }
            for (int i = 0; i < pubDBs.Length; i++)
            {
                pubDBs[i] = pubDBs[i].Replace($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}", "");
                if (!pubDBs[i].StartsWith("_"))
                    comboDBs.Items.Add(pubDBs[i] + " (share)");
            }

            if (comboDBs.Items.Count > 0 && File.Exists($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}Default.TXT"))
            {
                int index = Convert.ToInt32(File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}Default.TXT")[0]);
                comboDBs.SelectedIndex = index;
            }
        }

        private string db;
        private int n = 0;
        private Dictionary<string, string[]> fileLangDB;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            File.WriteAllText($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}Default.TXT", comboDBs.SelectedIndex.ToString());
            lstviewFoods.Clear();
            txtSrch.Clear();
            richTxtWarn.Text = "";
            warning = true;
            db = comboDBs.Text.Replace(" (share)", "").Replace(" (user)", "");
            if (comboDBs.Text.Contains("(share)"))
            {
                fileLangDB = new Dictionary<string, string[]>();
                List<string> fields = new List<string>();
                foreach (string s in File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}{db}{slash}_hashInfo.ini"))
                    if (frmMain.currentBasicFields.Contains(s.Split('=')[1]))
                        fields.Add(s.Split('=')[1]);
                string[] rawHashLang = File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}{db}{slash}_hashLang.ini");
                for (int i = 0; i < rawHashLang.Length; i++)
                    try { fileLangDB.Add(rawHashLang[i].Split('|')[1], File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}{db}{slash}{rawHashLang[i].Split('|')[0]}.TXT")); }
                    catch { fileLangDB.Add($"{rawHashLang[i].Split('|')[1]} {i}", File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}{db}{slash}{rawHashLang[i].Split('|')[0]}.TXT")); }
                n = rawHashLang.Length;
                txtSrch.Enabled = true;

                foreach (string s in fields)
                    lstviewFoods.Columns.Add(s);
                for (int i = 0; i < lstviewFoods.Columns.Count; i++)
                    lstviewFoods.Columns[i].Width = -2;

                if (n > 80000)
                {
                    richTxtWarn.Text = "There are more than 800 entries.\nPlease search to turn something up.";
                    return;
                }
                //TODO: revert to 800 (above) and fix general indexing
                itms = new List<ListViewItem>();
                for (int i = 0; i < fileLangDB.Count; i++)
                    itms.Add(getListItem(fields, fileLangDB.ElementAt(i).Value));
                
                //for (int j = 0; j < n; j)
                //{
                //    ListViewItem itm = new ListViewItem();
                //    for (int i = 0; i < nutKeyPairs.Length; i)
                //    {
                //        if (i == 0)
                //            itm.Text = fileLangDB[nutKeyPairs[i].Split('|')[0]][j];
                //        else
                //            itm.SubItems.Add(fileLangDB[nutKeyPairs[i].Split('|')[0]][j]);
                //    }
                //    itms.Add(itm);
                //}

                lstviewFoods.BeginUpdate();
                foreach (ListViewItem itm in itms)
                    lstviewFoods.Items.Add(itm);
                lstviewFoods.EndUpdate();

                //
                //
            }
            else
            {
                string[] files = Directory.GetFiles($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}{db}");
                fileLangDB = new Dictionary<string, string[]>();
                for (int i = 0; i < files.Length; i++)
                    fileLangDB.Add(files[i].Replace($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}{db}{slash}", ""), File.ReadAllLines(files[i]));

                string[] nutKeyPairs = File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}{db}_nutKeyPairs.TXT");
                for (int i = 0; i < nutKeyPairs.Length; i++)
                    if (!nutKeyPairs[i].StartsWith("#"))
                        lstviewFoods.Columns.Add(nutKeyPairs[i].Split('|')[1]);
            }
        }
        
        ListViewItem getListItem(List<string> fields, string[] dbEntry)
        {
            ListViewItem itm = new ListViewItem();
            foreach (string s in dbEntry)
                foreach (string st in fields)
                    if (s.StartsWith($"[{st}]"))
                        if (st == "FoodName")
                            itm.Text = s.Split(']')[1];
                        else
                            itm.SubItems.Add(s.Split(']')[1]);
            return itm;
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void txtSrch_TextChanged(object sender, EventArgs e)
        {
            srchTmout.Stop();
            srchTmout.Start();
            setWarningTextbox();
        }

        public void setWarningTextbox(string text = "")
        {
            richTxtWarn.Text = text;
        }

        string lastQuery = "";
        BackgroundWorker bw = new BackgroundWorker();
        List<ListViewItem> itms;
        private void srchTmout_Tick(object sender, EventArgs e)
        {
            if (txtSrch.Text.Trim() == lastQuery)
                return;
            bw.WorkerSupportsCancellation = true;
            bw.CancelAsync();
            bw = new BackgroundWorker();

            bw.DoWork += delegate
            {
                search();
                //try { search(); }
                //catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            };
            try
            {
                bw.RunWorkerAsync();
                lastQuery = txtSrch.Text.Trim();
            }
            catch { }
            this.UseWaitCursor = false;
        }

        //int resultCount = 0;
        List<string> range;
        private void search()
        {
            this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = true; }));
            string input = txtSrch.Text.ToUpper().Trim();
            if (input.Length < 2)
            //if (range.Count > 800)
            {
                this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = false; }));
                return;
            }

            string[] words = input.Split(new char[] { ' ', ',', '/' });
            string[] tmp = File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}{db}");
            range = new List<string>();
            foreach (string s in tmp)
                range.Add(s.Split('|')[1]);
            for (int k = 0; k < range.Count; k++)
                range[k] = range[k].ToUpper();
            //MessageBox.Show(words.Length.ToString());
            //if (words.Length > 1)
            lstviewFoods.Invoke(new MethodInvoker(delegate { lstviewFoods.Items.Clear(); }));

            int[] wCount = new int[range.Count];
            int n = words.Length - 1;
            //MessageBox.Show(n.ToString());
            for (int k = 0; k < n; k++)
                for (int i = 0; i < range.Count; i++)
                    if (words[k].Length > 2 && range[i].StartsWith(words[k]))
                        wCount[i] += Convert.ToInt32(1.5 * words[k].Length);
                    else if (words[k].Length > 2 && range[i].Contains(words[k]))
                        wCount[i] += Convert.ToInt32(words[k].Length);

            //MessageBox.Show(words[n]);

            int q = wCount.Max();
            //MessageBox.Show(q.ToString());
            if (q == 0)
            {
                this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = false; }));
                return;
            }
            int z = 0;
            itms = new List<ListViewItem>();
            //itms = new List<ListViewItem>();
            for (int i = q; i > (q == 1 ? 0 : q - 1); i--)
                for (int k = 0; k < range.Count; k++)
                    if (wCount[k] == i)
                    {
                        ListViewItem itm = new ListViewItem();
                        for (int m = 0; m < nutKeyPairs.Length; m++)
                            if (m == 0)
                                itm = new ListViewItem(fileLangDB[nutKeyPairs[m].Split('|')[0]][k]);
                            else
                                itm.SubItems.Add(fileLangDB[nutKeyPairs[m].Split('|')[0]][k]);
                        itms.Add(itm);
                    }
            z = itms.Count;
            if (z > 100 && !warn(z))
            {
                warning = true;
                this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = false; }));
                return;
            }

            lstviewFoods.Invoke(new MethodInvoker(delegate
            {
                lstviewFoods.BeginUpdate();
                foreach (ListViewItem itm in itms)
                    lstviewFoods.Items.Add(itm);
                lstviewFoods.EndUpdate();
            }));
            for (int i = 0; i < nutKeyPairs.Length; i++)
                if (nutKeyPairs[i].Contains("|FoodName"))
                    lstviewFoods.Invoke(new MethodInvoker(delegate { lstviewFoods.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent); }));

            this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = false; }));
        }

        private bool warn(int n)
        {
            this.Invoke(new MethodInvoker(delegate { richTxtWarn.Text = $"Search for {n} foods? It may go slow\nPress enter to continue.."; }));
            return false;
        }

        bool warning = false;
        private void txtSrch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && warning)
            {
                e.Handled = true;
                ignoreWarn();
            }
        }
        private void richTxtWarn_MouseClick(object sender, MouseEventArgs e)
        {
            if (warning)
                ignoreWarn();
        }

        private void ignoreWarn()
        {
            //if (!richTxtWarn.Enabled)
            //return;
            richTxtWarn.Text = "searching...";
            lstviewFoods.Items.Clear();
            bw = new BackgroundWorker();
            bw.DoWork += delegate
            {
                this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = true; }));

                lstviewFoods.Invoke(new MethodInvoker(delegate
                {
                    lstviewFoods.BeginUpdate();
                    foreach (ListViewItem itm in itms)
                        lstviewFoods.Items.Add(itm);
                    lstviewFoods.EndUpdate();
                }));
                for (int i = 0; i < nutKeyPairs.Length; i++)
                    if (nutKeyPairs[i].Contains("|FoodName"))
                        lstviewFoods.Invoke(new MethodInvoker(delegate { lstviewFoods.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent); }));

                warning = false;
                this.Invoke(new MethodInvoker(delegate
                {
                    richTxtWarn.Text = "Finished!";
                    lstviewFoods.Focus();
                    try
                    {
                        lstviewFoods.Items[0].Focused = true;
                        lstviewFoods.Items[0].Selected = true;
                    }//lstviewFoods.SelectedIndices.Add(0); }
                    catch { }
                }));
                this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = false; }));
            };
            bw.RunWorkerAsync();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            try { grams = Convert.ToDouble(txtQty.Text); }
            catch
            {
                grams = 0;
            }
            selectCheck();
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && btnAdd.Enabled)
                btnAdd.PerformClick();
        }

        private void comboMeal_SelectedIndexChanged(object sender, EventArgs e)
        {
            File.WriteAllText($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}DBs{slash}Meal.TXT", comboMeal.SelectedIndex.ToString());
        }

        private void swapOrManageUserFieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageField frmMF = new frmManageField(this);
            frmMF.ShowDialog();
        }

        string ndbno = "";
        double grams = 0.0;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            db = comboDBs.Text.Split(' ')[0];
            grams = 0;
            try { grams = Convert.ToDouble(txtQty.Text); }
            catch
            {
                MessageBox.Show("Not a valid weight.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (lstviewFoods.SelectedItems.Count == 0)
            {
                MessageBox.Show("No food selected.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (grams == 0.0)
            {
                MessageBox.Show("Invalid weight.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ndbno = lstviewFoods.SelectedItems[0].SubItems[0].Text;
            string todaysLog = "";


            string[] bLogLines = new string[0];
            string[] lLogLines = new string[0];
            string[] dLogLines = new string[0];
            try
            {
                todaysLog = File.ReadAllText($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}foodlog{slash}{frmMain.dte}.TXT").Replace("\r", "");
                bLogLines = todaysLog.Split(new string[] { "--Breakfast--" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new string[] { "--Lunch--" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                lLogLines = todaysLog.Split(new string[] { "--Lunch--" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "--Dinner--" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                dLogLines = todaysLog.Split(new string[] { "--Dinner--" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }

            List<string> output = new List<string>();
            output.Add("--Breakfast--");
            output.AddRange(bLogLines);
            if (comboMeal.SelectedIndex == 0)
                output.Add($"{db}|{ndbno}|{grams}");
            output.Add("--Lunch--");
            output.AddRange(lLogLines);
            if (comboMeal.SelectedIndex == 1)
                output.Add($"{db}|{ndbno}|{grams}");
            output.Add("--Dinner--");
            output.AddRange(dLogLines);
            if (comboMeal.SelectedIndex == 2)
                output.Add($"{db}|{ndbno}|{grams}");
            File.WriteAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}foodlog{slash}{frmMain.dte}.TXT", output);
            this.Close();
        }

        class dLogObj
        {
            //public string date;
            public List<string> bEntries = new List<string>();
            public List<string> lEntries = new List<string>();
            public List<string> dEntries = new List<string>();
        }
        private void lstviewFoods_Leave(object sender, EventArgs e)
        {
            try { ndbno = lstviewFoods.SelectedItems[0].SubItems[0].Text; }
            catch { }
            selectCheck();
        }

        private void selectCheck()
        {
            if (db != "" && ndbno != "" && grams > 0)
                btnAdd.Enabled = true;
            else
                btnAdd.Enabled = false;
        }

        private void lstviewFoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ndbno = lstviewFoods.SelectedItems[0].SubItems[0].Text;
                lblCurrentFood.Text = "Selected food: " + ndbno;//lblCurrentFood.Text = "Selected food: " + lstviewFoods.SelectedItems[0].SubItems[1].Text.Substring(0, Math.Min(30, lstviewFoods.SelectedItems[0].SubItems[1].Text.Length));
            }
            catch { }
        }

        private void lstviewFoods_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                txtQty.Focus();
        }
        private void lstviewFoods_MouseUp(object sender, MouseEventArgs e)
        {
            txtQty.Focus();
        }
    }
}