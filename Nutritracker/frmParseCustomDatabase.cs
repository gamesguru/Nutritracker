using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Nutritracker
{
    public partial class frmParseCustomDatabase : Form
    {
        public frmParseCustomDatabase()
        {
            InitializeComponent();
            this.AllowDrop = true;
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

        public double getBiggestDouble(string s)
        {
            s = Regex.Replace(s, "[^0-9.]", "");
            double d;
            try { d = Convert.ToDouble(s); return d; }
            catch { return 0.0; }
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

        public class Column
        {
            public string header;
            public string[] items;
            public string units;
        }

        public static Column[] columns;

        private void frmParseCustomDatabase_Load(object sender, EventArgs e)
        {
            lstViewResult.FullRowSelect = true;
        }


        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                    lstViewResult.Items.RemoveAt(lstViewResult.SelectedIndices[0]);
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        frmNewDB frmNDB;
        private void btnNewDB_Click(object sender, EventArgs e)
        {
            int n = lstViewResult.Columns.Count;

            if (n > 1)
            {
                if (n == 2 && MessageBox.Show("Only two fields detected.  It looks like you meant to create a field or relational database instead.  Continue?", "Create new Database?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                frmNDB = new frmNewDB(this);

                //adds headers/column names
                for (int i = 0; i < lstViewResult.Columns.Count; i++)
                    frmNDB.arr.Add(lstViewResult.Columns[i].Text);
                frmNDB.n = lstViewResult.Items.Count;

                frmNDB.ShowDialog();
            }
            else { MessageBox.Show("You haven't transferred more than 1 column to the list!"); }
        }

        private void btnNewField_Click(object sender, EventArgs e)
        {
            int n = lstViewResult.Columns.Count;

            if (n > 1)
            {
                frmNewField frmNDF = new frmNewField(this);
                for (int i = 0; i < lstViewResult.Columns.Count; i++)
                    frmNDF.arr.Add(lstViewResult.Columns[i].Text);
                frmNDF.n = lstViewResult.Items.Count;
                frmNDF.ShowDialog();
            }
            else { MessageBox.Show("You haven't transferred more than 1 column to the list!"); }
        }

        public string getVal(int i, int j)
        {
            return lstViewResult.Items[i].SubItems[j].Text;
        }

        public List<string> getCol(string header)
        {
            List<string> output = new List<string>();
            for (int i = 0; i < lstViewResult.Columns.Count; i++)
                if (lstViewResult.Columns[i].Text == header)
                {
                    for (int j = 0; j < lstViewResult.Items.Count; j++)
                        output.Add(lstViewResult.Items[j].SubItems[i].Text);
                    break;
                }
            return output;
        }

        public List<string> getRow(int x, List<string> headers)
        {
            List<string> output = new List<string>();
            for (int i = 0; i < lstViewResult.Columns.Count; i++)
                if (headers.Contains(lstViewResult.Columns[i].Text))
                    output.Add(lstViewResult.Items[x].SubItems[i].Text);
            return output;
        }

        private void parseInput()
        {
            int colSpan = 0;

            foreach (string s in sourceInput)
                if (s.Split('\t').Length > colSpan)
                    colSpan = s.Split('\t').Length;

            txtInput.Text += "\r\n# of headers:\t" + sourceInput[0].Split('\t').Length.ToString();
            txtInput.Text += "\r\n# of max columns:\t" + colSpan.ToString();
            txtInput.Text += "\r\n# of rows:\t\t" + sourceInput.Length.ToString();

            for (int i = 0; i < sourceInput.Length; i++)
                if (sourceInput[i].Split('\t').Length != colSpan)
                    if (MessageBox.Show($"Error on row #{i}\r\nonly has {sourceInput[i].Split('\t').Length} entries, {colSpan} expected!!\r\n{sourceInput[i]}", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                        return;


            progBarWait pbw = new progBarWait();
            Thread t = new Thread(() =>
               {
                   pbw.ShowDialog();
                   pbw.finished = true;
               });
            t.Start();
            while (!pbw.ready)
                Thread.Sleep(60);
            pbw.setTitle("Adding the columns...");
            int m = sourceInput[0].Split('\t').Length;
            int n = sourceInput.Length;
            pbw.setProgMax(n, 50);
            try
            {
                columns = new Column[colSpan];
                for (int i = 0; i < colSpan; i++)
                    columns[i] = new Column();
                for (int i = 0; i < m; i++)
                {
                    columns[i].header = sourceInput[0].Split('\t')[i];
                    columns[i].items = new string[sourceInput.Length];
                    for (int j = 0; j < n; j++)
                    {
                        pbw.setLblCurObj($"{j}/{n}");
                        columns[i].items[j] = sourceInput[j].Split('\t')[i];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Parse error.\n" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListViewItem[] itms = new ListViewItem[sourceInput.Length - 1];
            for (int j = 0; j < sourceInput.Length - 1; j++)
                itms[j] = new ListViewItem();
            for (int i = 0; i < colSpan; i++)
            {
                lstViewResult.Columns.Add(columns[i].header);
                for (int j = 1; j < sourceInput.Length; j++)
                    if (i == 0)
                        itms[j - 1].Text = columns[0].items[j];
                    else
                        itms[j - 1].SubItems.Add(columns[i].items[j]);
            }

            lstViewResult.BeginUpdate();
            lstViewResult.Items.AddRange(itms);
            lstViewResult.EndUpdate();
            itms = null;
            lstViewResult.AutoResizeColumns(System.Windows.Forms.ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        string[] sourceInput;

        private void importFromtxtFilequickestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            lstViewResult.Clear();
            importTxtDialog.InitialDirectory = Application.StartupPath + Path.DirectorySeparatorChar.ToString() + "lib";
            importTxtDialog.ShowDialog();
            txtInput.Text += importTxtDialog.FileName + "\r\n";
            if (!File.Exists(importTxtDialog.FileName))
                return;
            sourceInput = File.ReadAllLines(importTxtDialog.FileName);
            parseInput();
        }

        private void txtInput_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void txtInput_DragDrop(object sender, DragEventArgs e)
        {
            txtInput.Clear();
            lstViewResult.Clear();
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length != 1)
            {
                txtInput.Text += "Error: not exactly one file dropped onto pallete.";
                foreach (string s in files)
                    txtInput.Text += "\r\n" + s;
                return;
            }

            txtInput.Text += files[0] + "\r\n";
            sourceInput = File.ReadAllLines(files[0]);
            parseInput();
        }

        private void txtInput_DoubleClick(object sender, EventArgs e)
        {
            txtInput.Clear();
            lstViewResult.Clear();
            importTxtDialog.InitialDirectory = Application.StartupPath + Path.DirectorySeparatorChar.ToString() + "lib";
            importTxtDialog.ShowDialog();
            txtInput.Text += importTxtDialog.FileName + "\r\n";
            if (!File.Exists(importTxtDialog.FileName))
                return;
            sourceInput = File.ReadAllLines(importTxtDialog.FileName);
            parseInput();
        }

        private void createNewDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createNewFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}