using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Nutritracker
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
        public int defaultIndex;
        private void frmProfile_Load(object sender, EventArgs e)
        {
            profIndex = frmMain.currentUser.index;
            string root = $"{Application.StartupPath}{slash}usr";
            try
            {
                defaultIndex = Convert.ToInt32(Directory.GetFiles(root)[0].Replace($"{root}{slash}default", ""));
            }
            catch{
                defaultIndex = 0;
                File.Create($"{root}{slash}default0");
            }

            string[] directs = Directory.GetDirectories(root);
            //MessageBox.Show(string.Join(", ", directs));
            List<string> profs = new List<string>();
            for (int i=0;i<directs.Length;i++)
                if (directs[i].EndsWith($"{slash}profile{i}"))
                {
                    //MessageBox.Show(directs[i] + "{slash}profile.txt");
                    profs.Add(directs[i]);
                    comboExistingProfs.Items
                        .Add(importArray($"{directs[i]}{slash}profile.TXT")[0]); //importArray(root + "profile.txt")[0]);
                }
            if (comboExistingProfs.Items.Count > 0)
                comboExistingProfs.SelectedIndex = profIndex;

            if (defaultIndex > comboExistingProfs.Items.Count-1)
                defaultIndex -= 1;

            foreach (string s in Directory.GetFiles(root))
                File.Delete(s);
            File.Create($"{root}{slash}default{frmMain.currentUser.index}").Close();
            
            if (comboExistingProfs.SelectedIndex == defaultIndex)
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
            string root = Application.StartupPath + $"{slash}usr";
            string[] directs = Directory.GetDirectories(root);
            
            //profMax = files.Length;
            profs = new List<string>();
            for (int i = 0; i < directs.Length; i++)
            {
                if (directs[i].EndsWith($"{slash}profile{i}")
                    && importArray($"{directs[i]}{slash}profile.TXT")[0].ToLower() == comboExistingProfs.Text.ToLower())
                {
                    profIndex = i;
                    profs.Add(directs[i]);
                    comboExistingProfs.Items
                        .Add(importArray($"{directs[i]}{slash}profile.TXT")[0]); //importArray(root + "profile.txt")[0]);
                    break;
                }
                else
                {
                    profIndex = profMax;
                }
            }
            string gender = radioMale.Checked ? "male" : "female";
            text = txtNewProfName.Text + "\r\n" + gender + "\r\n" + txtAge.Text + "\r\n" + txtBodyfat.Text + "\r\n" + txtWt.Text + "\r\n" + txtHt.Text + "\r\n" + comboActivity.SelectedIndex.ToString() + "\r\n" + comboGoal.SelectedIndex.ToString() + "\r\n" + frmMain.dte;
            try { System.IO.File.WriteAllText($"{root}{slash}profile{profIndex}{slash}profile.TXT", text); }
            catch
            {
                Directory.CreateDirectory( $"{root}{slash}profile" + profIndex.ToString());
                Directory.CreateDirectory($"{root}{slash}profile{profIndex}{slash}foods");
                Directory.CreateDirectory($"{root}{slash}profile{profIndex}{slash}recipes");
                System.IO.File.WriteAllText($"{root}{slash}profile{profIndex}{slash}profile.TXT", text);
                comboExistingProfs.Items.Add(txtNewProfName.Text);
                comboExistingProfs.SelectedIndex = comboExistingProfs.Items.Count - 1;
            }
            if (checkDefaultProf.Checked)
            {
                foreach (string s in Directory.GetFiles(root))
                    File.Delete(s);
                File.Create(root + $"{slash}default{frmMain.currentUser.index}").Close();
            }
            
            frmMain.currentUser.index = comboExistingProfs.SelectedIndex;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                Directory.Delete($"{Application.StartupPath}{slash}usr{slash}profile{comboExistingProfs.SelectedIndex}");
            //File.Delete(Application.StartupPath + $"{slash}usr{slash}profile" + comboExistingProfs.SelectedIndex.ToString() + $"{slash}profile" + comboExistingProfs.SelectedIndex.ToString() + ".txt");
            else
                return;

            //same as form load
            comboExistingProfs.Items.Clear();
            string root = $"{Application.StartupPath}{slash}usr{slash}";
            string[] files = Directory.GetFiles(root);
            //MessageBox.Show(string.Join(", ", files));
            List<string> profs = new List<string>();
            for (int i = 0; i < files.Length; i++)
                if (files[i].Contains($"{slash}profile"))
                {
                    profs.Add(files[i]);
                    comboExistingProfs.Items
                        .Add(importArray(files[i])[0]); //importArray(root + "profile.txt")[0]);
                }

            if (defaultIndex >= comboExistingProfs.Items.Count)
            defaultIndex -= 1;

            comboExistingProfs.SelectedIndex = defaultIndex;

            foreach (string s in Directory.GetFiles(root))
                File.Delete(s);
            File.Create($"{root}{slash}default{frmMain.currentUser.index}").Close();

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

            string root = Application.StartupPath + $"{slash}usr{slash}";
            string[] directs = Directory.GetDirectories(root);
            profs = new List<string>();
            //MessageBox.Show(string.Join(", ", directs));

            for (int i = 0; i < directs.Length; i++)
                if (directs[i].Contains($"{slash}profile{i}") && importArray($"{directs[i]}{slash}profile.TXT")[0].ToLower() ==
                    comboExistingProfs.Text.ToLower())
                {
                    if (importArray($"{directs[i]}{slash}profile.TXT")[1] == "male")
                        radioMale.Checked = true;
                    else
                        radioFemale.Checked = true;
                    txtAge.Text = importArray($"{directs[i]}{slash}profile.TXT")[2];
                    txtBodyfat.Text = importArray($"{directs[i]}{slash}profile.TXT")[3];
                    txtWt.Text = importArray($"{directs[i]}{slash}profile.TXT")[4];
                    txtHt.Text = importArray($"{directs[i]}{slash}profile.TXT")[5];
                    comboActivity.SelectedIndex = Convert.ToInt32(importArray($"{directs[i]}{slash}profile.TXT")[6]);
                    comboGoal.SelectedIndex = Convert.ToInt32(importArray($"{directs[i]}{slash}profile.TXT")[7]);
                }
            if (comboExistingProfs.SelectedIndex == defaultIndex)
                checkDefaultProf.Checked = true;
            else
                checkDefaultProf.Checked = false;

            if (comboExistingProfs.SelectedIndex == defaultIndex)
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
