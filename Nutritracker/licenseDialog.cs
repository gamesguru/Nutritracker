using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

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

        public List<string> profData;
        public string rt = "";
        string sl = Path.DirectorySeparatorChar.ToString();
        bool license;
        private void btnAccept_Click(object sender, EventArgs e)
        {
            profData.Add("[License]true");
            File.WriteAllLines($"{rt}profile.TXT", profData);
            license = true;
            this.Close();
        }

        private void licenseDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!license)
                Process.GetCurrentProcess().Kill();
        }

        string[] rtfs = new string[] { Nutritracker.Properties.Resources.gnl1, Nutritracker.Properties.Resources.gnl2, Nutritracker.Properties.Resources.gnl3,
            Nutritracker.Properties.Resources.gnl4, Nutritracker.Properties.Resources.gnl5, Nutritracker.Properties.Resources.gnl6,
            Nutritracker.Properties.Resources.gnl7, Nutritracker.Properties.Resources.gnl9, Nutritracker.Properties.Resources.gnl10 };
        int m = 0;
        private void licenseDialog_Load(object sender, EventArgs e)
        {
            richTextBox1.Rtf = rtfs[m];
            foreach (string s in profData)
                if (s.StartsWith("[Name]"))
                    this.Text = $"License Agreement — {s.Replace("[Name]", "")}";
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            btnBack.Visible = true;
            if (m < 8)
                m++;
            richTextBox1.Rtf = rtfs[m];
            if (m == 8)
            {
                btnForward.Visible = false;
                btnAccept.Visible = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnForward.Visible = true;            
            if (m > 0)
                m--;
            richTextBox1.Rtf = rtfs[m];
            if (m == 0)
                btnBack.Visible = false;
        }
    }
}
