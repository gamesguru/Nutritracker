namespace Nutritracker
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtConfig = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lstBoxNutes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.radioPersonal.Location = new System.Drawing.Point(6, 42);
            this.radioPersonal.Name = "radioPersonal";
            this.radioPersonal.Size = new System.Drawing.Size(126, 17);
            this.radioPersonal.TabIndex = 1;
            this.radioPersonal.Text = "Personal (your profile)";
            this.radioPersonal.UseVisualStyleBackColor = true;
            // 
            // radioShared
            // 
            this.radioShared.AutoSize = true;
            this.radioShared.Checked = true;
            this.radioShared.Location = new System.Drawing.Point(6, 19);
            this.radioShared.Name = "radioShared";
            this.radioShared.Size = new System.Drawing.Size(86, 17);
            this.radioShared.TabIndex = 0;
            this.radioShared.TabStop = true;
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
            this.txtLoc.Location = new System.Drawing.Point(65, 39);
            this.txtLoc.MaxLength = 100;
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.ReadOnly = true;
            this.txtLoc.Size = new System.Drawing.Size(182, 20);
            this.txtLoc.TabIndex = 2;
            this.txtLoc.TabStop = false;
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
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.Location = new System.Drawing.Point(12, 396);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(405, 63);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Create Database";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblName);
            this.groupBox2.Controls.Add(this.lblLocation);
            this.groupBox2.Controls.Add(this.txtLoc);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Location = new System.Drawing.Point(162, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 67);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Title";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.lstBoxNutes);
            this.groupBox4.Controls.Add(this.txtConfig);
            this.groupBox4.Location = new System.Drawing.Point(12, 85);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(405, 274);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Configurator";
            // 
            // txtConfig
            // 
            this.txtConfig.Location = new System.Drawing.Point(9, 19);
            this.txtConfig.Multiline = true;
            this.txtConfig.Name = "txtConfig";
            this.txtConfig.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConfig.Size = new System.Drawing.Size(295, 240);
            this.txtConfig.Font = new System.Drawing.Font("Courier New", 12);
            this.txtConfig.TabIndex = 12;
            this.txtConfig.TextChanged += new System.EventHandler(this.txtConfig_TextChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(9, 368);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "lblStatus";
            // 
            // lstBoxNutes
            // 
            this.lstBoxNutes.FormattingEnabled = true;
            this.lstBoxNutes.Location = new System.Drawing.Point(310, 45);
            this.lstBoxNutes.Name = "lstBoxNutes";
            this.lstBoxNutes.Size = new System.Drawing.Size(87, 212);
            this.lstBoxNutes.TabIndex = 13;
            this.lstBoxNutes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstBoxNutes_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Available:";
            // 
            // frmNewDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 471);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioPersonal;
        private System.Windows.Forms.RadioButton radioShared;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLoc;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtConfig;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstBoxNutes;
    }
}