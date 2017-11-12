using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.IO;

namespace NutApp
{
    public partial class frmParseCustomDatabase : Form
    {
        public frmParseCustomDatabase()
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


        List<string> headers;
        List<string> lines;
        private void button1_Click(object sender, EventArgs e)
        {
            btnParseTxt.Enabled = false;
            lstViewResult.Clear();
            comboColumns.Items.Clear();
            lines = sourceInput.Split('\n').ToList<string>();//txtboxSource.Text.Split('\n').ToList<string>();

            headers = lines[0].Split('\t').ToList<string>(); ;
            int colSpan = headers.Count;


            for (int i = 1; i < lines.Count; i++)
                if (lines[i].Split('\t').Length > colSpan)
                    colSpan = lines[i].Split('\t').Length;

            int n = colSpan - headers.Count;
            while (n > 0)
            {
                headers.Add("||");
                n--;
            }

            for (int i = 0; i < colSpan; i++)
            {
                if (headers[i].Length < 1)
                    continue;
                lstViewResult.Columns.Add(headers[i]);
                comboColumns.Items.Add(headers[i]);
            }


            List<string> names = new List<string>();
            //string[,] core = new string[lines.Count, colSpan];
            for (int i = 1; i < lines.Count; i++)
            {
                if (lines[i].Length < 2)
                    continue;
                names.Add(lines[i].Split('\t')[0]);
                /*if (checkBox1.Checked)
                    for (int k = 2; k < headers.Count; k++)
                    {
                        if (lines[i].Split('\t').Length < colSpan)
                        {
                            //MessageBox.Show(i.ToString());
                            //newLineDelimit();
                            //return;
                        }
                    }*/
            }
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = names.Count;
            ListViewItem[] itms = new ListViewItem[names.Count];
            for (int i = 0; i < names.Count; i++)
            {
                if (lines[i].Length < 2)
                    continue;
                if (i > lines.Count - 2)
                    break;
                ListViewItem itm = new ListViewItem(lines[i + 1].Split('\t')[0]);
                if (itm.SubItems.Count < 1)
                    continue;
                //1.Items.Add(lines[i]);
                for (int k = 1; k < headers.Count; k++)
                {
                    try { itm.SubItems.Add(lines[i + 1].Split('\t')[k]); }
                    catch { }
                }

                itms[i] = itm;
                progressBar1.Value++;
            }
            // itms[lines.Count - 1] = new ListViewItem();

            lstViewResult.BeginUpdate();
            lstViewResult.Items.AddRange(itms);
            lstViewResult.EndUpdate();
            progressBar1.Visible = false;

            if (lstViewResult.Columns.Count > 0 && lstViewResult.Items.Count > 0)
            {
                //button2.Enabled = true;
                comboColumns.Enabled = true;
                //txtDelim.Enabled = true;
                try { comboColumns.SelectedIndex = 0; }
                catch { }
            }
            //label1.Text = string.Join(", ", core[3, 0]);
            btnParseTxt.Enabled = true;
        }

