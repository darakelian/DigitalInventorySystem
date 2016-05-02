namespace DigitalInventory
{
    partial class TradeForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cardAddingTextBox = new System.Windows.Forms.TextBox();
            this.addCardButton = new System.Windows.Forms.Button();
            this.toPartnerButton = new System.Windows.Forms.Button();
            this.toUserButton = new System.Windows.Forms.Button();
            this.removeCardButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cardColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addPartnerCardButton = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityToAdd = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityToAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // cardAddingTextBox
            // 
            this.cardAddingTextBox.Location = new System.Drawing.Point(13, 13);
            this.cardAddingTextBox.Name = "cardAddingTextBox";
            this.cardAddingTextBox.Size = new System.Drawing.Size(175, 20);
            this.cardAddingTextBox.TabIndex = 0;
            this.cardAddingTextBox.WordWrap = false;
            // 
            // addCardButton
            // 
            this.addCardButton.Location = new System.Drawing.Point(13, 47);
            this.addCardButton.Name = "addCardButton";
            this.addCardButton.Size = new System.Drawing.Size(85, 23);
            this.addCardButton.TabIndex = 1;
            this.addCardButton.Text = "Add Card";
            this.addCardButton.UseVisualStyleBackColor = true;
            this.addCardButton.Click += new System.EventHandler(this.addCardButton_Click);
            // 
            // toPartnerButton
            // 
            this.toPartnerButton.Location = new System.Drawing.Point(194, 209);
            this.toPartnerButton.Name = "toPartnerButton";
            this.toPartnerButton.Size = new System.Drawing.Size(85, 23);
            this.toPartnerButton.TabIndex = 3;
            this.toPartnerButton.Text = "Switch >>";
            this.toPartnerButton.UseVisualStyleBackColor = true;
            this.toPartnerButton.Click += new System.EventHandler(this.toPartnerButton_Click);
            // 
            // toUserButton
            // 
            this.toUserButton.Location = new System.Drawing.Point(194, 238);
            this.toUserButton.Name = "toUserButton";
            this.toUserButton.Size = new System.Drawing.Size(85, 23);
            this.toUserButton.TabIndex = 4;
            this.toUserButton.Text = "<< Switch";
            this.toUserButton.UseVisualStyleBackColor = true;
            this.toUserButton.Click += new System.EventHandler(this.toUserButton_Click);
            // 
            // removeCardButton
            // 
            this.removeCardButton.Location = new System.Drawing.Point(194, 267);
            this.removeCardButton.Name = "removeCardButton";
            this.removeCardButton.Size = new System.Drawing.Size(85, 23);
            this.removeCardButton.TabIndex = 5;
            this.removeCardButton.Text = "Remove";
            this.removeCardButton.UseVisualStyleBackColor = true;
            this.removeCardButton.Click += new System.EventHandler(this.removeCardButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cardColumn});
            this.dataGridView1.Location = new System.Drawing.Point(13, 76);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(175, 358);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.beginEditValue);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // cardColumn
            // 
            this.cardColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cardColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.cardColumn.HeaderText = "Card";
            this.cardColumn.Name = "cardColumn";
            this.cardColumn.ReadOnly = true;
            // 
            // addPartnerCardButton
            // 
            this.addPartnerCardButton.Location = new System.Drawing.Point(285, 47);
            this.addPartnerCardButton.Name = "addPartnerCardButton";
            this.addPartnerCardButton.Size = new System.Drawing.Size(85, 23);
            this.addPartnerCardButton.TabIndex = 8;
            this.addPartnerCardButton.Text = "Add Card";
            this.addPartnerCardButton.UseVisualStyleBackColor = true;
            this.addPartnerCardButton.Click += new System.EventHandler(this.addPartnerCardButton_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dataGridView2.Location = new System.Drawing.Point(285, 76);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.RowTemplate.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(175, 358);
            this.dataGridView2.TabIndex = 9;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.beginEditValue);
            this.dataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Card";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // quantityToAdd
            // 
            this.quantityToAdd.Location = new System.Drawing.Point(194, 13);
            this.quantityToAdd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityToAdd.Name = "quantityToAdd";
            this.quantityToAdd.Size = new System.Drawing.Size(57, 20);
            this.quantityToAdd.TabIndex = 10;
            this.quantityToAdd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 446);
            this.Controls.Add(this.quantityToAdd);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.addPartnerCardButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.removeCardButton);
            this.Controls.Add(this.toUserButton);
            this.Controls.Add(this.toPartnerButton);
            this.Controls.Add(this.addCardButton);
            this.Controls.Add(this.cardAddingTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TradeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TradeForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityToAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cardAddingTextBox;
        private System.Windows.Forms.Button addCardButton;
        private System.Windows.Forms.Button toPartnerButton;
        private System.Windows.Forms.Button toUserButton;
        private System.Windows.Forms.Button removeCardButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addPartnerCardButton;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.NumericUpDown quantityToAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardColumn;
    }
}