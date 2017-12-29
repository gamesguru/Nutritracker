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


    public partial class frmManageDB : Form
    {

        public frmManageDB()
        {
            InitializeComponent();
        }
        public List<String> importArray(string filename)
        {
            list.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            return list;
        }
        List<string> list = new List<string>();

        string slash = Path.DirectorySeparatorChar.ToString();

        public string nutkeyPath = "";
        string dbDir = "";
        string[] pubDBs;
        string[] userDBs;
        private void frmManageDBfields_Load(object sender, EventArgs e)
        {
            pubDBs = Directory.GetDirectories($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs");
            userDBs = Directory.GetDirectories($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.profIndex.ToString()}{slash}DBs");

            if (pubDBs.Length == 0 && userDBs.Length == 0)
            {
                MessageBox.Show("No databases found, try going to the spreadsheet wizard or reinstalling the program.");
;
                this.Close();
            }

            for (int i = 0; i < userDBs.Length; i++)
            {
                userDBs[i] = userDBs[i].Replace($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.profIndex.ToString()}{slash}DBs{slash}", "");
                if (!userDBs[i].StartsWith("f_user"))
                    comboBox1.Items.Add(userDBs[i] + " (user)");
            }
            for (int i = 0; i < pubDBs.Length; i++)
            {
                pubDBs[i] = pubDBs[i].Replace($"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}", "");
                comboBox1.Items.Add(pubDBs[i] + " (share)");
            }
            
            if (comboBox1.Items.Count > 0 && File.Exists($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.profIndex}{slash}DBs{slash}Default.TXT"))
            {
                int index = Convert.ToInt32(File.ReadAllLines($"{Application.StartupPath}{slash}usr{slash}profile{frmMain.profIndex}{slash}DBs{slash}Default.TXT")[0]);
                comboBox1.SelectedIndex = index;
            }

            //comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
        }

        private void refresh()
        {
            #region resets controls
            list.Clear();
            txtname.Text = "";
            txtNDB.Text = "";
            txtServ1.Text = "";
            txtWt1.Text = "";
            txtServ2.Text = "";
            txtWt2.Text = "";

            txtCals.Text = "";
            txtFat.Text = "";
            txtsatFat.Text = "";
            txtCarbs.Text = "";
            txtFiber.Text = "";
            txtSugar.Text = "";
            txtProtein.Text = "";
            txttransFat.Text = "";
            txtpolyFat.Text = "";
            txtmonoFat.Text = "";
            txtala.Text = "";
            txtepadha.Text = "";
            txtK.Text = "";
            txtMg.Text = "";
            txtCholesterol.Text = "";
            txtSodium.Text = "";
            txtCalcium.Text = "";
            txtIron.Text = "";
            txtVitA.Text = "";
            txtVitC.Text = "";

            txtVitD.Text = "";
            txtVitE.Text = "";
            txtVitK.Text = "";
            txtB1.Text = "";
            txtB2.Text = "";
            txtB3.Text = "";
            txtB5.Text = "";
            txtB6.Text = "";
            txtB7.Text = "";
            txtB9.Text = "";
            txtB12.Text = "";
            txtZn.Text = "";
            txtSe.Text = "";
            txtB.Text = "";
            txtI.Text = "";
            txtP.Text = "";
            txtMn.Text = "";
            txtFl.Text = "";
            txtCu.Text = "";
            txtCr.Text = "";
            txtMo.Text = "";
            txtLyco.Text = "";
            txtLutZea.Text = "";
            txtCho.Text = "";
            txtIno.Text = "";
            txtCarn.Text = "";
            txtLipoic.Text = "";

            txtalan.Text = "";
            txtarg.Text = "";
            txtasparag.Text = "";
            txtaspartic.Text = "";
            txtcys.Text = "";
            txtglutamine.Text = "";
            txtgluacid.Text = "";
            txtgly.Text = "";
            txthis.Text = "";
            txtisoleu.Text = "";
            txtleu.Text = "";
            txtlys.Text = "";
            txtmeth.Text = "";
            txtphen.Text = "";
            txtproline.Text = "";
            txtserine.Text = "";
            txtthreo.Text = "";
            txttrypto.Text = "";
            txttyro.Text = "";
            txtvaline.Text = "";
            #endregion
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            //MessageBox.Show(list.Count.ToString());
            if (File.Exists(nutkeyPath))
                list = importArray(nutkeyPath);
            dbDir = nutkeyPath.Replace($"{slash}_nutKeyPairs.TXT", "");
            string[] files = Directory.GetFiles(dbDir);

            for (int i = 0; i < list.Count; i++)
            {
                #region prepopulate
                string li = list[i].Split('|')[0];
                if (list[i].Contains("Name of Food"))
                    txtname.Text = li;
                else if (list[i].Contains("NDB No."))
                    txtNDB.Text = li;
                else if (list[i].Contains("Serving1"))
                    txtServ1.Text = li;
                else if (list[i].Contains("Serving2"))
                    txtServ2.Text = li;
                else if (list[i].Contains("Weight1"))
                    txtWt1.Text = li;
                else if (list[i].Contains("Weight2"))
                    txtWt2.Text = li;
                else if (list[i].Contains("Calories"))
                    txtCals.Text = li;
                else if (list[i].Contains("Total Fat"))
                    txtFat.Text = li;
                else if (list[i].Contains("Sat Fat"))
                    txtsatFat.Text = li;
                else if (list[i].Contains("Carbs"))
                    txtCarbs.Text = li;
                else if (list[i].Contains("Fiber"))
                    txtFiber.Text = li;
                else if (list[i].Contains("Sugar"))
                    txtSugar.Text = li;
                else if (list[i].Contains("Protein"))
                    txtProtein.Text = li;
                else if (list[i].Contains("Cholesterol"))
                    txtCholesterol.Text = li;
                else if (list[i].Contains("Sodium"))
                    txtSodium.Text = li;
                else if (list[i].Contains("Calcium"))
                    txtCalcium.Text = li;
                else if (list[i].Contains("Iron"))
                    txtIron.Text = li;
                else if (list[i].Contains("Vit A"))
                    txtVitA.Text = li;
                else if (list[i].Contains("Vit C"))
                    txtVitC.Text = li;
                else if (list[i].Contains("Trans Fat"))
                    txttransFat.Text = li;
                else if (list[i].Contains("Poly Fat"))
                    txtpolyFat.Text = li;
                else if (list[i].Contains("Mono Fat"))
                    txtmonoFat.Text = li;
                else if (list[i].Contains("Lipoic acid"))
                    txtala.Text = li;
                else if (list[i].Contains("EPA + DHA"))
                    txtepadha.Text = li;
                else if (list[i].Contains("Potassium"))
                    txtK.Text = li;
                else if (list[i].Contains("Magnesium"))
                    txtMg.Text = li;

                //tab 2
                else if (list[i].Contains("Vit D"))
                    txtVitD.Text = li;
                else if (list[i].Contains("Vit E"))
                    txtVitE.Text = li;
                else if (list[i].Contains("Vit K"))
                    txtVitK.Text = li;
                else if (list[i].Contains("B1, Thiamine"))
                    txtB1.Text = li;
                else if (list[i].Contains("B2, Riboflavin"))
                    txtB2.Text = li;
                else if (list[i].Contains("B3, Niacin"))
                    txtB3.Text = li;
                else if (list[i].Contains("B5, Pantothenate"))
                    txtB5.Text = li;
                else if (list[i].Contains("B6, Pyridoxine"))
                    txtB6.Text = li;
                else if (list[i].Contains("B7, Biotin"))
                    txtB7.Text = li;
                else if (list[i].Contains("B9, Folate"))
                    txtB9.Text = li;
                else if (list[i].Contains("B12, Cobalamins"))
                    txtB12.Text = li;
                else if (list[i].Contains("Zinc"))
                    txtZn.Text = li;
                else if (list[i].Contains("Selenium"))
                    txtSe.Text = li;
                else if (list[i].Contains("Boron"))
                    txtB.Text = li;
                else if (list[i].Contains("Iodine"))
                    txtI.Text = li;
                else if (list[i].Contains("Phosphorus"))
                    txtP.Text = li;
                else if (list[i].Contains("Manganese"))
                    txtMn.Text = li;
                else if (list[i].Contains("Fluoride"))
                    txtFl.Text = li;
                else if (list[i].Contains("Copper"))
                    txtCu.Text = li;
                else if (list[i].Contains("Chromium"))
                    txtCr.Text = li;
                else if (list[i].Contains("Molybdenum"))
                    txtMo.Text = li;
                else if (list[i].Contains("Lycopene"))
                    txtLyco.Text = li;
                else if (list[i].Contains("LutZea"))
                    txtLutZea.Text = li;
                else if (list[i].Contains("Choline"))
                    txtCho.Text = li;
                else if (list[i].Contains("Inositol IP6"))
                    txtIno.Text = li;
                else if (list[i].Contains("Carnitine"))
                    txtCarn.Text = li;
                else if (list[i].Contains("Lipoic acid"))
                    txtLipoic.Text = li;

                //tab 3
                else if (list[i].Contains("Alanine"))
                    txtalan.Text = li;
                else if (list[i].Contains("Arginine"))
                    txtarg.Text = li;
                else if (list[i].Contains("Asparagine"))
                    txtasparag.Text = li;
                else if (list[i].Contains("Aspartic acid"))
                    txtaspartic.Text = li;
                else if (list[i].Contains("Cysteine"))
                    txtCals.Text = li;
                else if (list[i].Contains("Glutamine"))
                    txtglutamine.Text = li;
                else if (list[i].Contains("Glutamic acid"))
                    txtgluacid.Text = li;
                else if (list[i].Contains("Glycine"))
                    txtgly.Text = li;
                else if (list[i].Contains("Histidine"))
                    txthis.Text = li;
                else if (list[i].Contains("Isoleucine"))
                    txtisoleu.Text = li;
                else if (list[i].Contains("Leucine"))
                    txtleu.Text = li;
                else if (list[i].Contains("Lysine"))
                    txtlys.Text = li;
                else if (list[i].Contains("Methionine"))
                    txtmeth.Text = li;
                else if (list[i].Contains("Phenylalanine"))
                    txtphen.Text = li;
                else if (list[i].Contains("Proline"))
                    txtproline.Text = li;
                else if (list[i].Contains("Serine"))
                    txtserine.Text = li;
                else if (list[i].Contains("Threonine"))
                    txtthreo.Text = li;
                else if (list[i].Contains("Tryptophan"))
                    txttrypto.Text = li;
                else if (list[i].Contains("Tyrosine"))
                    txttyro.Text = li;
                else if (list[i].Contains("Valine"))
                    txtvaline.Text = li;
                #endregion
            }

            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Replace(dbDir + $"{slash}", "");
                if (!files[i].StartsWith("_"))
                    source.Add(files[i]);
            }
            #region autocompletes
            txtname.AutoCompleteCustomSource = source;
            txtname.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtNDB.AutoCompleteCustomSource = source;
            txtNDB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtNDB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtServ1.AutoCompleteCustomSource = source;
            txtServ1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtServ1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtServ2.AutoCompleteCustomSource = source;
            txtServ2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtServ2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtWt1.AutoCompleteCustomSource = source;
            txtWt1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtWt1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtWt2.AutoCompleteCustomSource = source;
            txtWt2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtWt2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtCals.AutoCompleteCustomSource = source;
            txtCals.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCals.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtFat.AutoCompleteCustomSource = source;
            txtFat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtFat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtsatFat.AutoCompleteCustomSource = source;
            txtsatFat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsatFat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtCarbs.AutoCompleteCustomSource = source;
            txtCarbs.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCarbs.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtFiber.AutoCompleteCustomSource = source;
            txtFiber.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtFiber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtSugar.AutoCompleteCustomSource = source;
            txtSugar.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSugar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtProtein.AutoCompleteCustomSource = source;
            txtProtein.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtProtein.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtCholesterol.AutoCompleteCustomSource = source;
            txtCholesterol.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCholesterol.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtSodium.AutoCompleteCustomSource = source;
            txtSodium.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSodium.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtCalcium.AutoCompleteCustomSource = source;
            txtCalcium.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCalcium.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtIron.AutoCompleteCustomSource = source;
            txtIron.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtIron.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtVitA.AutoCompleteCustomSource = source;
            txtVitA.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtVitA.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtVitC.AutoCompleteCustomSource = source;
            txtVitC.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtVitC.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txttransFat.AutoCompleteCustomSource = source;
            txttransFat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txttransFat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtpolyFat.AutoCompleteCustomSource = source;
            txtpolyFat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtpolyFat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtmonoFat.AutoCompleteCustomSource = source;
            txtmonoFat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtmonoFat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtala.AutoCompleteCustomSource = source;
            txtala.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtala.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtepadha.AutoCompleteCustomSource = source;
            txtepadha.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtepadha.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtK.AutoCompleteCustomSource = source;
            txtK.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtK.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtMg.AutoCompleteCustomSource = source;
            txtMg.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtMg.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            //tab 2

            txtVitD.AutoCompleteCustomSource = source;
            txtVitD.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtVitD.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtVitE.AutoCompleteCustomSource = source;
            txtVitE.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtVitE.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtVitK.AutoCompleteCustomSource = source;
            txtVitK.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtVitK.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtB1.AutoCompleteCustomSource = source;
            txtB1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtB1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtB2.AutoCompleteCustomSource = source;
            txtB2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtB2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtB3.AutoCompleteCustomSource = source;
            txtB3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtB3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtB5.AutoCompleteCustomSource = source;
            txtB5.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtB5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtB6.AutoCompleteCustomSource = source;
            txtB6.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtB6.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtB7.AutoCompleteCustomSource = source;
            txtB7.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtB7.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtB9.AutoCompleteCustomSource = source;
            txtB9.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtB9.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtB12.AutoCompleteCustomSource = source;
            txtB12.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtB12.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtZn.AutoCompleteCustomSource = source;
            txtZn.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtZn.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtSe.AutoCompleteCustomSource = source;
            txtSe.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSe.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtB.AutoCompleteCustomSource = source;
            txtB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtI.AutoCompleteCustomSource = source;
            txtI.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtI.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtP.AutoCompleteCustomSource = source;
            txtP.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtP.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtMn.AutoCompleteCustomSource = source;
            txtMn.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtMn.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtFl.AutoCompleteCustomSource = source;
            txtFl.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtFl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtCu.AutoCompleteCustomSource = source;
            txtCu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtCr.AutoCompleteCustomSource = source;
            txtCr.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCr.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtMo.AutoCompleteCustomSource = source;
            txtMo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtMo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtLyco.AutoCompleteCustomSource = source;
            txtLyco.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtLyco.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtLutZea.AutoCompleteCustomSource = source;
            txtLutZea.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtLutZea.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtCho.AutoCompleteCustomSource = source;
            txtCho.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCho.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtIno.AutoCompleteCustomSource = source;
            txtIno.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtIno.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtCarn.AutoCompleteCustomSource = source;
            txtCarn.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCarn.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtLipoic.AutoCompleteCustomSource = source;
            txtLipoic.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtLipoic.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            //tab 3

            txtalan.AutoCompleteCustomSource = source;
            txtalan.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtalan.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtarg.AutoCompleteCustomSource = source;
            txtarg.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtarg.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtasparag.AutoCompleteCustomSource = source;
            txtasparag.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtasparag.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtaspartic.AutoCompleteCustomSource = source;
            txtaspartic.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtaspartic.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtcys.AutoCompleteCustomSource = source;
            txtcys.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtcys.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtglutamine.AutoCompleteCustomSource = source;
            txtglutamine.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtglutamine.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtgluacid.AutoCompleteCustomSource = source;
            txtgluacid.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtgluacid.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtgly.AutoCompleteCustomSource = source;
            txtgly.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtgly.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txthis.AutoCompleteCustomSource = source;
            txthis.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txthis.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtisoleu.AutoCompleteCustomSource = source;
            txtisoleu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtisoleu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtleu.AutoCompleteCustomSource = source;
            txtleu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtleu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtlys.AutoCompleteCustomSource = source;
            txtlys.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtlys.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtmeth.AutoCompleteCustomSource = source;
            txtmeth.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtmeth.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtphen.AutoCompleteCustomSource = source;
            txtphen.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtphen.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtproline.AutoCompleteCustomSource = source;
            txtproline.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtproline.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtserine.AutoCompleteCustomSource = source;
            txtserine.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtserine.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtthreo.AutoCompleteCustomSource = source;
            txtthreo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtthreo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txttrypto.AutoCompleteCustomSource = source;
            txttrypto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txttrypto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txttyro.AutoCompleteCustomSource = source;
            txttyro.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txttyro.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtvaline.AutoCompleteCustomSource = source;
            txtvaline.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtvaline.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            //user page


            #endregion
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> text = new List<string>();
            #region write new lines
            if (txtNDB.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtNDB.Text}"))
                text.Add(txtNDB.Text + "|NDB No.");
            if (txtname.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtname.Text}"))
                text.Add(txtname.Text + "|Name of Food");
            if (txtCals.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtCals.Text}"))
                text.Add(txtCals.Text + "|Calories");
            if (txtProtein.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtProtein.Text}"))
                text.Add(txtProtein.Text + "|Protein");
            if (txtCarbs.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtCarbs.Text}"))
                text.Add(txtCarbs.Text + "|Carbs");
            if (txtFiber.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtFiber.Text}"))
                text.Add(txtFiber.Text + "|Fiber");
            if (txtSugar.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtSugar.Text}"))
                text.Add(txtSugar.Text + "|Sugar");
            if (txtFat.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtFat.Text}"))
                text.Add(txtFat.Text + "|Total Fat");
            if (txttransFat.TextLength > 0 && File.Exists($"{dbDir}{slash}{txttransFat.Text}"))
                text.Add(txttransFat.Text + "|Trans Fat");
            if (txtsatFat.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtsatFat.Text}"))
                text.Add(txtsatFat.Text + "|Sat Fat");
            if (txtpolyFat.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtpolyFat.Text}"))
                text.Add(txtpolyFat.Text + "|Poly Fat");
            if (txtmonoFat.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtmonoFat.Text}"))
                text.Add(txtmonoFat.Text + "|Mono Fat");
            if (txtala.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtala.Text}"))
                text.Add(txtala.Text + "|ALA");
            if (txtepadha.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtepadha.Text}"))
                text.Add(txtepadha.Text + "|EPA + DHA");
            if (txtK.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtK.Text}"))
                text.Add(txtK.Text + "|Potassium");
            if (txtMg.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtMg.Text}"))
                text.Add(txtMg.Text + "|Magnesium");
            if (txtCholesterol.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtCholesterol.Text}"))
                text.Add(txtCholesterol.Text + "|Cholesterol");
            if (txtSodium.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtSodium.Text}"))
                text.Add(txtSodium.Text + "|Sodium");
            if (txtCalcium.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtCalcium.Text}"))
                text.Add(txtCalcium.Text + "|Calcium");
            if (txtIron.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtIron.Text}"))
                text.Add(txtIron.Text + "|Iron");
            if (txtVitA.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtVitA.Text}"))
                text.Add(txtVitA.Text + "|Vit A");
            if (txtVitC.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtVitC.Text}"))
                text.Add(txtVitC.Text + "|Vit C");

            //tab 2
            if (txtVitD.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtVitD.Text}"))
                text.Add(txtVitD.Text + "|Vit D");
            if (txtVitE.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtVitE.Text}"))
                text.Add(txtVitE.Text + "|Vit E");
            if (txtVitK.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtVitK.Text}"))
                text.Add(txtVitK.Text + "|Vit K");
            if (txtB1.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtB1.Text}"))
                text.Add(txtB1.Text + "|B1, Thiamine");
            if (txtB2.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtB2.Text}"))
                text.Add(txtB2.Text + "|B2, Riboflavin");
            if (txtB3.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtB3.Text}"))
                text.Add(txtB3.Text + "|B3, Niacin");
            if (txtB5.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtB5.Text}"))
                text.Add(txtB5.Text + "|B5, Pantothenate");
            if (txtB6.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtB6.Text}"))
                text.Add(txtB6.Text + "|B6, Pyridoxine");
            if (txtB7.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtB7.Text}"))
                text.Add(txtB7.Text + "|B7, Biotin");
            if (txtB9.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtB9.Text}"))
                text.Add(txtB9.Text + "|B9, Folate");
            if (txtB12.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtB12.Text}"))
                text.Add(txtB12.Text + "|B12, Cobalamins");

            if (txtZn.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtZn.Text}"))
                text.Add(txtZn.Text + "|Zinc");
            if (txtSe.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtSe.Text}"))
                text.Add(txtSe.Text + "|Selenium");
            if (txtB.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtB.Text}"))
                text.Add(txtB.Text + "|Boron");
            if (txtP.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtP.Text}"))
                text.Add(txtP.Text + "|Phosphorus");
            if (txtMn.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtMn.Text}"))
                text.Add(txtMn.Text + "|Manganese");
            if (txtFl.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtFl.Text}"))
                text.Add(txtFl.Text + "|Fluoride");
            if (txtCu.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtCu.Text}"))
                text.Add(txtCu.Text + "|Copper");
            if (txtCr.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtCr.Text}"))
                text.Add(txtCr.Text + "|Chromium");
            if (txtMo.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtMo.Text}"))
                text.Add(txtMo.Text + "|Molybdenum");
            if (txtCho.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtCho.Text}"))
                text.Add(txtCho.Text + "|Lycopene");
            if (txtCho.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtLyco.Text}"))
                text.Add(txtCho.Text + "|LutZea");
            if (txtCho.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtLutZea.Text}"))
                text.Add(txtCho.Text + "|Choline");
            if (txtIno.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtIno.Text}"))
                text.Add(txtIno.Text + "|Inositol IP6");
            if (txtCarn.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtCarn.Text}"))
                text.Add(txtCarn.Text + "|Carnitine");
            if (txtLipoic.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtLipoic.Text}"))
                text.Add(txtLipoic.Text + "|Lipoic acid");

            //tab 3
            if (txtalan.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtalan.Text}"))
                text.Add(txtalan.Text + "|Alanine");
            if (txtarg.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtarg.Text}"))
                text.Add(txtarg.Text + "|Arginine");
            if (txtasparag.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtasparag.Text}"))
                text.Add(txtasparag.Text + "|Asparagine");
            if (txtaspartic.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtaspartic.Text}"))
                text.Add(txtaspartic.Text + "|Aspartic acid");
            if (txtcys.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtcys.Text}"))
                text.Add(txtcys.Text + "|Cystine");
            if (txtglutamine.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtglutamine.Text}"))
                text.Add(txtglutamine.Text + "|Glutamine");
            if (txtgluacid.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtgluacid.Text}"))
                text.Add(txtgluacid.Text + "|Glutamic acid");
            if (txtgly.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtgly.Text}"))
                text.Add(txtgly.Text + "|Glycine");
            if (txthis.TextLength > 0 && File.Exists($"{dbDir}{slash}{txthis.Text}"))
                text.Add(txthis.Text + "|Histidine");
            if (txtisoleu.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtisoleu.Text}"))
                text.Add(txtisoleu.Text + "|Isoleucine");
            if (txtleu.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtleu.Text}"))
                text.Add(txtleu.Text + "|Leucine");
            if (txtmeth.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtmeth.Text}"))
                text.Add(txtmeth.Text + "|Methionine");
            if (txtphen.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtphen.Text}"))
                text.Add(txtphen.Text + "|Phenylalanine");
            if (txtproline.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtproline.Text}"))
                text.Add(txtproline.Text + "|Proline");
            if (txtserine.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtserine.Text}"))
                text.Add(txtserine.Text + "|Serine");
            if (txtthreo.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtthreo.Text}"))
                text.Add(txtthreo.Text + "|Threonine");
            if (txttrypto.TextLength > 0 && File.Exists($"{dbDir}{slash}{txttrypto.Text}"))
                text.Add(txttrypto.Text + "|Tryptophan");
            if (txttyro.TextLength > 0 && File.Exists($"{dbDir}{slash}{txttyro.Text}"))
                text.Add(txttyro.Text + "|Tyrosine");
            if (txtvaline.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtvaline.Text}"))
                text.Add(txtvaline.Text + "|Valine");

            //last to display
            if (txtServ1.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtServ1.Text}"))
                text.Add(txtServ1.Text + "|Serving1");
            if (txtServ2.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtServ2.Text}"))
                text.Add(txtServ2.Text + "|Serving2");
            if (txtWt1.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtWt1.Text}"))
                text.Add(txtWt1.Text + "|Weight1");
            if (txtWt2.TextLength > 0 && File.Exists($"{dbDir}{slash}{txtWt2.Text}"))
                text.Add(txtWt2.Text + "|Weight2");
            #endregion
            //MessageBox.Show(text);
            File.WriteAllLines(nutkeyPath, text);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Contains("(share)"))
                nutkeyPath = $"{Application.StartupPath}{slash}usr{slash}share{slash}DBs{slash}{comboBox1.Text.Replace(" (share)", "")}{slash}_nutKeyPairs.TXT";
            else
                nutkeyPath = $"{Application.StartupPath}{slash}usr{slash}profile{frmMain.profIndex.ToString()}{slash}DBs{slash}{comboBox1.Text.Replace(" (user)", "")}{slash}_nutKeyPairs.TXT";            
            refresh();
        }
    }
}