        private void newLineDelimit()
        {
            /*double d;

            lstViewResult.Clear();
            comboBox1.Items.Clear();
            lines = txtboxSource.Text.Split('\n').ToList<string>();

            headers = lines[0].Split('\t').ToList<string>(); ;
            int colSpan = headers.Count;

            List<string> extendedLines = new List<string>();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Length < 2 || double.TryParse(lines[i].Replace('\n', '\0'), out d))
                {
                    string st = "";
                    for (int q=0;q<=colSpan;q++)
                    {
                        if (i + q >= lines.Count)
                            break;
                        if (lines[i + q].Length < 4 || double.TryParse(lines[i + q].Replace('\n', '\0'), out d))
                        {
                            MessageBox.Show(st);
                            st += lines[i + q] + "\t";
                        }
                        else
                        {
                            i += q;
                            break;
                        }
                                //extendedLines.add
                    }
                    MessageBox.Show("added: " + st);
                    extendedLines.Add(st);
                    continue;
                }
                else
                    extendedLines.Add(lines[i]);
            }

            //MessageBox.Show(string.Join("||", lines));

            for (int i = 1; i < extendedLines.Count; i++)
                if (extendedLines[i].Split('\t').Length > colSpan)
                    colSpan = extendedLines[i].Split('\t').Length;

            int n = colSpan - headers.Count;
            while (n > 0)
            {
                headers.Add("||");
                n--;
            }

            for (int i = 0; i < colSpan; i++)
            {
                if (headers[i].Length < 1)
                    continue;
                lstViewResult.Columns.Add(headers[i]);
                comboBox1.Items.Add(headers[i]);
            }


            List<string> names = new List<string>();
            //string[,] core = new string[lines.Count, colSpan];
            for (int i = 1; i < extendedLines.Count; i++)
            {
                if (extendedLines[i].Length < 4)
                    continue;
                ListViewItem itm = new ListViewItem(extendedLines[i].Split('\t')[0]);

                //1.Items.Add(extendedLines[i]);
                names.Add(extendedLines[i].Split('\t')[0]);
                for (int k = 1; k < headers.Count; k++)
                {
                    try { itm.SubItems.Add(extendedLines[i].Split('\t')[k]); }
                    catch { }
                    //MessageBox.Show(extendedLines[i].Split('\t')[k]);
                    // core[i - 1, k] = ;

                }
                if (checkBox1.Checked)
                    for (int k = 2; k < headers.Count; k++)
                    {
                        if (extendedLines[i].Split('\t').Length < colSpan)
                        {
                            try { itm.SubItems.Add(extendedLines[i].Split('\n')[k]); }
                            catch { }
                        }
                    }

                lstViewResult.Items.Add(itm);
            }
            if (lstViewResult.Columns.Count > 0 && lstViewResult.Items.Count > 0)
            {
                //button2.Enabled = true;
                comboBox1.Enabled = true;
                //txtDelim.Enabled = true;
                try { comboBox1.SelectedIndex = 0; }
                catch { }
            }*/
        }

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

        private void txtboxSource_MouseClick(object sender, MouseEventArgs e)
        {
            frmSearchReplace.j = txtboxSource.SelectionStart;
            frmSearchFind.j = txtboxSource.SelectionStart;
            //frmSearchR.
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtboxSource.SelectAll();
            txtboxSource.Clear();
            txtboxSource.Paste();
            btnParseTxt.PerformClick();
        }

        public static string parseSource;
        frmSearchReplace frmSearchR = new NutApp.frmSearchReplace(null);
        private void txtboxSource_KeyDown(object sender, KeyEventArgs e)
        {
            frmSearchReplace.j = txtboxSource.SelectionStart;
            frmSearchFind.j = txtboxSource.SelectionStart;
            //frmSearchR.j = 
            if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
            {
                e.SuppressKeyPress = true;
                txtboxSource.SelectAll();
            }
        }

        private void txtboxSource_TextChanged(object sender, EventArgs e)
        {
            parseSource = txtboxSource.Text;
            if (txtboxSource.Text.Split('\n').Length < 2 || txtboxSource.Text.Split('\t').Length < 2)
                btnParseTxt.Enabled = false;
            else
                btnParseTxt.Enabled = true;
        }

        public int parentStartIndex
        {
            get { return txtboxSource.SelectionStart; }
            set { txtboxSource.SelectionStart = value; }
        }
        public int parentSelectionLength
        {
            get { return txtboxSource.SelectionLength; }
            set { txtboxSource.SelectionLength = value; }
        }

