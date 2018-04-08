namespace Nutritracker
{
    partial class frmParseCustomDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParseCustomDatabase));
            this.lstViewResult = new System.Windows.Forms.ListView();
            this.sprdshtMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromtxtFilequickestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNewField = new System.Windows.Forms.Button();
            this.btnNewDB = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.importTxtDialog = new System.Windows.Forms.OpenFileDialog();
            this.sprdshtMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstViewResult
            // 
            this.lstViewResult.AllowColumnReorder = true;
            this.lstViewResult.AllowDrop = true;
            this.lstViewResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstViewResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstViewResult.Location = new System.Drawing.Point(13, 200);
            this.lstViewResult.Margin = new System.Windows.Forms.Padding(4);
            this.lstViewResult.Name = "lstViewResult";
            this.lstViewResult.Size = new System.Drawing.Size(692, 391);
            this.lstViewResult.TabIndex = 2;
            this.lstViewResult.UseCompatibleStateImageBehavior = false;
            this.lstViewResult.View = System.Windows.Forms.View.Details;
            this.lstViewResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            // 
            // sprdshtMenuStrip
            // 
            this.sprdshtMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.sprdshtMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.sprdshtMenuStrip.Name = "sprdshtMenuStrip";
            this.sprdshtMenuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.sprdshtMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.sprdshtMenuStrip.Size = new System.Drawing.Size(723, 24);
            this.sprdshtMenuStrip.TabIndex = 4;
            this.sprdshtMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewDatabaseToolStripMenuItem,
            this.createNewFieldToolStripMenuItem,
            this.importFromtxtFilequickestToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createNewDatabaseToolStripMenuItem
            // 
            this.createNewDatabaseToolStripMenuItem.Name = "createNewDatabaseToolStripMenuItem";
            this.createNewDatabaseToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.createNewDatabaseToolStripMenuItem.Text = "Create New Database";
            this.createNewDatabaseToolStripMenuItem.Click += new System.EventHandler(this.createNewDatabaseToolStripMenuItem_Click);
            // 
            // createNewFieldToolStripMenuItem
            // 
            this.createNewFieldToolStripMenuItem.Name = "createNewFieldToolStripMenuItem";
            this.createNewFieldToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.createNewFieldToolStripMenuItem.Text = "Create New Field";
            this.createNewFieldToolStripMenuItem.Click += new System.EventHandler(this.createNewFieldToolStripMenuItem_Click);
            // 
            // importFromtxtFilequickestToolStripMenuItem
            // 
            this.importFromtxtFilequickestToolStripMenuItem.Name = "importFromtxtFilequickestToolStripMenuItem";
            this.importFromtxtFilequickestToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.importFromtxtFilequickestToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.importFromtxtFilequickestToolStripMenuItem.Text = "Import from .txt file (quickest)";
            this.importFromtxtFilequickestToolStripMenuItem.Click += new System.EventHandler(this.importFromtxtFilequickestToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(477, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Drag and Drop a .TXT file from your Computer (ctrl+T or double click to browse):";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(505, 599);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(191, 51);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNewField
            // 
            this.btnNewField.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewField.Location = new System.Drawing.Point(110, 599);
            this.btnNewField.Name = "btnNewField";
            this.btnNewField.Size = new System.Drawing.Size(111, 51);
            this.btnNewField.TabIndex = 14;
            this.btnNewField.Text = "Create new Field or Table";
            this.btnNewField.UseVisualStyleBackColor = true;
            this.btnNewField.Click += new System.EventHandler(this.btnNewField_Click);
            // 
            // btnNewDB
            // 
            this.btnNewDB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewDB.Location = new System.Drawing.Point(276, 599);
            this.btnNewDB.Name = "btnNewDB";
            this.btnNewDB.Size = new System.Drawing.Size(151, 51);
            this.btnNewDB.TabIndex = 15;
            this.btnNewDB.Text = "Create new Database";
            this.btnNewDB.UseVisualStyleBackColor = true;
            this.btnNewDB.Click += new System.EventHandler(this.btnNewDB_Click);
            // 
            // txtInput
            // 
            this.txtInput.AllowDrop = true;
            this.txtInput.Location = new System.Drawing.Point(12, 49);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ReadOnly = true;
            this.txtInput.Size = new System.Drawing.Size(699, 130);
            this.txtInput.TabIndex = 19;
            this.txtInput.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtInput_DragDrop);
            this.txtInput.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtInput_DragEnter);
            this.txtInput.DoubleClick += new System.EventHandler(this.txtInput_DoubleClick);
            // 
            // importTxtDialog
            // 
            this.importTxtDialog.Filter = "Text files|*.TXT";
            // 
            // frmParseCustomDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(723, 662);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnNewDB);
            this.Controls.Add(this.btnNewField);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstViewResult);
            this.Controls.Add(this.sprdshtMenuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.sprdshtMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmParseCustomDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spreadsheet Importing Wizard";
            this.Load += new System.EventHandler(this.frmParseCustomDatabase_Load);
            this.sprdshtMenuStrip.ResumeLayout(false);
            this.sprdshtMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lstViewResult;
        private System.Windows.Forms.MenuStrip sprdshtMenuStrip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNewField;
        private System.Windows.Forms.Button btnNewDB;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.OpenFileDialog importTxtDialog;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromtxtFilequickestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewFieldToolStripMenuItem;
    }
}