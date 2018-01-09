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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.trackGeo = new System.Windows.Forms.TrackBar();
            this.trackArith = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTweak = new System.Windows.Forms.TextBox();
            this.lstBoxIngrieds = new System.Windows.Forms.ListBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackGeo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackArith)).BeginInit();
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(343, 165);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstBoxIngrieds);
            this.groupBox1.Controls.Add(this.txtTweak);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(361, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 233);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View Detail For";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Location = new System.Drawing.Point(12, 251);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(573, 219);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(510, 476);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(429, 476);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "USDA NDB#: <click to choose>";
            // 
            // trackGeo
            // 
            this.trackGeo.Location = new System.Drawing.Point(46, 200);
            this.trackGeo.Name = "trackGeo";
            this.trackGeo.Size = new System.Drawing.Size(128, 45);
            this.trackGeo.TabIndex = 8;
            this.trackGeo.TabStop = false;
            this.trackGeo.Value = 4;
            this.trackGeo.Scroll += new System.EventHandler(this.trackGeo_Scroll);
            // 
            // trackArith
            // 
            this.trackArith.Location = new System.Drawing.Point(180, 200);
            this.trackArith.Name = "trackArith";
            this.trackArith.Size = new System.Drawing.Size(128, 45);
            this.trackArith.TabIndex = 9;
            this.trackArith.TabStop = false;
            this.trackArith.Tag = "";
            this.trackArith.Value = 5;
            this.trackArith.Scroll += new System.EventHandler(this.trackArith_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tweak name:";
            // 
            // txtTweak
            // 
            this.txtTweak.Location = new System.Drawing.Point(6, 176);
            this.txtTweak.Name = "txtTweak";
            this.txtTweak.Size = new System.Drawing.Size(195, 20);
            this.txtTweak.TabIndex = 13;
            this.txtTweak.TextChanged += new System.EventHandler(this.txtTweak_TextChanged);
            // 
            // lstBoxIngrieds
            // 
            this.lstBoxIngrieds.FormattingEnabled = true;
            this.lstBoxIngrieds.Location = new System.Drawing.Point(6, 19);
            this.lstBoxIngrieds.Name = "lstBoxIngrieds";
            this.lstBoxIngrieds.Size = new System.Drawing.Size(212, 134);
            this.lstBoxIngrieds.TabIndex = 12;
            this.lstBoxIngrieds.SelectedIndexChanged += new System.EventHandler(this.lstBoxIngrieds_SelectedIndexChanged);
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
            // frmDecomposeRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 506);
            this.Controls.Add(this.trackArith);
            this.Controls.Add(this.trackGeo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.trackArith)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackGeo;
        private System.Windows.Forms.TrackBar trackArith;
        private System.Windows.Forms.TextBox txtTweak;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstBoxIngrieds;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}