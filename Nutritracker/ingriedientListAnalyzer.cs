using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nutritracker
{
    public partial class frmDecomposeRecipe : Form
    {
        public frmDecomposeRecipe()
        {
            InitializeComponent();
        }

        string[] ingrieds;
        private void frmDecomposeRecipe_Load(object sender, EventArgs e)
        {
             
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            comboIngrieds.Items.Clear();
            try {
                ingrieds = input.Split(new string[] {", ", "\n"}, StringSplitOptions.None);
                comboIngrieds.Items.Add("ALL");
                foreach (string s in ingrieds)
                    if (s.Length > 2)
                        comboIngrieds.Items.Add(s);
                comboIngrieds.SelectedIndex = 0;
            }
            catch {
                ingrieds = new string[0];
                ingrieds[0] = input;
                comboIngrieds.Items.Add("ALL");
                comboIngrieds.Items.Add(ingrieds[0]);
                comboIngrieds.SelectedIndex = 0;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
