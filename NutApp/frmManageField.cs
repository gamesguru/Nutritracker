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
                    list.Add(line);
                }
            }
            return list;
        }
        List<string> list = new List<string>();

        public enum Unit
        {
            g, mg, ug, kg, percent, iu, tbsp, tsp, cup, kcal
        }


        public class field
        {
            public string[] nkLines;
            public string name;
            public int z;
            public string standardization;
            public string[] nameOfFood;
            public string[] value1;
            public string[] value2;
            public string[] value3;
            public string[] serving;
            public string[] weight;
            public string[] othUnits;
            public Unit weightUnit;
        }

        List<field> Fields = new List<field>();
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
                {
                    string field = fields[i].Remove(0, 7);

                    field f = new field();
                    f.name = fields[i];
                    Fields.Add(f);

                    comboBox1.Items.Add(field);
                    comboBox2.Items.Add(field);
                    comboBox3.Items.Add(field);
                    comboBox4.Items.Add(field);
                    comboFields.Items.Add(field);
                }
            }
            if (comboFields.Items.Count == 0)
            {
                MessageBox.Show("No Fields detected, please go to the spreadsheet wizard to create some.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            for (int i = 0; i < Fields.Count; i++)
            {
                Fields[i].nkLines = File.ReadAllLines(Application.StartupPath + $"{slash}usr{slash}profile" +
                                              frmMain.profIndex.ToString() + $"{slash}DBs{slash}{Fields[i].name}{slash}_nutKeyPairs.TXT");
                for (int j = 0; j < Fields[i].nkLines.Length; j++)
                {
                    if (Fields[i].nkLines[j].Split('|')[1] == "Name of Food")
                        Fields[i].nameOfFood = File.ReadAllLines(Application.StartupPath + $"{slash}usr{slash}profile" +
                                              frmMain.profIndex.ToString() + $"{slash}DBs{slash}{Fields[i].name}{slash}{Fields[i].nkLines[j].Split('|')[0]}");
                    else if (Fields[i].nkLines[j].Split('|')[1] == "Value1")
                        Fields[i].value1 = File.ReadAllLines(Application.StartupPath + $"{slash}usr{slash}profile" +
                                              frmMain.profIndex.ToString() + $"{slash}DBs{slash}{Fields[i].name}{slash}{Fields[i].nkLines[j].Split('|')[0]}");
                    else if (Fields[i].nkLines[j].Split('|')[1] == "Value2")
                        Fields[i].value2 = File.ReadAllLines(Application.StartupPath + $"{slash}usr{slash}profile" +
                                              frmMain.profIndex.ToString() + $"{slash}DBs{slash}{Fields[i].name}{slash}{Fields[i].nkLines[j].Split('|')[0]}");
                    else if (Fields[i].nkLines[j].Split('|')[1] == "Value3")
                        Fields[i].value3 = File.ReadAllLines(Application.StartupPath + $"{slash}usr{slash}profile" +
                                              frmMain.profIndex.ToString() + $"{slash}DBs{slash}{Fields[i].name}{slash}{Fields[i].nkLines[j].Split('|')[0]}");
                    else if (Fields[i].nkLines[j].Split('|')[1] == "Serving")
                        Fields[i].serving = File.ReadAllLines(Application.StartupPath + $"{slash}usr{slash}profile" +
                                              frmMain.profIndex.ToString() + $"{slash}DBs{slash}{Fields[i].name}{slash}{Fields[i].nkLines[j].Split('|')[0]}");
                    else if (Fields[i].nkLines[j].Split('|')[1] == "Weight")
                        Fields[i].weight = File.ReadAllLines(Application.StartupPath + $"{slash}usr{slash}profile" +
                                              frmMain.profIndex.ToString() + $"{slash}DBs{slash}{Fields[i].name}{slash}{Fields[i].nkLines[j].Split('|')[0]}");
                    else if (Fields[i].nkLines[j].Split('|')[1] == "Other Units")
                        Fields[i].othUnits = File.ReadAllLines(Application.StartupPath + $"{slash}usr{slash}profile" +
                                              frmMain.profIndex.ToString() + $"{slash}DBs{slash}{Fields[i].name}{slash}{Fields[i].nkLines[j].Split('|')[0]}");
                }
                Fields[i].z = Fields[i].nameOfFood.Length;
            }


            comboFields.SelectedIndex = 0;
            string[] slots = File.ReadAllLines(Application.StartupPath + $"{slash}usr{slash}profile" +
                frmMain.profIndex.ToString() + $"{slash}DBs{slash}Slots.TXT");
            //MessageBox.Show (string.Join ("\n", slots).Replace("f_user_", ""));
            foreach (string s in slots)
            {
                if (comboBox1.Items.Contains(s.Remove(0, 7)) && comboBox1.SelectedIndex == -1)
                    comboBox1.SelectedIndex = comboBox1.Items.IndexOf(s.Remove(0, 7));
                else if (comboBox2.Items.Contains(s.Remove(0, 7)) && comboBox2.SelectedIndex == -1)
                    comboBox2.SelectedIndex = comboBox2.Items.IndexOf(s.Remove(0, 7));
                else if (comboBox3.Items.Contains(s.Remove(0, 7)) && comboBox3.SelectedIndex == -1)
                    comboBox3.SelectedIndex = comboBox3.Items.IndexOf(s.Remove(0, 7));
                else if (comboBox4.Items.Contains(s.Remove(0, 7)) && comboBox4.SelectedIndex == -1)
                    comboBox4.SelectedIndex = comboBox4.Items.IndexOf(s.Remove(0, 7));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<string> lst = new List<string>();
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Clear();
            source.Clear();
            textBox1.Clear();
            renewFields();
            string dr = Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs{slash}f_user_" + comboFields.Text;
            string nkp = dr + $"{slash}_nutKeyPairs.TXT";
            string[] files = Directory.GetFiles(dr);

            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Replace(dr + $"{slash}", "");
                if (!files[i].StartsWith("_"))
                {
                    source.Add(files[i]);
                    if (textBox1.Text == "" || textBox1.Text.EndsWith("\n"))
                        textBox1.Text += files[i].Replace(dr + slash, "") + "\t";
                    else if (textBox1.Text.EndsWith("\t"))
                        textBox1.Text += files[i].Replace(dr + slash, "") + "\n";
                }
            }
            #region autocompletes
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
            #endregion

            foreach (field f in Fields)
                if (f.name.Replace("f_user_", "") == comboFields.Text)
                {
                    if (f.name != null)
                        listView1.Columns.Add("Name of Food");
                    if (f.value1 != null && f.value1.Length == f.z)
                        listView1.Columns.Add("Value1");
                    if (f.value2 != null && f.value2.Length == f.z)
                        listView1.Columns.Add("Value2");
                    if (f.value3 != null && f.value3.Length == f.z)
                        listView1.Columns.Add("Value3");
                    if (f.serving != null && f.serving.Length == f.z)
                        listView1.Columns.Add("Serving");
                    if (f.weight != null && f.weight.Length == f.z)
                        listView1.Columns.Add("Weight");
                    if (f.othUnits != null && f.othUnits.Length == f.z)
                        listView1.Columns.Add("Other Units");

                    List<ListViewItem> itms = new List<ListViewItem>();
                    for (int i = 0; i < f.z; i++)
                    {
                        ListViewItem itm = new ListViewItem();

                        if (f.name != null)
                            itm.Text = f.nameOfFood[i];
                        if (f.value1 != null && f.value1.Length == f.z)
                            itm.SubItems.Add(f.value1[i]);
                        if (f.value2 != null && f.value2.Length == f.z)
                            itm.SubItems.Add(f.value2[i]);
                        if (f.value3 != null && f.value3.Length == f.z)
                            itm.SubItems.Add(f.value3[i]);
                        if (f.serving != null && f.serving.Length == f.z)
                            itm.SubItems.Add(f.serving[i]);
                        if (f.weight != null && f.weight.Length == f.z)
                            itm.SubItems.Add(f.weight[i]);
                        if (f.othUnits != null && f.othUnits.Length == f.z)
                            itm.SubItems.Add(f.othUnits[i]);

                        itms.Add(itm);
                        //MessageBox.Show(f.ToString());
                    }
                    listView1.BeginUpdate();
                    foreach (ListViewItem itm in itms)
                        listView1.Items.Add(itm);
                    listView1.EndUpdate();
                }
            //MessageBox.Show(Fields[0].z.ToString());
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
            bool chkCalBool = false;
            bool chkGramsBool = false;

            for (int i = 0; i < lst.Count; i++)
            {
                string m = lst[i].Split('|')[0];
                string l = lst[i].Split('|')[1];

                if (m == "200 kcal")
                    chkCalBool = true;
                else if (m == "100 grams")
                    chkGramsBool = true;
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

            chkCal.Checked = chkCalBool;
            chkGrams.Checked = chkGramsBool;
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

            text = new List<string>();
            if (comboBox1.SelectedIndex > -1)
                text.Add("f_user_" + comboBox1.SelectedItem.ToString());

            if (comboBox2.SelectedIndex > -1)
                text.Add("f_user_" + comboBox2.SelectedItem.ToString());

            if (comboBox3.SelectedIndex > -1)
                text.Add("f_user_" + comboBox3.SelectedItem.ToString());

            if (comboBox4.SelectedIndex > -1)
                text.Add("f_user_" + comboBox4.SelectedItem.ToString());

            File.WriteAllLines(Application.StartupPath + $"{slash}usr{slash}profile" +
            frmMain.profIndex.ToString() + $"{slash}DBs{slash}Slots.TXT", text);
            this.Close();
        }

        private void chkCal_CheckedChanged(object sender, EventArgs e)
        {
            string dr = Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs{slash}f_user_" + comboFields.Text;
            if (chkCal.Checked)
            {
                if (File.Exists(dr + slash + "SER.TXT") && MessageBox.Show("Are you sure you want to overwrite the old files? \n" + dr + slash + "SER.TXT", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    chkCal.Checked = false;
                    return;
                }


                try
                {
                    int n = 0;
                    foreach (string file in Directory.GetFiles(dr))
                        if (!file.StartsWith("_"))
                        {
                            n = File.ReadAllLines(file).Length;
                            break;
                        }

                    string[] servs = new string[n];
                    for (int i = 0; i < n; i++)
                        servs[i] = "200 kcal";
                    File.WriteAllLines(dr + slash + "SER.TXT", servs);
                    txtServ.Text = "SER.TXT";
                }
                catch
                {

                }
                chkGrams.Checked = false;
            }
            else
            {
                if (MessageBox.Show("Also delete file?\n" + dr + slash + "SER.TXT", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    File.Delete(dr + slash + "SER.TXT");
                txtServ.Text = "";
            }
        }

        private void chkGrams_CheckedChanged(object sender, EventArgs e)
        {
            string dr = Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs{slash}f_user_" + comboFields.Text;
            int n = 0;
            try
            {
                foreach (string file in Directory.GetFiles(dr))
                    if (!file.StartsWith("_"))
                    {
                        n = File.ReadAllLines(file).Length;
                        break;
                    }

            }
            catch
            {

            }
            if (chkGrams.Checked)
            {
                string[] grams = new string[n];
                string[] readIN = new string[n];
                try { readIN = File.ReadAllLines(dr + slash + "WEI.TXT"); }
                catch { }
                for (int i = 0; i < n; i++)
                    grams[i] = "100 g";
                bool fileMatch = true;
                for (int i = 0; i < n; i++)
                    if (grams[i] != readIN[i])
                        fileMatch = false;
                //MessageBox.Show(fileMatch.ToString());
                if (File.Exists(dr + slash + "WEI.TXT") && !fileMatch && MessageBox.Show("Are you sure you want to overwrite the old files with 100g standardization? \n" + dr + slash + "WEI.TXT", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    chkGrams.Checked = false;
                    return;
                }

                File.WriteAllLines(dr + slash + "WEI.TXT", grams);
                txtWeight.Text = "WEI.TXT";

                chkCal.Checked = false;
            }
            else
            {
                string[] grams = new string[n];
                string[] readIN;
                try { readIN = File.ReadAllLines(dr + slash + "WEI.TXT"); }
                catch { return; }
                for (int i = 0; i < n; i++)
                    grams[i] = "100 g";
                bool fileMatch = true;
                for (int i = 0; i < n; i++)
                    if (grams[i] != readIN[i])
                        fileMatch = false;
                if (File.Exists(dr + slash + "WEI.TXT") && fileMatch && MessageBox.Show("Shall we also delete the record of the file?\n" + dr + slash + "WEI.TXT", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    File.Delete(dr + slash + "WEI.TXT");
                txtWeight.Text = "";
                //
                //add code to modify _nutKeyPairs.TXT
                //do the same for 200kcal standardization chunk of code
            }
        }
       
    }
}
