namespace NutApp
{
    partial class frmNewDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewDB));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioPersonal = new System.Windows.Forms.RadioButton();
            this.radioShared = new System.Windows.Forms.RadioButton();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblColumnCount = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCalories = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClearChoices = new System.Windows.Forms.Button();
            this.lblSearchField = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioPersonal);
            this.groupBox1.Controls.Add(this.radioShared);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type and Location";
            // 
            // radioPersonal
            // 
            this.radioPersonal.AutoSize = true;
            this.radioPersonal.Checked = true;
            this.radioPersonal.Location = new System.Drawing.Point(6, 42);
            this.radioPersonal.Name = "radioPersonal";
            this.radioPersonal.Size = new System.Drawing.Size(126, 17);
            this.radioPersonal.TabIndex = 1;
            this.radioPersonal.TabStop = true;
            this.radioPersonal.Text = "Personal (your profile)";
            this.radioPersonal.UseVisualStyleBackColor = true;
            // 
            // radioShared
            // 
            this.radioShared.AutoSize = true;
            this.radioShared.Location = new System.Drawing.Point(6, 19);
            this.radioShared.Name = "radioShared";
            this.radioShared.Size = new System.Drawing.Size(86, 17);
            this.radioShared.TabIndex = 0;
            this.radioShared.Text = "Shared (root)";
            this.radioShared.UseVisualStyleBackColor = true;
            this.radioShared.CheckedChanged += new System.EventHandler(this.radioShared_CheckedChanged);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(8, 42);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Text = "Location:";
            // 
            // txtLoc
            // 
            this.txtLoc.Enabled = false;
            this.txtLoc.Location = new System.Drawing.Point(65, 39);
            this.txtLoc.MaxLength = 100;
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(182, 20);
            this.txtLoc.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(65, 13);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(182, 20);
            this.txtName.TabIndex = 4;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name:";
            // 
            // lblColumnCount
            // 
            this.lblColumnCount.AutoSize = true;
            this.lblColumnCount.Location = new System.Drawing.Point(6, 16);
            this.lblColumnCount.Name = "lblColumnCount";
            this.lblColumnCount.Size = new System.Drawing.Size(184, 13);
            this.lblColumnCount.TabIndex = 5;
            this.lblColumnCount.Text = "Your columns and their abbreviations:";
            // 
            // listBox1
            // 
            this.listBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(181, 199);
            this.listBox1.TabIndex = 6;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            // 
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.Location = new System.Drawing.Point(282, 296);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(145, 63);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Create Database";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // listBox2
            // 
            this.listBox2.Cursor = System.Windows.Forms.Cursors.No;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(198, 32);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox2.Size = new System.Drawing.Size(53, 199);
            this.listBox2.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblName);
            this.groupBox2.Controls.Add(this.lblLocation);
            this.groupBox2.Controls.Add(this.txtLoc);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Location = new System.Drawing.Point(160, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 67);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Title";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblRowCount);
            this.groupBox3.Controls.Add(this.lblColumnCount);
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Controls.Add(this.listBox2);
            this.groupBox3.Location = new System.Drawing.Point(12, 85);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 274);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Contents";
            // 
            // lblRowCount
            // 
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Location = new System.Drawing.Point(6, 246);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(120, 13);
            this.lblRowCount.TabIndex = 9;
            this.lblRowCount.Text = "Your database will have";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.lblCalories);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btnClearChoices);
            this.groupBox4.Controls.Add(this.lblSearchField);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(282, 85);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(145, 176);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Admin Definitions";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 46);
            this.label4.TabIndex = 7;
            this.label4.Text = "(if calories aren\'t available, pick anything.  You can fix it later in the admin " +
    "center)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCalories
            // 
            this.lblCalories.AutoSize = true;
            this.lblCalories.Location = new System.Drawing.Point(17, 77);
            this.lblCalories.Name = "lblCalories";
            this.lblCalories.Size = new System.Drawing.Size(27, 13);
            this.lblCalories.TabIndex = 6;
            this.lblCalories.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Calorie column:";
            // 
            // btnClearChoices
            // 
            this.btnClearChoices.Location = new System.Drawing.Point(50, 147);
            this.btnClearChoices.Name = "btnClearChoices";
            this.btnClearChoices.Size = new System.Drawing.Size(75, 23);
            this.btnClearChoices.TabIndex = 4;
            this.btnClearChoices.Text = "Clear";
            this.btnClearChoices.UseVisualStyleBackColor = true;
            this.btnClearChoices.Click += new System.EventHandler(this.btnClearChoices_Click);
            // 
            // lblSearchField
            // 
            this.lblSearchField.AutoSize = true;
            this.lblSearchField.Location = new System.Drawing.Point(17, 39);
            this.lblSearchField.Name = "lblSearchField";
            this.lblSearchField.Size = new System.Drawing.Size(27, 13);
            this.lblSearchField.TabIndex = 2;
            this.lblSearchField.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Users will search by:";
            // 
            // frmNewDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 371);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmNewDB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Standalone Database";
            this.Load += new System.EventHandler(this.frmNewDB_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioPersonal;
        private System.Windows.Forms.RadioButton radioShared;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLoc;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblColumnCount;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSearchField;
        private System.Windows.Forms.Button btnClearChoices;
        private System.Windows.Forms.Label lblRowCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCalories;
        private System.Windows.Forms.Label label3;
    }
}