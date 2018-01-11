namespace Nutritracker
{
    partial class frmPairRelDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPairRelDB));
            this.label1 = new System.Windows.Forms.Label();
            this.comboFields = new System.Windows.Forms.ComboBox();
            this.btnBegin = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLstBoxUSDAresults = new System.Windows.Forms.CheckedListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtTweak = new System.Windows.Forms.TextBox();
            this.lblTweak = new System.Windows.Forms.Label();
            this.numUpDownIndex = new System.Windows.Forms.NumericUpDown();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblFieldVal = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose field to pair with USDA:";
            // 
            // comboFields
            // 
            this.comboFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFields.FormattingEnabled = true;
            this.comboFields.Location = new System.Drawing.Point(12, 28);
            this.comboFields.Name = "comboFields";
            this.comboFields.Size = new System.Drawing.Size(192, 24);
            this.comboFields.TabIndex = 1;
            this.comboFields.SelectedIndexChanged += new System.EventHandler(this.comboFields_SelectedIndexChanged);
            // 
            // btnBegin
            // 
            this.btnBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBegin.Location = new System.Drawing.Point(213, 21);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(92, 36);
            this.btnBegin.TabIndex = 2;
            this.btnBegin.Text = "Begin";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkLstBoxUSDAresults);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 203);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Possible Matches (0 of 0)  — none";
            // 
            // chkLstBoxUSDAresults
            // 
            this.chkLstBoxUSDAresults.CheckOnClick = true;
            this.chkLstBoxUSDAresults.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkLstBoxUSDAresults.FormattingEnabled = true;
            this.chkLstBoxUSDAresults.Location = new System.Drawing.Point(6, 21);
            this.chkLstBoxUSDAresults.Name = "chkLstBoxUSDAresults";
            this.chkLstBoxUSDAresults.Size = new System.Drawing.Size(582, 174);
            this.chkLstBoxUSDAresults.TabIndex = 7;
            this.chkLstBoxUSDAresults.TabStop = false;
            this.chkLstBoxUSDAresults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkLstBoxUSDAresults_KeyDown);
            this.chkLstBoxUSDAresults.Leave += new System.EventHandler(this.chkLstBoxUSDAresults_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(467, 272);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(139, 36);
            this.btnClose.TabIndex = 6;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtTweak
            // 
            this.txtTweak.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTweak.Location = new System.Drawing.Point(424, 36);
            this.txtTweak.Name = "txtTweak";
            this.txtTweak.Size = new System.Drawing.Size(142, 22);
            this.txtTweak.TabIndex = 7;
            this.txtTweak.Visible = false;
            this.txtTweak.TextChanged += new System.EventHandler(this.txtTweak_TextChanged);
            this.txtTweak.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTweak_KeyDown);
            // 
            // lblTweak
            // 
            this.lblTweak.AutoSize = true;
            this.lblTweak.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTweak.Location = new System.Drawing.Point(421, 17);
            this.lblTweak.Name = "lblTweak";
            this.lblTweak.Size = new System.Drawing.Size(89, 16);
            this.lblTweak.TabIndex = 8;
            this.lblTweak.Text = "Tweak name:";
            this.lblTweak.Visible = false;
            // 
            // numUpDownIndex
            // 
            this.numUpDownIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUpDownIndex.Location = new System.Drawing.Point(15, 287);
            this.numUpDownIndex.Name = "numUpDownIndex";
            this.numUpDownIndex.Size = new System.Drawing.Size(89, 26);
            this.numUpDownIndex.TabIndex = 9;
            this.numUpDownIndex.Visible = false;
            this.numUpDownIndex.ValueChanged += new System.EventHandler(this.numUpDownIndex_ValueChanged);
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum.Location = new System.Drawing.Point(12, 268);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(82, 16);
            this.lblNum.TabIndex = 10;
            this.lblNum.Text = "Goto entry #:";
            this.lblNum.Visible = false;
            // 
            // lblFieldVal
            // 
            this.lblFieldVal.AutoSize = true;
            this.lblFieldVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFieldVal.Location = new System.Drawing.Point(152, 281);
            this.lblFieldVal.Name = "lblFieldVal";
            this.lblFieldVal.Size = new System.Drawing.Size(122, 24);
            this.lblFieldVal.TabIndex = 11;
            this.lblFieldVal.Text = "Field value: 0";
            this.lblFieldVal.Visible = false;
            // 
            // frmPairRelDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 322);
            this.Controls.Add(this.lblFieldVal);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.numUpDownIndex);
            this.Controls.Add(this.lblTweak);
            this.Controls.Add(this.txtTweak);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.comboFields);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPairRelDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPairRelDB";
            this.Load += new System.EventHandler(this.frmPairRelDB_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboFields;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckedListBox chkLstBoxUSDAresults;
        private System.Windows.Forms.TextBox txtTweak;
        private System.Windows.Forms.Label lblTweak;
        private System.Windows.Forms.NumericUpDown numUpDownIndex;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblFieldVal;
    }
}