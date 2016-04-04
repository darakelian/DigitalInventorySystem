namespace WindowsFormsApplication1
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cardNameLabel1 = new System.Windows.Forms.Label();
            this.inventoryGridView = new System.Windows.Forms.DataGridView();
            this.cardName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardSet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantitySelection = new System.Windows.Forms.NumericUpDown();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.conditionSelection = new System.Windows.Forms.ComboBox();
            this.addCardButton = new System.Windows.Forms.Button();
            this.cardNameToAdd = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clipboardImportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFilecsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFiletxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textImportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shopInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pricingRulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantitySelection)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cardNameLabel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.inventoryGridView);
            this.splitContainer1.Panel2.Controls.Add(this.quantitySelection);
            this.splitContainer1.Panel2.Controls.Add(this.quantityLabel);
            this.splitContainer1.Panel2.Controls.Add(this.conditionSelection);
            this.splitContainer1.Panel2.Controls.Add(this.addCardButton);
            this.splitContainer1.Panel2.Controls.Add(this.cardNameToAdd);
            this.splitContainer1.Size = new System.Drawing.Size(784, 531);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 0;
            // 
            // cardNameLabel1
            // 
            this.cardNameLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardNameLabel1.Location = new System.Drawing.Point(3, 9);
            this.cardNameLabel1.Name = "cardNameLabel1";
            this.cardNameLabel1.Size = new System.Drawing.Size(255, 23);
            this.cardNameLabel1.TabIndex = 0;
            this.cardNameLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inventoryGridView
            // 
            this.inventoryGridView.AllowUserToAddRows = false;
            this.inventoryGridView.AllowUserToResizeRows = false;
            this.inventoryGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.inventoryGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.inventoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventoryGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cardName,
            this.cardSet,
            this.cardQuantity,
            this.cardCondition,
            this.cardPrice});
            this.inventoryGridView.Location = new System.Drawing.Point(15, 58);
            this.inventoryGridView.MultiSelect = false;
            this.inventoryGridView.Name = "inventoryGridView";
            this.inventoryGridView.RowHeadersVisible = false;
            this.inventoryGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.inventoryGridView.Size = new System.Drawing.Size(492, 463);
            this.inventoryGridView.TabIndex = 7;
            this.inventoryGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inventoryGridView_CellContentClick);
            // 
            // cardName
            // 
            this.cardName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cardName.FillWeight = 300F;
            this.cardName.HeaderText = "Name";
            this.cardName.Name = "cardName";
            this.cardName.ReadOnly = true;
            // 
            // cardSet
            // 
            this.cardSet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cardSet.HeaderText = "Set";
            this.cardSet.Name = "cardSet";
            this.cardSet.ReadOnly = true;
            // 
            // cardQuantity
            // 
            this.cardQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cardQuantity.HeaderText = "Quantity";
            this.cardQuantity.Name = "cardQuantity";
            this.cardQuantity.ReadOnly = true;
            // 
            // cardCondition
            // 
            this.cardCondition.HeaderText = "Condition";
            this.cardCondition.Name = "cardCondition";
            this.cardCondition.ReadOnly = true;
            // 
            // cardPrice
            // 
            this.cardPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cardPrice.HeaderText = "Price";
            this.cardPrice.Name = "cardPrice";
            this.cardPrice.ReadOnly = true;
            // 
            // quantitySelection
            // 
            this.quantitySelection.Location = new System.Drawing.Point(153, 15);
            this.quantitySelection.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.quantitySelection.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantitySelection.Name = "quantitySelection";
            this.quantitySelection.Size = new System.Drawing.Size(61, 20);
            this.quantitySelection.TabIndex = 6;
            this.quantitySelection.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(98, 18);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(49, 13);
            this.quantityLabel.TabIndex = 5;
            this.quantityLabel.Text = "Quantity:";
            // 
            // conditionSelection
            // 
            this.conditionSelection.FormattingEnabled = true;
            this.conditionSelection.Items.AddRange(new object[] {
            "NM",
            "LP",
            "MP",
            "HP"});
            this.conditionSelection.Location = new System.Drawing.Point(221, 15);
            this.conditionSelection.Name = "conditionSelection";
            this.conditionSelection.Size = new System.Drawing.Size(42, 21);
            this.conditionSelection.TabIndex = 4;
            this.conditionSelection.Text = "NM";
            // 
            // addCardButton
            // 
            this.addCardButton.Location = new System.Drawing.Point(15, 13);
            this.addCardButton.Name = "addCardButton";
            this.addCardButton.Size = new System.Drawing.Size(75, 23);
            this.addCardButton.TabIndex = 1;
            this.addCardButton.Text = "Add Card";
            this.addCardButton.UseVisualStyleBackColor = true;
            this.addCardButton.Click += new System.EventHandler(this.addCardButton_Click);
            // 
            // cardNameToAdd
            // 
            this.cardNameToAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardNameToAdd.Location = new System.Drawing.Point(269, 15);
            this.cardNameToAdd.Name = "cardNameToAdd";
            this.cardNameToAdd.Size = new System.Drawing.Size(238, 20);
            this.cardNameToAdd.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.importMenuItem,
            this.exportMenuItem,
            this.settingsMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // importMenuItem
            // 
            this.importMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clipboardImportMenuItem,
            this.fromFilecsvToolStripMenuItem,
            this.fromFiletxtToolStripMenuItem,
            this.fromFileToolStripMenuItem,
            this.textImportMenuItem});
            this.importMenuItem.Name = "importMenuItem";
            this.importMenuItem.Size = new System.Drawing.Size(55, 20);
            this.importMenuItem.Text = "Import";
            // 
            // clipboardImportMenuItem
            // 
            this.clipboardImportMenuItem.Name = "clipboardImportMenuItem";
            this.clipboardImportMenuItem.Size = new System.Drawing.Size(155, 22);
            this.clipboardImportMenuItem.Text = "From clipboard";
            this.clipboardImportMenuItem.Click += new System.EventHandler(this.clipboardImportMenuItem_Click);
            // 
            // fromFilecsvToolStripMenuItem
            // 
            this.fromFilecsvToolStripMenuItem.Name = "fromFilecsvToolStripMenuItem";
            this.fromFilecsvToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.fromFilecsvToolStripMenuItem.Text = "From file (.csv)";
            // 
            // fromFiletxtToolStripMenuItem
            // 
            this.fromFiletxtToolStripMenuItem.Name = "fromFiletxtToolStripMenuItem";
            this.fromFiletxtToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.fromFiletxtToolStripMenuItem.Text = "From file (.txt)";
            // 
            // fromFileToolStripMenuItem
            // 
            this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
            this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.fromFileToolStripMenuItem.Text = "From file (.*)";
            // 
            // textImportMenuItem
            // 
            this.textImportMenuItem.Name = "textImportMenuItem";
            this.textImportMenuItem.Size = new System.Drawing.Size(155, 22);
            this.textImportMenuItem.Text = "From text";
            this.textImportMenuItem.Click += new System.EventHandler(this.textImportMenuItem_Click);
            // 
            // exportMenuItem
            // 
            this.exportMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toClipboardToolStripMenuItem,
            this.toTextToolStripMenuItem,
            this.toCSVToolStripMenuItem});
            this.exportMenuItem.Name = "exportMenuItem";
            this.exportMenuItem.Size = new System.Drawing.Size(52, 20);
            this.exportMenuItem.Text = "Export";
            // 
            // toClipboardToolStripMenuItem
            // 
            this.toClipboardToolStripMenuItem.Name = "toClipboardToolStripMenuItem";
            this.toClipboardToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.toClipboardToolStripMenuItem.Text = "To clipboard";
            // 
            // toTextToolStripMenuItem
            // 
            this.toTextToolStripMenuItem.Name = "toTextToolStripMenuItem";
            this.toTextToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.toTextToolStripMenuItem.Text = "To text";
            // 
            // toCSVToolStripMenuItem
            // 
            this.toCSVToolStripMenuItem.Name = "toCSVToolStripMenuItem";
            this.toCSVToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.toCSVToolStripMenuItem.Text = "To CSV";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shopInformationToolStripMenuItem,
            this.pricingRulesToolStripMenuItem});
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsMenuItem.Text = "Settings";
            // 
            // shopInformationToolStripMenuItem
            // 
            this.shopInformationToolStripMenuItem.Name = "shopInformationToolStripMenuItem";
            this.shopInformationToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.shopInformationToolStripMenuItem.Text = "Shop Information";
            // 
            // pricingRulesToolStripMenuItem
            // 
            this.pricingRulesToolStripMenuItem.Name = "pricingRulesToolStripMenuItem";
            this.pricingRulesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.pricingRulesToolStripMenuItem.Text = "Pricing Rules";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantitySelection)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox cardNameToAdd;
        private System.Windows.Forms.Button addCardButton;
        private System.Windows.Forms.ComboBox conditionSelection;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.NumericUpDown quantitySelection;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clipboardImportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromFilecsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromFiletxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shopInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pricingRulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textImportMenuItem;
        private System.Windows.Forms.DataGridView inventoryGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardCondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardPrice;
        public System.Windows.Forms.Label cardNameLabel1;
    }
}

