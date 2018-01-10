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
            public double percent = 1;
            public double weight = 100;
        }
        List<_dbObj> dbobjs;
        int curDbIndex;
        //_dbObj currentObj;
        private static class DB
        {
            public static string[] ndbs;
            public static string[] names;
            public static string[] cals;
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
                else if (s.Split('|')[1] == "Cals")
                    DB.cals = File.ReadAllLines($"{Application.StartupPath}{sl}usr{sl}share{sl}DBs{sl}USDAstock{sl}{s.Split('|')[0]}");
        }
        
        private void txtIngrieds_TextChanged(object sender, EventArgs e)
        {
            string input = txtIngrieds.Text;
            lstBoxIngrieds.Items.Clear();
            List<string> output = input.Split(new string[] { nl }, StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i=0;i<output.Count;i++)
                if (output[i].Length < 3)
                    output.RemoveAt(i);
            string[] ingrieds = output.ToArray();
            dbobjs = new List<_dbObj>();
            foreach (string s in ingrieds)
            {
                _dbObj d = new _dbObj();
                d.name = s;
                dbobjs.Add(d);
            }
            //try { currentObj = dbobjs[dbobjs.Count - 1]; }
            //catch { }
            updatePer();
            updateList();
        }


        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        //string chosenName;
        //string chosenQuery;
        private void lstBoxIngrieds_MouseUp(object sender, MouseEventArgs e) => assignCurObj();
        private void lstBoxIngrieds_SelectedIndexChanged(object sender, EventArgs e) => assignCurObj();

        private void lstViewDBresults_MouseUp(object sender, MouseEventArgs e) => assignNdb();
        private void lstViewDBresults_SelectedIndexChanged(object sender, EventArgs e) => assignNdb();


        private void txtTweakName_TextChanged(object sender, EventArgs e) => search();
        private void txtTweakWeight_TextChanged(object sender, EventArgs e) { 
            try { dbobjs[curDbIndex].weight = Convert.ToDouble(txtTweakWeight.Text);

             } catch { }
            updateList();
        }
        
        private void assignNdb()
        {
            try { dbobjs[curDbIndex].ndbno = lstViewDBresults.SelectedItems[0].SubItems[0].Text; }
            catch { }
        }

        private void assignCurObj()
        {
            try{curDbIndex = lstBoxIngrieds.SelectedIndex;
                txtTweakName.Text = dbobjs[curDbIndex].name;
                txtTweakWeight.Text = Convert.ToString(dbobjs[curDbIndex].weight);
            }
            catch{}

        }

        double x = 0.4;
        //double[] percents;
        private void trackGeo_Scroll(object sender, EventArgs e)
        {
            updatePer();
            updateList();
        }

        private void updateList()
        {
            int o = lstBoxIngrieds.SelectedIndex;
            lstBoxIngrieds.Items.Clear();
            for (int i = 0; i < dbobjs.Count; i++)
                lstBoxIngrieds.Items.Add($"{dbobjs[i].name} -- {dbobjs[i].percent}% -- {dbobjs[i].weight}g");
            try { lstBoxIngrieds.SelectedIndex = o; }
            catch { lstBoxIngrieds.SelectedIndex = lstBoxIngrieds.Items.Count - 1; }
        }
        private void updatePer()
        {
            x = (double)trackGeo.Value / trackGeo.Maximum;
            if (dbobjs == null|| dbobjs.Count == 0) {
                //percents = new double[] { 100.0 };
            return;
            }

            double q = 0;
            for (int i = 0; i < dbobjs.Count; i++)
                q += Math.Pow(x, i);
            double a = 1 / q;

            for (int i = 0; i < dbobjs.Count; i++)
            {
                double m = dbobjs[i].percent;
                //dbobjs[i].weight = dbobjs[i].weight * (Math.Round(a * Math.Pow(x, i), 3) * 100 / dbobjs[i].percent);
                dbobjs[i].percent = Math.Round(a * Math.Pow(x, i), 3) * 100;
                dbobjs[i].weight = dbobjs[i].percent;
                //dbobjs[i].weight *= dbobjs[i].percent / m;
            }
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
            else if (txtTweakName.Text.Split(new char[] { ' ', '\n' }).Length < 2)
                words = new string[] { txtTweakName.Text };
            else
                words = txtTweakName.Text.Split(_delims);

            foreach (string s in words)
                for (int i = 0; i < DB.names.Length; i++)
                    if (s.Length > 2 && DB.names[i].ToUpper()/*.Split(_delims)*/.Contains(s.ToUpper()))
                        DB.wMatch[i]++; //usdaDB.joinedMatches[i] += s + ", ";                       


            int m = DB.wMatch.Max();
            int q = 0;
            List<ListViewItem> itms = new List<ListViewItem>();
            for (int i = m; i > 0; i--)
                for (int j = 0; j < DB.names.Length; j++)
                    if (DB.wMatch[j] == i && q++ > 0)
                    {
                        ListViewItem itm = new ListViewItem(DB.ndbs[j]);
                        itm.SubItems.Add($"{DB.names[j]} -- [{DB.wMatch[j]}]");
                        //itm.SubItems.Add($) //cals?
                    }         


            lstViewDBresults.BeginUpdate();
            for (int i = 0; i < itms.Count; i++)
                lstViewDBresults.Items.Add(itms[i]);
            lstViewDBresults.EndUpdate();
            //List<string> ns = new List<string>();
            //currentObj.ndbno = chosenQuery.Split; //????????????????????????????????
        }

        //List<double> _percents;
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
            //_percents = new List<double>();
            //foreach (string s in lstBoxIngrieds.Items)            
                //_percents.Add(Convert.ToDouble(s.Split(new string[] { " -- " }, StringSplitOptions.RemoveEmptyEntries)[1]));            
        }

        bool mH;
        bool tweak;
        private void txtIngrieds_Leave(object sender, EventArgs e) => tweak = true;
        private void txtIngrieds_Enter(object sender, EventArgs e)
        {
            if (tweak)
            {
                tweak = false;
                MessageBox.Show("Warning, editing this now will reset any progress you have already made.");
            }
        }
    }
}
