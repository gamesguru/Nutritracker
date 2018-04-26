namespace Nutritracker
{
    partial class frmCustomFoodRecipes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomFoodRecipes));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtNewFoodName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstBoxNutes = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnRemFood = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstBoxFoods = new System.Windows.Forms.ListBox();
            this.txtBoxFood = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnRemRecipe = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lstBoxRecipes = new System.Windows.Forms.ListBox();
            this.txtBoxRecipe = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(494, 334);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtNewFoodName);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lstBoxNutes);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.btnRemFood);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lstBoxFoods);
            this.tabPage1.Controls.Add(this.txtBoxFood);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(486, 305);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Foods";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtNewFoodName
            // 
            this.txtNewFoodName.Location = new System.Drawing.Point(233, 6);
            this.txtNewFoodName.Name = "txtNewFoodName";
            this.txtNewFoodName.Size = new System.Drawing.Size(191, 22);
            this.txtNewFoodName.TabIndex = 22;
            this.txtNewFoodName.Text = "New FoodName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Nutrients:";
            // 
            // lstBoxNutes
            // 
            this.lstBoxNutes.FormattingEnabled = true;
            this.lstBoxNutes.ItemHeight = 16;
            this.lstBoxNutes.Location = new System.Drawing.Point(9, 163);
            this.lstBoxNutes.Name = "lstBoxNutes";
            this.lstBoxNutes.Size = new System.Drawing.Size(211, 84);
            this.lstBoxNutes.TabIndex = 20;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(398, 260);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 29);
            this.button4.TabIndex = 18;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(317, 260);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 29);
            this.button3.TabIndex = 17;
            this.button3.Text = "New";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnRemFood
            // 
            this.btnRemFood.Location = new System.Drawing.Point(51, 112);
            this.btnRemFood.Name = "btnRemFood";
            this.btnRemFood.Size = new System.Drawing.Size(75, 29);
            this.btnRemFood.TabIndex = 16;
            this.btnRemFood.Text = "Remove";
            this.btnRemFood.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Edit Food:";
            // 
            // lstBoxFoods
            // 
            this.lstBoxFoods.FormattingEnabled = true;
            this.lstBoxFoods.ItemHeight = 16;
            this.lstBoxFoods.Location = new System.Drawing.Point(6, 22);
            this.lstBoxFoods.Name = "lstBoxFoods";
            this.lstBoxFoods.Size = new System.Drawing.Size(120, 84);
            this.lstBoxFoods.TabIndex = 14;
            // 
            // txtBoxFood
            // 
            this.txtBoxFood.Location = new System.Drawing.Point(233, 34);
            this.txtBoxFood.Multiline = true;
            this.txtBoxFood.Name = "txtBoxFood";
            this.txtBoxFood.Size = new System.Drawing.Size(240, 220);
            this.txtBoxFood.TabIndex = 13;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.btnRemRecipe);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.lstBoxRecipes);
            this.tabPage2.Controls.Add(this.txtBoxRecipe);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(486, 305);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Recipes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(156, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(191, 22);
            this.textBox1.TabIndex = 28;
            this.textBox1.Text = "New RecipeName";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(321, 260);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 29);
            this.button5.TabIndex = 27;
            this.button5.Text = "Save";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(156, 260);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 29);
            this.button6.TabIndex = 26;
            this.button6.Text = "New";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // btnRemRecipe
            // 
            this.btnRemRecipe.Location = new System.Drawing.Point(70, 112);
            this.btnRemRecipe.Name = "btnRemRecipe";
            this.btnRemRecipe.Size = new System.Drawing.Size(75, 29);
            this.btnRemRecipe.TabIndex = 25;
            this.btnRemRecipe.Text = "Remove";
            this.btnRemRecipe.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Edit Recipe:";
            // 
            // lstBoxRecipes
            // 
            this.lstBoxRecipes.FormattingEnabled = true;
            this.lstBoxRecipes.ItemHeight = 16;
            this.lstBoxRecipes.Location = new System.Drawing.Point(6, 22);
            this.lstBoxRecipes.Name = "lstBoxRecipes";
            this.lstBoxRecipes.Size = new System.Drawing.Size(139, 84);
            this.lstBoxRecipes.TabIndex = 23;
            // 
            // txtBoxRecipe
            // 
            this.txtBoxRecipe.Location = new System.Drawing.Point(156, 34);
            this.txtBoxRecipe.Multiline = true;
            this.txtBoxRecipe.Name = "txtBoxRecipe";
            this.txtBoxRecipe.Size = new System.Drawing.Size(240, 220);
            this.txtBoxRecipe.TabIndex = 22;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(385, 348);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(121, 48);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "lblStatus";
            // 
            // frmCustomFoodRecipes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 408);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmCustomFoodRecipes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Recipes and Custom Foods";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtBoxFood;
        private System.Windows.Forms.Button btnRemFood;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstBoxFoods;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstBoxNutes;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnRemRecipe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstBoxRecipes;
        private System.Windows.Forms.TextBox txtBoxRecipe;
        private System.Windows.Forms.TextBox txtNewFoodName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}