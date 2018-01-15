using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing;

namespace Nutritracker
{
    public partial class licenseDialog : Form
    {
        public licenseDialog()
        {
            InitializeComponent();
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
           Process.GetCurrentProcess().Kill();
        }

        string[] apache;
        public List<string> profData;
        public string rt = "";
        string sl = Path.DirectorySeparatorChar.ToString();
        bool license;
        private void btnAccept_Click(object sender, EventArgs e)
        {
            profData.Add($"[License]StallmanApproves_{name.GetHashCode()}");
            File.WriteAllLines($"{rt}profile.TXT", profData);
            license = true;
            this.Close();
        }

        private void licenseDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!license)
                Process.GetCurrentProcess().Kill();
        }

        string name;
        private void licenseDialog_Load(object sender, EventArgs e)
        {
            mH = true;
            richTextBox1.Rtf = Nutritracker.Properties.Resources.apache;
            mH = false;
            apache = richTextBox1.Lines;
            //richTextBox1.Rtf = rtfs[m];
            //Size size = TextRenderer.MeasureText(richTextBox1.Text, richTextBox1.Font);
            ////richTextBox1.Width = size.Width;
            //richTextBox1.Height = size.Height;
            foreach (string s in profData)
                if (s.StartsWith("[Name]"))
                {
                    name = s.Replace("[Name]", "");
                    this.Text = $"License Agreement — {name}";
                    break;
                }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            //btnBack.Visible = true;
            //if (m < 6)
            //    m++;
            //richTextBox1.Rtf = rtfs[m];
            //if (m == 6)
            //{
            //    btnForward.Visible = false;
            //    btnAccept.Visible = true;
            //    btnBack.Focus();
            //}
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
        //    btnForward.Visible = true;
        //    if (m > 0)
        //        m--;
        //    richTextBox1.Rtf = rtfs[m];
        //    if (m == 0)
        //    {
        //        btnBack.Visible = false;
        //        btnForward.Focus();
        //    }
        }

        bool mH = false;
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (mH) return;
            btnAccept.Visible = false;
            bool en = true;
            for (int i = 0; i < richTextBox1.Lines.Length; i++)
                if (richTextBox1.Lines[i].Replace($"in acknowledgement: {name}", "in acknowledgement: ") != apache[i])
                    en = false;
            btnAccept.Visible = en;
        }
    }
}
