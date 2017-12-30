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

        List<string> availFields = new List<string>();
        List<string> oldInput;
        string slash = Path.DirectorySeparatorChar.ToString();
        private void frmActiveFields_Load(object sender, EventArgs e)
        {
            this.Text = $"Editing {frmMain.currentUser.name}'s Active Fields";
            oldInput = File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}activeFields.TXT").ToList();
            for (int i = 0; i < oldInput.Count; i++)
                if (oldInput[i] == "")
                    oldInput.RemoveAt(i);
                else
                    oldInput[i] = oldInput[i].Replace("\r", "");
            richTxtInput.Text = string.Join("\n", oldInput);

            string[] dbs = Directory.GetDirectories($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs");
            foreach (string s in dbs){
                string[] nutLines = File.ReadAllLines($"{s}{slash}_nutKeyPairs.TXT");
                foreach (string st in nutLines)
                    if (!availFields.Contains(st.Split('|')[1]))
                        availFields.Add(st.Split('|')[1]);
            }
			availFields.Distinct();

            MessageBox.Show(string.Join(", ", availFields));
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            bool edited = false;
            List<string> newOutput = richTxtInput.Text.Split('\n').ToList();
            for (int i = 0; i < newOutput.Capacity; i++)
            {
                newOutput[i].Replace("\r", "");
                if (newOutput[i] != oldInput[i])
                    edited = true;
            }

            if (edited && MessageBox.Show("Save changes?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                File.WriteAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}activeFields.TXT", richTxtInput.Text.Split('\n'));
            this.Close();
        }

        private void richTxtInput_TextChanged(object sender, EventArgs e)
        {
            int z = richTxtInput.SelectionStart;
            Font font = richTxtInput.Font;
            string[] lines = richTxtInput.Text.Split('\n');
            for (int i = 0; i < lines.Length; i++)
                lines[i].Replace('\r', '\0');
            int m = 0;
            for (int i = 0; i < lines.Length; i++)
            {
				int l = lines[i].Length;
                if (lines[i].Contains("#"))
                {
                    int c = lines[i].IndexOf("#");
                    richTxtInput.SelectionStart = m + c;
                    richTxtInput.SelectionLength = l - c;
                    richTxtInput.SelectionColor = Color.Blue;
                    richTxtInput.SelectionFont = new Font(font, FontStyle.Italic);
                    richTxtInput.Select(z, 0);
                }
                else
                {
                    richTxtInput.SelectionStart = m;
                    richTxtInput.SelectionLength = l;
                    richTxtInput.SelectionColor = Color.Black;
                    richTxtInput.SelectionFont = new Font(font, FontStyle.Regular);
                    richTxtInput.Select(z, 0);
                }

                string[] words = lines[i].Split('#')[0].Split(' ');
                int n = m;
                for (int j = 0; j < words.Length; j++)
                {
                    if (availFields.Contains(words[j]))
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
