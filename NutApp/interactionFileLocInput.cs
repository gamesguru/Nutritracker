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

namespace NutApp
{
    public partial class interactionFileLocInput : Form
    {
        public interactionFileLocInput()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fileLoc = "";
            this.Close();
        }

        public string fileLoc = "";
        private void button1_Click(object sender, EventArgs e)
        {
            fileLoc = textBox1.Text;
            this.Close();
        }

        List<string> subDirects;
        AutoCompleteStringCollection rootSource = new AutoCompleteStringCollection();
        private void interactionFileLocInput_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            string dir = Application.StartupPath.Replace("\\", "/") + "/module_imports";
            string str = dir + "/";
            textBox1.Text = str;
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.Focus();


            if (Directory.Exists(dir))
            {
                string[] files = Directory.GetFiles(dir);
                foreach (string file in files)
                    source.Add(file);

                foreach (string subdir in Directory.GetDirectories(dir))
                {
                    files = Directory.GetFiles(subdir);
                    foreach (string file in files)
                        source.Add(file);
                }
            }         

            textBox1.AutoCompleteCustomSource = source;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
