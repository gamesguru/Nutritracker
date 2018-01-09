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
    }
}
