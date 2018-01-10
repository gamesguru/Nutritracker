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

        private class _dbObj
        {
            public string db = "USDAstock";
            public string ndbno;
            public string name;
            public double percent;
            public double weight;
        }
        List<_dbObj> dbobjs;
        _dbObj currentObj;
        private static class DB
        {
            public static string[] ndbs;
            public static string[] names;
            public static int[] wMatch;
            public static string[] joinedMatches;
        }
        char[] _delims = new char[] { '/', ',', ' ', '-', ';', '(', ')' };

        static string nl;
		static string sl;
        private void frmDecomposeRecipe_Load(object sender, EventArgs e)
        {
            updatePer();
            nl = Environment.NewLine;
            sl = Path.DirectorySeparatorChar.ToString();
            string[] nutKeyLines = File.ReadAllLines($"{Application.StartupPath}{sl}usr{sl}share{sl}DBs{sl}USDAstock{sl}_nutKeyPairs.TXT");
            foreach (string s in nutKeyLines)
                if (s.Split('|')[1] == "NDBNo")
                    DB.ndbs = File.ReadAllLines($"{Application.StartupPath}{sl}usr{sl}share{sl}DBs{sl}USDAstock{sl}{s.Split('|')[0]}");
                else if (s.Split('|')[1] == "FoodName")
                    DB.names = File.ReadAllLines($"{Application.StartupPath}{sl}usr{sl}share{sl}DBs{sl}USDAstock{sl}{s.Split('|')[0]}");
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
            dbobjs = new List<_dbObj>();
            foreach (string s in ingrieds)
            {
                _dbObj d = new _dbObj();
                d.name = s;
                dbobjs.Add(d);
            }
            try { currentObj = dbobjs[dbobjs.Count - 1]; }
            catch { }
            updatePer();
            updateList();
        }

        private void assignCurObj()
        {
            try
            {
                chosenQuery = lstBoxIngrieds.Text;
                chosenName = chosenQuery.Split(new string[] { " -- " }, StringSplitOptions.None)[0];
                txtTweakName.Text = chosenName;
                foreach (_dbObj d in dbobjs)
                    if (d.name == chosenName)
                        currentObj = d;
            }
            catch { }
        }

        private void assignNdb()
        {
            try { currentObj.ndbno = lstViewDBresults.SelectedItems[0].SubItems[0].Text; }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        string chosenName;
        string chosenQuery;
        private void lstBoxIngrieds_MouseUp(object sender, MouseEventArgs e) => assignCurObj();
        private void lstBoxIngrieds_SelectedIndexChanged(object sender, EventArgs e) => assignCurObj();

        private void lstViewDBresults_MouseUp(object sender, MouseEventArgs e) => assignNdb();
        private void lstViewDBresults_SelectedIndexChanged(object sender, EventArgs e) => assignNdb();


        private void txtTweakName_TextChanged(object sender, EventArgs e) => search();
        private void txtTweakWeight_TextChanged(object sender, EventArgs e)
        {
            try { currentObj.weight = Convert.ToDouble(txtTweakWeight.Text); }
            catch { }
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
                lstBoxIngrieds.Items.Add($"{ingrieds[i]} -- {percents[i]}% -- {percents[i]}g");
            lstBoxIngrieds.SelectedIndex = lstBoxIngrieds.Items.Count - 1;
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

        private void search()
        {
            lstViewDBresults.Items.Clear();
            //int[] wordMatch = new int[usdaDB.names.Length];
            DB.wMatch = new int[DB.names.Length];
            DB.joinedMatches = new string[DB.names.Length];
            string[] words;

            if (txtTweakName.TextLength < 4)
                return;
            else if (txtTweakName.Text.Split(' ').Length < 2)
                words = new string[] { txtTweakName.Text };
            else
                words = txtTweakName.Text.Split(_delims);

            foreach (string s in words)
                for (int i = 0; i < DB.names.Length; i++)
                    if (s.Length > 2 && DB.names[i].ToUpper()/*.Split(_delims)*/.Contains(s.ToUpper()))
                        DB.wMatch[i]++; //usdaDB.joinedMatches[i] += s + ", ";                       


            int m = DB.wMatch.Max();
            int q = 0;
            List<string> itms = new List<string>();
            for (int i = m; i > 0; i--)
                for (int j = 0; j < DB.names.Length; j++)
                    if (DB.wMatch[j] == i && q++ > 0)
                        itms.Add($"{DB.ndbs[j]} -- {DB.names[j]} -- [{DB.wMatch[j]}]"); //-({usdaDB.joinedMatches[j]})");                     


            lstViewDBresults.BeginUpdate();
            for (int i = 0; i < itms.Count; i++)
                lstViewDBresults.Items.Add(itms[i]);
            lstViewDBresults.EndUpdate();
            //List<string> ns = new List<string>();
            //currentObj.ndbno = chosenQuery.Split; //????????????????????????????????
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
        
    }
}
