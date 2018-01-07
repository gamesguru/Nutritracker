namespace Nutritracker
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnAddEx = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuesstimate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDetailReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataDay = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtExerciseVal = new System.Windows.Forms.TextBox();
            this.btnRemEx = new System.Windows.Forms.Button();
            this.btnAdvCalc = new System.Windows.Forms.Button();
            this.lblActType = new System.Windows.Forms.Label();
            this.comboExType = new System.Windows.Forms.ComboBox();
            this.dataExercise = new System.Windows.Forms.DataGridView();
            this.columnActivityType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnIntensity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCalsperMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTotCal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.btnProfile = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboMeal = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLogCustFood = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEditRecipe = new System.Windows.Forms.Button();
            this.lstBoxRecipes = new System.Windows.Forms.ListBox();
            this.btnEditCustFoods = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageActiveFieldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customFoodEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decomposeRecipeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rankFoodsByNutrientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSearchCommonFoodsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addExerciseToLogToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedExerciseCalcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDetailReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bodyFatCalcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.naturalPotentialCalcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseExcelSpreadsheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relationalDatabaseWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRelativeDBPairsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageCustomFieldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageStandaloneDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemoveFood = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.comboLoggedDays = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDay)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataExercise)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddEx
            // 
            this.btnAddEx.Enabled = false;
            this.btnAddEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEx.Location = new System.Drawing.Point(13, 34);
            this.btnAddEx.Name = "btnAddEx";
            this.btnAddEx.Size = new System.Drawing.Size(166, 28);
            this.btnAddEx.TabIndex = 1;
            this.btnAddEx.TabStop = false;
            this.btnAddEx.Text = "Add Exercise to Log";
            this.btnAddEx.UseVisualStyleBackColor = true;
            this.btnAddEx.Click += new System.EventHandler(this.btnAddEx_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnGuesstimate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnDetailReport);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataDay);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(956, 469);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Daily nutrition";
            // 
            // btnGuesstimate
            // 
            this.btnGuesstimate.Enabled = false;
            this.btnGuesstimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuesstimate.Location = new System.Drawing.Point(592, 422);
            this.btnGuesstimate.Name = "btnGuesstimate";
            this.btnGuesstimate.Size = new System.Drawing.Size(158, 32);
            this.btnGuesstimate.TabIndex = 9;
            this.btnGuesstimate.TabStop = false;
            this.btnGuesstimate.Text = "Open Guesstimator";
            this.btnGuesstimate.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(284, 409);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Overall Grade:";
            // 
            // btnDetailReport
            // 
            this.btnDetailReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetailReport.Location = new System.Drawing.Point(757, 422);
            this.btnDetailReport.Name = "btnDetailReport";
            this.btnDetailReport.Size = new System.Drawing.Size(158, 32);
            this.btnDetailReport.TabIndex = 3;
            this.btnDetailReport.TabStop = false;
            this.btnDetailReport.Text = "Run Detail Report";
            this.btnDetailReport.UseVisualStyleBackColor = true;
            this.btnDetailReport.Click += new System.EventHandler(this.btnDetailReport_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lowest Score:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Best Score:";
            // 
            // dataDay
            // 
            this.dataDay.AllowUserToDeleteRows = false;
            this.dataDay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataDay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDay.Location = new System.Drawing.Point(17, 49);
            this.dataDay.MultiSelect = false;
            this.dataDay.Name = "dataDay";
            this.dataDay.Size = new System.Drawing.Size(920, 346);
            this.dataDay.TabIndex = 0;
            this.dataDay.TabStop = false;
            this.dataDay.ReadOnly = true;
            this.dataDay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataDay_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtExerciseVal);
            this.groupBox2.Controls.Add(this.btnRemEx);
            this.groupBox2.Controls.Add(this.btnAdvCalc);
            this.groupBox2.Controls.Add(this.lblActType);
            this.groupBox2.Controls.Add(this.comboExType);
            this.groupBox2.Controls.Add(this.dataExercise);
            this.groupBox2.Controls.Add(this.btnAddEx);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 542);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(627, 357);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Daily Exercise";
            // 
            // txtExerciseVal
            // 
            this.txtExerciseVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtExerciseVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExerciseVal.Location = new System.Drawing.Point(518, 28);
            this.txtExerciseVal.MaxLength = 6;
            this.txtExerciseVal.Name = "txtExerciseVal";
            this.txtExerciseVal.Size = new System.Drawing.Size(74, 29);
            this.txtExerciseVal.TabIndex = 22;
            this.txtExerciseVal.Text = "0";
            this.txtExerciseVal.TextChanged += new System.EventHandler(this.txtExerciseVal_TextChanged);
            this.txtExerciseVal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtExerciseVal_KeyDown);
            this.txtExerciseVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExerciseVal_KeyPress);
            // 
            // btnRemEx
            // 
            this.btnRemEx.Enabled = false;
            this.btnRemEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemEx.Location = new System.Drawing.Point(14, 315);
            this.btnRemEx.Name = "btnRemEx";
            this.btnRemEx.Size = new System.Drawing.Size(151, 28);
            this.btnRemEx.TabIndex = 6;
            this.btnRemEx.TabStop = false;
            this.btnRemEx.Text = "Remove Exercise";
            this.btnRemEx.UseVisualStyleBackColor = true;
            this.btnRemEx.Click += new System.EventHandler(this.btnRemEx_Click);
            // 
            // btnAdvCalc
            // 
            this.btnAdvCalc.Enabled = false;
            this.btnAdvCalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdvCalc.Location = new System.Drawing.Point(413, 315);
            this.btnAdvCalc.Name = "btnAdvCalc";
            this.btnAdvCalc.Size = new System.Drawing.Size(202, 28);
            this.btnAdvCalc.TabIndex = 5;
            this.btnAdvCalc.TabStop = false;
            this.btnAdvCalc.Text = "View Advanced Calculator";
            this.btnAdvCalc.UseVisualStyleBackColor = true;
            this.btnAdvCalc.Click += new System.EventHandler(this.btnAdvCalc_Click);
            // 
            // lblActType
            // 
            this.lblActType.AutoSize = true;
            this.lblActType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActType.Location = new System.Drawing.Point(440, 33);
            this.lblActType.Name = "lblActType";
            this.lblActType.Size = new System.Drawing.Size(55, 20);
            this.lblActType.TabIndex = 4;
            this.lblActType.Text = "Steps:";
            // 
            // comboExType
            // 
            this.comboExType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboExType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboExType.FormattingEnabled = true;
            this.comboExType.Items.AddRange(new object[] {
            "Walking [Steps]",
            "Walking (3mph)",
            "Jogging (5-6mph)",
            "Running (7-8mph)",
            "Sprinting (10-12mph)",
            "Other - Calories"});
            this.comboExType.Location = new System.Drawing.Point(218, 30);
            this.comboExType.Name = "comboExType";
            this.comboExType.Size = new System.Drawing.Size(187, 28);
            this.comboExType.TabIndex = 3;
            this.comboExType.SelectedIndexChanged += new System.EventHandler(this.comboExType_SelectedIndexChanged);
            // 
            // dataExercise
            // 
            this.dataExercise.AllowUserToDeleteRows = false;
            this.dataExercise.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataExercise.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnActivityType,
            this.columnIntensity,
            this.columnCalsperMin,
            this.column,
            this.columnTotCal});
            this.dataExercise.Location = new System.Drawing.Point(13, 68);
            this.dataExercise.MultiSelect = false;
            this.dataExercise.Name = "dataExercise";
            this.dataExercise.Size = new System.Drawing.Size(603, 230);
            this.dataExercise.TabIndex = 0;
            this.dataExercise.TabStop = false;
            this.dataExercise.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataExercise_CellValueChanged);
            this.dataExercise.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataExercise_KeyDown);
            // 
            // columnActivityType
            // 
            this.columnActivityType.HeaderText = "Activity Type";
            this.columnActivityType.Name = "columnActivityType";
            this.columnActivityType.ReadOnly = true;
            this.columnActivityType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // columnIntensity
            // 
            this.columnIntensity.HeaderText = "Intensity";
            this.columnIntensity.Name = "columnIntensity";
            this.columnIntensity.ReadOnly = true;
            this.columnIntensity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // columnCalsperMin
            // 
            this.columnCalsperMin.HeaderText = "kCal per Minute";
            this.columnCalsperMin.Name = "columnCalsperMin";
            this.columnCalsperMin.ReadOnly = true;
            this.columnCalsperMin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.columnCalsperMin.Width = 130;
            // 
            // column
            // 
            this.column.HeaderText = "Duration";
            this.column.Name = "column";
            this.column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.column.Width = 115;
            // 
            // columnTotCal
            // 
            this.columnTotCal.HeaderText = "Total Expended";
            this.columnTotCal.Name = "columnTotCal";
            this.columnTotCal.ReadOnly = true;
            this.columnTotCal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.columnTotCal.Width = 115;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(440, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Load Previous Day:";
            // 
            // btnProfile
            // 
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.Location = new System.Drawing.Point(725, 30);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(192, 31);
            this.btnProfile.TabIndex = 5;
            this.btnProfile.TabStop = false;
            this.btnProfile.Text = "Switch or Edit Profiles";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.comboMeal);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtQty);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnLogCustFood);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.btnEditRecipe);
            this.groupBox3.Controls.Add(this.lstBoxRecipes);
            this.groupBox3.Controls.Add(this.btnEditCustFoods);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(636, 542);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(323, 357);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Recipes and Custom Foods";
            // 
            // comboMeal
            // 
            this.comboMeal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboMeal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMeal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMeal.FormattingEnabled = true;
            this.comboMeal.Items.AddRange(new object[] {
            "Breakfast",
            "Lunch",
            "Dinner"});
            this.comboMeal.Location = new System.Drawing.Point(195, 316);
            this.comboMeal.Name = "comboMeal";
            this.comboMeal.Size = new System.Drawing.Size(120, 32);
            this.comboMeal.TabIndex = 21;
            this.comboMeal.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(191, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 24);
            this.label6.TabIndex = 20;
            this.label6.Text = "Meal:";
            // 
            // txtQty
            // 
            this.txtQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQty.Enabled = false;
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(51, 262);
            this.txtQty.MaxLength = 5;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(74, 29);
            this.txtQty.TabIndex = 19;
            this.txtQty.TabStop = false;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(131, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 24);
            this.label5.TabIndex = 18;
            this.label5.Text = "g";
            // 
            // btnLogCustFood
            // 
            this.btnLogCustFood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogCustFood.Enabled = false;
            this.btnLogCustFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogCustFood.Location = new System.Drawing.Point(6, 310);
            this.btnLogCustFood.Name = "btnLogCustFood";
            this.btnLogCustFood.Size = new System.Drawing.Size(147, 38);
            this.btnLogCustFood.TabIndex = 17;
            this.btnLogCustFood.TabStop = false;
            this.btnLogCustFood.Text = "Add to Log";
            this.btnLogCustFood.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 24);
            this.label7.TabIndex = 16;
            this.label7.Text = "Qty:";
            // 
            // btnEditRecipe
            // 
            this.btnEditRecipe.Enabled = false;
            this.btnEditRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRecipe.Location = new System.Drawing.Point(6, 28);
            this.btnEditRecipe.Name = "btnEditRecipe";
            this.btnEditRecipe.Size = new System.Drawing.Size(137, 28);
            this.btnEditRecipe.TabIndex = 3;
            this.btnEditRecipe.TabStop = false;
            this.btnEditRecipe.Text = "Edit Recipes";
            this.btnEditRecipe.UseVisualStyleBackColor = true;
            // 
            // lstBoxRecipes
            // 
            this.lstBoxRecipes.FormattingEnabled = true;
            this.lstBoxRecipes.ItemHeight = 24;
            this.lstBoxRecipes.Location = new System.Drawing.Point(2, 63);
            this.lstBoxRecipes.Name = "lstBoxRecipes";
            this.lstBoxRecipes.Size = new System.Drawing.Size(301, 196);
            this.lstBoxRecipes.TabIndex = 0;
            this.lstBoxRecipes.TabStop = false;
            // 
            // btnEditCustFoods
            // 
            this.btnEditCustFoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditCustFoods.Location = new System.Drawing.Point(148, 28);
            this.btnEditCustFoods.Name = "btnEditCustFoods";
            this.btnEditCustFoods.Size = new System.Drawing.Size(154, 28);
            this.btnEditCustFoods.TabIndex = 2;
            this.btnEditCustFoods.TabStop = false;
            this.btnEditCustFoods.Text = "Custom Foods";
            this.btnEditCustFoods.UseVisualStyleBackColor = true;
            this.btnEditCustFoods.Click += new System.EventHandler(this.btnEditCustFoods_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addToLogToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.databaseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1001, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageActiveFieldsToolStripMenuItem,
            this.customFoodEntryToolStripMenuItem,
            this.editProfilesToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.decomposeRecipeToolStripMenuItem,
            this.rankFoodsByNutrientToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // manageActiveFieldsToolStripMenuItem
            // 
            this.manageActiveFieldsToolStripMenuItem.Name = "manageActiveFieldsToolStripMenuItem";
            this.manageActiveFieldsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.manageActiveFieldsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.manageActiveFieldsToolStripMenuItem.Text = "Manage Active Fields";
            this.manageActiveFieldsToolStripMenuItem.Click += new System.EventHandler(this.manageActiveFieldsToolStripMenuItem_Click);
            // 
            // customFoodEntryToolStripMenuItem
            // 
            this.customFoodEntryToolStripMenuItem.Name = "customFoodEntryToolStripMenuItem";
            this.customFoodEntryToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.customFoodEntryToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.customFoodEntryToolStripMenuItem.Text = "Manage Custom Foods";
            this.customFoodEntryToolStripMenuItem.Click += new System.EventHandler(this.customFoodEntryToolStripMenuItem_Click);
            // 
            // editProfilesToolStripMenuItem
            // 
            this.editProfilesToolStripMenuItem.Name = "editProfilesToolStripMenuItem";
            this.editProfilesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.editProfilesToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.editProfilesToolStripMenuItem.Text = "Edit Profiles";
            this.editProfilesToolStripMenuItem.Click += new System.EventHandler(this.editProfilesToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // decomposeRecipeToolStripMenuItem
            // 
            this.decomposeRecipeToolStripMenuItem.Name = "decomposeRecipeToolStripMenuItem";
            this.decomposeRecipeToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.decomposeRecipeToolStripMenuItem.Text = "Analyze Ingriedent List";
            this.decomposeRecipeToolStripMenuItem.Click += new System.EventHandler(this.analyzeIngriedientListToolStripMenuItem_Click);
            // 
            // rankFoodsByNutrientToolStripMenuItem
            // 
            this.rankFoodsByNutrientToolStripMenuItem.Enabled = false;
            this.rankFoodsByNutrientToolStripMenuItem.Name = "rankFoodsByNutrientToolStripMenuItem";
            this.rankFoodsByNutrientToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.rankFoodsByNutrientToolStripMenuItem.Text = "Rank Foods by Nutrient";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Enabled = false;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // addToLogToolStripMenuItem
            // 
            this.addToLogToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSearchCommonFoodsToolStripMenuItem1,
            this.addExerciseToLogToolStripMenuItem1});
            this.addToLogToolStripMenuItem.Name = "addToLogToolStripMenuItem";
            this.addToLogToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.addToLogToolStripMenuItem.Text = "Add to Log";
            // 
            // addSearchCommonFoodsToolStripMenuItem1
            // 
            this.addSearchCommonFoodsToolStripMenuItem1.Name = "addSearchCommonFoodsToolStripMenuItem1";
            this.addSearchCommonFoodsToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.addSearchCommonFoodsToolStripMenuItem1.Size = new System.Drawing.Size(244, 22);
            this.addSearchCommonFoodsToolStripMenuItem1.Text = "Add/Search Common Foods";
            this.addSearchCommonFoodsToolStripMenuItem1.Click += new System.EventHandler(this.addSearchCommonFoodsToolStripMenuItem1_Click);
            // 
            // addExerciseToLogToolStripMenuItem1
            // 
            this.addExerciseToLogToolStripMenuItem1.Enabled = false;
            this.addExerciseToLogToolStripMenuItem1.Name = "addExerciseToLogToolStripMenuItem1";
            this.addExerciseToLogToolStripMenuItem1.Size = new System.Drawing.Size(244, 22);
            this.addExerciseToLogToolStripMenuItem1.Text = "Add Exercise to Log";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.advancedExerciseCalcToolStripMenuItem,
            this.viewDetailReportToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.bodyFatCalcToolStripMenuItem,
            this.naturalPotentialCalcToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // advancedExerciseCalcToolStripMenuItem
            // 
            this.advancedExerciseCalcToolStripMenuItem.Enabled = false;
            this.advancedExerciseCalcToolStripMenuItem.Name = "advancedExerciseCalcToolStripMenuItem";
            this.advancedExerciseCalcToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.advancedExerciseCalcToolStripMenuItem.Text = "Advanced Exercise Calc";
            // 
            // viewDetailReportToolStripMenuItem
            // 
            this.viewDetailReportToolStripMenuItem.Name = "viewDetailReportToolStripMenuItem";
            this.viewDetailReportToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.viewDetailReportToolStripMenuItem.Text = "Run Detail Report";
            this.viewDetailReportToolStripMenuItem.Click += new System.EventHandler(this.viewDetailReportToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Enabled = false;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // bodyFatCalcToolStripMenuItem
            // 
            this.bodyFatCalcToolStripMenuItem.Name = "bodyFatCalcToolStripMenuItem";
            this.bodyFatCalcToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.bodyFatCalcToolStripMenuItem.Text = "Bodyfat Calculator";
            this.bodyFatCalcToolStripMenuItem.Click += new System.EventHandler(this.bodyFatCalcToolStripMenuItem_Click);
            // 
            // naturalPotentialCalcToolStripMenuItem
            // 
            this.naturalPotentialCalcToolStripMenuItem.Name = "naturalPotentialCalcToolStripMenuItem";
            this.naturalPotentialCalcToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.naturalPotentialCalcToolStripMenuItem.Text = "Strength Limits for Men";
            this.naturalPotentialCalcToolStripMenuItem.Click += new System.EventHandler(this.naturalPotentialCalcToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parseExcelSpreadsheetToolStripMenuItem,
            this.relationalDatabaseWizardToolStripMenuItem,
            this.manageRelativeDBPairsToolStripMenuItem,
            this.manageCustomFieldsToolStripMenuItem,
            this.manageStandaloneDatabaseToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // parseExcelSpreadsheetToolStripMenuItem
            // 
            this.parseExcelSpreadsheetToolStripMenuItem.Name = "parseExcelSpreadsheetToolStripMenuItem";
            this.parseExcelSpreadsheetToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.parseExcelSpreadsheetToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.parseExcelSpreadsheetToolStripMenuItem.Text = "Import DB or Field";
            this.parseExcelSpreadsheetToolStripMenuItem.Click += new System.EventHandler(this.parseExcelSpreadsheetToolStripMenuItem_Click);
            // 
            // relationalDatabaseWizardToolStripMenuItem
            // 
            this.relationalDatabaseWizardToolStripMenuItem.Name = "relationalDatabaseWizardToolStripMenuItem";
            this.relationalDatabaseWizardToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.relationalDatabaseWizardToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.relationalDatabaseWizardToolStripMenuItem.Text = "Import Relational Database";
            this.relationalDatabaseWizardToolStripMenuItem.Click += new System.EventHandler(this.relationalDatabaseWizardToolStripMenuItem_Click);
            // 
            // manageRelativeDBPairsToolStripMenuItem
            // 
            this.manageRelativeDBPairsToolStripMenuItem.Name = "manageRelativeDBPairsToolStripMenuItem";
            this.manageRelativeDBPairsToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.manageRelativeDBPairsToolStripMenuItem.Text = "Manage Field Pairs for USDA";
            this.manageRelativeDBPairsToolStripMenuItem.Click += new System.EventHandler(this.manageRelativeDBPairsToolStripMenuItem_Click);
            // 
            // manageCustomFieldsToolStripMenuItem
            // 
            this.manageCustomFieldsToolStripMenuItem.Name = "manageCustomFieldsToolStripMenuItem";
            this.manageCustomFieldsToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.manageCustomFieldsToolStripMenuItem.Text = "Manage Custom Fields";
            this.manageCustomFieldsToolStripMenuItem.Click += new System.EventHandler(this.manageCustomFieldsToolStripMenuItem_Click);
            // 
            // manageStandaloneDatabaseToolStripMenuItem
            // 
            this.manageStandaloneDatabaseToolStripMenuItem.Name = "manageStandaloneDatabaseToolStripMenuItem";
            this.manageStandaloneDatabaseToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.manageStandaloneDatabaseToolStripMenuItem.Text = "Manage Standalone Database";
            this.manageStandaloneDatabaseToolStripMenuItem.Click += new System.EventHandler(this.manageStandaloneDatabaseToolStripMenuItem_Click);
            // 
            // btnRemoveFood
            // 
            this.btnRemoveFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFood.Location = new System.Drawing.Point(239, 29);
            this.btnRemoveFood.Name = "btnRemoveFood";
            this.btnRemoveFood.Size = new System.Drawing.Size(127, 31);
            this.btnRemoveFood.TabIndex = 9;
            this.btnRemoveFood.TabStop = false;
            this.btnRemoveFood.Text = "Remove Food";
            this.btnRemoveFood.UseVisualStyleBackColor = true;
            this.btnRemoveFood.Click += new System.EventHandler(this.btnRemoveFood_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(3, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(212, 56);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search Food Databases\r\nAdd to Log";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(654, 905);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(284, 42);
            this.btnExit.TabIndex = 22;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // comboLoggedDays
            // 
            this.comboLoggedDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLoggedDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLoggedDays.FormattingEnabled = true;
            this.comboLoggedDays.Location = new System.Drawing.Point(459, 30);
            this.comboLoggedDays.Name = "comboLoggedDays";
            this.comboLoggedDays.Size = new System.Drawing.Size(121, 32);
            this.comboLoggedDays.TabIndex = 23;
            this.comboLoggedDays.SelectedIndexChanged += new System.EventHandler(this.comboLoggedDays_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.comboLoggedDays);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btnRemoveFood);
            this.panel1.Controls.Add(this.btnProfile);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Location = new System.Drawing.Point(9, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(988, 953);
            this.panel1.TabIndex = 24;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 989);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nutritracker";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDay)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataExercise)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddEx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataDay;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataExercise;
        private System.Windows.Forms.Button btnDetailReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboExType;
        private System.Windows.Forms.Label lblActType;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnAdvCalc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnEditRecipe;
        private System.Windows.Forms.Button btnEditCustFoods;
        private System.Windows.Forms.ListBox lstBoxRecipes;
        private System.Windows.Forms.ComboBox comboMeal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLogCustFood;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGuesstimate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editProfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedExerciseCalcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bodyFatCalcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDetailReportToolStripMenuItem;
        private System.Windows.Forms.Button btnRemoveFood;
        private System.Windows.Forms.Button btnRemEx;
        private System.Windows.Forms.ToolStripMenuItem customFoodEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.TextBox txtExerciseVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnActivityType;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnIntensity;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCalsperMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn column;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTotCal;
        private System.Windows.Forms.ToolStripMenuItem naturalPotentialCalcToolStripMenuItem;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolStripMenuItem addToLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSearchCommonFoodsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addExerciseToLogToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageCustomFieldsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageStandaloneDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decomposeRecipeToolStripMenuItem;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox comboLoggedDays;
        private System.Windows.Forms.ToolStripMenuItem rankFoodsByNutrientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parseExcelSpreadsheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relationalDatabaseWizardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageRelativeDBPairsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageActiveFieldsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}

