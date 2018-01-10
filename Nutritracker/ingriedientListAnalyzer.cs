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
            updatePer();
        }

        private void txtIngrieds_TextChanged(object sender, EventArgs e)
        {
            string input = txtIngrieds.Text;
            lstBoxIngrieds.Items.Clear();
            try {
                ingrieds = input.Split(new string[] {/*", ", */"\n"}, StringSplitOptions.None);
                for (int i = 0; i < ingrieds.Length; i++)
                    if (ingrieds[0].Length > 2)
                        lstBoxIngrieds.Items.Add($"{ingrieds[0]} -- {percents[0]}");

                lstBoxIngrieds.Items.Add("ALL");
            }
            catch {
                ingrieds = new string[0];
                ingrieds[0] = input;
                lstBoxIngrieds.Items.Add($"{ingrieds[0]} -- {percents[0]}");
				lstBoxIngrieds.Items.Add("ALL");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void lstBoxIngrieds_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTweakName.Text = lstBoxIngrieds.SelectedItem.ToString().Split(new string[] { " [\"" }, StringSplitOptions.None)[0];
        }

        private void txtTweakName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTweakWeight_TextChanged(object sender, EventArgs e)
        {

        }

        double x = 0.4;
        double[] percents;
        private void trackGeo_Scroll(object sender, EventArgs e)
        {
          
        }

        private void updatePer()
        {
            lstBoxIngrieds.Items.Clear();
            x = (double)trackGeo.Value / trackGeo.Maximum;
            if (ingrieds == null) return;

            double q = 0;
            for (int i = 0; i < ingrieds.Length; i++)
                q += Math.Pow(x, i);
            double a = 1 / q;

            percents = new double[ingrieds.Length];
            for (int i = 0; i < percents.Length; i++)
                percents[i] = Math.Round(a * Math.Pow(x, i), 3) * 100;
            foreach (double d in percents)
                lstBoxIngrieds.Items.Add(d.ToString());
        }
    }
}
