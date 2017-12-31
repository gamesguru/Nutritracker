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
                string leading = s.Split('#')[0]; 
                if (leading != "") // && frmMain.activeFields.Contains(leading))
                    activeFields.Add(leading);
            }


            ProcessStartInfo ps = new ProcessStartInfo($"{Application.StartupPath}{slash}logRunner.exe");
            // arg1   = profile #
            // arg2   = unique log output *.TXT, full file name
            // arg4[] = dates
            ps.Arguments = $"{frmMain.currentUser.index} {file} {string.Join(" ", days)}"; 
            Process.Start(ps);

            //need to add RDA in database for helper program to perform analysis..
            MessageBox.Show($"Log performed over {days.Count} days with {activeFields.Count} active fields\n\nWait for console to finish, it will save a log to\n{file}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
