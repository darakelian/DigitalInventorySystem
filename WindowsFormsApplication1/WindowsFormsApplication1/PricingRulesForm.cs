using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalInventory
{
    public partial class PricingRulesForm : Form
    {
        public PricingRulesForm()
        {
            InitializeComponent();
            BulkRareTextBox.Text = "$" + Convert.ToString(Properties.Settings.Default.BulkRarePrice);
            RareTrackBar.Value = Properties.Settings.Default.BulkRarePriceThreshold;
        }

        private void BulkRareTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                string text = ((TextBox)sender).Text;
                if (text.Contains("$"))
                {
                    text = text.Replace("$", "");
                }
                double val = Convert.ToDouble(text);
                Properties.Settings.Default.BulkRarePrice = (float)val;
                Properties.Settings.Default.Save();
                ((TextBox)sender).Text = "$" + text;
            }
        }

        private void RareTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.BulkRarePriceThreshold = ((TrackBar)sender).Value;
            Properties.Settings.Default.Save();
        }

        private void BulkMythicRareTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                string text = ((TextBox)sender).Text;
                if (text.Contains("$"))
                {
                    text = text.Replace("$", "");
                }
                double val = Convert.ToDouble(text) * 100;
                MythicTrackBar.Value = (int)val > MythicTrackBar.Maximum ? MythicTrackBar.Maximum : (int)val;
                ((TextBox)sender).Text = "$" + text;
            }
        }

        private void BulkFoilRareTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                string text = ((TextBox)sender).Text;
                if (text.Contains("$"))
                {
                    text = text.Replace("$", "");
                }
                double val = Convert.ToDouble(text) * 100;
                FoilRareTrackBar.Value = (int)val > FoilRareTrackBar.Maximum ? FoilRareTrackBar.Maximum : (int)val;
                ((TextBox)sender).Text = "$" + text;
            }
        }

        private void BulkFoilMythicRareTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                string text = ((TextBox)sender).Text;
                if (text.Contains("$"))
                {
                    text = text.Replace("$", "");
                }
                double val = Convert.ToDouble(text) * 100;
                FoilMythicTrackBar.Value = (int)val > FoilMythicTrackBar.Maximum ? FoilMythicTrackBar.Maximum : (int)val;
                ((TextBox)sender).Text = "$" + text;
            }
        }
    }
}
