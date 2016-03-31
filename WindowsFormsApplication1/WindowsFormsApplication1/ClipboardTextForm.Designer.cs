namespace WindowsFormsApplication1
{
    partial class ClipboardTextForm
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
            this.clipboardTextbox = new System.Windows.Forms.TextBox();
            this.addCardsFromClip = new System.Windows.Forms.Button();
            this.cancelCardsFromClip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clipboardTextbox
            // 
            this.clipboardTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clipboardTextbox.Location = new System.Drawing.Point(0, 0);
            this.clipboardTextbox.Multiline = true;
            this.clipboardTextbox.Name = "clipboardTextbox";
            this.clipboardTextbox.Size = new System.Drawing.Size(283, 220);
            this.clipboardTextbox.TabIndex = 0;
            this.clipboardTextbox.WordWrap = false;
            // 
            // addCardsFromClip
            // 
            this.addCardsFromClip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addCardsFromClip.Location = new System.Drawing.Point(127, 226);
            this.addCardsFromClip.Name = "addCardsFromClip";
            this.addCardsFromClip.Size = new System.Drawing.Size(75, 23);
            this.addCardsFromClip.TabIndex = 1;
            this.addCardsFromClip.Text = "OK";
            this.addCardsFromClip.UseVisualStyleBackColor = true;
            // 
            // cancelCardsFromClip
            // 
            this.cancelCardsFromClip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelCardsFromClip.Location = new System.Drawing.Point(208, 226);
            this.cancelCardsFromClip.Name = "cancelCardsFromClip";
            this.cancelCardsFromClip.Size = new System.Drawing.Size(75, 23);
            this.cancelCardsFromClip.TabIndex = 2;
            this.cancelCardsFromClip.Text = "Cancel";
            this.cancelCardsFromClip.UseVisualStyleBackColor = true;
            // 
            // ClipboardTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cancelCardsFromClip);
            this.Controls.Add(this.addCardsFromClip);
            this.Controls.Add(this.clipboardTextbox);
            this.Name = "ClipboardTextForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import from Clipboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox clipboardTextbox;
        public System.Windows.Forms.Button cancelCardsFromClip;
        public System.Windows.Forms.Button addCardsFromClip;
    }
}