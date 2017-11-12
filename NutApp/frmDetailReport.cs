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

        string slash = Path.DirectorySeparatorChar.ToString();
        private void frmDetailReport_Load(object sender, EventArgs e)
        {
            string[] directs = Directory.GetFiles(Application.StartupPath + $"{slash}user data{slash}profile" + frmMain.profIndex.ToString() + $"{slash}foodlog");
            for (int i = 0; i < directs.Length; i++)
            {
                directs[i] = directs[i].Replace(Application.StartupPath + $"{slash}user data{slash}profile" + frmMain.profIndex.ToString() + $"{slash}foodlog{slash}", "");
                directs[i] = directs[i].Replace(".TXT", "");
                chkLstBoxDays.Items.Add(directs[i]);
            }
            txtOutput.Text = $"{slash}detailReport.TXT";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
