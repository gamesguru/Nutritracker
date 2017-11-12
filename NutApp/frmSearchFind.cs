using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutApp
{
    public partial class frmSearchFind : Form
    {

        private frmParseCustomDatabase mainForm = null;
        public frmSearchFind(Form callingForm)
        {
            mainForm = callingForm as frmParseCustomDatabase;
            InitializeComponent();
        }

        string source;
        string f;
        public static int j = 0;
        public static bool busy = false;
        private void btnFind_Click(object sender, EventArgs e)
        {
            source = frmParseCustomDatabase.parseSource;
            f = txtFind.Text;
            if (!checkboxCase.Checked)
            {
                source = source.ToLower();
                f = f.ToLower();
            }


            if (radioDown.Checked)
            {
                j = source.IndexOf(f, j < 0 ? 0 : j);
                if (j < 0)
                {
                    mainForm.parentStartIndex = 0;
                    System.Media.SystemSounds.Asterisk.Play();
                    return;
                }
                mainForm.parentStartIndex = j;
                mainForm.parentSelectionLength = f.Length;
                j++;
            }
            else
            {
                source = source.Substring(0, mainForm.parentStartIndex);
                j = source.LastIndexOf(f);
                if (j < 0)
                { System.Media.SystemSounds.Asterisk.Play();
                    return; }
                mainForm.parentStartIndex = j;
                mainForm.parentSelectionLength = f.Length;
                mainForm.scrollToSelect();
                j--;
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            source = frmParseCustomDatabase.parseSource;
            if (txtFind.TextLength > 0)
            {
                btnFind.Enabled = true;
                //checkboxHighlightAll.Enabled = true;
                if (checkboxHighlightAll.Checked)
                {

                }
            }
            else
            {
                btnFind.Enabled = false;
                checkboxHighlightAll.Enabled = false;
            }
        }
        
        private void checkboxHighlightAll_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void frmSearchFind_Load(object sender, EventArgs e)
        {
            busy = true;
        }

        private void frmSearchFind_FormClosing(object sender, FormClosingEventArgs e)
        {
            busy = false;
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            { e.SuppressKeyPress = true;
                btnFind.PerformClick();}
            else if (e.KeyCode == Keys.Escape)
            { e.SuppressKeyPress = true;
                this.Close(); }
        }
    }
}
