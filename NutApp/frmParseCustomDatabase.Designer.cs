namespace NutApp
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
            this.btnParseTxt = new System.Windows.Forms.Button();
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
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseWithoutPastingquickerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findReplaceCtrlHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rowSelectingEngineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.performUSDAIntegrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.performOtherDBIntegrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboColumns = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtboxSource = new System.Windows.Forms.TextBox();
            this.btnNewField = new System.Windows.Forms.Button();
            this.btnNewDB = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnInsertValue = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.importFromtxtFilequickestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnParseTxt
            // 
            this.btnParseTxt.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnParseTxt.Enabled = false;
            this.btnParseTxt.Location = new System.Drawing.Point(205, 408);
            this.btnParseTxt.Margin = new System.Windows.Forms.Padding(4);
            this.btnParseTxt.Name = "btnParseTxt";
            this.btnParseTxt.Size = new System.Drawing.Size(142, 42);
            this.btnParseTxt.TabIndex = 1;
            this.btnParseTxt.Text = " ↓ Transfer to List ↓ ";
            this.btnParseTxt.UseVisualStyleBackColor = true;
            this.btnParseTxt.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstViewResult
            // 
            this.lstViewResult.AllowColumnReorder = true;
            this.lstViewResult.AllowDrop = true;
            this.lstViewResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstViewResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstViewResult.Location = new System.Drawing.Point(13, 458);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 48);
            this.contextMenuStrip1.Text = "Paste";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.pasteToolStripMenuItem.Text = "Paste and Parse";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.replaceToolStripMenuItem.Text = "Replace";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
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
            this.undoToolStripMenuItem,
            this.parseWithoutPastingquickerToolStripMenuItem,
            this.importFromtxtFilequickestToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // removeSelectedColumnToolStripMenuItem
            // 
            this.removeSelectedColumnToolStripMenuItem.Name = "removeSelectedColumnToolStripMenuItem";
            this.removeSelectedColumnToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.removeSelectedColumnToolStripMenuItem.Text = "Remove Selected Column";
            this.removeSelectedColumnToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedColumnToolStripMenuItem_Click);
            // 
            // checkForColumnUnitsToolStripMenuItem
            // 
            this.checkForColumnUnitsToolStripMenuItem.Name = "checkForColumnUnitsToolStripMenuItem";
            this.checkForColumnUnitsToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.checkForColumnUnitsToolStripMenuItem.Text = "Check for Column Units";
            this.checkForColumnUnitsToolStripMenuItem.Click += new System.EventHandler(this.checkForColumnUnitsToolStripMenuItem_Click);
            // 
            // convertToGramsToolStripMenuItem
            // 
            this.convertToGramsToolStripMenuItem.Name = "convertToGramsToolStripMenuItem";
            this.convertToGramsToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.convertToGramsToolStripMenuItem.Text = "Convert Chosen Column  to Grams";
            this.convertToGramsToolStripMenuItem.Click += new System.EventHandler(this.convertToGramsToolStripMenuItem_Click);
            // 
            // addUnitsToColumnToolStripMenuItem
            // 
            this.addUnitsToColumnToolStripMenuItem.Name = "addUnitsToColumnToolStripMenuItem";
            this.addUnitsToColumnToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.addUnitsToColumnToolStripMenuItem.Text = "Rename Column or Add Units";
            // 
            // separateDecimalsByCollumnToolStripMenuItem
            // 
            this.separateDecimalsByCollumnToolStripMenuItem.Name = "separateDecimalsByCollumnToolStripMenuItem";
            this.separateDecimalsByCollumnToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.separateDecimalsByCollumnToolStripMenuItem.Text = "Recognize Numbers as Column Breaks";
            // 
            // selectColumnToMake100gToolStripMenuItem
            // 
            this.selectColumnToMake100gToolStripMenuItem.Name = "selectColumnToMake100gToolStripMenuItem";
            this.selectColumnToMake100gToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.selectColumnToMake100gToolStripMenuItem.Text = "Make Selected Column 100g";
            this.selectColumnToMake100gToolStripMenuItem.Click += new System.EventHandler(this.selectColumnToMake100gToolStripMenuItem_Click);
            // 
            // makeSelectedColumn200kcalToolStripMenuItem
            // 
            this.makeSelectedColumn200kcalToolStripMenuItem.Name = "makeSelectedColumn200kcalToolStripMenuItem";
            this.makeSelectedColumn200kcalToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.makeSelectedColumn200kcalToolStripMenuItem.Text = "Make Selected Column 200kcal";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // parseWithoutPastingquickerToolStripMenuItem
            // 
            this.parseWithoutPastingquickerToolStripMenuItem.Name = "parseWithoutPastingquickerToolStripMenuItem";
            this.parseWithoutPastingquickerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.parseWithoutPastingquickerToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.parseWithoutPastingquickerToolStripMenuItem.Text = "Parse without Pasting (quicker)";
            this.parseWithoutPastingquickerToolStripMenuItem.Click += new System.EventHandler(this.parseWithoutPastingquickerToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem,
            this.findReplaceCtrlHToolStripMenuItem,
            this.rowSelectingEngineToolStripMenuItem,
            this.performUSDAIntegrationToolStripMenuItem,
            this.performOtherDBIntegrationToolStripMenuItem,
            this.createNewDatabaseToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.findToolStripMenuItem.Text = "Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // findReplaceCtrlHToolStripMenuItem
            // 
            this.findReplaceCtrlHToolStripMenuItem.Name = "findReplaceCtrlHToolStripMenuItem";
            this.findReplaceCtrlHToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.findReplaceCtrlHToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.findReplaceCtrlHToolStripMenuItem.Text = "Find and Replace";
            this.findReplaceCtrlHToolStripMenuItem.Click += new System.EventHandler(this.findReplaceCtrlHToolStripMenuItem_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Paste a spreadsheet or a chart from the web:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Chosen column:";
            // 
            // comboColumns
            // 
            this.comboColumns.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboColumns.FormattingEnabled = true;
            this.comboColumns.Location = new System.Drawing.Point(411, 422);
            this.comboColumns.Name = "comboColumns";
            this.comboColumns.Size = new System.Drawing.Size(132, 24);
            this.comboColumns.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(505, 820);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(191, 51);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtboxSource
            // 
            this.txtboxSource.AcceptsTab = true;
            this.txtboxSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxSource.ContextMenuStrip = this.contextMenuStrip1;
            this.txtboxSource.HideSelection = false;
            this.txtboxSource.Location = new System.Drawing.Point(12, 49);
            this.txtboxSource.MaxLength = 2147483647;
            this.txtboxSource.Multiline = true;
            this.txtboxSource.Name = "txtboxSource";
            this.txtboxSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtboxSource.Size = new System.Drawing.Size(699, 351);
            this.txtboxSource.TabIndex = 13;
            this.txtboxSource.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtboxSource_MouseClick);
            this.txtboxSource.TextChanged += new System.EventHandler(this.txtboxSource_TextChanged);
            this.txtboxSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtboxSource_KeyDown);
            this.txtboxSource.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtboxSource_MouseUp);
            // 
            // btnNewField
            // 
            this.btnNewField.Location = new System.Drawing.Point(169, 820);
            this.btnNewField.Name = "btnNewField";
            this.btnNewField.Size = new System.Drawing.Size(111, 51);
            this.btnNewField.TabIndex = 14;
            this.btnNewField.Text = "Create new Field or Table";
            this.btnNewField.UseVisualStyleBackColor = true;
            this.btnNewField.Click += new System.EventHandler(this.btnNewField_Click);
            // 
            // btnNewDB
            // 
            this.btnNewDB.Location = new System.Drawing.Point(286, 820);
            this.btnNewDB.Name = "btnNewDB";
            this.btnNewDB.Size = new System.Drawing.Size(151, 30);
            this.btnNewDB.TabIndex = 15;
            this.btnNewDB.Text = "Create new Database";
            this.btnNewDB.UseVisualStyleBackColor = true;
            this.btnNewDB.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(286, 856);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(149, 20);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Relational database";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnInsertValue
            // 
            this.btnInsertValue.Enabled = false;
            this.btnInsertValue.Location = new System.Drawing.Point(16, 820);
            this.btnInsertValue.Name = "btnInsertValue";
            this.btnInsertValue.Size = new System.Drawing.Size(117, 51);
            this.btnInsertValue.TabIndex = 17;
            this.btnInsertValue.Text = "Insert Values to an Existing Field";
            this.btnInsertValue.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(22, 415);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(152, 23);
            this.progressBar1.TabIndex = 18;
            this.progressBar1.Visible = false;
            // 
            // importFromtxtFilequickestToolStripMenuItem
            // 
            this.importFromtxtFilequickestToolStripMenuItem.Name = "importFromtxtFilequickestToolStripMenuItem";
            this.importFromtxtFilequickestToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.importFromtxtFilequickestToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.importFromtxtFilequickestToolStripMenuItem.Text = "Import from .txt file (quickest)";
            this.importFromtxtFilequickestToolStripMenuItem.Click += new System.EventHandler(this.importFromtxtFilequickestToolStripMenuItem_Click);
            // 
            // frmParseCustomDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(723, 883);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnInsertValue);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnNewDB);
            this.Controls.Add(this.btnNewField);
            this.Controls.Add(this.txtboxSource);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.comboColumns);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstViewResult);
            this.Controls.Add(this.btnParseTxt);
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
        private System.Windows.Forms.Button btnParseTxt;
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
        private System.Windows.Forms.ToolStripMenuItem findReplaceCtrlHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeSelectedColumn200kcalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUnitsToColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtboxSource;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToGramsToolStripMenuItem;
        private System.Windows.Forms.Button btnNewField;
        private System.Windows.Forms.Button btnNewDB;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnInsertValue;
        private System.Windows.Forms.ToolStripMenuItem rowSelectingEngineToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem parseWithoutPastingquickerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromtxtFilequickestToolStripMenuItem;
    }
}