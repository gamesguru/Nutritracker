namespace Nutritracker
{
    partial class frmDetailReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetailReport));
            this.lblChooseDays = new System.Windows.Forms.Label();
            this.chkLstBoxDays = new System.Windows.Forms.CheckedListBox();
            this.btnRunReport = new System.Windows.Forms.Button();
            this.lblOut = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblChooseDays
            // 
            this.lblChooseDays.AutoSize = true;
            this.lblChooseDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseDays.Location = new System.Drawing.Point(13, 13);
            this.lblChooseDays.Name = "lblChooseDays";
            this.lblChooseDays.Size = new System.Drawing.Size(236, 20);
            this.lblChooseDays.TabIndex = 0;
            this.lblChooseDays.Text = "Please choose days to evaluate:";
            // 
            // chkLstBoxDays
            // 
            this.chkLstBoxDays.CheckOnClick = true;
            this.chkLstBoxDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLstBoxDays.FormattingEnabled = true;
            this.chkLstBoxDays.Location = new System.Drawing.Point(12, 36);
            this.chkLstBoxDays.MultiColumn = true;
            this.chkLstBoxDays.Name = "chkLstBoxDays";
            this.chkLstBoxDays.Size = new System.Drawing.Size(237, 277);
            this.chkLstBoxDays.TabIndex = 1;
            this.chkLstBoxDays.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstBoxDays_ItemCheck);
            // 
            // btnRunReport
            // 
            this.btnRunReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunReport.Location = new System.Drawing.Point(12, 363);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.Size = new System.Drawing.Size(241, 57);
            this.btnRunReport.TabIndex = 2;
            this.btnRunReport.Text = "Run Report";
            this.btnRunReport.UseVisualStyleBackColor = true;
            this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);
            // 
            // lblOut
            // 
            this.lblOut.AutoSize = true;
            this.lblOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOut.Location = new System.Drawing.Point(12, 328);
            this.lblOut.Name = "lblOut";
            this.lblOut.Size = new System.Drawing.Size(67, 20);
            this.lblOut.TabIndex = 3;
            this.lblOut.Text = "Save to:";
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(85, 325);
            this.txtOutput.MaxLength = 100;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(150, 26);
            this.txtOutput.TabIndex = 4;
            // 
            // frmDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 432);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.lblOut);
            this.Controls.Add(this.btnRunReport);
            this.Controls.Add(this.chkLstBoxDays);
            this.Controls.Add(this.lblChooseDays);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmDetailReport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Run Detail Report";
            this.Load += new System.EventHandler(this.frmDetailReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChooseDays;
        private System.Windows.Forms.CheckedListBox chkLstBoxDays;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.Label lblOut;
        private System.Windows.Forms.TextBox txtOutput;
    }
}