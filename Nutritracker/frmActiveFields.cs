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

namespace Nutritracker
{
    public partial class frmActiveFields : Form
    {
        public frmActiveFields()
        {
            InitializeComponent();
        }

        List<string> oldInput;
        string slash = Path.DirectorySeparatorChar.ToString();
        private void frmActiveFields_Load(object sender, EventArgs e)
        {
            this.Text = $"Editing {frmMain.profName}'s Active Fields";
            oldInput = File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.profIndex}{slash}activeFields.TXT").ToList();
            for (int i = 0; i < oldInput.Count; i++)            
                if (oldInput[i] == "")
                    oldInput.RemoveAt(i);
            richTxtInput.Text = string.Join("\n", oldInput);

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Save changes (if any)?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                this.Close();
            
            File.WriteAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.profIndex}{slash}activeFields.TXT", richTxtInput.Text.Split('\n'));
            this.Close();
        }

        string[] knownFields = {
        
        };
        private void richTxtInput_TextChanged(object sender, EventArgs e)
        {
            int z = richTxtInput.SelectionStart;
            Font font = richTxtInput.Font;
            string[] lines = richTxtInput.Text.Split('\n');
            int m = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("#"))
                {
                    richTxtInput.SelectionStart = m + lines[i].IndexOf("#");
                    richTxtInput.SelectionLength = lines[i].Length - lines[i].IndexOf("#");
                    richTxtInput.SelectionColor = Color.Blue;
                    richTxtInput.SelectionFont = new Font(font, FontStyle.Italic);
                    richTxtInput.Select(z, 0);
                }
                else
                {
                    richTxtInput.SelectionStart = m;
                    richTxtInput.SelectionLength = lines[i].Length;
                    richTxtInput.SelectionColor = Color.Black;
                    richTxtInput.SelectionFont = new Font(font, FontStyle.Regular);
                    richTxtInput.Select(z, 0);
                }

                string[] words = lines[i].Split(' ');
                int n = m;
                for (int j = 0; j < words.Length; j++)
                {
                    if (knownFields.Contains(words[j]) && !(lines[i].IndexOf("#") != -1 && lines[i].IndexOf(words[j]) < lines[i].LastIndexOf("#")))
                    {
                        richTxtInput.SelectionStart = n;
                        richTxtInput.SelectionLength = words[j].Length;
                        richTxtInput.SelectionColor = Color.Red;
                        richTxtInput.SelectionFont = new Font(font, FontStyle.Bold);
                        richTxtInput.Select(z, 0);
                    }
                    n += words[j].Length + 1;
                }
                m += lines[i].Length + 1;
            }
        }
    }
}
