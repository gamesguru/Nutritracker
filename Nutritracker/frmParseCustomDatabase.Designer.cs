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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParseCustomDatabase));
            this.lstViewResult = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForColumnUnitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToGramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUnitsToColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separateDecimalsByCollumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectColumnToMake100gToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeSelectedColumn200kcalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromtxtFilequickestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rowSelectingEngineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.performUSDAIntegrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.performOtherDBIntegrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboColumns = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNewField = new System.Windows.Forms.Button();
            this.btnNewDB = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstViewResult
            // 
            this.lstViewResult.AllowColumnReorder = true;
            this.lstViewResult.AllowDrop = true;
            this.lstViewResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstViewResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstViewResult.Location = new System.Drawing.Point(13, 236);
            this.lstViewResult.Margin = new System.Windows.Forms.Padding(4);
            this.lstViewResult.Name = "lstViewResult";
            this.lstViewResult.Size = new System.Drawing.Size(692, 355);
            this.lstViewResult.TabIndex = 2;
            this.lstViewResult.UseCompatibleStateImageBehavior = false;
            this.lstViewResult.View = System.Windows.Forms.View.Details;
            this.lstViewResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteToolStripMenuItem,
            this.replaceToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(68, 48);
            this.contextMenuStrip1.Text = "Paste";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(723, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedColumnToolStripMenuItem,
            this.checkForColumnUnitsToolStripMenuItem,
            this.convertToGramsToolStripMenuItem,
            this.addUnitsToColumnToolStripMenuItem,
            this.separateDecimalsByCollumnToolStripMenuItem,
            this.selectColumnToMake100gToolStripMenuItem,
            this.makeSelectedColumn200kcalToolStripMenuItem,
            this.importFromtxtFilequickestToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // removeSelectedColumnToolStripMenuItem
            // 
            this.removeSelectedColumnToolStripMenuItem.Name = "removeSelectedColumnToolStripMenuItem";
            this.removeSelectedColumnToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.removeSelectedColumnToolStripMenuItem.Text = "Remove Selected Column";
            this.removeSelectedColumnToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedColumnToolStripMenuItem_Click);
            // 
            // checkForColumnUnitsToolStripMenuItem
            // 
            this.checkForColumnUnitsToolStripMenuItem.Name = "checkForColumnUnitsToolStripMenuItem";
            this.checkForColumnUnitsToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.checkForColumnUnitsToolStripMenuItem.Text = "Check for Column Units";
            this.checkForColumnUnitsToolStripMenuItem.Click += new System.EventHandler(this.checkForColumnUnitsToolStripMenuItem_Click);
            // 
            // convertToGramsToolStripMenuItem
            // 
            this.convertToGramsToolStripMenuItem.Name = "convertToGramsToolStripMenuItem";
            this.convertToGramsToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.convertToGramsToolStripMenuItem.Text = "Convert Chosen Column  to Grams";
            this.convertToGramsToolStripMenuItem.Click += new System.EventHandler(this.convertToGramsToolStripMenuItem_Click);
            // 
            // addUnitsToColumnToolStripMenuItem
            // 
            this.addUnitsToColumnToolStripMenuItem.Name = "addUnitsToColumnToolStripMenuItem";
            this.addUnitsToColumnToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.addUnitsToColumnToolStripMenuItem.Text = "Rename Column or Add Units";
            // 
            // separateDecimalsByCollumnToolStripMenuItem
            // 
            this.separateDecimalsByCollumnToolStripMenuItem.Name = "separateDecimalsByCollumnToolStripMenuItem";
            this.separateDecimalsByCollumnToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.separateDecimalsByCollumnToolStripMenuItem.Text = "Recognize Numbers as Column Breaks";
            // 
            // selectColumnToMake100gToolStripMenuItem
            // 
            this.selectColumnToMake100gToolStripMenuItem.Name = "selectColumnToMake100gToolStripMenuItem";
            this.selectColumnToMake100gToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.selectColumnToMake100gToolStripMenuItem.Text = "Make Selected Column 100g";
            this.selectColumnToMake100gToolStripMenuItem.Click += new System.EventHandler(this.selectColumnToMake100gToolStripMenuItem_Click);
            // 
            // makeSelectedColumn200kcalToolStripMenuItem
            // 
            this.makeSelectedColumn200kcalToolStripMenuItem.Name = "makeSelectedColumn200kcalToolStripMenuItem";
            this.makeSelectedColumn200kcalToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.makeSelectedColumn200kcalToolStripMenuItem.Text = "Make Selected Column 200kcal";
            // 
            // importFromtxtFilequickestToolStripMenuItem
            // 
            this.importFromtxtFilequickestToolStripMenuItem.Name = "importFromtxtFilequickestToolStripMenuItem";
            this.importFromtxtFilequickestToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.importFromtxtFilequickestToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.importFromtxtFilequickestToolStripMenuItem.Text = "Import from .txt file (quickest)";
            this.importFromtxtFilequickestToolStripMenuItem.Click += new System.EventHandler(this.importFromtxtFilequickestToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rowSelectingEngineToolStripMenuItem,
            this.performUSDAIntegrationToolStripMenuItem,
            this.performOtherDBIntegrationToolStripMenuItem,
            this.createNewDatabaseToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // rowSelectingEngineToolStripMenuItem
            // 
            this.rowSelectingEngineToolStripMenuItem.Name = "rowSelectingEngineToolStripMenuItem";
            this.rowSelectingEngineToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.rowSelectingEngineToolStripMenuItem.Text = "Row Selecting/Value Pairing Engine";
            // 
            // performUSDAIntegrationToolStripMenuItem
            // 
            this.performUSDAIntegrationToolStripMenuItem.Name = "performUSDAIntegrationToolStripMenuItem";
            this.performUSDAIntegrationToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.performUSDAIntegrationToolStripMenuItem.Text = "New USDA Field";
            // 
            // performOtherDBIntegrationToolStripMenuItem
            // 
            this.performOtherDBIntegrationToolStripMenuItem.Name = "performOtherDBIntegrationToolStripMenuItem";
            this.performOtherDBIntegrationToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.performOtherDBIntegrationToolStripMenuItem.Text = "New Custom DB Field";
            // 
            // createNewDatabaseToolStripMenuItem
            // 
            this.createNewDatabaseToolStripMenuItem.Name = "createNewDatabaseToolStripMenuItem";
            this.createNewDatabaseToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.createNewDatabaseToolStripMenuItem.Text = "Create New Database";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
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
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Chosen column:";
            // 
            // comboColumns
            // 
            this.comboColumns.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboColumns.FormattingEnabled = true;
            this.comboColumns.Location = new System.Drawing.Point(411, 201);
            this.comboColumns.Name = "comboColumns";
            this.comboColumns.Size = new System.Drawing.Size(132, 24);
            this.comboColumns.TabIndex = 9;
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
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(12, 49);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(699, 130);
            this.textBox1.TabIndex = 19;
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            this.textBox1.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text files|*.TXT";
            // 
            // frmParseCustomDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(723, 662);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnNewDB);
            this.Controls.Add(this.btnNewField);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.comboColumns);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstViewResult);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmParseCustomDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spreadsheet Importing Wizard";
            this.Load += new System.EventHandler(this.frmParseCustomDatabase_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lstViewResult;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem separateDecimalsByCollumnToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem selectColumnToMake100gToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboColumns;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem performUSDAIntegrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem performOtherDBIntegrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForColumnUnitsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeSelectedColumn200kcalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUnitsToColumnToolStripMenuItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToGramsToolStripMenuItem;
        private System.Windows.Forms.Button btnNewField;
        private System.Windows.Forms.Button btnNewDB;
        private System.Windows.Forms.ToolStripMenuItem rowSelectingEngineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromtxtFilequickestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}