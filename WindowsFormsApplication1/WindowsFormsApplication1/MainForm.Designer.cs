namespace DigitalInventory
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.priceLabel = new System.Windows.Forms.Label();
            this.quantityLabel2 = new System.Windows.Forms.Label();
            this.conditionLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.FoilCheckBox = new System.Windows.Forms.CheckBox();
            this.inventoryDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Foil = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RowRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOnTCGPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryDataSet = new DigitalInventory.InventoryDataSet();
            this.quantitySelection = new System.Windows.Forms.NumericUpDown();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.conditionSelection = new System.Windows.Forms.ComboBox();
            this.addCardButton = new System.Windows.Forms.Button();
            this.cardNameToAdd = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clipboardImportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFilecsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFiletxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textImportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryTableAdapter = new DigitalInventory.InventoryDataSetTableAdapters.InventoryTableAdapter();
            this.tableAdapterManager = new DigitalInventory.InventoryDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataGridView)).BeginInit();
            this.RowRightClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSet)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.priceLabel);
            this.splitContainer1.Panel1.Controls.Add(this.quantityLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.conditionLabel);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.nameLabel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.FoilCheckBox);
            this.splitContainer1.Panel2.Controls.Add(this.inventoryDataGridView);
            this.splitContainer1.Panel2.Controls.Add(this.quantitySelection);
            this.splitContainer1.Panel2.Controls.Add(this.quantityLabel);
            this.splitContainer1.Panel2.Controls.Add(this.conditionSelection);
            this.splitContainer1.Panel2.Controls.Add(this.addCardButton);
            this.splitContainer1.Panel2.Controls.Add(this.cardNameToAdd);
            this.splitContainer1.Size = new System.Drawing.Size(784, 531);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 0;
            // 
            // priceLabel
            // 
            this.priceLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.priceLabel.Location = new System.Drawing.Point(0, 462);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(261, 23);
            this.priceLabel.TabIndex = 4;
            this.priceLabel.Text = "Price: ";
            this.priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // quantityLabel2
            // 
            this.quantityLabel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.quantityLabel2.Location = new System.Drawing.Point(0, 485);
            this.quantityLabel2.Name = "quantityLabel2";
            this.quantityLabel2.Size = new System.Drawing.Size(261, 23);
            this.quantityLabel2.TabIndex = 3;
            this.quantityLabel2.Text = "Quantity: ";
            this.quantityLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // conditionLabel
            // 
            this.conditionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.conditionLabel.Location = new System.Drawing.Point(0, 508);
            this.conditionLabel.Name = "conditionLabel";
            this.conditionLabel.Size = new System.Drawing.Size(261, 23);
            this.conditionLabel.TabIndex = 2;
            this.conditionLabel.Text = "Condition: ";
            this.conditionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(35, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 240);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.nameLabel.Location = new System.Drawing.Point(0, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(261, 23);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FoilCheckBox
            // 
            this.FoilCheckBox.AutoSize = true;
            this.FoilCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FoilCheckBox.Location = new System.Drawing.Point(269, 17);
            this.FoilCheckBox.Name = "FoilCheckBox";
            this.FoilCheckBox.Size = new System.Drawing.Size(45, 17);
            this.FoilCheckBox.TabIndex = 7;
            this.FoilCheckBox.Text = "Foil:";
            this.FoilCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FoilCheckBox.UseVisualStyleBackColor = true;
            // 
            // inventoryDataGridView
            // 
            this.inventoryDataGridView.AllowUserToAddRows = false;
            this.inventoryDataGridView.AllowUserToDeleteRows = false;
            this.inventoryDataGridView.AllowUserToResizeRows = false;
            this.inventoryDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryDataGridView.AutoGenerateColumns = false;
            this.inventoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Foil});
            this.inventoryDataGridView.ContextMenuStrip = this.RowRightClick;
            this.inventoryDataGridView.DataSource = this.inventoryBindingSource;
            this.inventoryDataGridView.Location = new System.Drawing.Point(17, 67);
            this.inventoryDataGridView.MultiSelect = false;
            this.inventoryDataGridView.Name = "inventoryDataGridView";
            this.inventoryDataGridView.ReadOnly = true;
            this.inventoryDataGridView.RowHeadersVisible = false;
            this.inventoryDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.inventoryDataGridView.Size = new System.Drawing.Size(490, 454);
            this.inventoryDataGridView.TabIndex = 6;
            this.inventoryDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.inventoryDataGridView_RowEnter);
            this.inventoryDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.inventoryDataGridView_MouseDown);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Set";
            this.dataGridViewTextBoxColumn3.HeaderText = "Set";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 48;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn4.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 71;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Condition";
            this.dataGridViewTextBoxColumn5.HeaderText = "Condition";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 76;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Price";
            this.dataGridViewTextBoxColumn6.HeaderText = "Price";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 56;
            // 
            // Foil
            // 
            this.Foil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Foil.DataPropertyName = "Foil";
            this.Foil.HeaderText = "Foil";
            this.Foil.Name = "Foil";
            this.Foil.ReadOnly = true;
            this.Foil.Width = 29;
            // 
            // RowRightClick
            // 
            this.RowRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.showOnTCGPlayerToolStripMenuItem});
            this.RowRightClick.Name = "RowRightClick";
            this.RowRightClick.Size = new System.Drawing.Size(178, 48);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // showOnTCGPlayerToolStripMenuItem
            // 
            this.showOnTCGPlayerToolStripMenuItem.Name = "showOnTCGPlayerToolStripMenuItem";
            this.showOnTCGPlayerToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.showOnTCGPlayerToolStripMenuItem.Text = "Show on TCGPlayer";
            this.showOnTCGPlayerToolStripMenuItem.Click += new System.EventHandler(this.showOnTCGPlayerToolStripMenuItem_Click);
            // 
            // inventoryBindingSource
            // 
            this.inventoryBindingSource.DataMember = "Inventory";
            this.inventoryBindingSource.DataSource = this.inventoryDataSet;
            // 
            // inventoryDataSet
            // 
            this.inventoryDataSet.DataSetName = "InventoryDataSet";
            this.inventoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.cardNameToAdd.Location = new System.Drawing.Point(320, 14);
            this.cardNameToAdd.Name = "cardNameToAdd";
            this.cardNameToAdd.Size = new System.Drawing.Size(187, 20);
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
            this.saveToolStripMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // importMenuItem
            // 
            this.importMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clipboardImportMenuItem,
            this.fromFilecsvToolStripMenuItem,
            this.fromFiletxtToolStripMenuItem,
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
            this.fromFilecsvToolStripMenuItem.Click += new System.EventHandler(this.fromFilecsvToolStripMenuItem_Click);
            // 
            // fromFiletxtToolStripMenuItem
            // 
            this.fromFiletxtToolStripMenuItem.Name = "fromFiletxtToolStripMenuItem";
            this.fromFiletxtToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.fromFiletxtToolStripMenuItem.Text = "From file (.txt)";
            this.fromFiletxtToolStripMenuItem.Click += new System.EventHandler(this.fromFiletxtToolStripMenuItem_Click);
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
            this.toClipboardToolStripMenuItem.Click += new System.EventHandler(this.toClipboardToolStripMenuItem_Click);
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
            this.toCSVToolStripMenuItem.Click += new System.EventHandler(this.toCSVToolStripMenuItem_Click);
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsMenuItem.Text = "Settings";
            this.settingsMenuItem.Click += new System.EventHandler(this.settingsMenuItem_Click);
            // 
            // inventoryTableAdapter
            // 
            this.inventoryTableAdapter.ClearBeforeFill = false;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.InventoryTableAdapter = this.inventoryTableAdapter;
            this.tableAdapterManager.UpdateOrder = DigitalInventory.InventoryDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataGridView)).EndInit();
            this.RowRightClick.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSet)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem fromFilecsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromFiletxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textImportMenuItem;
        public System.Windows.Forms.Label nameLabel;
        private InventoryDataSet inventoryDataSet;
        private System.Windows.Forms.BindingSource inventoryBindingSource;
        private InventoryDataSetTableAdapters.InventoryTableAdapter inventoryTableAdapter;
        private InventoryDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        public System.Windows.Forms.DataGridView inventoryDataGridView;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label conditionLabel;
        public System.Windows.Forms.Label priceLabel;
        public System.Windows.Forms.Label quantityLabel2;
        private System.Windows.Forms.CheckBox FoilCheckBox;
        private System.Windows.Forms.ContextMenuStrip RowRightClick;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Foil;
        private System.Windows.Forms.ToolStripMenuItem showOnTCGPlayerToolStripMenuItem;
    }
}

