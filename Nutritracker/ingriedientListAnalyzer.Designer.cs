namespace Nutritracker
{
    partial class frmDecomposeRecipe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDecomposeRecipe));
            this.label1 = new System.Windows.Forms.Label();
            this.txtIngrieds = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTweakWeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstBoxIngrieds = new System.Windows.Forms.ListBox();
            this.txtTweakName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNDBNo = new System.Windows.Forms.Label();
            this.lstViewDBresults = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.trackGeo = new System.Windows.Forms.TrackBar();
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackGeo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingredients ARE separated by newline (pressing Enter):";
            // 
            // txtIngrieds
            // 
            this.txtIngrieds.Location = new System.Drawing.Point(12, 25);
            this.txtIngrieds.Multiline = true;
            this.txtIngrieds.Name = "txtIngrieds";
            this.txtIngrieds.Size = new System.Drawing.Size(343, 165);
            this.txtIngrieds.TabIndex = 1;
            this.txtIngrieds.TextChanged += new System.EventHandler(this.txtIngrieds_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTweakWeight);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lstBoxIngrieds);
            this.groupBox1.Controls.Add(this.txtTweakName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblNDBNo);
            this.groupBox1.Location = new System.Drawing.Point(361, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 233);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View Detail For";
            // 
            // txtTweakWeight
            // 
            this.txtTweakWeight.Location = new System.Drawing.Point(9, 210);
            this.txtTweakWeight.Name = "txtTweakWeight";
            this.txtTweakWeight.Size = new System.Drawing.Size(72, 20);
            this.txtTweakWeight.TabIndex = 15;
            this.txtTweakWeight.TextChanged += new System.EventHandler(this.txtTweakWeight_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tweak weight:";
            // 
            // lstBoxIngrieds
            // 
            this.lstBoxIngrieds.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstBoxIngrieds.FormattingEnabled = true;
            this.lstBoxIngrieds.Location = new System.Drawing.Point(6, 19);
            this.lstBoxIngrieds.Name = "lstBoxIngrieds";
            this.lstBoxIngrieds.Size = new System.Drawing.Size(212, 108);
            this.lstBoxIngrieds.TabIndex = 12;
            this.lstBoxIngrieds.SelectedIndexChanged += new System.EventHandler(this.lstBoxIngrieds_SelectedIndexChanged);
            this.lstBoxIngrieds.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstBoxIngrieds_MouseUp);
            // 
            // txtTweakName
            // 
            this.txtTweakName.Location = new System.Drawing.Point(9, 171);
            this.txtTweakName.Name = "txtTweakName";
            this.txtTweakName.Size = new System.Drawing.Size(195, 20);
            this.txtTweakName.TabIndex = 13;
            this.txtTweakName.TextChanged += new System.EventHandler(this.txtTweakName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tweak name:";
            // 
            // lblNDBNo
            // 
            this.lblNDBNo.AutoSize = true;
            this.lblNDBNo.Location = new System.Drawing.Point(9, 130);
            this.lblNDBNo.Name = "lblNDBNo";
            this.lblNDBNo.Size = new System.Drawing.Size(155, 13);
            this.lblNDBNo.TabIndex = 8;
            this.lblNDBNo.Text = "USDA NDB#: <none selected>";
            // 
            // lstViewDBresults
            // 
            this.lstViewDBresults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstViewDBresults.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstViewDBresults.Location = new System.Drawing.Point(12, 251);
            this.lstViewDBresults.Name = "lstViewDBresults";
            this.lstViewDBresults.Size = new System.Drawing.Size(573, 219);
            this.lstViewDBresults.TabIndex = 5;
            this.lstViewDBresults.UseCompatibleStateImageBehavior = false;
            this.lstViewDBresults.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "NDBNo";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "FoodName";
            this.columnHeader2.Width = 360;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Cals";
            this.columnHeader3.Width = 80;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(495, 478);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(399, 478);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // trackGeo
            // 
            this.trackGeo.AutoSize = false;
            this.trackGeo.Location = new System.Drawing.Point(51, 210);
            this.trackGeo.Name = "trackGeo";
            this.trackGeo.Size = new System.Drawing.Size(292, 35);
            this.trackGeo.TabIndex = 8;
            this.trackGeo.TabStop = false;
            this.trackGeo.Value = 4;
            this.trackGeo.Scroll += new System.EventHandler(this.trackGeo_Scroll);
            // 
            // txtRecipeName
            // 
            this.txtRecipeName.Location = new System.Drawing.Point(12, 489);
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.Size = new System.Drawing.Size(195, 20);
            this.txtRecipeName.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 473);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Name of recipe:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Ratio between ingredients:";
            // 
            // frmDecomposeRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 520);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRecipeName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trackGeo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstViewDBresults);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtIngrieds);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDecomposeRecipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingriedient List Analysis Tool";
            this.Load += new System.EventHandler(this.frmDecomposeRecipe_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackGeo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIngrieds;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstViewDBresults;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblNDBNo;
        private System.Windows.Forms.TrackBar trackGeo;
        private System.Windows.Forms.TextBox txtTweakName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstBoxIngrieds;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox txtTweakWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRecipeName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}