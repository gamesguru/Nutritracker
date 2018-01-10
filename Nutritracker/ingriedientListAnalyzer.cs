using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace Nutritracker
{
    public partial class frmDecomposeRecipe : Form
    {
        public frmDecomposeRecipe()
        {
            InitializeComponent();
        }

		static string nl;
		static string sl;
        private void frmDecomposeRecipe_Load(object sender, EventArgs e)
        {
            updatePer();
            nl = Environment.NewLine;
            sl = Path.DirectorySeparatorChar.ToString();
        }

		string[] ingrieds;
        private void txtIngrieds_TextChanged(object sender, EventArgs e)
        {
            string input = txtIngrieds.Text;
            lstBoxIngrieds.Items.Clear();
            List<string> output = input.Split(new string[] { nl }, StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i=0;i<output.Count;i++)
                if (output[i].Length < 3)
                    output.RemoveAt(i);
            ingrieds = output.ToArray();
            updatePer();
            updateList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void lstBoxIngrieds_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTweakName.Text = lstBoxIngrieds.SelectedItem.ToString().Split(new string[] { " -- " }, StringSplitOptions.None)[0];
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
            updatePer();
            updateList();
        }
        private void updateList()
        {
            lstBoxIngrieds.Items.Clear();
            for (int i = 0; i < ingrieds.Length; i++)
                lstBoxIngrieds.Items.Add($"{ingrieds[i]} -- {percents[i]}%");
            lstBoxIngrieds.SelectedIndex = 0;
        }
        private void updatePer()
        {
            x = (double)trackGeo.Value / trackGeo.Maximum;
            if (ingrieds == null) {
                percents = new double[] { 100.0 };
            return;
            }

            double q = 0;
            for (int i = 0; i < ingrieds.Length; i++)
                q += Math.Pow(x, i);
            double a = 1 / q;

            percents = new double[ingrieds.Length];
            for (int i = 0; i < percents.Length; i++)
                percents[i] = Math.Round(a * Math.Pow(x, i), 3) * 100;
        }
        List<double> _percents;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRecipeName.TextLength < 4)
            {
                MessageBox.Show("Error: recipe name must be at least four characters.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (char c in txtRecipeName.Text)
                if (!Char.IsLetterOrDigit(c) && !Char.IsSeparator(c))
                {
                    MessageBox.Show("Error: recipe name contains illegal characters.  Letters, digits and spaces only.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            _percents = new List<double>();
            foreach (string s in lstBoxIngrieds.Items)            
                _percents.Add(Convert.ToDouble(s.Split(new string[] { " -- " }, StringSplitOptions.RemoveEmptyEntries)[1]));            
        }

        private void lstBoxIngrieds_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
