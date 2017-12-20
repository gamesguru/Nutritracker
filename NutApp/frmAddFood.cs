using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.CompilerServices;

namespace NutApp
{
    public partial class frmAddFood : Form
    {
        public frmAddFood()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }

        public List<String> importArray(string filename)
        {
            list.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line); // Add to list.
                }
            }
            return list;
        }

        private ListViewColumnSorter lvwColumnSorter;
        List<string> list = new List<string>();
        string slash = Path.DirectorySeparatorChar.ToString();
        public int n;

        public string[] dbNum;
        public string[] names;
        public string[] water;
        public string[] kcal;
        public string[] protein;
        public string[] fat;
        public string[] sat;
        public string[] mono;
        public string[] poly;
        public string[] cholest;
        public string[] carbs;
        public string[] fiber;
        public string[] sugar;
        public string[] calcium;
        public string[] iron;
        public string[] magnesium;
        public string[] phosphorous;
        public string[] Potassium;
        public string[] Sodium;
        public string[] Zinc;
        public string[] Copper;
        public string[] Manganese;
        public string[] Selenium;
        public string[] Vit_C;
        public string[] Thiamin;
        public string[] Riboflavin;
        public string[] Niacin;
        public string[] Panto_Acid;
        public string[] Vit_B6;
        public string[] Folate_Tot;
        public string[] Folic_Acid;
        public string[] Food_Folate;
        public string[] Folate_DFE;
        public string[] Choline_Tot;
        public string[] Vit_B12;
        public string[] Vit_A_IU;
        public string[] Vit_A_RAE;
        public string[] Retinol;
        public string[] Alpha_Carot;
        public string[] Beta_Carot;
        public string[] Beta_Crypt;
        public string[] Lycopene;
        public string[] Lut_Zea;
        public string[] Vit_E;
        public string[] Vit_D_ug;
        public string[] Vit_D_IU;
        public string[] Vit_K;
        public string[] ash;

        private void AddFood_Load(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString();
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
            comboConvert.SelectedIndex = 0;
            comboMeal.SelectedIndex = frmMain.mealIndex;


            //string root = Application.StartupPath + "\\FDA nutrient values\\";
            string root = Application.StartupPath + $"{slash}USDA nutrient data{slash}"; //"C:\\Users\\Shane_Dev\\Desktop\\nut\\";


            dbNum = importArray(root + "dbNum.TXT").ToArray();
            n = dbNum.Length;

            names = importArray(root + "name.TXT").ToArray();
            water = importArray(root + "water.TXT").ToArray();
            kcal = importArray(root + "kcal.TXT").ToArray();
            protein = importArray(root + "protein.TXT").ToArray();
            fat = importArray(root + "fat.TXT").ToArray();
            sat = importArray(root + "sat.TXT").ToArray();
            mono = importArray(root + "mono.TXT").ToArray();
            poly = importArray(root + "poly.TXT").ToArray();
            cholest = importArray(root + "cholesterol.TXT").ToArray();
            carbs = importArray(root + "carbs.TXT").ToArray();
            fiber = importArray(root + "fiber.TXT").ToArray();
            sugar = importArray(root + "sugar.TXT").ToArray();
            calcium = importArray(root + "calcium.TXT").ToArray();
            iron = importArray(root + "iron.TXT").ToArray();
            magnesium = importArray(root + "magnesium.TXT").ToArray();
            phosphorous = importArray(root + "phosphorous.TXT").ToArray();

            Potassium = importArray(root + "potassium.TXT").ToArray();
            Sodium = importArray(root + "sodium.TXT").ToArray();
            Zinc = importArray(root + "zinc.TXT").ToArray();
            Copper = importArray(root + "copper.TXT").ToArray();
            Manganese = importArray(root + "manganese.TXT").ToArray();
            Selenium = importArray(root + "selenium.TXT").ToArray();
            Vit_C = importArray(root + "vitC.TXT").ToArray();
            Thiamin = importArray(root + "thaimin.TXT").ToArray();
            Riboflavin = importArray(root + "riboflavin.TXT").ToArray();
            Niacin = importArray(root + "niacin.TXT").ToArray();
            Panto_Acid = importArray(root + "pantoAcid.TXT").ToArray();
            Vit_B6 = importArray(root + "vitB6.TXT").ToArray();
            Folate_Tot = importArray(root + "folateTot.TXT").ToArray();
            Folic_Acid = importArray(root + "folicAcid.TXT").ToArray();
            Food_Folate = importArray(root + "foodFolate.TXT").ToArray();
            Folate_DFE = importArray(root + "folateDFE.TXT").ToArray();
            Choline_Tot = importArray(root + "choline.TXT").ToArray();
            Vit_B12 = importArray(root + "vitB12.TXT").ToArray();
            Vit_A_IU = importArray(root + "vitAiu.TXT").ToArray();
            Vit_A_RAE = importArray(root + "vitArae.TXT").ToArray();
            Retinol = importArray(root + "retinol.TXT").ToArray();
            Alpha_Carot = importArray(root + "alphaCarot.TXT").ToArray();
            Beta_Carot = importArray(root + "betaCarot.TXT").ToArray();
            Beta_Crypt = importArray(root + "betaCrypt.TXT").ToArray();
            Lycopene = importArray(root + "lycopene.TXT").ToArray();
            Lut_Zea = importArray(root + "lutZea.TXT").ToArray();
            Vit_E = importArray(root + "vitE.TXT").ToArray();
            Vit_D_ug = importArray(root + "vitDug.TXT").ToArray();
            Vit_D_IU = importArray(root + "vitDiu.TXT").ToArray();
            Vit_K = importArray(root + "vitK.TXT").ToArray();
            ash = importArray(root + "ash.TXT").ToArray();

            txtSrch.Focus();
            //reload();
        }



        public void reload()
        {
            listView1.Items.Clear();

            for (int i = 0; i < n; i++)
            {
                ListViewItem itm = new ListViewItem(dbNum[i]);
                itm.SubItems.Add(names[i]);
                itm.SubItems.Add(water[i]);
                itm.SubItems.Add(kcal[i]);
                itm.SubItems.Add(protein[i]);

                itm.SubItems.Add(fat[i]);
                itm.SubItems.Add(sat[i]);
                itm.SubItems.Add(mono[i]);
                itm.SubItems.Add(poly[i]);
                itm.SubItems.Add(cholest[i]);

                itm.SubItems.Add(carbs[i]);
                itm.SubItems.Add(fiber[i]);
                itm.SubItems.Add(sugar[i]);

                itm.SubItems.Add(calcium[i]);
                itm.SubItems.Add(iron[i]);
                itm.SubItems.Add(magnesium[i]);
                itm.SubItems.Add(phosphorous[i]);

                itm.SubItems.Add(Potassium[i]);
                itm.SubItems.Add(Sodium[i]);
                itm.SubItems.Add(Zinc[i]);
                itm.SubItems.Add(Copper[i]);
                itm.SubItems.Add(Manganese[i]);
                itm.SubItems.Add(Selenium[i]);
                itm.SubItems.Add(Vit_C[i]);
                itm.SubItems.Add(Thiamin[i]);
                itm.SubItems.Add(Riboflavin[i]);
                itm.SubItems.Add(Niacin[i]);
                itm.SubItems.Add(Panto_Acid[i]);
                itm.SubItems.Add(Vit_B6[i]);
                itm.SubItems.Add(Folate_Tot[i]);
                itm.SubItems.Add(Folic_Acid[i]);
                itm.SubItems.Add(Food_Folate[i]);
                itm.SubItems.Add(Folate_DFE[i]);
                itm.SubItems.Add(Choline_Tot[i]);
                itm.SubItems.Add(Vit_B12[i]);
                itm.SubItems.Add(Vit_A_IU[i]);
                itm.SubItems.Add(Vit_A_RAE[i]);
                itm.SubItems.Add(Retinol[i]);
                itm.SubItems.Add(Alpha_Carot[i]);
                itm.SubItems.Add(Beta_Carot[i]);
                itm.SubItems.Add(Beta_Crypt[i]);
                itm.SubItems.Add(Lycopene[i]);
                itm.SubItems.Add(Lut_Zea[i]);
                itm.SubItems.Add(Vit_E[i]);
                itm.SubItems.Add(Vit_D_ug[i]);
                itm.SubItems.Add(Vit_D_IU[i]);
                itm.SubItems.Add(Vit_K[i]);
                itm.SubItems.Add(ash[i]);

                listView1.Items.Add(itm);
            }

            /*for (int i = 0; i < dbNumber.Length; i++)
            {
                ListViewItem itm = new ListViewItem(dbNumber[i]);
                itm.SubItems.Add(water[i]);
                listView1.Items.Add(itm);
                
            }*/

        }

        public void reload(int i)
        {
            ListViewItem itm = new ListViewItem(dbNum[i]);
            itm.SubItems.Add(names[i]);
            itm.SubItems.Add(water[i]);
            itm.SubItems.Add(kcal[i]);
            itm.SubItems.Add(protein[i]);

            itm.SubItems.Add(fat[i]);
            itm.SubItems.Add(sat[i]);
            itm.SubItems.Add(mono[i]);
            itm.SubItems.Add(poly[i]);
            itm.SubItems.Add(cholest[i]);

            itm.SubItems.Add(carbs[i]);
            itm.SubItems.Add(fiber[i]);
            itm.SubItems.Add(sugar[i]);

            itm.SubItems.Add(calcium[i]);
            itm.SubItems.Add(iron[i]);
            itm.SubItems.Add(magnesium[i]);
            itm.SubItems.Add(phosphorous[i]);

            itm.SubItems.Add(Potassium[i]);
            itm.SubItems.Add(Sodium[i]);
            itm.SubItems.Add(Zinc[i]);
            itm.SubItems.Add(Copper[i]);
            itm.SubItems.Add(Manganese[i]);
            itm.SubItems.Add(Selenium[i]);
            itm.SubItems.Add(Vit_C[i]);
            itm.SubItems.Add(Thiamin[i]);
            itm.SubItems.Add(Riboflavin[i]);
            itm.SubItems.Add(Niacin[i]);
            itm.SubItems.Add(Panto_Acid[i]);
            itm.SubItems.Add(Vit_B6[i]);
            itm.SubItems.Add(Folate_Tot[i]);
            itm.SubItems.Add(Folic_Acid[i]);
            itm.SubItems.Add(Food_Folate[i]);
            itm.SubItems.Add(Folate_DFE[i]);
            itm.SubItems.Add(Choline_Tot[i]);
            itm.SubItems.Add(Vit_B12[i]);
            itm.SubItems.Add(Vit_A_IU[i]);
            itm.SubItems.Add(Vit_A_RAE[i]);
            itm.SubItems.Add(Retinol[i]);
            itm.SubItems.Add(Alpha_Carot[i]);
            itm.SubItems.Add(Beta_Carot[i]);
            itm.SubItems.Add(Beta_Crypt[i]);
            itm.SubItems.Add(Lycopene[i]);
            itm.SubItems.Add(Lut_Zea[i]);
            itm.SubItems.Add(Vit_E[i]);
            itm.SubItems.Add(Vit_D_ug[i]);
            itm.SubItems.Add(Vit_D_IU[i]);
            itm.SubItems.Add(Vit_K[i]);
            itm.SubItems.Add(ash[i]);
            listView1.Items.Add(itm);

        }

        private void listUpdate()
        {

        }

        private void txtSrch_TextChanged(object sender, EventArgs e)
        {
            //newCalc = false;

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
            }).Start();

            //Parallel.Invoke(() => BackgroundMethod());
            //Thread workingThread = new Thread(new ParameterizedThreadStart("listUpdate"));

            string[] strs = txtSrch.Text.ToLower().Split(' ');

            if ((txtSrch.Text.Contains(" ") || txtSrch.Text.Length > 2) && !txtSrch.Text.StartsWith(" ") && !txtSrch.Text.EndsWith(" "))
            {
                listView1.Items.Clear();
                comboConvert.Items.Clear();
                comboConvert.Items.Add("per 100 g");
                comboConvert.Items.Add("per 100 kCal");
                comboConvert.SelectedIndex = 0;
                int[] wMatch = new int[n];
                for (int i = 0; i < n; i++)
                {
                    //bool rload = false;
                    /*foreach (string s in strs) //words
                        if (s.Length > 2 && names[i].ToLower().Contains(s))
                            wMatch[i]++;*/
                    foreach (string s in strs) //words
                        foreach (string st in names[i].ToLower().Split(new char[] { ',', ' ' }))
                            if (s.Length > 2 && st == s)
                                wMatch[i]++;
                }

                //MessageBox.Show(wMatch[0].ToString());
                int[] y = new int[wMatch.Max()];
                for (int j = wMatch.Max(); j > 0; j--)
                for (int i = 0; i < n; i++)
                    if (wMatch[i] == j)
                        reload(i);
            }
            //if (txtSrch.Text.Length == 0)
                 //reload();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string[] ingried;
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (txtQty.Text.Length > 0 && listView1.SelectedItems[0].SubItems[1].Text != "")
                {
                    btnAdd.Enabled = true;
                    ingried = new string[15]; //[listView1.SelectedItems[0].SubItems.Count - 1];
                    ingried[0] = listView1.SelectedItems[0].SubItems[1].Text;
                    ingried[1] = txtQty.Text;
                    ingried[2] = listView1.SelectedItems[0].SubItems[3].Text;
                    ingried[3] = listView1.SelectedItems[0].SubItems[4].Text;
                    ingried[4] = listView1.SelectedItems[0].SubItems[5].Text;
                    ingried[5] = listView1.SelectedItems[0].SubItems[10].Text;
                    ingried[6] = listView1.SelectedItems[0].SubItems[12].Text;
                    ingried[7] = listView1.SelectedItems[0].SubItems[11].Text;
                    ingried[8] = listView1.SelectedItems[0].SubItems[6].Text;
                    ingried[9] = listView1.SelectedItems[0].SubItems[9].Text;
                    ingried[10] = listView1.SelectedItems[0].SubItems[18].Text;
                    ingried[11] = listView1.SelectedItems[0].SubItems[13].Text;
                    ingried[12] = listView1.SelectedItems[0].SubItems[14].Text;
                    ingried[13] = listView1.SelectedItems[0].SubItems[35].Text;
                    ingried[14] = listView1.SelectedItems[0].SubItems[23].Text;

                }

                txtQty.SelectAll();
                txtQty.Focus();

                for (int i = 0; i < 15; i++)
                    if (ingried[i] == "" || ingried[i] == " ")
                        ingried[i] = "0";
                //else
                //btnAdd.Enabled = false;
                //MessageBox.Show("k");

            }
            catch
            {
            }
            
            /*try
            {
                if (txtQty.Text.Length > 0 && listView1.SelectedItems[0].SubItems[1].Text != "")
                {
                    btnAdd.Enabled = true;
                    ingried=new string[listView1.SelectedItems[0].SubItems.Count - 1];
                    for (int i = 1; i < ingried.Length; i++)
                        ingried[i - 1] = listView1.SelectedItems[0].SubItems[i].Text;
                }
                else
                    btnAdd.Enabled = false;

                //MessageBox.Show(string.Join(" ", ingried));
            }
            catch
            {
            }*/
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //int j;

            foreach (char c in txtQty.Text)
            {
                if (!isNumeric(c))
                {
                    int i = txtQty.SelectionStart;
                    txtQty.Text = txtQty.Text.Remove(txtQty.Text.IndexOf(c),1);
                    txtQty.SelectionStart = i - 1;
                }
                    
            }



            try
            {
                if (txtQty.Text.Length > 0 && listView1.SelectedItems[0].SubItems[1].Text != "")
                {
                    btnAdd.Enabled = true;
                    ingried = new string[15]; //[listView1.SelectedItems[0].SubItems.Count - 1];
                    ingried[0] = listView1.SelectedItems[0].SubItems[1].Text;
                    ingried[1] = txtQty.Text;
                    ingried[2] = listView1.SelectedItems[0].SubItems[3].Text;
                    ingried[3] = listView1.SelectedItems[0].SubItems[4].Text;
                    ingried[4] = listView1.SelectedItems[0].SubItems[5].Text;
                    ingried[5] = listView1.SelectedItems[0].SubItems[10].Text;
                    ingried[6] = listView1.SelectedItems[0].SubItems[12].Text;
                    ingried[7] = listView1.SelectedItems[0].SubItems[11].Text;
                    ingried[8] = listView1.SelectedItems[0].SubItems[6].Text;
                    ingried[9] = listView1.SelectedItems[0].SubItems[9].Text;
                    ingried[10] = listView1.SelectedItems[0].SubItems[18].Text;
                    ingried[11] = listView1.SelectedItems[0].SubItems[13].Text;
                    ingried[12] = listView1.SelectedItems[0].SubItems[14].Text;
                    ingried[13] = listView1.SelectedItems[0].SubItems[35].Text;
                    ingried[14] = listView1.SelectedItems[0].SubItems[23].Text;

                }
                for (int i = 0; i < 15; i++)
                    if (ingried[i] == "" || ingried[i] == " ")
                        ingried[i] = "0";
                    //else
                        //btnAdd.Enabled = false;
                //MessageBox.Show("k");

            }
            catch
            {
            }

            /*
            if (textBox2.Text.Length < 2 && !int.TryParse(textBox2.Text, out j))
                textBox2.Text = "";

            else if (textBox2.Text.Length > 5 || !int.TryParse(textBox2.Text, out j))
            {
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 2, 1);
                //textBox2.SelectionStart = textBox2.Text.Length;
            }*/
        }

        public bool isNumeric(char c)
        {
            char[] ints = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            foreach (char k in ints)
            {
                if (k == c)
                {
                    return true;
                }
            }
            return false;
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                    lvwColumnSorter.Order = SortOrder.Descending;
                else
                    lvwColumnSorter.Order = SortOrder.Ascending;
                
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            this.listView1.Sort();
            if (comboConvert.SelectedIndex == 1)
            {
                comboConvert.Items.Clear();//.Enabled = false;
                comboConvert.Items.Add("per 100 kCal");
                comboConvert.SelectedIndex = 0;
                //txtSrch.Enabled = true;
            }
        }

        List<double> mult = new List<double>();
        //private bool newCalc = false;
        //bool mHandled = false;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //mHandled = false;
            double[] cValuesO, mults;
            if (comboConvert.SelectedIndex == 1 && listView1.Items.Count > 0)
            {
                cValuesO = new double[listView1.Items.Count];
                mults = new double[cValuesO.Length];
                //txtSrch.Enabled = false;
                //listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
                //mult.Clear();
                for (int i = 0; i < cValuesO.Length; i++)
                {
                    double.TryParse(listView1.Items[i].SubItems[3].Text, out cValuesO[i]);
                    if (cValuesO[i] != 0.0)
                        mults[i] = 100 / cValuesO[i];
                    mult.Add(mults[i]);
                }
                double g;
                for (int i = 0; i < listView1.Items.Count; i++)
                for (int j = 2; j < listView1.Items[0].SubItems.Count; j++)
                {
                    double.TryParse(listView1.Items[i].SubItems[j].Text, out g);
                    g *= mults[i];
                    listView1.Items[i].SubItems[j].Text = Math.Round(g, 2).ToString();
                }
            }
            else
            {
                if (comboConvert.Items.Count == 1)
                    return;
                //txtSrch.Enabled = true;

                //listView1.HeaderStyle = ColumnHeaderStyle.Clickable;
                double g;
                for (int i = 0; i < listView1.Items.Count; i++)
                for (int j = 2; j < listView1.Items[0].SubItems.Count; j++)
                {
                    double.TryParse(listView1.Items[i].SubItems[j].Text, out g);
                    g /= mult[i];
                    listView1.Items[i].SubItems[j].Text = Math.Round(g, 2).ToString();
                }
            }
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            //if (newCalc)// && !mHandled)
            
                //MessageBox.Show("Please start a new search, because you resorted the kcal values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //mHandled = true;


                //comboBox1.SelectedIndex = 0;
                //comboBox1.Focus();
                //SendKeys.Send("{esc}");

                //textBox1.Enabled = true;
                //textBox1.Focus();
            
        }

        ToolTip tip = new ToolTip();

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            if (comboConvert.Items.Count == 1)
                tip.SetToolTip(comboConvert, "You must start a new search after sorting kcal values.");
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboConvert.Items.Count == 1)
                tip.SetToolTip(comboConvert, "You must start a new search after sorting kcal values.");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsLetter(e.KeyChar) && !Char.IsSeparator(e.KeyChar))
                e.Handled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmMain.addFood = ingried;
            frmMain.mealIndex = comboMeal.SelectedIndex;
            frmMain.mealSpe = comboMeal.SelectedIndex;
            //MessageBox.Show(string.Join(", ", ingried));
            this.Close();
        }

        private void txtSrch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return" && listView1.Items.Count > 0)
            {
                listView1.Items[0].Selected = true;
                listView1.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                txtQty.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return" && txtQty.Text.Length > 0 && listView1.SelectedItems[0].SubItems[1].Text != "")
            {
                e.SuppressKeyPress = true;
                btnAdd.PerformClick();
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(listView1.Items[0].BackColor.ToString());
            if (e.Button == MouseButtons.Right && listView1.SelectedItems[0].BackColor != Color.Yellow)
            {
                listView1.Items[listView1.SelectedIndices[0]].BackColor = Color.Yellow;
            }
            else if (e.Button == MouseButtons.Right)
            {
                listView1.Items[listView1.SelectedIndices[0]].BackColor = Color.Transparent;
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (txtQty.Text.Length > 0 && listView1.SelectedItems[0].SubItems[1].Text != "")
                {
                    btnAdd.Enabled = true;
                    ingried = new string[15]; //[listView1.SelectedItems[0].SubItems.Count - 1];
                    ingried[0] = listView1.SelectedItems[0].SubItems[1].Text;
                    ingried[1] = txtQty.Text;
                    ingried[2] = listView1.SelectedItems[0].SubItems[3].Text;
                    ingried[3] = listView1.SelectedItems[0].SubItems[4].Text;
                    ingried[4] = listView1.SelectedItems[0].SubItems[5].Text;
                    ingried[5] = listView1.SelectedItems[0].SubItems[10].Text;
                    ingried[6] = listView1.SelectedItems[0].SubItems[12].Text;
                    ingried[7] = listView1.SelectedItems[0].SubItems[11].Text;
                    ingried[8] = listView1.SelectedItems[0].SubItems[6].Text;
                    ingried[9] = listView1.SelectedItems[0].SubItems[9].Text;
                    ingried[10] = listView1.SelectedItems[0].SubItems[18].Text;
                    ingried[11] = listView1.SelectedItems[0].SubItems[13].Text;
                    ingried[12] = listView1.SelectedItems[0].SubItems[14].Text;
                    ingried[13] = listView1.SelectedItems[0].SubItems[35].Text;
                    ingried[14] = listView1.SelectedItems[0].SubItems[23].Text;

                }

                //txtQty.SelectAll();
                //txtQty.Focus();

                for (int i = 0; i < 15; i++)
                    if (ingried[i] == "" || ingried[i] == " ")
                        ingried[i] = "0";

                //else
                //btnAdd.Enabled = false;
                //MessageBox.Show("k");

            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
