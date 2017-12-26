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
    public partial class frmDetailReport : Form
    {
        public frmDetailReport()
        {
            InitializeComponent();
        }

		static string slash = Path.DirectorySeparatorChar.ToString();
		string file = "";
        string profileRoot = Application.StartupPath + $"{slash}usr{slash}profile" + frmMain.profIndex.ToString();

        private void frmDetailReport_Load(object sender, EventArgs e)
        {
            string dte = DateTime.Now.ToString().Split(' ')[0].Replace("/", "-");
            string[] directs = Directory.GetFiles(profileRoot + $"{slash}foodlog");
            for (int i = 0; i < directs.Length; i++)
            {
                directs[i] = directs[i].Replace(profileRoot + $"{slash}foodlog{slash}", "");
                directs[i] = directs[i].Replace(".TXT", "");
                chkLstBoxDays.Items.Add(directs[i]);
            }
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

            string[] basicFields = new string[0];
            string[] extFields = new string[0];

			if (File.Exists(profileRoot + slash + "_basicFields.TXT") && File.Exists(profileRoot + slash + "_extFields.TXT"))
			{
                basicFields = File.ReadAllLines(profileRoot + slash + "_basicFields.TXT");
                extFields = File.ReadAllLines(profileRoot + slash + "_extFields.TXT");
			}

            MessageBox.Show($"Log performed with {basicFields.Length} basic fields and {extFields.Length} extended fields\n\nSaved to\n{file}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chkLstBoxDays_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (chkLstBoxDays.CheckedItems.Count == 0)
                btnRunReport.Enabled = false;
            else
                btnRunReport.Enabled = true;
        }
    }
}
