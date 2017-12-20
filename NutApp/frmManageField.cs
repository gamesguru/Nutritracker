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
    public partial class frmManageField : Form
    {
        private frmParseCustomDatabase mainForm = null;
        public frmManageField(Form callingForm)
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
        string slash = Path.DirectorySeparatorChar.ToString();
        private void frmManageField_Load(object sender, EventArgs e)
        {
            string[] fields = Directory.GetDirectories(Application.StartupPath + $"{slash}usr{slash}profile" +
                                                       frmMain.profIndex.ToString() + $"{slash}DBs");
            for (int i = 0; i < fields.Length; i++)
            {
                fields[i] = fields[i].Replace(Application.StartupPath + $"{slash}usr{slash}profile" +
                                              frmMain.profIndex.ToString() + $"{slash}DBs{slash}", "");
                if (fields[i].StartsWith("f_user_"))
                    comboFields.Items.Add(fields[i].Remove(0, 7));
            }
            if (comboFields.Items.Count == 0)
            {
                MessageBox.Show("No Fields detected, please go to the spreadsheet wizard to create some.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            comboFields.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<string> lst = new List<string>();
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            source.Clear();
            renewFields();
            string dr = Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs{slash}f_user_" + comboFields.Text;
            string nkp = dr + $"{slash}_nutKeyPairs.TXT";
            string[] files = Directory.GetFiles(dr);

            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Replace(dr + $"{slash}", "");
                if (!files[i].StartsWith("_"))
                    source.Add(files[i]);
            }

            txtName.AutoCompleteCustomSource = source;
            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtServ.AutoCompleteCustomSource = source;
            txtServ.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtServ.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtWeight.AutoCompleteCustomSource = source;
            txtWeight.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtWeight.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtVal1.AutoCompleteCustomSource = source;
            txtVal1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtVal1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtVal2.AutoCompleteCustomSource = source;
            txtVal2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtVal2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtVal3.AutoCompleteCustomSource = source;
            txtVal3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtVal3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtOthUn.AutoCompleteCustomSource = source;
            txtOthUn.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtOthUn.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            string[] lst = importArray(nkp).ToArray();
            listView1.Clear();
            int z = 0;
            string[] vals = new string[] { "Name of Food", "Value1", "Value2", "Value3", "Serving", "Weight", "Other Units" };
            string[] keys = new string[7];

            for (int i = 0; i < vals.Length; i++)
                for (int j = 0; j < lst.Length; j++)
                {
                    string m = lst[j].Split('|')[0];
                    string n = lst[j].Split('|')[1];
                    keys[j] = m;
                    if (n == vals[i])
                        listView1.Columns.Add(n);
                    if (z == 0)
                        z = importArray(dr + $"{slash}" + m).Count;
                }

            //for (int i = 0; i < lst.Length; i++)
            //{

            //    string m = lst[i].Split('|')[0];
            //    string l = lst[i].Split('|')[1];
            //    if (l == "Name of Food")
            //    {
            //        listView1.Columns.Add(l);
            //        if (z == 0)
            //            z = importArray(dr + $"{slash}" + m).Count;
            //    }
            //    else if (l == "Value1")
            //    {
            //        listView1.Columns.Add(l);
            //        if (z == 0)
            //            z = importArray(dr + $"{slash}" + m).Count;
            //    }
            //    else if (l == "Value2")
            //    {
            //        listView1.Columns.Add(l);
            //        if (z == 0)
            //            z = importArray(dr + $"{slash}" + m).Count;
            //    }
            //    else if (l == "Value3")
            //    {
            //        listView1.Columns.Add(l);
            //        if (z == 0)
            //            z = importArray(dr + $"{slash}" + m).Count;
            //    }
            //    else if (l == "Other Units")
            //    {
            //        listView1.Columns.Add(l);
            //        if (z == 0)
            //            z = importArray(dr + $"{slash}" + m).Count;
            //    }
            //    else if (l == "Serving")
            //    {
            //        listView1.Columns.Add(l);
            //        if (z == 0)
            //            z = importArray(dr + $"{slash}" + m).Count;
            //    }
            //    else if (l == "Weight")
            //    {
            //        listView1.Columns.Add(l);
            //        if (z == 0)
            //            z = importArray(dr + $"{slash}" + m).Count;
            //    }
            //}

            //MessageBox.Show(string.Join(", ", importArray(dr + $"{slash}" + txtVal1.Text)));
            //int q = 0;
            List<string[]> valls = new List<string[]>();
            //string[,] valls = new string[vals.Length, 7];
            string[] names = new string[z];
            string[] val1 = new string[z];
            string[] val2 = new string[z];
            string[] val3 = new string[z];
            string[] servs = new string[z];
            string[] weights = new string[z];
            string[] othUnts = new string[z];

            for (int i = 0; i < 7/*valls.Count*/; i++)
                for (int j = 0; j < lst.Length; j++)
                {
                    string m = lst[j].Split('|')[0];
                    string n = lst[j].Split('|')[1];
                    string[] tmp = importArray(dr + $"{slash}" + m).ToArray();
                    //MessageBox.Show("k");
                    if (n == vals[i])
                        valls.Add(tmp);

                }
            //for (int i = 0; i < lst.Length; i++)
            //{

            //    string m = lst[i].Split('|')[0];
            //    string l = lst[i].Split('|')[1];
            //    if (l == "Name of Food")
            //        names = importArray(dr + $"{slash}" + m).ToArray();
            //    else if (l == "Value1")
            //        val1 = importArray(dr + $"{slash}" + m).ToArray();
            //    else if (l == "Value2")
            //        val2 = importArray(dr + $"{slash}" + m).ToArray();
            //    else if (l == "Value3")
            //        val3 = importArray(dr + $"{slash}" + m).ToArray();
            //    else if (l == "Other Units")
            //        othUnts = importArray(dr + $"{slash}" + m).ToArray();
            //    else if (l == "Serving")
            //        servs = importArray(dr + $"{slash}" + m).ToArray();
            //    else if (l == "Weight")
            //        weights = importArray(dr + $"{slash}" + m).ToArray();
            //}

            //MessageBox.Show(string.Join(", ", names));
            //MessageBox.Show(string.Join(", ", val1));

            //are these text fields null valued at this time??
            //does this go alphabetical and not according to plan?
            for (int i = 0; i < z; i++) {
                int q = 0;
                ListViewItem itm = new ListViewItem();
                for (int j = 0; j < Directory.GetFiles(dr).Length- 1; j++)
                {
                    if (Directory.GetFiles(dr)[j].Replace(dr + $"{slash}", "") == keys[0])
                    {
                        itm.Text = valls[0][q];
                        q++;
                    }
                    else if (Directory.GetFiles(dr)[j].Replace(dr + $"{slash}", "") == keys[j])
                    {
                        itm.SubItems.Add(valls[j][q]);
                        q++;
                    }
                }
                listView1.Items.Add(itm);
            }
            //for (int q = 0; q < z; q++)
            //{
            //    ListViewItem itm = new ListViewItem();
            //    for (int i = 0; i < Directory.GetFiles(dr).Length; i++)
            //    {
            //        if (Directory.GetFiles(dr)[i].Replace(dr + $"{slash}", "") == txtName.Text)
            //            itm.Text = valls[0][q];
            //        else if (Directory.GetFiles(dr)[i].Replace(dr + $"{slash}", "") == txtVal1.Text)
            //            itm.SubItems.Add(valls[1][q]);
            //        else if (Directory.GetFiles(dr)[i].Replace(dr + $"{slash}", "") == txtVal2.Text)
            //            itm.SubItems.Add(valls[2][q]);
            //        else if (Directory.GetFiles(dr)[i].Replace(dr + $"{slash}", "") == txtVal3.Text)
            //            itm.SubItems.Add(valls[3][q]);
            //        else if (Directory.GetFiles(dr)[i].Replace(dr + $"{slash}", "") == txtServ.Text)
            //            itm.SubItems.Add(valls[4][q]);
            //        else if (Directory.GetFiles(dr)[i].Replace(dr + $"{slash}", "") == txtWeight.Text)
            //            itm.SubItems.Add(valls[5][q]);
            //        else if (Directory.GetFiles(dr)[i].Replace(dr + $"{slash}", "") == txtOthUn.Text)
            //            itm.SubItems.Add(valls[6][q]);
            //    }
            //    listView1.Items.Add(itm);
            //}


            /*for (int i = 0; i < lst.Count; i++)
            {
                string m = lst[i].Split('|')[0];
                string l = lst[i].Split('|')[1];

                int q = 0;
                ListViewItem itm;
                if (l == "Name of Food")
                {
                    List<string> tmp = importArray(dr + $"{slash}" + m);

                }
                else if (l == "Value1")
                {
                    itm.SubItems.Add(m);
                }
                else if (l == "Value2")
                    listView1.Columns.Add(l);
                else if (l == "Value3")
                    listView1.Columns.Add(l);
                else if (l == "Other Units")
                    listView1.Columns.Add(l);
                else if (l == "Serving")
                    listView1.Columns.Add(l);
                else if (l == "Weight")
                    listView1.Columns.Add(l);

                listView1.Items.Add(itm);
            }*/
        }

        private void renewFields()
        {
            txtName.Text = "";
            txtVal1.Text = "";
            txtVal2.Text = "";
            txtVal3.Text = "";
            txtOthUn.Text = "";
            txtServ.Text = "";
            txtWeight.Text = "";

            lst = importArray(Application.StartupPath + $"{slash}usr{slash}profile" +
                              frmMain.profIndex.ToString() + $"{slash}DBs{slash}f_user_" + comboFields.Text + $"{slash}_nutKeyPairs.TXT");
            for (int i = 0; i < lst.Count; i++)
            {
                string m = lst[i].Split('|')[0];
                string l = lst[i].Split('|')[1];

                if (m == "200 kcal")
                    chkCal.Checked = true;
                else if (m == "100 grams")
                    chkGrams.Checked = true;
                else if (l == "Name of Food")
                    txtName.Text = m;
                else if (l == "Value1")
                    txtVal1.Text = m;
                else if (l == "Value2")
                    txtVal2.Text = m;
                else if (l == "Value3")
                    txtVal3.Text = m;
                else if (l == "Other Units")
                    txtOthUn.Text = m;
                else if (l == "Serving")
                    txtServ.Text = m;
                else if (l == "Weight")
                    txtWeight.Text = m;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            renewFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string dr = Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs{slash}f_user_" + comboFields.Text;
            List<string> text = new List<string>();

            if (chkCal.Checked)
                text.Add("200 kcal|Standardization");

            if (chkGrams.Checked)
                text.Add("100 grams|Standardization");

            if (txtName.TextLength > 0 && File.Exists(dr + $"{slash}" + txtName.Text))
                text.Add(txtName.Text + "|Name of Food");

            if (txtVal1.TextLength > 0 && File.Exists(dr + $"{slash}" + txtVal1.Text))
                text.Add(txtVal1.Text + "|Value1");

            if (txtVal2.TextLength > 0 && File.Exists(dr + $"{slash}" + txtVal2.Text))
                text.Add(txtVal2.Text + "|Value2");

            if (txtVal3.TextLength > 0 && File.Exists(dr + $"{slash}" + txtVal3.Text))
                text.Add(txtVal3.Text + "|Value3");

            if (txtOthUn.TextLength > 0 && File.Exists(dr + $"{slash}" + txtOthUn.Text))
                text.Add(txtOthUn.Text + "|Other Units");

            if (txtServ.TextLength > 0 && File.Exists(dr + $"{slash}" + txtServ.Text))
                text.Add(txtServ.Text + "|Serving");

            if (txtWeight.TextLength > 0 && File.Exists(dr + $"{slash}" + txtWeight.Text))
                text.Add(txtWeight.Text + "|Weight");
            File.WriteAllLines(dr + $"{slash}_nutKeyPairs.TXT", text);
            this.Close();
        }

        private void chkCal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCal.Checked)
                chkGrams.Checked = false;
        }

        private void chkGrams_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGrams.Checked)
                chkCal.Checked = false;
        }
    }
}
