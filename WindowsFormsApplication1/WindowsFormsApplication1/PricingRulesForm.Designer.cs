namespace DigitalInventory
{
    partial class PricingRulesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.BulkFoilRareTextBox = new System.Windows.Forms.TextBox();
            this.FoilRareTrackBar = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FoilMythicTrackBar = new System.Windows.Forms.TrackBar();
            this.BulkMythicRareTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MythicTrackBar = new System.Windows.Forms.TrackBar();
            this.BulkFoilMythicRareTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.RareTrackBar = new System.Windows.Forms.TrackBar();
            this.BulkRareTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.BulkCommonTextBox = new System.Windows.Forms.TextBox();
            this.BulkUncommonTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.FoilRareTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FoilMythicTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MythicTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RareTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bulk Rare Price:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BulkFoilRareTextBox
            // 
            this.BulkFoilRareTextBox.Location = new System.Drawing.Point(238, 170);
            this.BulkFoilRareTextBox.MaxLength = 6;
            this.BulkFoilRareTextBox.Name = "BulkFoilRareTextBox";
            this.BulkFoilRareTextBox.Size = new System.Drawing.Size(104, 20);
            this.BulkFoilRareTextBox.TabIndex = 4;
            this.BulkFoilRareTextBox.TabStop = false;
            this.BulkFoilRareTextBox.Text = "$0";
            this.BulkFoilRareTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BulkFoilRareTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BulkFoilRareTextBox_KeyDown);
            // 
            // FoilRareTrackBar
            // 
            this.FoilRareTrackBar.LargeChange = 100;
            this.FoilRareTrackBar.Location = new System.Drawing.Point(238, 196);
            this.FoilRareTrackBar.Maximum = 1000;
            this.FoilRareTrackBar.Name = "FoilRareTrackBar";
            this.FoilRareTrackBar.Size = new System.Drawing.Size(104, 45);
            this.FoilRareTrackBar.SmallChange = 10;
            this.FoilRareTrackBar.TabIndex = 8;
            this.FoilRareTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(13, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Bulk Rare Price Threshold:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label5, "The value of this determines the cut off for a bulk rare.");
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = "Bulk Foil Rare Price Threshold:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FoilMythicTrackBar
            // 
            this.FoilMythicTrackBar.LargeChange = 100;
            this.FoilMythicTrackBar.Location = new System.Drawing.Point(238, 273);
            this.FoilMythicTrackBar.Maximum = 1000;
            this.FoilMythicTrackBar.Name = "FoilMythicTrackBar";
            this.FoilMythicTrackBar.Size = new System.Drawing.Size(104, 45);
            this.FoilMythicTrackBar.SmallChange = 10;
            this.FoilMythicTrackBar.TabIndex = 15;
            this.FoilMythicTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // BulkMythicRareTextBox
            // 
            this.BulkMythicRareTextBox.Location = new System.Drawing.Point(238, 93);
            this.BulkMythicRareTextBox.MaxLength = 6;
            this.BulkMythicRareTextBox.Name = "BulkMythicRareTextBox";
            this.BulkMythicRareTextBox.Size = new System.Drawing.Size(104, 20);
            this.BulkMythicRareTextBox.TabIndex = 14;
            this.BulkMythicRareTextBox.Text = "$0";
            this.BulkMythicRareTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BulkMythicRareTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BulkMythicRareTextBox_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Bulk Foil Rare Price:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 23);
            this.label4.TabIndex = 24;
            this.label4.Text = "Bulk Foil Mythic Rare Price Threshold:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MythicTrackBar
            // 
            this.MythicTrackBar.LargeChange = 100;
            this.MythicTrackBar.Location = new System.Drawing.Point(238, 119);
            this.MythicTrackBar.Maximum = 1000;
            this.MythicTrackBar.Name = "MythicTrackBar";
            this.MythicTrackBar.Size = new System.Drawing.Size(104, 45);
            this.MythicTrackBar.SmallChange = 10;
            this.MythicTrackBar.TabIndex = 23;
            this.MythicTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // BulkFoilMythicRareTextBox
            // 
            this.BulkFoilMythicRareTextBox.Location = new System.Drawing.Point(238, 247);
            this.BulkFoilMythicRareTextBox.MaxLength = 6;
            this.BulkFoilMythicRareTextBox.Name = "BulkFoilMythicRareTextBox";
            this.BulkFoilMythicRareTextBox.Size = new System.Drawing.Size(104, 20);
            this.BulkFoilMythicRareTextBox.TabIndex = 22;
            this.BulkFoilMythicRareTextBox.Text = "$0";
            this.BulkFoilMythicRareTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BulkFoilMythicRareTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BulkFoilMythicRareTextBox_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 25);
            this.label6.TabIndex = 21;
            this.label6.Text = "Bulk Foil Mythic Rare Price:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(13, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 23);
            this.label7.TabIndex = 20;
            this.label7.Text = "Bulk Mythic Rare Price Threshold:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RareTrackBar
            // 
            this.RareTrackBar.LargeChange = 100;
            this.RareTrackBar.Location = new System.Drawing.Point(238, 42);
            this.RareTrackBar.Maximum = 1000;
            this.RareTrackBar.Name = "RareTrackBar";
            this.RareTrackBar.Size = new System.Drawing.Size(104, 45);
            this.RareTrackBar.SmallChange = 10;
            this.RareTrackBar.TabIndex = 19;
            this.RareTrackBar.TickFrequency = 50;
            this.toolTip1.SetToolTip(this.RareTrackBar, "The value of this determines the cut off for a bulk rare.");
            this.RareTrackBar.ValueChanged += new System.EventHandler(this.RareTrackBar_ValueChanged);
            // 
            // BulkRareTextBox
            // 
            this.BulkRareTextBox.Location = new System.Drawing.Point(238, 16);
            this.BulkRareTextBox.MaxLength = 6;
            this.BulkRareTextBox.Name = "BulkRareTextBox";
            this.BulkRareTextBox.Size = new System.Drawing.Size(104, 20);
            this.BulkRareTextBox.TabIndex = 18;
            this.BulkRareTextBox.Text = "$0";
            this.BulkRareTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BulkRareTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BulkRareTextBox_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(194, 25);
            this.label8.TabIndex = 17;
            this.label8.Text = "Bulk Mythic Rare Price:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(13, 312);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(194, 23);
            this.label9.TabIndex = 25;
            this.label9.Text = "Bulk Common Price:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(13, 347);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(194, 23);
            this.label10.TabIndex = 26;
            this.label10.Text = "Bulk Uncommon Price:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BulkCommonTextBox
            // 
            this.BulkCommonTextBox.Location = new System.Drawing.Point(238, 314);
            this.BulkCommonTextBox.MaxLength = 6;
            this.BulkCommonTextBox.Name = "BulkCommonTextBox";
            this.BulkCommonTextBox.Size = new System.Drawing.Size(104, 20);
            this.BulkCommonTextBox.TabIndex = 27;
            this.BulkCommonTextBox.Text = "$0";
            this.BulkCommonTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BulkUncommonTextBox
            // 
            this.BulkUncommonTextBox.Location = new System.Drawing.Point(238, 349);
            this.BulkUncommonTextBox.MaxLength = 6;
            this.BulkUncommonTextBox.Name = "BulkUncommonTextBox";
            this.BulkUncommonTextBox.Size = new System.Drawing.Size(104, 20);
            this.BulkUncommonTextBox.TabIndex = 28;
            this.BulkUncommonTextBox.Text = "$0";
            this.BulkUncommonTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PricingRulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 390);
            this.Controls.Add(this.BulkUncommonTextBox);
            this.Controls.Add(this.BulkCommonTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MythicTrackBar);
            this.Controls.Add(this.BulkFoilMythicRareTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RareTrackBar);
            this.Controls.Add(this.BulkRareTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FoilMythicTrackBar);
            this.Controls.Add(this.BulkMythicRareTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FoilRareTrackBar);
            this.Controls.Add(this.BulkFoilRareTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PricingRulesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pricing Rules";
            ((System.ComponentModel.ISupportInitialize)(this.FoilRareTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FoilMythicTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MythicTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RareTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BulkFoilRareTextBox;
        private System.Windows.Forms.TrackBar FoilRareTrackBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar FoilMythicTrackBar;
        private System.Windows.Forms.TextBox BulkMythicRareTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar MythicTrackBar;
        private System.Windows.Forms.TextBox BulkFoilMythicRareTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar RareTrackBar;
        private System.Windows.Forms.TextBox BulkRareTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox BulkCommonTextBox;
        private System.Windows.Forms.TextBox BulkUncommonTextBox;
    }
}