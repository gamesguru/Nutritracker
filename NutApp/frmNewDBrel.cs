using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NutApp
{
    public partial class frmNewDBrel : Form
    {
        public frmNewDBrel()
        {
            InitializeComponent();
        }

        string slash = Path.DirectorySeparatorChar.ToString();
        string shareDBdir;
        string activeDBdir;
        //int n = 0;
        private void frmNewDBrel_Load(object sender, EventArgs e)
        {
            shareDBdir = $"{Application.StartupPath}{slash}usr{slash}share{slash}DBs";
            txtLoc.Text = $"{slash}usr{slash}share{slash}DBs{slash}rel{slash}";//$"{slash}usr{slash}profile{frmMain.profIndex.ToString()}{slash}DBs{slash}rel{slash}";

            foreach (string s in Directory.GetDirectories(shareDBdir))
                comboBox1.Items.Add(s.Replace(shareDBdir + slash, ""));

            try {
                comboBox1.SelectedIndex = Convert.ToInt32(File.ReadAllText($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.profIndex}{slash}DBs{slash}Default.TXT"));
            }
            catch { }       
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (radioShared.Checked)
                txtLoc.Text = $"{slash}usr{slash}share{slash}DBs{slash}rel{slash}" + txtName.Text;
            else
                txtLoc.Text = $"{slash}usr{slash}profile{frmMain.profIndex.ToString()}{slash}DBs{slash}" + txtName.Text;

            if (txtName.TextLength > 2)//&& lblSearchField.Text != "N/A" && lblCalories.Text != "N/A")
                btnCreate.Enabled = true;
            if (txtName.TextLength < 2)
                btnCreate.Enabled = false;
        }       

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private class relFile
        {
            public string file;
            public string[] lines;
            public string[] headers;
            public List<column> columns = new List<column>();
            public string unit = "";
        }
        private class Header
        {
            public string header;
            public int occcurance = 0;
        }
        private class column
        {
            public string header;
            public List<string> rows = new List<string>();
        }
        List<relFile> relFiles;
        List<string> headers;
        List<Header> Headers;
        List<string> nutrNos;
        string flavVal;
        string[] files;
        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            relFiles = new List<relFile>();
            headers = new List<string>();
            Headers = new List<Header>();
            nutrNos = new List<string>();
            txtOutput.Clear();
            txtName.Clear();
            txtNutrDesc.Clear();
            txtFlavVal.Clear();
            txtNdb.Clear();
            txtNutrNo.Clear();
            listBox1.Items.Clear();

            string folder = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            if (!Directory.Exists(folder))
            {
                MessageBox.Show("Is not a valid directory\n" + folder);
                return;
            }
            files = Directory.GetFiles(((string[])e.Data.GetData(DataFormats.FileDrop))[0]);
            folder = folder.Split(new char[] { '/', '\\' })[folder.Split(new char[] { '/', '\\' }).Length - 1];
            txtName.Text = folder.ToUpper();
            foreach (string s in files)
            {
                relFile r = new relFile();
                r.file = s;
                r.lines = File.ReadAllLines(s);
                r.headers = r.lines[0].Split('\t');
                
                for (int i = 0; i < r.headers.Length; i++)
                //foreach (string st in r.headers)
                {
                    if (r.unit == "")
                    {
                        try
                        {
                            r.unit = r.headers[i].Split('(')[1].Split(')')[0];
                            r.headers[i] = r.headers[i].Split('(')[0].Trim();
                        }
                        catch { }
                    }
                    if (!headers.Contains(r.headers[i]))
                        headers.Add(r.headers[i]);
                }
                column c = new column();            
                
                string f = s.Split(new char[] { '/', '\\'})[s.Split(new char[] { '/', '\\' }).Length - 1];
                txtOutput.Text += f + ":\r\n";
                txtOutput.Text += $"schemas: [{string.Join("], [", r.headers)}]\r\n\r\n";
                relFiles.Add(r);
            }

            foreach (string s in headers)
            {
                Header h = new Header();
                h.header = s;
                Headers.Add(h);
            }

            foreach (Header h in Headers)
                foreach (relFile r in relFiles)
                    if (r.headers.Contains(h.header))
                        h.occcurance++;

            int hMax = 0;
            foreach (Header h in Headers)
                if (h.occcurance > hMax)
                    hMax = h.occcurance;

            List<string> suspKeys = new List<string>();
            for (int i = hMax; i > 1; i--)
                foreach (Header h in Headers)
                    if (h.occcurance == i)
                        suspKeys.Add(h.header);
            txtOutput.Text += $"Recurrent keys:\r\n{string.Join("\r\n", suspKeys)}";

            string[] parentHeaders = File.ReadAllLines(activeDBdir + slash + "_nameKeyPairs.TXT");
            for (int i = 0; i < parentHeaders.Length; i++)
                parentHeaders[i] = parentHeaders[i].Split('|')[1];

            foreach (string s in parentHeaders)
                foreach (string st in headers)
                    if (s == st)
                        listBox1.Items.Add(s);

            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            foreach (string s in headers)
            {
                source.Add(s);
                if (s == "NDB_No")
                    txtNdb.Text = s;
                else if (s == "NutrDesc")
                    txtNutrDesc.Text = s;
                else if (s == "Nutr_No")
                    txtNutrNo.Text = s;
                else if (s == "Flav_Val" || s == "Isfl_Val")
                    txtFlavVal.Text = s;
            }

            txtNutrDesc.AutoCompleteCustomSource = source;
            txtNutrDesc.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtNutrDesc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtNutrNo.AutoCompleteCustomSource = source;
            txtNutrNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtNutrNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtFlavVal.AutoCompleteCustomSource = source;
            txtFlavVal.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtFlavVal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtNdb.AutoCompleteCustomSource = source;
            txtNdb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtNdb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeDBdir = shareDBdir + slash + comboBox1.Text;
            listBox1.Items.Clear();
            listBox1.Items.Add("<no matches>");
            listBox1.Items.Add("<drop a.TXT>");
            btnCreate.Enabled = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!headers.Contains(txtNutrNo.Text) || !headers.Contains(txtNutrDesc.Text) || !headers.Contains(txtNdb.Text) || !headers.Contains(txtFlavVal.Text))
            {
                MessageBox.Show("Please fill everything out.  Not all the fields match.");
                return;
            }

            string newRelDir = $"{Application.StartupPath}{slash}usr{slash}share{slash}rel{slash}{txtName.Text}";
            Directory.CreateDirectory(newRelDir);

			string unit = "";
            foreach (relFile r in relFiles)
            {
                string f = r.file.Split(new char[] { '/', '\\' })[r.file.Split(new char[] { '/', '\\' }).Length - 1].Replace(".TXT", "");
                Directory.CreateDirectory(newRelDir + slash + f);
                for (int i = 0; i < r.headers.Length; i++)
                {
                    column c = new column();
                    c.header = r.headers[i];
                    for (int j = 1; j < r.lines.Length; j++)
                        c.rows.Add(r.lines[j].Split('\t')[i]);
                    r.columns.Add(c);
                }
                foreach (column c in r.columns)
                {
                    File.WriteAllLines(newRelDir + slash + f + slash + c.header + ".TXT", c.rows);
                    if (c.header == txtNutrNo.Text)
                        nutrNos = c.rows;
                    else if (c.header == txtFlavVal.Text)
                        flavVal = $"{slash}{f}{slash}{c.header}.TXT";
                    if (r.unit != "")
                        unit = r.unit;
                }
                nutrNos = nutrNos.ToArray().Distinct().ToList();
                nutrNos.Sort();
                File.WriteAllText(newRelDir + slash + "_dbInit.TXT", $"[Flav_Val]{flavVal}\r\n[NDB_No]{txtNdb.Text}\r\n[Nutr_No]{txtNutrNo.Text}\r\n[NutrDesc]{txtNutrDesc.Text}\r\n[Units]{unit}\r\n\r\n[Fields]\r\n{string.Join("\r\n", nutrNos)}");
            }


            MessageBox.Show("Database created successfully!");
            //this.Close();
        }

        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
            txtNdb.Text = listBox1.Text;
        }
    }
}
