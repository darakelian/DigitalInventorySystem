namespace DigitalInventory
{
    partial class SettingsForm
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
            this.saveLocalImages = new System.Windows.Forms.CheckBox();
            this.localFileDirectory = new System.Windows.Forms.Label();
            this.localFileDirectoryButton = new System.Windows.Forms.Button();
            this.BulkUncommonTextBox = new System.Windows.Forms.TextBox();
            this.BulkCommonTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveLocalImages
            // 
            this.saveLocalImages.AutoSize = true;
            this.saveLocalImages.Location = new System.Drawing.Point(13, 13);
            this.saveLocalImages.Name = "saveLocalImages";
            this.saveLocalImages.Size = new System.Drawing.Size(117, 17);
            this.saveLocalImages.TabIndex = 0;
            this.saveLocalImages.Text = "Save Local Images";
            this.saveLocalImages.UseVisualStyleBackColor = true;
            this.saveLocalImages.CheckedChanged += new System.EventHandler(this.saveLocalImages_CheckedChanged);
            // 
            // localFileDirectory
            // 
            this.localFileDirectory.Location = new System.Drawing.Point(13, 37);
            this.localFileDirectory.Name = "localFileDirectory";
            this.localFileDirectory.Size = new System.Drawing.Size(222, 36);
            this.localFileDirectory.TabIndex = 1;
            this.localFileDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // localFileDirectoryButton
            // 
            this.localFileDirectoryButton.Location = new System.Drawing.Point(242, 37);
            this.localFileDirectoryButton.Name = "localFileDirectoryButton";
            this.localFileDirectoryButton.Size = new System.Drawing.Size(80, 36);
            this.localFileDirectoryButton.TabIndex = 2;
            this.localFileDirectoryButton.Text = "Directory...";
            this.localFileDirectoryButton.UseVisualStyleBackColor = true;
            this.localFileDirectoryButton.Click += new System.EventHandler(this.localFileDirectoryButton_Click);
            // 
            // BulkUncommonTextBox
            // 
            this.BulkUncommonTextBox.Location = new System.Drawing.Point(235, 119);
            this.BulkUncommonTextBox.MaxLength = 6;
            this.BulkUncommonTextBox.Name = "BulkUncommonTextBox";
            this.BulkUncommonTextBox.Size = new System.Drawing.Size(104, 20);
            this.BulkUncommonTextBox.TabIndex = 32;
            this.BulkUncommonTextBox.Text = "0";
            this.BulkUncommonTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BulkUncommonTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BulkUncommonTextBox_KeyDown);
            // 
            // BulkCommonTextBox
            // 
            this.BulkCommonTextBox.Location = new System.Drawing.Point(235, 84);
            this.BulkCommonTextBox.MaxLength = 6;
            this.BulkCommonTextBox.Name = "BulkCommonTextBox";
            this.BulkCommonTextBox.Size = new System.Drawing.Size(104, 20);
            this.BulkCommonTextBox.TabIndex = 31;
            this.BulkCommonTextBox.Text = "0";
            this.BulkCommonTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BulkCommonTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BulkCommonTextBox_KeyDown);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(10, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(194, 23);
            this.label10.TabIndex = 30;
            this.label10.Text = "Bulk Uncommon Price:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(10, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(194, 23);
            this.label9.TabIndex = 29;
            this.label9.Text = "Bulk Common Price:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 149);
            this.Controls.Add(this.BulkUncommonTextBox);
            this.Controls.Add(this.BulkCommonTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.localFileDirectoryButton);
            this.Controls.Add(this.localFileDirectory);
            this.Controls.Add(this.saveLocalImages);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox saveLocalImages;
        private System.Windows.Forms.Label localFileDirectory;
        private System.Windows.Forms.Button localFileDirectoryButton;
        private System.Windows.Forms.TextBox BulkUncommonTextBox;
        private System.Windows.Forms.TextBox BulkCommonTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}