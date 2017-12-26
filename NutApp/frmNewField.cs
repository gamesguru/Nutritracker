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
    public partial class frmNewField : Form
    {
        private frmParseCustomDatabase mainForm = null;
        public frmNewField(Form callingForm)
        {
            mainForm = callingForm as frmParseCustomDatabase;
            InitializeComponent();
        }

        string slash = Path.DirectorySeparatorChar.ToString();
        public List<string> arr = new List<string>();
        public int n = 0;
        string searchKey = "";
        string value1Key = "";
        List<string> nameKeyPairs;
        private void frmNewField_Load(object sender, EventArgs e)
        {
            txtLoc.Text = $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs{slash}f_user_";
            lblRowCount.Text = "Your Field will have " + n.ToString() + " entries";
            for (int i = 0; i < arr.Count; i++)
            {
                string s = arr[i];
                listBox1.Items.Add(s);
                string s2 = "";
                try { s2 = s.Substring(0, 3); }
                catch { s2 = s.Substring(0, 2); }

                char[] iC = new char[] { '/', '\\', ':', '*', '?', '"', '<', '>', '|' , ' '};
                foreach (char c in iC)
                    if (s2.Contains(c))
                        s2 = s2.Replace(c, 'X');


                s2 = s2.Replace("(", i.ToString()).Replace(" ", "X");

                if (!listBox2.Items.Contains(s2.ToUpper()))
                    listBox2.Items.Add(s2.ToUpper());
                else { listBox2.Items.Add(s2.ToUpper() + i.ToString()); }
            }
            nameKeyPairs = new List<string>();
            for (int i = 0; i < listBox1.Items.Count; i++)
                nameKeyPairs.Add(listBox1.Items[i].ToString() + "|" + listBox2.Items[i].ToString());


            lblColumnCount.Text = "Your " + listBox1.Items.Count.ToString() + " columns and their abbreviations";

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.TextLength > 2 && lblSearchField.Text != "N/A" && lblCalories.Text != "N/A")
                btnCreate.Enabled = true;
            if (txtName.TextLength < 2)
                btnCreate.Enabled = false;
            txtLoc.Text = $"{slash}usr{slash}profile" + frmMain.profIndex.ToString() + $"{slash}DBs{slash}f_user_" +
                          txtName.Text.ToUpper();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsLetterOrDigit(e.KeyChar) && !Char.IsSeparator(e.KeyChar) &&
                e.KeyChar != '_' && e.KeyChar != '-')
                e.Handled = true;
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (lblSearchField.Text == "N/A")
            {
                lblSearchField.Text = listBox1.SelectedItem.ToString();
                searchKey = listBox2.Items[listBox1.SelectedIndex].ToString() + ".TXT";
                return;
            }
            if (lblCalories.Text == "N/A")
            {
                lblCalories.Text = listBox1.SelectedItem.ToString();
                value1Key = listBox2.Items[listBox1.SelectedIndex].ToString() + ".TXT";
            }
            if (txtName.TextLength > 2 && lblSearchField.Text != "N/A" && lblCalories.Text != "N/A")
                btnCreate.Enabled = true;
        }

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
                goto nxt;
            }
            Directory.CreateDirectory(fp);
            //MessageBox.Show(fp.Split(new string[] { "f_user_" }, StringSplitOptions.None)[0]);
            if (!File.Exists(fp.Split(new string[] { "f_user_" }, StringSplitOptions.None)[0] + "Slots.TXT"))
                File.Create(fp.Split(new string[] { "f_user_" }, StringSplitOptions.None)[0] + "Slots.TXT");
            nxt:
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string[] colVal = new string[n];
                for (int j = 0; j < n; j++)
                    colVal[j] = mainForm.getVal(j, i).Replace('\r', '\0').Replace('\n', '\0');
                File.WriteAllLines(fp + $"{slash}" + listBox2.Items[i].ToString() + ".TXT", colVal);
            }
            //File.WriteAllLines(fp + $"{slash}_nameKeyPairs.txt", nameKeyPairs);
            string[] firstCommit = { searchKey + "|Name of Food", value1Key + "|Value1" };
            File.WriteAllLines(fp + $"{slash}_nutKeyPairs.TXT", firstCommit);

            //File.WriteAllText(fp + $"{slash}_searchKey.txt", searchKey + ".txt");
            MessageBox.Show("Database created successfully.  Please use the search function on the main page to try it out.  Your first time using it, you will be asked to assign real nutrient names to the imported fields.  The software isn't able to do that yet.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnClearChoices_Click(object sender, EventArgs e)
        {
            lblSearchField.Text = "N/A";
            lblCalories.Text = "N/A";
            searchKey = "";
            value1Key = "";
            btnCreate.Enabled = false;
        }
    }
}
