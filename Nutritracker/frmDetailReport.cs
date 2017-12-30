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
using System.Diagnostics;

namespace Nutritracker
{
    public partial class frmDetailReport : Form
    {
        public frmDetailReport()
        {
            InitializeComponent();
        }

		static string slash = Path.DirectorySeparatorChar.ToString();
		string file = "";
        string profileRoot = Application.StartupPath + $"{slash}usr{slash}profile{frmMain.currentUser.index}";
        List<string> activeFields = new List<string>();
        
        private void frmDetailReport_Load(object sender, EventArgs e)
        {
            string dte = DateTime.Now.ToString().Split(' ')[0].Replace("/", "-");
            string[] directs = Directory.GetFiles(profileRoot + $"{slash}foodlog");
            for (int i = 0; i < directs.Length; i++)
            {
                directs[i] = directs[i].Replace($"{profileRoot}{slash}foodlog{slash}", "");
                directs[i] = directs[i].Replace(".TXT", "");
                chkLstBoxDays.Items.Add(directs[i]);
            }
            chkLstBoxDays.Items.Add("All");
            int n = 0;
            while (File.Exists(file = profileRoot + $"{slash}detailReport_{dte}_{n}.TXT"))
                n++;
            txtOutput.Text = file.Replace(Application.StartupPath, "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chkLstBoxDays.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select something!!");
                return;
            }

            List<string> days = new List<string>();
            for (int i = 0; i < chkLstBoxDays.Items.Count; i++)
                if (chkLstBoxDays.GetItemChecked(i) && chkLstBoxDays.Items[i].ToString() != "All")
                    days.Add(chkLstBoxDays.Items[i].ToString());

            string[] activeNutsLines = File.ReadAllLines($"{profileRoot}{slash}activeFields.TXT");
            foreach (string s in activeNutsLines){
                if (s.Split('#')[0] != "")
                    activeFields.Add(s.Split('#')[0]);
            }

            ProcessStartInfo ps = new ProcessStartInfo($"{Application.StartupPath}{slash}logRunner.exe");
            // arg1   = profile #
            // arg2[] = active fields
            // arg3[] = days
            ps.Arguments = $"{frmMain.currentUser.index} {profileRoot}{slash}activeFields.TXT {string.Join(" ", days)}"; 
            Process.Start(ps);

            
            string[] basicFields = new string[0];
            string[] extFields = new string[0];

			if (File.Exists(profileRoot + slash + "_basicFields.TXT") && File.Exists(profileRoot + slash + "_extFields.TXT"))
			{
                basicFields = File.ReadAllLines(profileRoot + slash + "_basicFields.TXT");
                extFields = File.ReadAllLines(profileRoot + slash + "_extFields.TXT");
			}

            //MessageBox.Show($"Log performed with {basicFields.Length} basic fields and {extFields.Length} extended fields\n\nSaved to\n{file}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chkLstBoxDays_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (chkLstBoxDays.Items[e.Index].ToString() == "All" && e.NewValue == System.Windows.Forms.CheckState.Checked)
                for (int i = 0; i < chkLstBoxDays.Items.Count - 1; i++)
                    chkLstBoxDays.SetItemChecked(i, true);
             else if (chkLstBoxDays.Items[e.Index].ToString() == "All" && e.NewValue == System.Windows.Forms.CheckState.Unchecked)
                for (int i = 0; i < chkLstBoxDays.Items.Count - 1; i++)
                    chkLstBoxDays.SetItemChecked(i, false);
        }
    }
}
