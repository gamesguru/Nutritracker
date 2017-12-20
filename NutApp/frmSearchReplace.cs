using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutApp
{
    public partial class frmSearchReplace : Form
    {
        private frmParseCustomDatabase mainForm = null;
        public frmSearchReplace(Form callingForm)
        {
            mainForm = callingForm as frmParseCustomDatabase;
            InitializeComponent();
        }
        public static bool busy = false;

        int matches = 0;
        List<string> m;
        string f;
        string r;
        string source;
        string parSelect;
        int q;
        public static int j = 0;
        private void btnFind_Click(object sender, EventArgs e)
        {
            source = frmParseCustomDatabase.parseSource;
            f = txtFind.Text;
            if (!checkboxCase.Checked)
            {
                source = source.ToLower();
                f = f.ToLower();
            }
            q = mainForm.parentStartIndex;

            j = source.IndexOf(f, j < 0 ? 0 : j);//j < q ? q : j + 1);
            if (j < 0)
            {
                mainForm.parentStartIndex = 0;
                System.Media.SystemSounds.Asterisk.Play();
                return;
            }
            mainForm.parentStartIndex = j;
            mainForm.parentSelectionLength = f.Length;
            mainForm.scrollToSelect();
            j++;
        }

        private void frmSearchReplace_Load(object sender, EventArgs e)
        {
            busy = true;
        }
        private void frmSearchReplace_FormClosing(object sender, FormClosingEventArgs e)
        {

            busy = false;
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            btnFind.PerformClick();
            parSelect = mainForm.parentSelection;
            f = txtFind.Text;
            q = mainForm.parentStartIndex;
            if (!checkboxCase.Checked)
            {
                parSelect = parSelect.ToLower();
                f = f.ToLower();
            }
            if (parSelect == f)
                mainForm.parentSelection = txtReplace.Text;
            mainForm.parentStartIndex = q;
            mainForm.parentSelectionLength = txtReplace.TextLength;
            //btnFind.PerformClick();
            //btnFind.PerformClick();
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            source = frmParseCustomDatabase.parseSource;
            string source2 = source;
            f = txtFind.Text;
            r = txtReplace.Text;
            if (!checkboxCase.Checked)
            { source2 = source.ToLower();
                f = f.ToLower();
            }
            if (!source2.Contains(f) && source2 != r)
            {
                mainForm.parentStartIndex = 0;
                System.Media.SystemSounds.Asterisk.Play();
                return;
            }
            if (!checkboxCase.Checked)
                mainForm.parentWholeText = Regex.Replace(source, f, r, RegexOptions.IgnoreCase);
            else
                mainForm.parentWholeText = source.Replace(f, r);
            //matches = source.Split(new string[] { f }, StringSplitOptions.None).Length - 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnFind.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.SuppressKeyPress = true;
            }
        }

        private void txtReplace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && txtFind.TextLength > 0)
            {
                btnReplace.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.SuppressKeyPress = true;
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            if (txtFind.TextLength > 0)
            {
                btnFind.Enabled = true;
                btnReplace.Enabled = true;
                btnReplaceAll.Enabled = true;
            }
            else
            {
                btnFind.Enabled = false;
                btnReplace.Enabled = false;
                btnReplaceAll.Enabled = false;
            }
        }
    }
}
