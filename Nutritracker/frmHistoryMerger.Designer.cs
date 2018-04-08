namespace Nutritracker
{
    partial class frmHistoryMerger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistoryMerger));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboMeal = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddBatch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrimKeyToAdd = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkLstBoxDays = new System.Windows.Forms.CheckedListBox();
            this.chkLstBoxDBs = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.chkPrimKey = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkFoodName = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btnAction = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Internal";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboMeal);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.btnAddBatch);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtPrimKeyToAdd);
            this.groupBox5.Location = new System.Drawing.Point(6, 98);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(414, 57);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Add to Batch";
            // 
            // comboMeal
            // 
            this.comboMeal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMeal.FormattingEnabled = true;
            this.comboMeal.Items.AddRange(new object[] {
            "Breakfast",
            "Lunch",
            "Dinner"});
            this.comboMeal.Location = new System.Drawing.Point(297, 21);
            this.comboMeal.Name = "comboMeal";
            this.comboMeal.Size = new System.Drawing.Size(95, 24);
            this.comboMeal.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Meal:";
            // 
            // btnAddBatch
            // 
            this.btnAddBatch.Location = new System.Drawing.Point(173, 21);
            this.btnAddBatch.Name = "btnAddBatch";
            this.btnAddBatch.Size = new System.Drawing.Size(52, 23);
            this.btnAddBatch.TabIndex = 5;
            this.btnAddBatch.Text = "Add";
            this.btnAddBatch.UseVisualStyleBackColor = true;
            this.btnAddBatch.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "primKey:";
            // 
            // txtPrimKeyToAdd
            // 
            this.txtPrimKeyToAdd.Location = new System.Drawing.Point(72, 21);
            this.txtPrimKeyToAdd.Name = "txtPrimKeyToAdd";
            this.txtPrimKeyToAdd.Size = new System.Drawing.Size(95, 22);
            this.txtPrimKeyToAdd.TabIndex = 4;
            this.txtPrimKeyToAdd.TextChanged += new System.EventHandler(this.txtPrimKeyToAdd_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 176);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(756, 215);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkLstBoxDays);
            this.groupBox4.Controls.Add(this.chkLstBoxDBs);
            this.groupBox4.Location = new System.Drawing.Point(474, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(288, 119);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filter";
            // 
            // chkLstBoxDays
            // 
            this.chkLstBoxDays.FormattingEnabled = true;
            this.chkLstBoxDays.Location = new System.Drawing.Point(162, 21);
            this.chkLstBoxDays.Name = "chkLstBoxDays";
            this.chkLstBoxDays.Size = new System.Drawing.Size(120, 89);
            this.chkLstBoxDays.TabIndex = 1;
            // 
            // chkLstBoxDBs
            // 
            this.chkLstBoxDBs.FormattingEnabled = true;
            this.chkLstBoxDBs.Location = new System.Drawing.Point(6, 21);
            this.chkLstBoxDBs.Name = "chkLstBoxDBs";
            this.chkLstBoxDBs.Size = new System.Drawing.Size(150, 89);
            this.chkLstBoxDBs.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkLock);
            this.groupBox3.Controls.Add(this.chkPrimKey);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.chkFoodName);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtQuery);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(462, 86);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search";
            // 
            // chkLock
            // 
            this.chkLock.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLock.AutoSize = true;
            this.chkLock.Location = new System.Drawing.Point(387, 49);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(47, 26);
            this.chkLock.TabIndex = 6;
            this.chkLock.Text = "Lock";
            this.chkLock.UseVisualStyleBackColor = true;
            // 
            // chkPrimKey
            // 
            this.chkPrimKey.AutoSize = true;
            this.chkPrimKey.Location = new System.Drawing.Point(175, 49);
            this.chkPrimKey.Name = "chkPrimKey";
            this.chkPrimKey.Size = new System.Drawing.Size(99, 20);
            this.chkPrimKey.TabIndex = 5;
            this.chkPrimKey.Text = "Primary Key";
            this.chkPrimKey.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter by:";
            // 
            // chkFoodName
            // 
            this.chkFoodName.AutoSize = true;
            this.chkFoodName.Location = new System.Drawing.Point(70, 49);
            this.chkFoodName.Name = "chkFoodName";
            this.chkFoodName.Size = new System.Drawing.Size(99, 20);
            this.chkFoodName.TabIndex = 4;
            this.chkFoodName.Text = "Food Name";
            this.chkFoodName.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Query:";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(59, 21);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(375, 22);
            this.txtQuery.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.checkedListBox1);
            this.tabPage2.Controls.Add(this.btnAction);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 397);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Android Sync";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtConsole);
            this.groupBox6.Location = new System.Drawing.Point(6, 139);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(756, 209);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Console Output";
            // 
            // txtConsole
            // 
            this.txtConsole.Location = new System.Drawing.Point(6, 21);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(744, 182);
            this.txtConsole.TabIndex = 3;
            this.txtConsole.WordWrap = false;
            this.txtConsole.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtConsole_MouseDown);
            this.txtConsole.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtConsole_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeView1);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 127);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Meal Conflicts";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(6, 21);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 97);
            this.treeView1.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(186, 27);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 89);
            this.checkedListBox1.TabIndex = 1;
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(7, 354);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(215, 37);
            this.btnAction.TabIndex = 1;
            this.btnAction.Text = "Load Device";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(545, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Your Device";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 21);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 84);
            this.textBox1.TabIndex = 0;
            // 
            // frmHistoryMerger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmHistoryMerger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "History Manager &  Merger";
            this.Load += new System.EventHandler(this.frmHistoryMerger_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkPrimKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkFoodName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox chkLstBoxDays;
        private System.Windows.Forms.CheckedListBox chkLstBoxDBs;
        private System.Windows.Forms.CheckBox chkLock;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnAddBatch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrimKeyToAdd;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox comboMeal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtConsole;
    }
}