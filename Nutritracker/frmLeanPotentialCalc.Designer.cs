namespace NutApp
{
    partial class frmLeanPotentialCalc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLeanPotentialCalc));
            this.lblMBresult = new System.Windows.Forms.Label();
            this.lblEHdesiredBF = new System.Windows.Forms.Label();
            this.numUpDownEH = new System.Windows.Forms.NumericUpDown();
            this.lblEHresult = new System.Windows.Forms.Label();
            this.lblWristin = new System.Windows.Forms.Label();
            this.lblAnklein = new System.Windows.Forms.Label();
            this.txtAnkle = new System.Windows.Forms.TextBox();
            this.txtWrist = new System.Windows.Forms.TextBox();
            this.lblAnkle = new System.Windows.Forms.Label();
            this.lblWrist = new System.Windows.Forms.Label();
            this.lblCBdesiredBF = new System.Windows.Forms.Label();
            this.numUpDownCB = new System.Windows.Forms.NumericUpDown();
            this.lblCBNatLeanLim = new System.Windows.Forms.Label();
            this.lblHt = new System.Windows.Forms.Label();
            this.lblWt = new System.Windows.Forms.Label();
            this.lblBF = new System.Windows.Forms.Label();
            this.lblCBNatLim = new System.Windows.Forms.Label();
            this.lblCBchest = new System.Windows.Forms.Label();
            this.lblCBarm = new System.Windows.Forms.Label();
            this.lblCBforearm = new System.Windows.Forms.Label();
            this.lblCBneck = new System.Windows.Forms.Label();
            this.lblCBthigh = new System.Windows.Forms.Label();
            this.lblCBcalf = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownEH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCB)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMBresult
            // 
            this.lblMBresult.AutoSize = true;
            this.lblMBresult.Location = new System.Drawing.Point(6, 22);
            this.lblMBresult.Name = "lblMBresult";
            this.lblMBresult.Size = new System.Drawing.Size(184, 20);
            this.lblMBresult.TabIndex = 0;
            this.lblMBresult.Text = "Contest shape (5-6%) @";
            // 
            // lblEHdesiredBF
            // 
            this.lblEHdesiredBF.AutoSize = true;
            this.lblEHdesiredBF.Location = new System.Drawing.Point(6, 27);
            this.lblEHdesiredBF.Name = "lblEHdesiredBF";
            this.lblEHdesiredBF.Size = new System.Drawing.Size(104, 20);
            this.lblEHdesiredBF.TabIndex = 3;
            this.lblEHdesiredBF.Text = "Desired bf %:";
            // 
            // numUpDownEH
            // 
            this.numUpDownEH.Location = new System.Drawing.Point(116, 25);
            this.numUpDownEH.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numUpDownEH.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numUpDownEH.Name = "numUpDownEH";
            this.numUpDownEH.Size = new System.Drawing.Size(55, 26);
            this.numUpDownEH.TabIndex = 4;
            this.numUpDownEH.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numUpDownEH.ValueChanged += new System.EventHandler(this.numUpDownEH_ValueChanged);
            this.numUpDownEH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numUpDownEH_KeyPress);
            // 
            // lblEHresult
            // 
            this.lblEHresult.AutoSize = true;
            this.lblEHresult.Location = new System.Drawing.Point(6, 68);
            this.lblEHresult.Name = "lblEHresult";
            this.lblEHresult.Size = new System.Drawing.Size(131, 20);
            this.lblEHresult.TabIndex = 1;
            this.lblEHresult.Text = "Your natural limit:";
            // 
            // lblWristin
            // 
            this.lblWristin.AutoSize = true;
            this.lblWristin.Location = new System.Drawing.Point(116, 28);
            this.lblWristin.Name = "lblWristin";
            this.lblWristin.Size = new System.Drawing.Size(21, 20);
            this.lblWristin.TabIndex = 12;
            this.lblWristin.Text = "in";
            // 
            // lblAnklein
            // 
            this.lblAnklein.AutoSize = true;
            this.lblAnklein.Location = new System.Drawing.Point(116, 60);
            this.lblAnklein.Name = "lblAnklein";
            this.lblAnklein.Size = new System.Drawing.Size(21, 20);
            this.lblAnklein.TabIndex = 11;
            this.lblAnklein.Text = "in";
            // 
            // txtAnkle
            // 
            this.txtAnkle.Location = new System.Drawing.Point(64, 57);
            this.txtAnkle.MaxLength = 6;
            this.txtAnkle.Name = "txtAnkle";
            this.txtAnkle.Size = new System.Drawing.Size(46, 26);
            this.txtAnkle.TabIndex = 6;
            this.txtAnkle.Text = "13";
            this.txtAnkle.TextChanged += new System.EventHandler(this.txtAnkle_TextChanged);
            this.txtAnkle.Enter += new System.EventHandler(this.txtAnkle_Enter);
            this.txtAnkle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAnkle_KeyDown);
            this.txtAnkle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            this.txtAnkle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtAnkle_MouseDown);
            this.txtAnkle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtAnkle_MouseUp);
            // 
            // txtWrist
            // 
            this.txtWrist.Location = new System.Drawing.Point(64, 25);
            this.txtWrist.MaxLength = 6;
            this.txtWrist.Name = "txtWrist";
            this.txtWrist.Size = new System.Drawing.Size(46, 26);
            this.txtWrist.TabIndex = 5;
            this.txtWrist.Text = "8";
            this.txtWrist.TextChanged += new System.EventHandler(this.txtWrist_TextChanged);
            this.txtWrist.Enter += new System.EventHandler(this.txtWrist_Enter);
            this.txtWrist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWrist_KeyDown);
            this.txtWrist.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.txtWrist.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtWrist_MouseDown);
            this.txtWrist.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtWrist_MouseUp);
            // 
            // lblAnkle
            // 
            this.lblAnkle.AutoSize = true;
            this.lblAnkle.Location = new System.Drawing.Point(5, 60);
            this.lblAnkle.Name = "lblAnkle";
            this.lblAnkle.Size = new System.Drawing.Size(53, 20);
            this.lblAnkle.TabIndex = 8;
            this.lblAnkle.Text = "Ankle:";
            // 
            // lblWrist
            // 
            this.lblWrist.AutoSize = true;
            this.lblWrist.Location = new System.Drawing.Point(9, 28);
            this.lblWrist.Name = "lblWrist";
            this.lblWrist.Size = new System.Drawing.Size(49, 20);
            this.lblWrist.TabIndex = 7;
            this.lblWrist.Text = "Wrist:";
            // 
            // lblCBdesiredBF
            // 
            this.lblCBdesiredBF.AutoSize = true;
            this.lblCBdesiredBF.Location = new System.Drawing.Point(5, 86);
            this.lblCBdesiredBF.Name = "lblCBdesiredBF";
            this.lblCBdesiredBF.Size = new System.Drawing.Size(104, 20);
            this.lblCBdesiredBF.TabIndex = 6;
            this.lblCBdesiredBF.Text = "Desired bf %:";
            // 
            // numUpDownCB
            // 
            this.numUpDownCB.Location = new System.Drawing.Point(54, 109);
            this.numUpDownCB.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numUpDownCB.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numUpDownCB.Name = "numUpDownCB";
            this.numUpDownCB.Size = new System.Drawing.Size(55, 26);
            this.numUpDownCB.TabIndex = 7;
            this.numUpDownCB.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numUpDownCB.ValueChanged += new System.EventHandler(this.numUpDownCB_ValueChanged);
            // 
            // lblCBNatLeanLim
            // 
            this.lblCBNatLeanLim.AutoSize = true;
            this.lblCBNatLeanLim.Location = new System.Drawing.Point(9, 197);
            this.lblCBNatLeanLim.Name = "lblCBNatLeanLim";
            this.lblCBNatLeanLim.Size = new System.Drawing.Size(123, 20);
            this.lblCBNatLeanLim.TabIndex = 4;
            this.lblCBNatLeanLim.Text = "Your lean mass:";
            // 
            // lblHt
            // 
            this.lblHt.AutoSize = true;
            this.lblHt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHt.Location = new System.Drawing.Point(12, 9);
            this.lblHt.Name = "lblHt";
            this.lblHt.Size = new System.Drawing.Size(60, 20);
            this.lblHt.TabIndex = 1;
            this.lblHt.Text = "Height:";
            // 
            // lblWt
            // 
            this.lblWt.AutoSize = true;
            this.lblWt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWt.Location = new System.Drawing.Point(12, 31);
            this.lblWt.Name = "lblWt";
            this.lblWt.Size = new System.Drawing.Size(63, 20);
            this.lblWt.TabIndex = 2;
            this.lblWt.Text = "Weight:";
            // 
            // lblBF
            // 
            this.lblBF.AutoSize = true;
            this.lblBF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBF.Location = new System.Drawing.Point(162, 31);
            this.lblBF.Name = "lblBF";
            this.lblBF.Size = new System.Drawing.Size(68, 20);
            this.lblBF.TabIndex = 3;
            this.lblBF.Text = "Bodyfat:";
            // 
            // lblCBNatLim
            // 
            this.lblCBNatLim.AutoSize = true;
            this.lblCBNatLim.Location = new System.Drawing.Point(9, 177);
            this.lblCBNatLim.Name = "lblCBNatLim";
            this.lblCBNatLim.Size = new System.Drawing.Size(129, 20);
            this.lblCBNatLim.TabIndex = 13;
            this.lblCBNatLim.Text = "Your bulked limit:";
            // 
            // lblCBchest
            // 
            this.lblCBchest.AutoSize = true;
            this.lblCBchest.Location = new System.Drawing.Point(177, 41);
            this.lblCBchest.Name = "lblCBchest";
            this.lblCBchest.Size = new System.Drawing.Size(55, 20);
            this.lblCBchest.TabIndex = 14;
            this.lblCBchest.Text = "Chest:";
            // 
            // lblCBarm
            // 
            this.lblCBarm.AutoSize = true;
            this.lblCBarm.Location = new System.Drawing.Point(177, 61);
            this.lblCBarm.Name = "lblCBarm";
            this.lblCBarm.Size = new System.Drawing.Size(88, 20);
            this.lblCBarm.TabIndex = 15;
            this.lblCBarm.Text = "Upper arm:";
            // 
            // lblCBforearm
            // 
            this.lblCBforearm.AutoSize = true;
            this.lblCBforearm.Location = new System.Drawing.Point(177, 81);
            this.lblCBforearm.Name = "lblCBforearm";
            this.lblCBforearm.Size = new System.Drawing.Size(73, 20);
            this.lblCBforearm.TabIndex = 16;
            this.lblCBforearm.Text = "Forearm:";
            // 
            // lblCBneck
            // 
            this.lblCBneck.AutoSize = true;
            this.lblCBneck.Location = new System.Drawing.Point(177, 101);
            this.lblCBneck.Name = "lblCBneck";
            this.lblCBneck.Size = new System.Drawing.Size(49, 20);
            this.lblCBneck.TabIndex = 17;
            this.lblCBneck.Text = "Neck:";
            // 
            // lblCBthigh
            // 
            this.lblCBthigh.AutoSize = true;
            this.lblCBthigh.Location = new System.Drawing.Point(177, 121);
            this.lblCBthigh.Name = "lblCBthigh";
            this.lblCBthigh.Size = new System.Drawing.Size(52, 20);
            this.lblCBthigh.TabIndex = 18;
            this.lblCBthigh.Text = "Thigh:";
            // 
            // lblCBcalf
            // 
            this.lblCBcalf.AutoSize = true;
            this.lblCBcalf.Location = new System.Drawing.Point(177, 141);
            this.lblCBcalf.Name = "lblCBcalf";
            this.lblCBcalf.Size = new System.Drawing.Size(41, 20);
            this.lblCBcalf.TabIndex = 19;
            this.lblCBcalf.Text = "Calf:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMBresult);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 54);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Martin Berkhan";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblEHresult);
            this.groupBox2.Controls.Add(this.lblEHdesiredBF);
            this.groupBox2.Controls.Add(this.numUpDownEH);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 91);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Eric Helms";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblCBcalf);
            this.groupBox3.Controls.Add(this.txtWrist);
            this.groupBox3.Controls.Add(this.lblCBthigh);
            this.groupBox3.Controls.Add(this.lblCBNatLeanLim);
            this.groupBox3.Controls.Add(this.lblCBneck);
            this.groupBox3.Controls.Add(this.numUpDownCB);
            this.groupBox3.Controls.Add(this.lblCBforearm);
            this.groupBox3.Controls.Add(this.lblCBdesiredBF);
            this.groupBox3.Controls.Add(this.lblCBarm);
            this.groupBox3.Controls.Add(this.lblWrist);
            this.groupBox3.Controls.Add(this.lblCBchest);
            this.groupBox3.Controls.Add(this.lblAnkle);
            this.groupBox3.Controls.Add(this.lblCBNatLim);
            this.groupBox3.Controls.Add(this.txtAnkle);
            this.groupBox3.Controls.Add(this.lblWristin);
            this.groupBox3.Controls.Add(this.lblAnklein);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 244);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 223);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Casey Butt";
            // 
            // frmLeanPotentialCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 477);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblBF);
            this.Controls.Add(this.lblWt);
            this.Controls.Add(this.lblHt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLeanPotentialCalc";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lean Mass Limits for Young Men";
            this.Load += new System.EventHandler(this.frmLeanPotentialCalc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownEH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCB)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMBresult;
        private System.Windows.Forms.Label lblHt;
        private System.Windows.Forms.Label lblWt;
        private System.Windows.Forms.Label lblBF;
        private System.Windows.Forms.Label lblEHresult;
        private System.Windows.Forms.Label lblEHdesiredBF;
        private System.Windows.Forms.NumericUpDown numUpDownEH;
        private System.Windows.Forms.Label lblWristin;
        private System.Windows.Forms.Label lblAnklein;
        private System.Windows.Forms.TextBox txtAnkle;
        private System.Windows.Forms.TextBox txtWrist;
        private System.Windows.Forms.Label lblAnkle;
        private System.Windows.Forms.Label lblWrist;
        private System.Windows.Forms.Label lblCBdesiredBF;
        private System.Windows.Forms.NumericUpDown numUpDownCB;
        private System.Windows.Forms.Label lblCBNatLeanLim;
        private System.Windows.Forms.Label lblCBNatLim;
        private System.Windows.Forms.Label lblCBcalf;
        private System.Windows.Forms.Label lblCBthigh;
        private System.Windows.Forms.Label lblCBneck;
        private System.Windows.Forms.Label lblCBforearm;
        private System.Windows.Forms.Label lblCBarm;
        private System.Windows.Forms.Label lblCBchest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}