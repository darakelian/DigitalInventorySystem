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
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 411);
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
    }
}