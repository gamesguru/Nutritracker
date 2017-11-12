namespace NutApp
{
    partial class frmProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfile));
            this.lblCreateNew = new System.Windows.Forms.Label();
            this.txtNewProfName = new System.Windows.Forms.TextBox();
            this.lblEditExisting = new System.Windows.Forms.Label();
            this.comboExistingProfs = new System.Windows.Forms.ComboBox();
            this.radioMale = new System.Windows.Forms.RadioButton();
            this.radioFemale = new System.Windows.Forms.RadioButton();
            this.lblWt = new System.Windows.Forms.Label();
            this.lblHt = new System.Windows.Forms.Label();
            this.txtWt = new System.Windows.Forms.TextBox();
            this.txtHt = new System.Windows.Forms.TextBox();
            this.lblLbs = new System.Windows.Forms.Label();
            this.lblinches = new System.Windows.Forms.Label();
            this.lblActLvl = new System.Windows.Forms.Label();
            this.lblGoal = new System.Windows.Forms.Label();
            this.comboActivity = new System.Windows.Forms.ComboBox();
            this.comboGoal = new System.Windows.Forms.ComboBox();
            this.checkDefaultProf = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.txtBodyfat = new System.Windows.Forms.TextBox();
            this.lblBodyfat = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCreateNew
            // 
            this.lblCreateNew.AutoSize = true;
            this.lblCreateNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateNew.Location = new System.Drawing.Point(12, 15);
            this.lblCreateNew.Name = "lblCreateNew";
            this.lblCreateNew.Size = new System.Drawing.Size(141, 20);
            this.lblCreateNew.TabIndex = 0;
            this.lblCreateNew.Text = "Create new profile:";
            // 
            // txtNewProfName
            // 
            this.txtNewProfName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewProfName.Location = new System.Drawing.Point(159, 12);
            this.txtNewProfName.MaxLength = 15;
            this.txtNewProfName.Name = "txtNewProfName";
            this.txtNewProfName.Size = new System.Drawing.Size(129, 26);
            this.txtNewProfName.TabIndex = 1;
            this.txtNewProfName.TextChanged += new System.EventHandler(this.txtNewProfName_TextChanged);
            this.txtNewProfName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewProfName_KeyPress);
            // 
            // lblEditExisting
            // 
            this.lblEditExisting.AutoSize = true;
            this.lblEditExisting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditExisting.Location = new System.Drawing.Point(370, 9);
            this.lblEditExisting.Name = "lblEditExisting";
            this.lblEditExisting.Size = new System.Drawing.Size(98, 20);
            this.lblEditExisting.TabIndex = 2;
            this.lblEditExisting.Text = "Edit existing:";
            // 
            // comboExistingProfs
            // 
            this.comboExistingProfs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboExistingProfs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboExistingProfs.FormattingEnabled = true;
            this.comboExistingProfs.Location = new System.Drawing.Point(374, 32);
            this.comboExistingProfs.Name = "comboExistingProfs";
            this.comboExistingProfs.Size = new System.Drawing.Size(121, 28);
            this.comboExistingProfs.TabIndex = 10;
            this.comboExistingProfs.SelectedIndexChanged += new System.EventHandler(this.comboExistingProfs_SelectedIndexChanged);
            // 
            // radioMale
            // 
            this.radioMale.AutoSize = true;
            this.radioMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioMale.Location = new System.Drawing.Point(16, 61);
            this.radioMale.Name = "radioMale";
            this.radioMale.Size = new System.Drawing.Size(61, 24);
            this.radioMale.TabIndex = 5;
            this.radioMale.Text = "Male";
            this.radioMale.UseVisualStyleBackColor = true;
            this.radioMale.CheckedChanged += new System.EventHandler(this.radioMale_CheckedChanged);
            // 
            // radioFemale
            // 
            this.radioFemale.AutoSize = true;
            this.radioFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioFemale.Location = new System.Drawing.Point(16, 91);
            this.radioFemale.Name = "radioFemale";
            this.radioFemale.Size = new System.Drawing.Size(80, 24);
            this.radioFemale.TabIndex = 6;
            this.radioFemale.Text = "Female";
            this.radioFemale.UseVisualStyleBackColor = true;
            this.radioFemale.CheckedChanged += new System.EventHandler(this.radioFemale_CheckedChanged);
            // 
            // lblWt
            // 
            this.lblWt.AutoSize = true;
            this.lblWt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWt.Location = new System.Drawing.Point(162, 94);
            this.lblWt.Name = "lblWt";
            this.lblWt.Size = new System.Drawing.Size(63, 20);
            this.lblWt.TabIndex = 6;
            this.lblWt.Text = "Weight:";
            // 
            // lblHt
            // 
            this.lblHt.AutoSize = true;
            this.lblHt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHt.Location = new System.Drawing.Point(165, 62);
            this.lblHt.Name = "lblHt";
            this.lblHt.Size = new System.Drawing.Size(60, 20);
            this.lblHt.TabIndex = 7;
            this.lblHt.Text = "Height:";
            // 
            // txtWt
            // 
            this.txtWt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWt.Location = new System.Drawing.Point(231, 91);
            this.txtWt.MaxLength = 4;
            this.txtWt.Name = "txtWt";
            this.txtWt.Size = new System.Drawing.Size(54, 26);
            this.txtWt.TabIndex = 3;
            this.txtWt.TextChanged += new System.EventHandler(this.txtWt_TextChanged);
            this.txtWt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWt_KeyPress);
            // 
            // txtHt
            // 
            this.txtHt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHt.Location = new System.Drawing.Point(231, 59);
            this.txtHt.MaxLength = 3;
            this.txtHt.Name = "txtHt";
            this.txtHt.Size = new System.Drawing.Size(54, 26);
            this.txtHt.TabIndex = 2;
            this.txtHt.TextChanged += new System.EventHandler(this.txtHt_TextChanged);
            this.txtHt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHt_KeyPress);
            // 
            // lblLbs
            // 
            this.lblLbs.AutoSize = true;
            this.lblLbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLbs.Location = new System.Drawing.Point(291, 94);
            this.lblLbs.Name = "lblLbs";
            this.lblLbs.Size = new System.Drawing.Size(29, 20);
            this.lblLbs.TabIndex = 10;
            this.lblLbs.Text = "lbs";
            // 
            // lblinches
            // 
            this.lblinches.AutoSize = true;
            this.lblinches.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinches.Location = new System.Drawing.Point(291, 62);
            this.lblinches.Name = "lblinches";
            this.lblinches.Size = new System.Drawing.Size(55, 20);
            this.lblinches.TabIndex = 11;
            this.lblinches.Text = "inches";
            // 
            // lblActLvl
            // 
            this.lblActLvl.AutoSize = true;
            this.lblActLvl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActLvl.Location = new System.Drawing.Point(5, 168);
            this.lblActLvl.Name = "lblActLvl";
            this.lblActLvl.Size = new System.Drawing.Size(147, 20);
            this.lblActLvl.TabIndex = 12;
            this.lblActLvl.Text = "Overall activity level:";
            // 
            // lblGoal
            // 
            this.lblGoal.AutoSize = true;
            this.lblGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoal.Location = new System.Drawing.Point(160, 168);
            this.lblGoal.Name = "lblGoal";
            this.lblGoal.Size = new System.Drawing.Size(147, 20);
            this.lblGoal.TabIndex = 13;
            this.lblGoal.Text = "Fitness/health goal:";
            // 
            // comboActivity
            // 
            this.comboActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboActivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboActivity.FormattingEnabled = true;
            this.comboActivity.Items.AddRange(new object[] {
            "Sedentary",
            "Moderate",
            "Active",
            "Intense",
            "Extreme"});
            this.comboActivity.Location = new System.Drawing.Point(9, 191);
            this.comboActivity.Name = "comboActivity";
            this.comboActivity.Size = new System.Drawing.Size(137, 28);
            this.comboActivity.TabIndex = 7;
            this.comboActivity.SelectedIndexChanged += new System.EventHandler(this.comboActivity_SelectedIndexChanged);
            // 
            // comboGoal
            // 
            this.comboGoal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboGoal.FormattingEnabled = true;
            this.comboGoal.Items.AddRange(new object[] {
            "Weight Loss",
            "Muscle Gain",
            "Physique Transformation",
            "Maintenance"});
            this.comboGoal.Location = new System.Drawing.Point(164, 191);
            this.comboGoal.Name = "comboGoal";
            this.comboGoal.Size = new System.Drawing.Size(190, 28);
            this.comboGoal.TabIndex = 8;
            this.comboGoal.SelectedIndexChanged += new System.EventHandler(this.comboGoal_SelectedIndexChanged);
            // 
            // checkDefaultProf
            // 
            this.checkDefaultProf.AutoSize = true;
            this.checkDefaultProf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDefaultProf.Location = new System.Drawing.Point(359, 126);
            this.checkDefaultProf.Name = "checkDefaultProf";
            this.checkDefaultProf.Size = new System.Drawing.Size(167, 24);
            this.checkDefaultProf.TabIndex = 16;
            this.checkDefaultProf.TabStop = false;
            this.checkDefaultProf.Text = "Make default profile";
            this.checkDefaultProf.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(391, 168);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 51);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save Changes and Load";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.Location = new System.Drawing.Point(183, 126);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(42, 20);
            this.lblAge.TabIndex = 17;
            this.lblAge.Text = "Age:";
            // 
            // txtAge
            // 
            this.txtAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(231, 123);
            this.txtAge.MaxLength = 3;
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(54, 26);
            this.txtAge.TabIndex = 4;
            this.txtAge.TextChanged += new System.EventHandler(this.txtAge_TextChanged);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(415, 66);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(80, 37);
            this.btnDel.TabIndex = 19;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // txtBodyfat
            // 
            this.txtBodyfat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBodyfat.Location = new System.Drawing.Point(79, 127);
            this.txtBodyfat.MaxLength = 3;
            this.txtBodyfat.Name = "txtBodyfat";
            this.txtBodyfat.Size = new System.Drawing.Size(54, 26);
            this.txtBodyfat.TabIndex = 20;
            // 
            // lblBodyfat
            // 
            this.lblBodyfat.AutoSize = true;
            this.lblBodyfat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBodyfat.Location = new System.Drawing.Point(12, 130);
            this.lblBodyfat.Name = "lblBodyfat";
            this.lblBodyfat.Size = new System.Drawing.Size(68, 20);
            this.lblBodyfat.TabIndex = 21;
            this.lblBodyfat.Text = "Bodyfat:";
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.Location = new System.Drawing.Point(134, 131);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(23, 20);
            this.lblPercent.TabIndex = 22;
            this.lblPercent.Text = "%";
            // 
            // frmProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 235);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.txtBodyfat);
            this.Controls.Add(this.lblBodyfat);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.checkDefaultProf);
            this.Controls.Add(this.comboGoal);
            this.Controls.Add(this.comboActivity);
            this.Controls.Add(this.lblGoal);
            this.Controls.Add(this.lblActLvl);
            this.Controls.Add(this.lblinches);
            this.Controls.Add(this.lblLbs);
            this.Controls.Add(this.txtHt);
            this.Controls.Add(this.txtWt);
            this.Controls.Add(this.lblHt);
            this.Controls.Add(this.lblWt);
            this.Controls.Add(this.radioFemale);
            this.Controls.Add(this.radioMale);
            this.Controls.Add(this.comboExistingProfs);
            this.Controls.Add(this.lblEditExisting);
            this.Controls.Add(this.txtNewProfName);
            this.Controls.Add(this.lblCreateNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profile Editor";
            this.Load += new System.EventHandler(this.frmProfile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCreateNew;
        private System.Windows.Forms.TextBox txtNewProfName;
        private System.Windows.Forms.Label lblEditExisting;
        private System.Windows.Forms.ComboBox comboExistingProfs;
        private System.Windows.Forms.RadioButton radioMale;
        private System.Windows.Forms.RadioButton radioFemale;
        private System.Windows.Forms.Label lblWt;
        private System.Windows.Forms.Label lblHt;
        private System.Windows.Forms.TextBox txtWt;
        private System.Windows.Forms.TextBox txtHt;
        private System.Windows.Forms.Label lblLbs;
        private System.Windows.Forms.Label lblinches;
        private System.Windows.Forms.Label lblActLvl;
        private System.Windows.Forms.Label lblGoal;
        private System.Windows.Forms.ComboBox comboActivity;
        private System.Windows.Forms.ComboBox comboGoal;
        private System.Windows.Forms.CheckBox checkDefaultProf;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TextBox txtBodyfat;
        private System.Windows.Forms.Label lblBodyfat;
        private System.Windows.Forms.Label lblPercent;
    }
}