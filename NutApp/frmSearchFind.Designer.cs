namespace NutApp
{
    partial class frmSearchFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchFind));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioDown = new System.Windows.Forms.RadioButton();
            this.radioUp = new System.Windows.Forms.RadioButton();
            this.checkboxCase = new System.Windows.Forms.CheckBox();
            this.checkboxHighlightAll = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find what:";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(75, 10);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(163, 20);
            this.txtFind.TabIndex = 1;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
            // 
            // btnFind
            // 
            this.btnFind.Enabled = false;
            this.btnFind.Location = new System.Drawing.Point(244, 10);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(71, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find Next";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(244, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioDown);
            this.groupBox1.Controls.Add(this.radioUp);
            this.groupBox1.Location = new System.Drawing.Point(125, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 39);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Direction";
            // 
            // radioDown
            // 
            this.radioDown.AutoSize = true;
            this.radioDown.Checked = true;
            this.radioDown.Location = new System.Drawing.Point(52, 19);
            this.radioDown.Name = "radioDown";
            this.radioDown.Size = new System.Drawing.Size(53, 17);
            this.radioDown.TabIndex = 1;
            this.radioDown.TabStop = true;
            this.radioDown.Text = "Down";
            this.radioDown.UseVisualStyleBackColor = true;
            // 
            // radioUp
            // 
            this.radioUp.AutoSize = true;
            this.radioUp.Location = new System.Drawing.Point(7, 19);
            this.radioUp.Name = "radioUp";
            this.radioUp.Size = new System.Drawing.Size(39, 17);
            this.radioUp.TabIndex = 0;
            this.radioUp.TabStop = true;
            this.radioUp.Text = "Up";
            this.radioUp.UseVisualStyleBackColor = true;
            // 
            // checkboxCase
            // 
            this.checkboxCase.AutoSize = true;
            this.checkboxCase.Location = new System.Drawing.Point(12, 70);
            this.checkboxCase.Name = "checkboxCase";
            this.checkboxCase.Size = new System.Drawing.Size(82, 17);
            this.checkboxCase.TabIndex = 5;
            this.checkboxCase.TabStop = false;
            this.checkboxCase.Text = "Match case";
            this.checkboxCase.UseVisualStyleBackColor = true;
            // 
            // checkboxHighlightAll
            // 
            this.checkboxHighlightAll.AutoSize = true;
            this.checkboxHighlightAll.Enabled = false;
            this.checkboxHighlightAll.Location = new System.Drawing.Point(12, 47);
            this.checkboxHighlightAll.Name = "checkboxHighlightAll";
            this.checkboxHighlightAll.Size = new System.Drawing.Size(81, 17);
            this.checkboxHighlightAll.TabIndex = 6;
            this.checkboxHighlightAll.TabStop = false;
            this.checkboxHighlightAll.Text = "Highlight All";
            this.checkboxHighlightAll.UseVisualStyleBackColor = true;
            this.checkboxHighlightAll.CheckedChanged += new System.EventHandler(this.checkboxHighlightAll_CheckedChanged);
            // 
            // frmSearchFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 99);
            this.Controls.Add(this.checkboxHighlightAll);
            this.Controls.Add(this.checkboxCase);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSearchFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchFind_FormClosing);
            this.Load += new System.EventHandler(this.frmSearchFind_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioDown;
        private System.Windows.Forms.RadioButton radioUp;
        private System.Windows.Forms.CheckBox checkboxCase;
        private System.Windows.Forms.CheckBox checkboxHighlightAll;
    }
}