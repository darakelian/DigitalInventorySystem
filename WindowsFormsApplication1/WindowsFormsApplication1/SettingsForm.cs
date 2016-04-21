using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalInventory
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            localFileDirectory.Text = Properties.Settings.Default.LocalFilesDirectory;
            saveLocalImages.Checked = Properties.Settings.Default.SaveLocalFiles;
        }

        /// <summary>
        /// Prompts the user to choose a directory to save the local images to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void localFileDirectoryButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Properties.Settings.Default.LocalFilesDirectory);
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Select the folder to save downloaded images to.";
            dialog.ShowNewFolderButton = true;
            dialog.RootFolder = Environment.SpecialFolder.MyDocuments;
            DialogResult result = dialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                string folderName = dialog.SelectedPath;
                localFileDirectory.Text = folderName;
                Properties.Settings.Default.LocalFilesDirectory = folderName;
                Properties.Settings.Default.Save();
                Console.WriteLine(Properties.Settings.Default.LocalFilesDirectory);
            }
        }

        /// <summary>
        /// Toggles the setting of saving local images. If enabled, will create
        /// a directory at the specified location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveLocalImages_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            Properties.Settings.Default.SaveLocalFiles = box.Checked;
            if (Properties.Settings.Default.LocalFilesDirectory == "")
            {
                //Prompt the user to select a save location
                localFileDirectoryButton_Click(null, null);
                if (!Directory.Exists(Properties.Settings.Default.LocalFilesDirectory))
                {
                    Directory.CreateDirectory(Properties.Settings.Default.LocalFilesDirectory);
                }
            }
        }

        private void BulkCommonTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                string text = ((TextBox)sender).Text;
                if (text.Contains("$"))
                {
                    text = text.Replace("$", "");
                }
                double val = Convert.ToDouble(text);
                Properties.Settings.Default.BulkCommonPrice = (float)val;
                Properties.Settings.Default.Save();
                ((TextBox)sender).Text = "$" + text;
            }
        }

        private void BulkUncommonTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                string text = ((TextBox)sender).Text;
                if (text.Contains("$"))
                {
                    text = text.Replace("$", "");
                }
                double val = Convert.ToDouble(text);
                Properties.Settings.Default.BulkUncommonPrice = (float)val;
                Properties.Settings.Default.Save();
                ((TextBox)sender).Text = "$" + text;
            }
        }
    }
}