        public string parentSelection
        {
            get { return txtboxSource.Text.Substring(txtboxSource.SelectionStart, txtboxSource.SelectionLength); }
            set { txtboxSource.Text = txtboxSource.Text.Remove(txtboxSource.SelectionStart, txtboxSource.SelectionLength).Insert(txtboxSource.SelectionStart, value); }
        }
        public string parentWholeText
        {
            get { return txtboxSource.Text; }
            set { txtboxSource.Text = value; }
        }

        private void txtboxSource_MouseUp(object sender, MouseEventArgs e)
        {
            frmSearchReplace.j = txtboxSource.SelectionStart;
            frmSearchFind.j = txtboxSource.SelectionStart;
        }

        private void txtboxSource_SelectionChanged(object sender, EventArgs e)
        {
            //frmSearchReplace.j = txtboxSource.SelectionStart;
        }

        private void findReplaceCtrlHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parseSource = txtboxSource.Text;
            if (frmSearchReplace.busy)
            {
                frmSearchR.Activate();
                return;
            }
            else if (frmSearchFind.busy)
            {
                frmSearchF.Activate();
                return;
            }
            frmSearchR = new frmSearchReplace(this);
            frmSearchR.StartPosition = this.StartPosition;
            frmSearchR.Show(this);
        }
        frmSearchFind frmSearchF = new frmSearchFind(null);
        private void removeSelectedColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstViewResult.Columns.Count > 0)
            {
                lstViewResult.Columns.RemoveAt(comboColumns.SelectedIndex);
                comboColumns.Items.RemoveAt(comboColumns.SelectedIndex);
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parseSource = txtboxSource.Text;
            if (frmSearchFind.busy)
            {
                frmSearchF.Activate();
                return;
            }
            else if (frmSearchReplace.busy)
            {
                frmSearchR.Activate();
                return;
            }
            frmSearchF = new frmSearchFind(this);
            frmSearchF.StartPosition = this.StartPosition;
            frmSearchF.Show(this);
        }

        public void scrollToSelect()
        {
            txtboxSource.ScrollToCaret();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSearchReplace.busy)
            {
                frmSearchR.Activate();
                return;
            }
            else if (frmSearchFind.busy)
            {
                frmSearchF.Activate();
                return;
            }
            frmSearchR = new frmSearchReplace(this);
            frmSearchR.StartPosition = this.StartPosition;
            frmSearchR.Show(this);
        }

        List<string> knownUnits = new List<string>() { "mg", "g", "iu", "mcg", "%", "μg", "µg", "kj" };
        List<string> gatheredUnits;
        List<string> suspectedUnits;
        private void checkForColumnUnitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboColumns.Items.Count == 0)
                MessageBox.Show("No columns were detected!  Please parse something.", "Nothing found", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            else if (comboColumns.Items.Count == 1)
                if (MessageBox.Show("Only one column detected, are you sure you want to gather units?", "Only one column..", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)                
                    gatherColumnUnits();
                
            else
                    gatherColumnUnits();
            
        }

        private void gatherColumnUnits()
        {
            int sure = 0;
            int susp = 0;
            gatheredUnits = new List<string>();
            for (int i = 0; i < lstViewResult.Columns.Count; i++)
            {
                string colText = lstViewResult.Columns[i].Text.ToLower();

                int n2 = colText.IndexOf(")");
                int n1 = colText.IndexOf("(");

                string suspU = "";
                if (n2 > 0 && n1 > 0)
                    suspU = colText.Substring(n1, n2 - n1 + 1);

                foreach (string s in knownUnits)
                {
                    //MessageBox.Show(s);
                    if (colText.Contains(s) && s.Length > 1 || colText.Contains("(" + s + ")"))
                    {
                        gatheredUnits.Add(s);
                        sure++;
                        //MessageBox.Show(s);
                        goto cont;
                    }
                }

                if (colText.Contains("(") && colText.Contains(")") && (n2 - n1) > 1 && (n2 - n1) < 9 && !gatheredUnits.Contains(suspU.Replace("(", "").Replace(")", "")))
                {

                    if (n2 < 0 || n1 < 0)
                        continue;
                    gatheredUnits.Add(suspU);
                    susp++;
                }
                cont:
                continue;
            }

            
            if (gatheredUnits.Count == 0)
                return;
            string result = string.Join(", ", gatheredUnits);
            MessageBox.Show(sure.ToString() + " units identified and " + susp.ToString() + " suspected:\n" + result, "Results", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void convertToGramsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int k = comboColumns.SelectedIndex;
            for (int i = 0; i < lstViewResult.Items.Count; i++)
            {
                string source = lstViewResult.Items[i].SubItems[k].Text.ToLower();
                if (source.Contains("ounces") || source.Contains("ounce"))
                {
                    double oldV = getBiggestDouble(source);
                    double newV = Math.Round(oldV * 28.4, oldV.ToString().Length - oldV.ToString().IndexOf("."));
                    lstViewResult.Items[i].SubItems[k].Text = source.Replace(oldV.ToString(), newV.ToString()).Replace("ounces", "g").Replace("ounce", "g");
                }
            }
        }

        private void selectColumnToMake100gToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int k = comboColumns.SelectedIndex;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            int n = lstViewResult.Columns.Count;

            if (n > 1)
            {
                if (n == 2 && MessageBox.Show("Only two fields detected.  It looks like you meant to create a field or relational database instead.  Continue?", "Create new Database?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                                    
                frmNewDB frmNDB = new frmNewDB(this);
                for (int i = 0; i < comboColumns.Items.Count; i++)
                    frmNDB.arr.Add(comboColumns.Items[i].ToString());
                frmNDB.n = lstViewResult.Items.Count;
                frmNDB.ShowDialog();
            }
            else { MessageBox.Show("You haven't transferred more than 1 column to the list!"); }
        }
        public string getVal(int i, int j)
        {
            return lstViewResult.Items[i].SubItems[j].Text;
        }

        private void btnNewField_Click(object sender, EventArgs e)
        {
            int n = lstViewResult.Columns.Count;

            if (n > 1)
            {
                frmNewField frmNDF = new frmNewField(this);
                for (int i = 0; i < comboColumns.Items.Count; i++)
                    frmNDF.arr.Add(comboColumns.Items[i].ToString());
                frmNDF.n = lstViewResult.Items.Count;
                frmNDF.ShowDialog();
            }
            else { MessageBox.Show("You haven't transferred more than 1 column to the list!"); }
        }

        string sourceInput = "";

        private void parseWithoutPastingquickerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                sourceInput = Clipboard.GetText(TextDataFormat.CommaSeparatedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Paste format exception\n\n" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sourceInput.Split('\n').Length < 2 || sourceInput.Split('\t').Length < 2)
                btnParseTxt.Enabled = false;
            else
                btnParseTxt.Enabled = true;
            try
            {
                btnParseTxt.PerformClick();
            }
            catch (Exception ex)
            { MessageBox.Show("Parsing error\n\n" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void importFromtxtFilequickestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileLoc = "";
            interactionFileLocInput frmFileLoc = new interactionFileLocInput();
            while (true)
            {
                frmFileLoc.ShowDialog();
                fileLoc = frmFileLoc.fileLoc;
                //fileLoc = Interaction.InputBox("Please input the location of the file, include the .txt", "Which file to import?", "C:/table.txt");
                if (fileLoc.Length == 0) 
                    return;
                else if (File.Exists(fileLoc))
                    break;
            }
            //MessageBox.Show(fileLoc);
            sourceInput = File.ReadAllText(fileLoc);
            if (sourceInput.Split('\n').Length < 2 || sourceInput.Split('\t').Length < 2)
                btnParseTxt.Enabled = false;
            else
                btnParseTxt.Enabled = true;
            try
            {
                btnParseTxt.PerformClick();
            }
            catch (Exception ex)
            { MessageBox.Show("Parsing error\n\n" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
