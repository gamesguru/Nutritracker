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
    public partial class frmProfile : Form
    {
        public frmProfile()
        {
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

        private void txtNewProfName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtHt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtWt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private bool mH = false;
        private void txtNewProfName_TextChanged(object sender, EventArgs e)
        {
            if (mH)
                return;
            int n = txtNewProfName.SelectionStart;
            string chr = "";
            string rest = "";
            if (txtNewProfName.TextLength == 1)
            {
                mH = true;
                chr = txtNewProfName.Text[0].ToString().ToUpper();
                txtNewProfName.Text = chr;
                txtNewProfName.SelectionStart = n;
                mH = false;
            }
            else if (txtNewProfName.TextLength > 1)
            {
                mH = true;
                rest = txtNewProfName.Text.Substring(1, txtNewProfName.TextLength - 1).ToLower();
                chr = txtNewProfName.Text[0].ToString().ToUpper();
                txtNewProfName.Text = chr + rest;
                txtNewProfName.SelectionStart = n;
                mH = false;
            }

            

            for (int i = 0; i < comboExistingProfs.Items.Count; i++)
                if (txtNewProfName.Text.ToLower() == comboExistingProfs.Items[i].ToString().ToLower())
                {
                    comboExistingProfs.SelectedIndex = i;
                    btnDel.Enabled = true;
                    comboActivity.Enabled = true;
                    comboGoal.Enabled = true;
                    radioFemale.Enabled = true;
                    radioMale.Enabled = true;
                    txtAge.Enabled = true;
                    txtWt.Enabled = true;
                    txtHt.Enabled = true;
                    btnSave.Text = "Save Changes and Load";
                    return;
                }

            if (txtNewProfName.TextLength > 1)
            {
                if ((radioMale.Checked || radioFemale.Checked) &&
                    Convert.ToInt32(txtHt.Text) > 9 && Convert.ToInt32(txtWt.Text) > 4 &&
                    Convert.ToInt32(txtAge.Text) > 0 && comboActivity.SelectedIndex > -1 && comboGoal.SelectedIndex > -1)
                    btnSave.Enabled = true;
                else
                    btnSave.Enabled = false;
                btnSave.Text = "Create new Profile";
                mH = true;
                comboExistingProfs.SelectedIndex = -1;
                mH = false;

                comboActivity.Enabled = true;
                comboGoal.Enabled = true;
                comboActivity.SelectedIndex = -1;
                comboGoal.SelectedIndex = -1;

                radioFemale.Enabled = true;
                radioMale.Enabled = true;
                radioFemale.Checked = false;
                radioMale.Checked = false;

                txtAge.Enabled = true;
                txtWt.Enabled = true;
                txtHt.Enabled = true;
                txtAge.Clear();
                txtWt.Clear();
                txtHt.Clear();
                return;
            }

            btnDel.Enabled = false;
            mH = true;
            comboExistingProfs.SelectedIndex = -1;
            mH = false;

            comboActivity.Enabled = false;
            comboGoal.Enabled = false;
            comboActivity.SelectedIndex = -1;
            comboGoal.SelectedIndex = -1;

            radioFemale.Enabled = false;
            radioMale.Enabled = false;
            radioFemale.Checked = false;
            radioMale.Checked = false;

            txtAge.Enabled = false;
            txtWt.Enabled = false;
            txtHt.Enabled = false;
            txtAge.Clear();
            txtWt.Clear();
            txtHt.Clear();
        }


        private int profMax = 0;
        private int profIndex;
        private void frmProfile_Load(object sender, EventArgs e)
        {
            profIndex = frmMain.profIndex;
            //MessageBox.Show(Properties.Settings.Default.defaultIndex.ToString());
            string root = Application.StartupPath + $"{slash}user data";// profile" + profIndex.ToString();
            string[] directs = Directory.GetDirectories(root);
            //MessageBox.Show(string.Join(", ", directs));
            List<string> profs = new List<string>();
            for (int i=0;i<directs.Length;i++)
                if (directs[i].EndsWith($"{slash}profile" + i.ToString()))
                {
                    //MessageBox.Show(directs[i] + "{slash}profile" + i.ToString() + ".txt");
                    profs.Add(directs[i]);
                    comboExistingProfs.Items
                        .Add(importArray(directs[i] + $"{slash}profile" + i.ToString() + ".TXT")[0]); //importArray(root + "profile" + i.ToString() + ".txt")[0]);
                }
            if (comboExistingProfs.Items.Count > 0)
                comboExistingProfs.SelectedIndex = profIndex;

            if (Properties.Settings.Default.defaultIndex > comboExistingProfs.Items.Count-1)
                Properties.Settings.Default.defaultIndex -= 1;

            Properties.Settings.Default.Save();
            
            if (comboExistingProfs.SelectedIndex == Properties.Settings.Default.defaultIndex)
                checkDefaultProf.Enabled = false;
            else
                checkDefaultProf.Enabled = true;
            

            //comboActivity.SelectedIndex = Properties.Settings.Default.activityLvl;
            //comboGoal.SelectedIndex = Properties.Settings.Default.goal;

            profMax = directs.Length;
        }

        private void newProf()
        {

        }
        List<string> profs;
        private void btnSave_Click(object sender, EventArgs e)
        {


            if (Convert.ToInt32(txtBodyfat.Text) < 4 || Convert.ToInt32(txtBodyfat.Text) > 80)
            {
                MessageBox.Show("Please enter a body fat value between 4 and 80%.  This will affect calculations.  You can update your bodyfat later.", "Please check body fat %", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string text = "";
            int profIndex = 0;
            string root = Application.StartupPath + $"{slash}user data";
            string[] directs = Directory.GetDirectories(root);
            
            //profMax = files.Length;
            profs = new List<string>();
            for (int i = 0; i < directs.Length; i++)
            {
                if (directs[i].EndsWith($"{slash}profile" + i.ToString())
                    && importArray(directs[i] + $"{slash}profile" + i.ToString() + ".TXT")[0].ToLower() == comboExistingProfs.Text.ToLower())
                {
                    profIndex = i;
                    profs.Add(directs[i]);
                    comboExistingProfs.Items
                        .Add(importArray(directs[i] + $"{slash}profile" + i.ToString() + ".TXT")[0]); //importArray(root + "profile" + i.ToString() + ".txt")[0]);
                    break;
                }
                else
                {
                    profIndex = profMax;
                }
            }
            string gender = radioMale.Checked ? "male" : "female";
            text = txtNewProfName.Text + "\r\n" + gender + "\r\n" + txtAge.Text + "\r\n" + txtBodyfat.Text + "\r\n" + txtWt.Text +"\r\n" +txtHt.Text +"\r\n" + comboActivity.SelectedIndex.ToString() +"\r\n" +comboGoal.SelectedIndex.ToString();
            try { System.IO.File.WriteAllText(root + $"{slash}profile" + profIndex.ToString() + $"{slash}profile" + profIndex.ToString() + ".TXT", text); }
            catch
            {
                Directory.CreateDirectory(root + $"{slash}profile" + profIndex.ToString());
                Directory.CreateDirectory(root + $"{slash}profile" + profIndex.ToString() + $"{slash}foods");
                Directory.CreateDirectory(root + $"{slash}profile" + profIndex.ToString() + $"{slash}recipes");
                System.IO.File.WriteAllText(root + $"{slash}profile" + profIndex.ToString() + $"{slash}profile" + profIndex.ToString() + ".TXT", text);
                comboExistingProfs.Items.Add(txtNewProfName.Text);
                comboExistingProfs.SelectedIndex = comboExistingProfs.Items.Count - 1;
            }
            if (checkDefaultProf.Checked)
            {
                Properties.Settings.Default.defaultIndex = profIndex;
                Properties.Settings.Default.gender = radioMale.Checked;
                Properties.Settings.Default.age=Convert.ToInt32(txtAge.Text);
                Properties.Settings.Default.weight = Convert.ToInt32(txtWt.Text);
                Properties.Settings.Default.height=Convert.ToInt32(txtHt.Text);
                Properties.Settings.Default.activityLvl = comboActivity.SelectedIndex;
                Properties.Settings.Default.goal = comboGoal.SelectedIndex;
                Properties.Settings.Default.bodyFat = Convert.ToInt32(txtBodyfat.Text);
            }
            Properties.Settings.Default.Save();
            
            frmMain.loadIndex = comboExistingProfs.SelectedIndex;
            frmMain.profIndex = comboExistingProfs.SelectedIndex;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                Directory.Delete(Application.StartupPath + $"{slash}user data{slash}profile" + comboExistingProfs.SelectedIndex.ToString());
            //File.Delete(Application.StartupPath + $"{slash}user data{slash}profile" + comboExistingProfs.SelectedIndex.ToString() + $"{slash}profile" + comboExistingProfs.SelectedIndex.ToString() + ".txt");
            else
                return;

            //same as form load
            comboExistingProfs.Items.Clear();
            string root = Application.StartupPath + $"{slash}user data{slash}";
            string[] files = Directory.GetFiles(root);
            //MessageBox.Show(string.Join(", ", files));
            List<string> profs = new List<string>();
            for (int i = 0; i < files.Length; i++)
                if (files[i].Contains($"{slash}profile"))
                {
                    profs.Add(files[i]);
                    comboExistingProfs.Items
                        .Add(importArray(files[i])[0]); //importArray(root + "profile" + i.ToString() + ".txt")[0]);
                }

            if (Properties.Settings.Default.defaultIndex >= comboExistingProfs.Items.Count)
            Properties.Settings.Default.defaultIndex -= 1;

            comboExistingProfs.SelectedIndex = Properties.Settings.Default.defaultIndex;

            Properties.Settings.Default.Save();

            profMax = files.Length;

        }

        private void radioMale_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNewProfName.TextLength > 1 && (radioMale.Checked || radioFemale.Checked) &&
                    Convert.ToInt32(txtHt.Text) > 9 && Convert.ToInt32(txtWt.Text) > 4 &&
                    Convert.ToInt32(txtAge.Text) > 0 && comboActivity.SelectedIndex > -1 && comboGoal.SelectedIndex > -1)
                    btnSave.Enabled = true;
                else
                    btnSave.Enabled = false;
            }
            catch
            { btnSave.Enabled = false; }
        }

        private void radioFemale_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNewProfName.TextLength > 1 && (radioMale.Checked || radioFemale.Checked) &&
                    Convert.ToInt32(txtHt.Text) > 9 && Convert.ToInt32(txtWt.Text) > 4 &&
                    Convert.ToInt32(txtAge.Text) > 0 && comboActivity.SelectedIndex > -1 && comboGoal.SelectedIndex > -1)
                    btnSave.Enabled = true;
                else
                    btnSave.Enabled = false;
            }
            catch
            { btnSave.Enabled = false; }
        }

        private void txtHt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNewProfName.TextLength > 1 && (radioMale.Checked || radioFemale.Checked) &&
                    Convert.ToInt32(txtHt.Text) > 9 && Convert.ToInt32(txtWt.Text) > 4 &&
                    Convert.ToInt32(txtAge.Text) > 0 && comboActivity.SelectedIndex > -1 && comboGoal.SelectedIndex > -1)
                    btnSave.Enabled = true;
                else
                    btnSave.Enabled = false;
            }
            catch
            { btnSave.Enabled = false; }
        }

        private void txtWt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNewProfName.TextLength > 1 && (radioMale.Checked || radioFemale.Checked) &&
                    Convert.ToInt32(txtHt.Text) > 9 && Convert.ToInt32(txtWt.Text) > 4 &&
                    Convert.ToInt32(txtAge.Text) > 0 && comboActivity.SelectedIndex > -1 && comboGoal.SelectedIndex > -1)
                    btnSave.Enabled = true;
                else
                    btnSave.Enabled = false;
            }
            catch
            { btnSave.Enabled = false; }
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNewProfName.TextLength > 1 && (radioMale.Checked || radioFemale.Checked) &&
                    Convert.ToInt32(txtHt.Text) > 9 && Convert.ToInt32(txtWt.Text) > 4 &&
                    Convert.ToInt32(txtAge.Text) > 0 && comboActivity.SelectedIndex > -1 &&comboGoal.SelectedIndex > -1)
                    btnSave.Enabled = true;
                else
                    btnSave.Enabled = false;
            }
            catch
            { btnSave.Enabled = false; }
        }

        private void comboExistingProfs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!mH && txtNewProfName.Text.ToLower() != comboExistingProfs.Text.ToLower())
                txtNewProfName.Text = comboExistingProfs.Text;

            string root = Application.StartupPath + $"{slash}user data{slash}";
            string[] directs = Directory.GetDirectories(root);
            profs = new List<string>();
            //MessageBox.Show(string.Join(", ", directs));

            for (int i = 0; i < directs.Length; i++)
                if (directs[i].Contains($"{slash}profile" + i.ToString()) && importArray(directs[i] + $"{slash}profile" + i.ToString() + ".TXT")[0].ToLower() ==
                    comboExistingProfs.Text.ToLower())
                {
                    if (importArray(directs[i] + $"{slash}profile" + i.ToString() + ".TXT")[1] == "male")
                        radioMale.Checked = true;
                    else
                        radioFemale.Checked = true;
                    txtAge.Text = importArray(directs[i] + $"{slash}profile" + i.ToString() + ".TXT")[2];
                    txtBodyfat.Text = importArray(directs[i] + $"{slash}profile" + i.ToString() + ".TXT")[3];
                    txtWt.Text = importArray(directs[i] + $"{slash}profile" + i.ToString() + ".TXT")[4];
                    txtHt.Text = importArray(directs[i] + $"{slash}profile" + i.ToString() + ".TXT")[5];
                    comboActivity.SelectedIndex = Convert.ToInt32(importArray(directs[i] + $"{slash}profile" + i.ToString() + ".TXT")[6]);
                    comboGoal.SelectedIndex = Convert.ToInt32(importArray(directs[i] + $"{slash}profile" + i.ToString() + ".TXT")[7]);
                }
            if (comboExistingProfs.SelectedIndex == Properties.Settings.Default.defaultIndex)
                checkDefaultProf.Checked = true;
            else
                checkDefaultProf.Checked = false;

            if (comboExistingProfs.SelectedIndex == Properties.Settings.Default.defaultIndex)
                checkDefaultProf.Enabled = false;
            else
                checkDefaultProf.Enabled = true;
        }

        private void comboActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNewProfName.TextLength > 1 && (radioMale.Checked || radioFemale.Checked) &&
                    Convert.ToInt32(txtHt.Text) > 9 && Convert.ToInt32(txtWt.Text) > 4 &&
                    Convert.ToInt32(txtAge.Text) > 0 && comboActivity.SelectedIndex > -1 && comboGoal.SelectedIndex > -1)
                    btnSave.Enabled = true;
                else
                    btnSave.Enabled = false;
            }
            catch
            { btnSave.Enabled = false; }
        }

        private void comboGoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNewProfName.TextLength > 1 && (radioMale.Checked || radioFemale.Checked) &&
                    Convert.ToInt32(txtHt.Text) > 9 && Convert.ToInt32(txtWt.Text) > 4 &&
                    Convert.ToInt32(txtAge.Text) > 0 && comboActivity.SelectedIndex > -1 && comboGoal.SelectedIndex > -1)
                    btnSave.Enabled = true;
                else
                    btnSave.Enabled = false;
            }
            catch
            { btnSave.Enabled = false; }
        }
    }
}
