using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace NutApp
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

        public List<String> importArray(string filename)
        {
            list = new List<string>();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    list.Add(line); // Add to list.
            }
            return list;
        }
        List<string> list;


        string[] pubDBs;
        string[] userDBs;
        string slash = Path.DirectorySeparatorChar.ToString();
        private class slotObj {
            public string[] names = new string[0];
            public string[] vals = new string[0];
            public string[] weights = new string[0];
        }
        slotObj[] slotObjs = new slotObj[4];


        private void frmSearchFoods_Load(object sender, EventArgs e)
        {
            pubDBs = Directory.GetDirectories(Application.StartupPath + $"{slash}usr{slash}public{slash}DBs");
            userDBs = Directory.GetDirectories(Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs");

            if (pubDBs.Length == 0 && userDBs.Length == 0)
            {
                MessageBox.Show("No databases found, try going to the spreadsheet wizard or reinstalling the program.");
                this.Close();
            }

            for (int i = 0; i < userDBs.Length; i++)
            {
                userDBs[i] = userDBs[i].Replace(Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs{slash}", "");
                if (!userDBs[i].StartsWith("f_user"))
                    comboDBs.Items.Add(userDBs[i] + " (user)");
            }
            for (int i = 0; i < pubDBs.Length; i++)
            {
                pubDBs[i] = pubDBs[i].Replace(Application.StartupPath + $"{slash}usr{slash}public{slash}DBs{slash}", "");
                comboDBs.Items.Add(pubDBs[i] + " (public)");
            }


            if (comboDBs.Items.Count > 0 && File.Exists(Application.StartupPath + $"{slash}usr{slash}profile{frmMain.profIndex}{slash}DBs{slash}Default.TXT"))
            {
                int index = Convert.ToInt32(File.ReadAllLines(Application.StartupPath + $"{slash}usr{slash}profile{frmMain.profIndex}{slash}DBs{slash}Default.TXT")[0]);
                comboDBs.SelectedIndex = index;
            }

            //Loads the user-defined fields
            slotObjs[0] = new slotObj();
            slotObjs[1] = new slotObj();
            slotObjs[2] = new slotObj();
            slotObjs[3] = new slotObj();
            if (File.Exists(Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs" + slash + "Slots.TXT"))
            {
                string[] slots = File.ReadAllLines(Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs" + slash + "Slots.TXT");
                int slotMax = 0;
                foreach (string s in slots)
                {
                    string dir = Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs" + slash + s;
                        string[] nkp = File.ReadAllLines(dir + slash + "_nutKeyPairs.TXT");
                        string[] names = new string[0];
                        string[] vals = new string[0];
                        string[] weights = new string[0];

                    if (Directory.Exists(dir))
                    {
                        //List<ListViewItem> itms;
                        if (slotMax == 0)
                        {
                            itms = new List<ListViewItem>();
                            lblSlot1.Text = s.Replace("f_user_" , "");
                            foreach (string t in nkp)
                            {
                                if (t.Split('|')[1] == "Name of Food")
                                {
                                    names = File.ReadAllLines(dir + slash + t.Split('|')[0]);
                                    slotObjs[0].names = names;
                                }
                                else if (t.Split('|')[1] == "Value1")
                                {
                                    vals = File.ReadAllLines(dir + slash + t.Split('|')[0]);
                                    slotObjs[0].vals = vals;
                                }

                                else if (t.Split('|')[1] == "Weight")
                                {
                                    weights = File.ReadAllLines(dir + slash + t.Split('|')[0]);
                                    slotObjs[0].weights = weights;
                                }
                            }

                            //adds to list
                            for (int i = 0; i < names.Length; i++)
                            {
                                ListViewItem itm = new ListViewItem(names[i]);
                                if (weights.Length == names.Length)
                                    itm.SubItems.Add(weights[i]);
                                else
                                    itm.SubItems.Add("");
                                if (vals.Length == names.Length)
                                    itm.SubItems.Add(vals[i]);
                                else
									itm.SubItems.Add("");
								itms.Add(itm);
                                //lstViewSlot1.Items.Add(itm);
                            }
                            lstViewSlot1.BeginUpdate();

                            foreach (ListViewItem itm in itms)
                                lstViewSlot1.Items.Add(itm);
                            //lstViewSlot1.Items.AddRange(itms);
                            lstViewSlot1.EndUpdate();
                        }
                        else if (slotMax == 1)
                        {
                            itms = new List<ListViewItem>();
                            lblSlot2.Text = s.Replace("f_user_", "");
                            foreach (string t in nkp)
                            {
                                if (t.Split('|')[1] == "Name of Food")
                                {
                                    names = File.ReadAllLines(dir + slash + t.Split('|')[0]);
                                    slotObjs[1].names = names;
                                }
                                else if (t.Split('|')[1] == "Value1")
                                {
                                    vals = File.ReadAllLines(dir + slash + t.Split('|')[0]);
                                    slotObjs[1].vals = vals;
                                }
                                else if (t.Split('|')[1] == "Weight")
                                {
                                    weights = File.ReadAllLines(dir + slash + t.Split('|')[0]);
                                    slotObjs[1].weights = weights;
                                }
                            }

                            //adds to list
                            for (int i = 0; i < names.Length; i++)
                            {
                                                                    //if (names.Length != weights.Length || weights.Length != vals.Length)
                                    //{
                                    //    MessageBox.Show($"the {s} field is corrupt, not all entries have the same length\nameLength: {names.Length}\nweightsLength: {weights.Length}\nvalueLength: {vals.Length}");
                                    //    break;
                                    //}
                                ListViewItem itm = new ListViewItem(names[i]);
                                if (weights.Length == names.Length)
                                    itm.SubItems.Add(weights[i]);
                                else
                                    itm.SubItems.Add("");
                                if (vals.Length == names.Length)
                                    itm.SubItems.Add(vals[i]);
                                else
									itm.SubItems.Add("");
								itms.Add(itm);
								//lstViewSlot2.Items.Add(itm);
							}
							lstViewSlot2.BeginUpdate();
                            foreach (ListViewItem itm in itms)
                                lstViewSlot2.Items.Add(itm);
                            //lstViewSlot2.Items.AddRange(itms);
							lstViewSlot2.EndUpdate();
                        }
                        else if (slotMax == 2)
                        {
                            itms = new List<ListViewItem>();
                            lblSlot3.Text = s.Replace("f_user_", "");
                            foreach (string t in nkp)
                            {
                                if (t.Split('|')[1] == "Name of Food")
                                {
                                    names = File.ReadAllLines(dir + slash + t.Split('|')[0]);
                                    slotObjs[2].names = names;
                                }
                                else if (t.Split('|')[1] == "Value1")
                                {
                                    vals = File.ReadAllLines(dir + slash + t.Split('|')[0]);
                                    slotObjs[2].vals = vals;
                                }

                                else if (t.Split('|')[1] == "Weight")
                                {
                                    weights = File.ReadAllLines(dir + slash + t.Split('|')[0]);
                                    slotObjs[2].weights = weights;
                                }
                            }

                            //adds to list
                            for (int i = 0; i < names.Length; i++)
                            {
                                ListViewItem itm = new ListViewItem(names[i]);
                                if (weights.Length == names.Length)
                                    itm.SubItems.Add(weights[i]);
                                else
                                    itm.SubItems.Add("");
                                if (vals.Length == names.Length)
                                    itm.SubItems.Add(vals[i]);
                                else
									itm.SubItems.Add("");
								itms.Add(itm);
								//lstViewSlot3.Items.Add(itm);
							}
							lstViewSlot3.BeginUpdate();
                            foreach (ListViewItem itm in itms)
                                lstViewSlot3.Items.Add(itm);
                            //lstViewSlot3.Items.AddRange(itms);
                            lstViewSlot3.EndUpdate();
                        }
                        else if (slotMax == 3)
                        {
                            itms = new List<ListViewItem>();
                            lblSlot4.Text = s.Replace("f_user_", "");
                            foreach (string t in nkp)
                            {
                                if (t.Split('|')[1] == "Name of Food")
                                {
                                    names = File.ReadAllLines(dir + slash + t.Split('|')[0]);
                                    slotObjs[3].names = names;
                                }

                                else if (t.Split('|')[1] == "Value1")
                                {
                                    vals = File.ReadAllLines(dir + slash + t.Split('|')[0]);
                                    slotObjs[3].vals = vals;
                                }

                                else if (t.Split('|')[1] == "Weight")
                                {
                                    weights = File.ReadAllLines(dir + slash + t.Split('|')[0]);
                                    slotObjs[3].weights = weights;
                                }
                            }

                            //adds to list
                            for (int i = 0; i < names.Length; i++)
                            {
                                ListViewItem itm = new ListViewItem(names[i]);
                                if (weights.Length == names.Length)
                                    itm.SubItems.Add(weights[i]);
                                else
                                    itm.SubItems.Add("");
                                if (vals.Length == names.Length)
                                    itm.SubItems.Add(vals[i]);
                                else
                                    itm.SubItems.Add("");
                                itms.Add(itm);
								//lstViewSlot4.Items.Add(itm);
							}
							lstViewSlot4.BeginUpdate();

                            foreach (ListViewItem itm in itms)
                                lstViewSlot4.Items.Add(itm);

                            //lstViewSlot4.Items.AddRange(itms);
                            lstViewSlot4.EndUpdate();
                        }
                        slotMax++;
                    }
                    if (slotMax >= 4)
                        break;
                }
            }
        }

        private string nameKeyPath = "";
        private string db;
        private List<string> range = new List<string>();
        private string[] nutKeyPairs;
        private int n = 0;
        private Dictionary<string, List<string>> mainDB;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            File.WriteAllText(Application.StartupPath + $"{slash}usr{slash}profile{frmMain.profIndex}{slash}DBs{slash}Default.TXT", comboDBs.SelectedIndex.ToString());
            lstviewFoods.Clear();
            txtSrch.Clear();
            richTxtWarn.Text = "";
            //richTxtWarn.Enabled = false;
            warning = true;
            db = comboDBs.Text.Replace(" (public)", "").Replace(" (user)", "");
            if (comboDBs.Text.Contains("(public)"))
            {
                string[] files = Directory.GetFiles(Application.StartupPath + $"{slash}usr{slash}public{slash}DBs{slash}" + db);

                if (File.Exists(Application.StartupPath + $"{slash}usr{slash}public{slash}DBs{slash}" + db + $"{slash}_nutKeyPairs.TXT"))
                {
                    mainDB = new Dictionary<string, List<string>>();
                    for (int i = 0; i < files.Length; i++)
                        mainDB.Add(files[i].Replace(Application.StartupPath + $"{slash}usr{slash}public{slash}DBs{slash}" + db + $"{slash}", "")/*.ToUpper()*/, importArray(files[i]));

                    nutKeyPairs = importArray(Application.StartupPath + $"{slash}usr{slash}public{slash}DBs{slash}" + db + $"{slash}_nutKeyPairs.TXT").ToArray();

                    //MessageBox.Show("hmm");
                    n = importArray(Application.StartupPath + $"{slash}usr{slash}public{slash}DBs{slash}" + db + $"{slash}" + nutKeyPairs[0].Split('|')[0]).Count;
                    //MessageBox.Show("ok");
                    for (int i = 0; i < nutKeyPairs.Length; i++)
                        if (nutKeyPairs[i].Contains("|Name of Food"))
                            nameKeyPath = Application.StartupPath + $"{slash}usr{slash}public{slash}DBs{slash}" + db + $"{slash}" +
                                          nutKeyPairs[i].Replace("|Name of Food", "");
                    for (int i = 0; i < nutKeyPairs.Length; i++)
                        lstviewFoods.Columns.Add(nutKeyPairs[i].Split('|')[1]);

                    txtSrch.Enabled = true;
                    manageBasicFieldsToolStripMenuItem.Enabled = true;


                    for (int i=0;i<lstviewFoods.Columns.Count;i++)
                        lstviewFoods.Columns[i].Width = -2;

                    if (n > 800)
                    {
                        richTxtWarn.Text = "There are more than 800 entries.\nPlease search to turn something up.";
                        //MessageBox.Show("There are more than 800 entries.  Please search to turn something up.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    itms = new List<ListViewItem>();
                    for (int j = 0; j < n; j++)
                    {
                        ListViewItem itm = new ListViewItem();
                        for (int i = 0; i < nutKeyPairs.Length; i++)
                        {
                            if (i == 0)
                                itm.Text = mainDB[nutKeyPairs[i].Split('|')[0]][j];
                            else
                                itm.SubItems.Add(mainDB[nutKeyPairs[i].Split('|')[0]][j]);
                        }
                        itms.Add(itm);
                        //lstviewFoods.Items.Add(itm);
                        //MessageBox.Show("wow");
                    }
                    lstviewFoods.BeginUpdate();
                    foreach (ListViewItem itm in itms)
                        lstviewFoods.Items.Add(itm);
                    //lstviewFoods.Items.AddRange(itms); 
                    lstviewFoods.EndUpdate();

                    //

                    //


                }
                else
                {
                    MessageBox.Show("The nutrient keys have not been paired for this database.  You will be taken to the admin center.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmManageDBfields frmMDB = new frmManageDBfields();
                    NewMethod(frmMDB);
                    frmMDB.ShowDialog();
                }
            }

            else
            {
                string[] files = Directory.GetFiles(Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs{slash}"
                    + db);
                if (File.Exists(Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs{slash}" + db + "_nutKeyPairs.TXT"))
                {
                    Dictionary<string, List<string>> mainDB = new Dictionary<string, List<string>>();
                    for (int i = 0; i < files.Length; i++)
                        mainDB.Add(files[i].Replace(Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs{slash}" + db + $"{slash}", ""), importArray(files[i]));

                    List<string> nutKeyPairs = importArray(Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs{slash}" + db + "_nutKeyPairs.TXT");
                    for (int i = 0; i < nutKeyPairs.Count; i++)
                        lstviewFoods.Columns.Add(nutKeyPairs[i].Split('|')[1]);
                    

                }
                else
                {
                    MessageBox.Show("The nutrient keys have not been paired for this database.  You will be taken to the admin center.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmManageDBfields frmMDB = new frmManageDBfields();
                    frmMDB.nutkeyPath = Application.StartupPath + $"{slash}usr{slash}public{slash}DBs{slash}" + db + $"{slash}_nutKeyPairs.TXT";
                    frmMDB.ShowDialog();
                }
            }
        }

        private void NewMethod(frmManageDBfields frmMDB)
        {
            frmMDB.nutkeyPath = Application.StartupPath + $"{slash}usr{slash}public{slash}DBs{slash}" + db + $"{slash}_nutKeyPairs.TXT";
        }

        private void manageBasicFieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string db = comboDBs.Text.Replace(" (public)", "");
            frmManageDBfields frmMDB = new frmManageDBfields();
            frmMDB.nutkeyPath = Application.StartupPath + $"{slash}usr{slash}public{slash}DBs{slash}" + db + $"{slash}_nutKeyPairs.TXT";
            frmMDB.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void txtSrch_TextChanged(object sender, EventArgs e)
        {
            srchTmout.Stop();
            srchTmout.Start();
            richTxtWarn.Text = "";

            txtUser1.Text = txtSrch.Text;
            txtUser2.Text = txtSrch.Text;
            txtUser3.Text = txtSrch.Text;
            txtUser4.Text = txtSrch.Text;
        }

        string lastQuery = "";
        BackgroundWorker bw = new BackgroundWorker();
        List<ListViewItem> itms;
        private void srchTmout_Tick(object sender, EventArgs e)
        {
            if (txtSrch.Text.Trim() == lastQuery)
                return;
            //this.UseWaitCursor = false;
            //lstviewFoods.Items.Clear();
            //search();
            bw.WorkerSupportsCancellation = true;
            bw.CancelAsync();
            bw = new BackgroundWorker();

            //while (bw.CancellationPending)
            //    Thread.Sleep(50);
            bw.DoWork += delegate
            {
                try { search(); }
                catch { }
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
        private void search()
        {
            this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = true; }));
            string input = txtSrch.Text.ToUpper().Trim();
            if (input.Length < 2)
                //if (range.Count > 800)
                return;

            string[] words = input.Split(new char[] { ' ', ',', '/' });

            range = importArray(nameKeyPath);
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
                {
                    if (words[k].Length > 2 && range[i].StartsWith(words[k]))
                        wCount[i] += Convert.ToInt32(1.5 * words[k].Length);
                    else if (words[k].Length > 2 && range[i].Contains(words[k]))
                        wCount[i] += Convert.ToInt32(words[k].Length);
                }
            //MessageBox.Show(words[n]);
            for (int i = 0; i < range.Count; i++)
            {
                if (words[n].Length > 1 && range[i].StartsWith(words[n]))
                    wCount[i] += Convert.ToInt32(1.5 * words[n].Length);
                else if (words[n].Length > 1 && range[i].Contains(words[n]))
                    wCount[i] += Convert.ToInt32(words[n].Length);
            }


            int q = wCount.Max();
            //MessageBox.Show(q.ToString());
            if (q == 0)
                return;
            int z = 0;
            itms = new List<ListViewItem>();
            //itms = new List<ListViewItem>();
            for (int i = q; i > (q == 1 ? 0 : q - 1); i--)
                for (int k = 0; k < range.Count; k++)
                    if (wCount[k] == i)
                    {
                        ListViewItem itm = new ListViewItem();
                        for (int m = 0; m < nutKeyPairs.Length; m++)
                        {
                            if (m == 0)
                                itm = new ListViewItem(mainDB[nutKeyPairs[m].Split('|')[0]][k]);
                            else
                                itm.SubItems.Add(mainDB[nutKeyPairs[m].Split('|')[0]][k]);
                            //MessageBox.Show("k");*/
                        }
                        itms.Add(itm);
                        //lstviewFoods.Invoke(new MethodInvoker(delegate { lstviewFoods.Items.Add(itm); }));
                        
                        //MessageBox.Show(i.ToString());
                        //MessageBox.Show("wow");
                    }
            z = itms.Count;
            if (z > 100 && !warn(z))
            {
                //richTxtWarn.Enabled = true;
                warning = true;
                this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = false; }));
                return;
            }
            
            lstviewFoods.Invoke(new MethodInvoker(delegate {
                lstviewFoods.BeginUpdate();
                foreach (ListViewItem itm in itms)
                    lstviewFoods.Items.Add(itm);
                lstviewFoods.EndUpdate();
                //lstviewFoods.Items.AddRange(itms);
            }));
            for (int i = 0; i < nutKeyPairs.Length; i++)
                if (nutKeyPairs[i].Contains("|Name of Food"))
                    lstviewFoods.Invoke(new MethodInvoker(delegate { lstviewFoods.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent); }));


            this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = false; }));


            /*else if (input.Length > 3) //starts with
            {
                for (int i = input.Length; i > 3; i--)
                {

                }
            }
            else if (input.Length > 4) //contains
            { }*/
        }

        private bool warn(int n)
        {
            this.Invoke(new MethodInvoker(delegate { richTxtWarn.Text = $"Search for {n} foods? It may go slow\nPress enter to continue.."; }));

            return false;
            //if (MessageBox.Show($"You are about to list information for {n} foods, this will take a moment.\nTo try again press enter or Retry, to continue with the lengthy search please press Cancel or close this box.", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            //    return true;
            //else
            //    return false;
        }

        private void richTxtWarn_DoubleClick(object sender, EventArgs e)
        {

        }

        bool warning = false;
        private void txtSrch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && warning)
            {
                e.Handled = true;
                //if (!richTxtWarn.Enabled)
                //return;
                richTxtWarn.Text = "searching...";
                lstviewFoods.Items.Clear();
                bw = new BackgroundWorker();
                bw.DoWork += delegate {
                    this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = true; }));

                    lstviewFoods.Invoke(new MethodInvoker(delegate {
                        //lstviewFoods.Items.AddRange(itms);
                        lstviewFoods.BeginUpdate();
                        foreach (ListViewItem itm in itms)
                            lstviewFoods.Items.Add(itm);
                        lstviewFoods.EndUpdate();
                    }));
                    for (int i = 0; i < nutKeyPairs.Length; i++)
                        if (nutKeyPairs[i].Contains("|Name of Food"))
                            lstviewFoods.Invoke(new MethodInvoker(delegate { lstviewFoods.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent); }));

                    //richTxtWarn.Enabled = false;
                    warning = false;
                    this.Invoke(new MethodInvoker(delegate { richTxtWarn.Text = "Finished!"; }));
                    this.Invoke(new MethodInvoker(delegate { this.UseWaitCursor = false; }));
                };
                bw.RunWorkerAsync();
            }
        }

        private void txtUser1_TextChanged(object sender, EventArgs e)
        {
            lstViewSlot1.Items.Clear();
            itms = new List<ListViewItem>();
            for ( int i = 0;  i < slotObjs[0].names.Length; i++)
            {
                if (slotObjs[0].names[i].ToUpper().Contains(txtUser1.Text.ToUpper()))
                {
                    ListViewItem itm = new ListViewItem(slotObjs[0].names[i]);
                    if (slotObjs[0].names.Length == slotObjs[0].weights.Length)
                        itm.SubItems.Add(slotObjs[0].weights[i]);
                    else
                        itm.SubItems.Add("");
                    if (slotObjs[0].names.Length == slotObjs[0].vals.Length)
                        itm.SubItems.Add(slotObjs[0].vals[i]);
                    else
                        itm.SubItems.Add("");
                    //lstViewSlot1.Items.Add(itm);
                    itms.Add(itm);
                }
            }
            lstViewSlot1.BeginUpdate();
            foreach (ListViewItem itm in itms)
                lstViewSlot1.Items.Add(itm);
            //lstViewSlot1.Items.AddRange(itms);
            lstViewSlot1.EndUpdate();
        }

        private void txtUser2_TextChanged(object sender, EventArgs e)
        {
			lstViewSlot2.Items.Clear();
            itms = new List<ListViewItem>();
            for (int i = 0; i < slotObjs[1].names.Length; i++)
            {
                if (slotObjs[1].names[i].ToUpper().Contains(txtUser2.Text.ToUpper()))
                {
                    ListViewItem itm = new ListViewItem(slotObjs[1].names[i]);
                    if (slotObjs[1].names.Length == slotObjs[1].weights.Length)
                        itm.SubItems.Add(slotObjs[1].weights[i]);
                    else
                        itm.SubItems.Add("");
                    if (slotObjs[1].names.Length == slotObjs[1].vals.Length)
                        itm.SubItems.Add(slotObjs[1].vals[i]);
                    else
                        itm.SubItems.Add("");
					//lstViewSlot2.Items.Add(itm);
					itms.Add(itm);
                }
			}
			lstViewSlot2.BeginUpdate();
            foreach (ListViewItem itm in itms)
                lstViewSlot2.Items.Add(itm);
            //lstViewSlot2.Items.AddRange(itms);
			lstViewSlot2.EndUpdate();
        }

        private void txtUser3_TextChanged(object sender, EventArgs e)
        {
			lstViewSlot3.Items.Clear();
            itms = new List<ListViewItem>();
            for (int i = 0; i < slotObjs[2].names.Length; i++)
            {
                if (slotObjs[2].names[i].ToUpper().Contains(txtUser3.Text.ToUpper()))
                {
                    ListViewItem itm = new ListViewItem(slotObjs[2].names[i]);
                    if (slotObjs[2].names.Length == slotObjs[2].weights.Length)
                        itm.SubItems.Add(slotObjs[2].weights[i]);
                    else
                        itm.SubItems.Add("");
                    if (slotObjs[2].names.Length == slotObjs[2].vals.Length)
                        itm.SubItems.Add(slotObjs[2].vals[i]);
                    else
                        itm.SubItems.Add("");
					//lstViewSlot3.Items.Add(itm);
					itms.Add(itm);
                }
			}
			lstViewSlot3.BeginUpdate();
            foreach (ListViewItem itm in itms)
                lstViewSlot3.Items.Add(itm);
            //lstViewSlot3.Items.AddRange(itms);
			lstViewSlot3.EndUpdate();
        }

        private void txtUser4_TextChanged(object sender, EventArgs e)
        {
			lstViewSlot4.Items.Clear();
            itms = new List<ListViewItem>();
            for (int i = 0; i < slotObjs[3].names.Length; i++)
            {
                if (slotObjs[3].names[i].ToUpper().Contains(txtUser4.Text.ToUpper()))
                {
                    ListViewItem itm = new ListViewItem(slotObjs[3].names[i]);
                    if (slotObjs[3].names.Length == slotObjs[3].weights.Length)
                        itm.SubItems.Add(slotObjs[3].weights[i]);
                    else
                        itm.SubItems.Add("");
                    if (slotObjs[3].names.Length == slotObjs[3].vals.Length)
                        itm.SubItems.Add(slotObjs[3].vals[i]);
                    else
                        itm.SubItems.Add("");
					//lstViewSlot4.Items.Add(itm);
					itms.Add(itm);
                }
			}
			lstViewSlot4.BeginUpdate();
            foreach (ListViewItem itm in itms)
                lstViewSlot4.Items.Add(itm);
            //lstViewSlot4.Items.AddRange(itms);
			lstViewSlot4.EndUpdate();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            txtUser1Qty.Text = txtQty.Text;
            txtUser2Qty.Text = txtQty.Text;
            txtUser3Qty.Text = txtQty.Text;
            txtUser4Qty.Text = txtQty.Text;
        }
    }
}
