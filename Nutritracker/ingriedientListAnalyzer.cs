using System;
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
            lstBoxIngrieds.Items.Clear();
            try {
                ingrieds = input.Split(new string[] {/*", ", */"\n"}, StringSplitOptions.None);
                lstBoxIngrieds.Items.Add("ALL");
                foreach (string s in ingrieds)
                    if (s.Length > 2)
                        lstBoxIngrieds.Items.Add(s);
            }
            catch {
                ingrieds = new string[0];
                ingrieds[0] = input;
                lstBoxIngrieds.Items.Add("ALL");
                lstBoxIngrieds.Items.Add(ingrieds[0]);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void lstBoxIngrieds_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTweak.Text = lstBoxIngrieds.SelectedItem.ToString().Split(new string[] { " [\"" }, StringSplitOptions.None)[0];
        }

        private void txtTweak_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackGeo_Scroll(object sender, EventArgs e)
        {

        }

        private void trackArith_Scroll(object sender, EventArgs e)
        {

        }
    }
}
