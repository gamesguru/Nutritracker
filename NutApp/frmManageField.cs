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
			public string dbInit;
            public string dbConfig;
			public List<dbi> dbInitKeys = new List<dbi>();
			public List<dbc> dbConfigKeys = new List<dbc>();
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
			public string[] valueNames = new string[2];
			public Unit weightUnit;
			public Unit servUnit;
        }

		public class dbi
		{
			public string fileName;
			public string header;
			public string unit;
		}
		public class dbc
		{
			public string fileName;
			public string metricName;
			public string nut;
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
                    f.name = fields[i].Replace("f_user_", "");
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
                Fields[i].dbInit = File.ReadAllText(Application.StartupPath + $"{slash}usr{slash}profile{frmMain.profIndex.ToString()}{slash}DBs{slash}f_user_{Fields[i].name}{slash}_dbInit.TXT");
                string[] items = Fields[i].dbInit.Split(new string[] {"[File]"}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in items){
                    string[] lines = s.Replace("\r", "").Split('\n');
                    dbi di = new dbi();
                    di.fileName = lines[0];
                    di.header = lines[1].Replace("[Header]", "");
					foreach (string st in lines)					
						if (st.Contains("[Unit]"))
                            di.unit = st.Replace("[Unit]", "");
                    Fields[i].dbInitKeys.Add(di);
                }


				Fields[i].dbConfig = File.ReadAllText(Application.StartupPath + $"{slash}usr{slash}profile{frmMain.profIndex.ToString()}{slash}DBs{slash}f_user_{Fields[i].name}{slash}_dbConfig.TXT");
				items = Fields[i].dbConfig.Split(new string[] { "[File]" }, StringSplitOptions.RemoveEmptyEntries);
				foreach (string s in items)
				{
					string[] lines = s.Replace("\r", "").Split('\n');
					dbc dc = new dbc();
					dc.fileName = lines[0];
					foreach (string st in lines)
					{
						if (st.Contains("[Nut]"))
							dc.nut = st.Replace("[Nut]", "");
						else if (st.Contains("[MetricName]"))
							dc.metricName = st.Replace("[MetricName]", "");
					}
                    Fields[i].dbConfigKeys.Add(dc);
				}
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


        //private List<string> lst = new List<string>();
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Clear();
            source.Clear();
            textBox1.Clear();
            updateTextboxes();
            string dr = Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs{slash}f_user_" + comboFields.Text;
            //nkp = dr + $"{slash}_nutKeyPairs.TXT";
            //dbi = dr + slash + "_dbInfo.TXT";
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

			List<ListViewItem> itms = new List<ListViewItem>();
            foreach (field f in Fields)
                if (f.name == comboFields.Text)
                {
                    foreach (dbc k in f.dbConfigKeys)
                    {
                        if (k.nut == "Name of Food")
                            listView1.Columns.Add(k.nut);
                        else if (k.nut == "Value1")
                            listView1.Columns.Add(k.metricName);
                        else if (k.nut == "Value2")
                            listView1.Columns.Add(k.metricName);
                        else if (k.nut == "Value3")
                            listView1.Columns.Add(k.metricName);
                        else if (k.nut == "Other Units")
                            listView1.Columns.Add(k.nut);
                        else if (k.nut == "Serving")
                            listView1.Columns.Add(k.nut);
                        else if (k.nut == "Weight")
                            listView1.Columns.Add(k.nut);
                    }

                    listView1.BeginUpdate();
                    foreach (ListViewItem itm in itms)
                        listView1.Items.Add(itm);
                    listView1.EndUpdate();
                }
        }
            //MessageBox.Show(Fields[0].z.ToString());


        private void updateTextboxes()
        {
            txtName.Text = "";
            txtVal1.Text = "";
            txtVal2.Text = "";
            txtVal3.Text = "";
            txtValName1.Text = "";
            txtValName2.Text = "";
            txtValName3.Text = "";
            txtOthUn.Text = "";
            txtServ.Text = "";
            txtWeight.Text = "";
            //dbi = Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs{slash}f_user_" + comboFields.Text + $"{slash}_dbInfo.TXT";
            foreach (field f in Fields)
            {
                if (f.name == comboFields.Text)
                    foreach (dbc k in f.dbConfigKeys)
                    {
                        if (k.nut == "Name of Food")
                            txtName.Text = k.fileName;
                        else if (k.nut == "Value1")
                        {
                            txtVal1.Text = k.fileName;
                            txtValName1.Text = k.metricName;
                        }
                        else if (k.nut == "Value2")
                        {
                            txtVal2.Text = k.fileName;
                            txtValName2.Text = k.metricName;
                        }
                        else if (k.nut == "Value3")
                        {
                            txtVal3.Text = k.fileName;
                            txtValName3.Text = k.metricName;
                        }
                        else if (k.nut == "Other Units")
                            txtOthUn.Text = k.fileName;
                        else if (k.nut == "Serving")
                            txtServ.Text = k.fileName;
                        else if (k.nut == "Weight")
                            txtWeight.Text = k.fileName;
                    }
            }

            //lst = importArray(dbi); //importArray(Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs{slash}f_user_" + comboFields.Text + $"{slash}_nutKeyPairs.TXT");
            bool chkCalBool = false;
            bool chkGramsBool = false;

            chkCal.Checked = chkCalBool;
            chkGrams.Checked = chkGramsBool;
        }

        private void button4_Click(object sender, EventArgs e) //reset button
        {
            updateTextboxes();
        }

        //this is causing problems if the user switches values 2 and 3, or something similar.  the [Header] and [Units]
        private void btnSave_Click(object sender, EventArgs e)
        {
            string dr = Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs{slash}f_user_" + comboFields.Text;

            //List<string> text = new List<string>();

            field f = new field();
            foreach (field F in Fields)
                if (F.name == comboFields.Text)
                    f = F;


			//marks updates to the log
			//if (chkCal.Checked)
			//    text.Add("200 kcal|Standardization");

			//if (chkGrams.Checked)
			//text.Add("100 grams|Standardization");
			foreach (dbc ck in f.dbConfigKeys)
			{
				if (txtName.Text == ck.fileName)				
					ck.nut = "Name of Food";				
				else if (txtVal1.Text == ck.fileName)
				{
					ck.nut = "Value1";
					ck.metricName = txtValName1.Text;
				}
				else if (txtVal2.Text == ck.fileName)
				{
					ck.nut = "Value2";
					ck.metricName = txtValName2.Text;
				}
				else if (txtVal3.Text == ck.fileName)
				{
					ck.nut = "Value3";
					ck.metricName = txtValName3.Text;
				}
				else if (txtOthUn.Text == ck.fileName)
					ck.nut = "Other Units";
				else if (txtServ.Text == ck.fileName)
					ck.nut = "Serving";
			}

            //saves to disk
            List<string> output = new List<string>();
            foreach (dbc k in f.dbConfigKeys){
				List<string> temp = new List<string>();
				temp.Add($"[File]{k.fileName}");
				if (k.nut != null)
					temp.Add("[Nut]" + k.nut);
				if (k.nut != null && (k.nut == "Value1" || k.nut == "Value2" || k.nut == "Value3"))
					temp.Add("[MetricName]" + k.metricName);
				temp.Add("");
				output.Add(string.Join("\r\n", temp));
            }


            File.WriteAllLines(dr + slash+"_dbConfig.TXT", output);

			output = new List<string>();
			if (comboBox1.SelectedIndex > -1)
			    output.Add("f_user_" + comboBox1.SelectedItem.ToString());

			if (comboBox2.SelectedIndex > -1)
			    output.Add("f_user_" + comboBox2.SelectedItem.ToString());

			if (comboBox3.SelectedIndex > -1)
			    output.Add("f_user_" + comboBox3.SelectedItem.ToString());

			if (comboBox4.SelectedIndex > -1)
			    output.Add("f_user_" + comboBox4.SelectedItem.ToString());

            File.WriteAllLines(Application.StartupPath + $"{slash}usr{slash}profile{frmMain.profIndex.ToString()}{slash}DBs{slash}Slots.TXT", output);
			this.Close();
        }

        private void chkCal_CheckedChanged(object sender, EventArgs e)
        {
            string dr = Application.StartupPath + $"{slash}usr{slash}profile{frmMain.profIndex.ToString()}{slash}DBs{slash}f_user_" + comboFields.Text;
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
