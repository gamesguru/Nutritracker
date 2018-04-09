namespace Nutritracker
{
    partial class frmSearchFoods
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchFoods));
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboMeal = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboConvert = new System.Windows.Forms.ComboBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSrch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstviewFoods = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboDBs = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.srchTmout = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTxtWarn = new System.Windows.Forms.RichTextBox();
            this.lblCurrentFood = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(696, 495);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(119, 63);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.comboMeal.Location = new System.Drawing.Point(224, 511);
            this.comboMeal.Name = "comboMeal";
            this.comboMeal.Size = new System.Drawing.Size(127, 32);
            this.comboMeal.TabIndex = 4;
            this.comboMeal.SelectedIndexChanged += new System.EventHandler(this.comboMeal_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(162, 514);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 24);
            this.label6.TabIndex = 28;
            this.label6.Text = "Meal:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(406, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Per 100g or per 100kcal:";
            this.label4.Visible = false;
            // 
            // comboConvert
            // 
            this.comboConvert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboConvert.FormattingEnabled = true;
            this.comboConvert.Items.AddRange(new object[] {
            "per 100 g",
            "per 100 kCal"});
            this.comboConvert.Location = new System.Drawing.Point(423, 47);
            this.comboConvert.Name = "comboConvert";
            this.comboConvert.Size = new System.Drawing.Size(164, 32);
            this.comboConvert.Sorted = true;
            this.comboConvert.TabIndex = 24;
            this.comboConvert.TabStop = false;
            this.comboConvert.Visible = false;
            // 
            // txtQty
            // 
            this.txtQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(58, 465);
            this.txtQty.MaxLength = 5;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(74, 29);
            this.txtQty.TabIndex = 2;
            this.txtQty.TextChanged += new System.EventHandler(this.txtQty_TextChanged);
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(138, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 24);
            this.label3.TabIndex = 23;
            this.label3.Text = "grams";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(9, 500);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(141, 53);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add to Log";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 468);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "Qty:";
            // 
            // txtSrch
            // 
            this.txtSrch.AcceptsReturn = true;
            this.txtSrch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSrch.Location = new System.Drawing.Point(128, 43);
            this.txtSrch.MaxLength = 32;
            this.txtSrch.Name = "txtSrch";
            this.txtSrch.Size = new System.Drawing.Size(272, 29);
            this.txtSrch.TabIndex = 0;
            this.txtSrch.TextChanged += new System.EventHandler(this.txtSrch_TextChanged);
            this.txtSrch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSrch_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Search Foods:";
            // 
            // lstviewFoods
            // 
            this.lstviewFoods.AllowColumnReorder = true;
            this.lstviewFoods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstviewFoods.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstviewFoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstviewFoods.FullRowSelect = true;
            this.lstviewFoods.HideSelection = false;
            this.lstviewFoods.Location = new System.Drawing.Point(10, 162);
            this.lstviewFoods.MultiSelect = false;
            this.lstviewFoods.Name = "lstviewFoods";
            this.lstviewFoods.Size = new System.Drawing.Size(805, 297);
            this.lstviewFoods.TabIndex = 1;
            this.lstviewFoods.TabStop = false;
            this.lstviewFoods.UseCompatibleStateImageBehavior = false;
            this.lstviewFoods.View = System.Windows.Forms.View.Details;
            this.lstviewFoods.SelectedIndexChanged += new System.EventHandler(this.lstviewFoods_SelectedIndexChanged);
            this.lstviewFoods.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstviewFoods_KeyDown);
            this.lstviewFoods.Leave += new System.EventHandler(this.lstviewFoods_Leave);
            this.lstviewFoods.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstviewFoods_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboDBs);
            this.groupBox1.Location = new System.Drawing.Point(239, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 62);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Default Database";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Search From:";
            // 
            // comboDBs
            // 
            this.comboDBs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDBs.FormattingEnabled = true;
            this.comboDBs.Location = new System.Drawing.Point(98, 24);
            this.comboDBs.Name = "comboDBs";
            this.comboDBs.Size = new System.Drawing.Size(121, 21);
            this.comboDBs.TabIndex = 0;
            this.comboDBs.TabStop = false;
            this.comboDBs.SelectedIndexChanged += new System.EventHandler(this.comboDBs_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(827, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historyManagerToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // historyManagerToolStripMenuItem
            // 
            this.historyManagerToolStripMenuItem.Name = "historyManagerToolStripMenuItem";
            this.historyManagerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.historyManagerToolStripMenuItem.Text = "History Manager";
            this.historyManagerToolStripMenuItem.Click += new System.EventHandler(this.historyManagerToolStripMenuItem_Click);
            // 
            // srchTmout
            // 
            this.srchTmout.Enabled = true;
            this.srchTmout.Interval = 180;
            this.srchTmout.Tick += new System.EventHandler(this.srchTmout_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTxtWarn);
            this.groupBox3.Location = new System.Drawing.Point(12, 84);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(221, 62);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Warning Palette";
            // 
            // richTxtWarn
            // 
            this.richTxtWarn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richTxtWarn.ForeColor = System.Drawing.Color.Red;
            this.richTxtWarn.Location = new System.Drawing.Point(6, 19);
            this.richTxtWarn.Name = "richTxtWarn";
            this.richTxtWarn.ReadOnly = true;
            this.richTxtWarn.Size = new System.Drawing.Size(209, 37);
            this.richTxtWarn.TabIndex = 0;
            this.richTxtWarn.TabStop = false;
            this.richTxtWarn.Text = "";
            this.richTxtWarn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTxtWarn_MouseClick);
            // 
            // lblCurrentFood
            // 
            this.lblCurrentFood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurrentFood.AutoSize = true;
            this.lblCurrentFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentFood.Location = new System.Drawing.Point(245, 468);
            this.lblCurrentFood.Name = "lblCurrentFood";
            this.lblCurrentFood.Size = new System.Drawing.Size(180, 24);
            this.lblCurrentFood.TabIndex = 33;
            this.lblCurrentFood.Text = "Selected food: none";
            // 
            // frmSearchFoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(827, 570);
            this.Controls.Add(this.lblCurrentFood);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.comboMeal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboConvert);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSrch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstviewFoods);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmSearchFoods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search and Add Foods to Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchFoods_FormClosing);
            this.Load += new System.EventHandler(this.frmSearchFoods_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox comboMeal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboConvert;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSrch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstviewFoods;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboDBs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Timer srchTmout;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTxtWarn;
        private System.Windows.Forms.Label lblCurrentFood;
        private System.Windows.Forms.ToolStripMenuItem historyManagerToolStripMenuItem;
    }
}