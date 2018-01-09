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

        string sl = Path.DirectorySeparatorChar.ToString();
        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<string> profData = File.ReadAllLines($"{frmMain.currentUser.root}{sl}profile.TXT").ToList();
            for (int i = 0; i < profData.Count; i++)
                if (profData[i].Contains("[License]"))
                {
                    profData[i] = "[License]true";
                    File.WriteAllLines($"{frmMain.currentUser.root}{sl}profile.TXT", profData);
                    this.Close();
                }
        }

        private void licenseDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
