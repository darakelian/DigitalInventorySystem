namespace DigitalInventory
{
    partial class TradeEditForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.quantitySelect = new System.Windows.Forms.NumericUpDown();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.setComboBox = new System.Windows.Forms.ComboBox();
            this.setLabel = new System.Windows.Forms.Label();
            this.saveEdits = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.quantitySelect)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.nameLabel.Location = new System.Drawing.Point(0, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(192, 31);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "cardName";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // quantitySelect
            // 
            this.quantitySelect.Location = new System.Drawing.Point(55, 34);
            this.quantitySelect.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantitySelect.Name = "quantitySelect";
            this.quantitySelect.Size = new System.Drawing.Size(125, 20);
            this.quantitySelect.TabIndex = 1;
            this.quantitySelect.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // quantityLabel
            // 
            this.quantityLabel.Location = new System.Drawing.Point(0, 31);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(49, 23);
            this.quantityLabel.TabIndex = 2;
            this.quantityLabel.Text = "Quantity:";
            this.quantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // setComboBox
            // 
            this.setComboBox.FormattingEnabled = true;
            this.setComboBox.Location = new System.Drawing.Point(55, 81);
            this.setComboBox.Name = "setComboBox";
            this.setComboBox.Size = new System.Drawing.Size(125, 21);
            this.setComboBox.TabIndex = 3;
            // 
            // setLabel
            // 
            this.setLabel.Location = new System.Drawing.Point(0, 79);
            this.setLabel.Name = "setLabel";
            this.setLabel.Size = new System.Drawing.Size(49, 23);
            this.setLabel.TabIndex = 4;
            this.setLabel.Text = "Set:";
            this.setLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // saveEdits
            // 
            this.saveEdits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.saveEdits.Location = new System.Drawing.Point(55, 133);
            this.saveEdits.Name = "saveEdits";
            this.saveEdits.Size = new System.Drawing.Size(79, 23);
            this.saveEdits.TabIndex = 5;
            this.saveEdits.Text = "Done";
            this.saveEdits.UseVisualStyleBackColor = true;
            // 
            // TradeEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 168);
            this.Controls.Add(this.saveEdits);
            this.Controls.Add(this.setLabel);
            this.Controls.Add(this.setComboBox);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.quantitySelect);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TradeEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit";
            ((System.ComponentModel.ISupportInitialize)(this.quantitySelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.NumericUpDown quantitySelect;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.ComboBox setComboBox;
        private System.Windows.Forms.Label setLabel;
        private System.Windows.Forms.Button saveEdits;
    }
}