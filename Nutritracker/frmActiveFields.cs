﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
//using System.Windows.Documents;

namespace Nutritracker
{
    public partial class frmActiveFields : Form
    {
		FileSystemWatcher watcher = new FileSystemWatcher();
        public frmActiveFields()
        {
            InitializeComponent();
        }

        List<string> availFields = new List<string>();
        List<string> oldInput;
        string slash = Path.DirectorySeparatorChar.ToString();
        string userRoot = "";
        private void frmActiveFields_Load(object sender, EventArgs e)
        {
            userRoot = $"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}";
            watcher.Path = userRoot;
			//watcher.EnableRaisingEvents = true;
            watcher.Changed += new FileSystemEventHandler(watcher_OnChanged);
            this.Text = $"Editing {frmMain.currentUser.name}'s Active Fields";
            oldInput = File.ReadAllLines($"{userRoot}{slash}activeFields.TXT").ToList();
            for (int i = 0; i < oldInput.Count; i++)
                if (oldInput[i] == "")
                    oldInput.RemoveAt(i);
                else
                    oldInput[i] = oldInput[i].Replace("\r", "");

            string[] dbs = Directory.GetDirectories($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs");
            foreach (string s in dbs){
                string[] nutLines = File.ReadAllLines($"{s}{slash}_nutKeyPairs.TXT");
                foreach (string st in nutLines)
                    if (!st.StartsWith("#") && !availFields.Contains(st.Split('|')[1]))
                        availFields.Add(st.Split('|')[1]);
            }
		    //availFields.Sort();
            richTxtInput.Text = string.Join("\n", oldInput);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
                        //bool edited = false;
            //List<string> newOutput = richTxtInput.Text.Split('\n').ToList();

            //for (int i = 0; i < newOutput.Count; i++)
            //{
            //    if (newOutput.Count != oldInput.Count)
            //    {
            //        edited = true;
            //        break;
            //    }
            //    newOutput[i].Replace("\r", "");
            //    if (newOutput[i] != oldInput[i])
            //        edited = true;
            //}

            //if (edited && MessageBox.Show("Save changes?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    File.WriteAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.currentUser.index}{slash}activeFields.TXT", richTxtInput.Text.Split('\n'));
            this.Close();
        }

        string[] units = {"μg", "ug", "g", "mg", "g"};
        private void richTxtInput_TextChanged(object sender, EventArgs e)
        {
            //richTxtInput.textr
            //TextRange
            int z = richTxtInput.SelectionStart;
            Font font = richTxtInput.Font;
            string[] lines = richTxtInput.Text.Split('\n');
            for (int i = 0; i < lines.Length; i++)
                lines[i] = lines[i].Replace("\r", " ");
            int m = 0;
            for (int i = 0; i < lines.Length; i++)
            {
				int l = lines[i].Length;
                if (lines[i].Contains("#"))
                {
                    int c = lines[i].IndexOf("#");
                    
                    richTxtInput.Select(m + c, l - c);
                    richTxtInput.SelectionColor = Color.Blue;
                    richTxtInput.SelectionFont = new Font(font, FontStyle.Italic);
                    richTxtInput.Select(z, 0);
                }
                else
                {
                    richTxtInput.Select(m, l);
                    richTxtInput.SelectionColor = Color.Black;
                    richTxtInput.SelectionFont = new Font(font, FontStyle.Regular);
                    richTxtInput.Select(z, 0);
                }

                string[] words = lines[i].Split('#')[0].Split(new char [] {' ', '|'});
                int n = m;
                for (int j = 0; j < words.Length; j++)
                {
                    if (availFields.Contains(words[j]))
                    {
                        richTxtInput.Select(n, words[j].Length);
                        richTxtInput.SelectionColor = Color.Red;
                        richTxtInput.SelectionFont = new Font(font, FontStyle.Bold);
                        richTxtInput.Select(z, 0);
                    }
                    else if (units.Contains(words[j]))
                    {
                        richTxtInput.Select(n, words[j].Length);
                        richTxtInput.SelectionColor = Color.Green;
                        richTxtInput.SelectionFont = new Font(font, FontStyle.Bold);
                        richTxtInput.Select(z, 0);
                    }
                    n += words[j].Length + 1;
                }
                m += lines[i].Length + 1;
            }
        }

        private void watcher_OnChanged(object source, FileSystemEventArgs e)
        {
            watcher.EnableRaisingEvents = false;
            if (e.Name.EndsWith("activeFields.TXT"))
                richTxtInput.Text = File.ReadAllText($"{userRoot}{slash}activeFields.TXT").Replace("\r", "");
            watcher.EnableRaisingEvents = true;                
        }
        
        private void btnListFields_Click(object sender, EventArgs e)
        {
            itemListerDialog ild = new itemListerDialog(this);
            ild.items = availFields;
            btnListFields.Enabled = false;
            ild.Show();
            //MessageBox.Show(string.Join("\n", availFields));
        }
        
        public void reEnableButton()
        {
            btnListFields.Enabled = true;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTxtInput.Text = File.ReadAllText($"{userRoot}{slash}activeFields.TXT");
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo ps = new ProcessStartInfo();
            ps.Arguments = $"{userRoot}{slash}activeFields.TXT";
            if (slash == "/")
                ps.FileName = "gedit";
            else
                ps.FileName = "notepad";
            Process.Start(ps);
        }
    }
}
