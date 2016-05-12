using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace DigitalInventory
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Value storing if a save is needed (aka if new data was put into the
        /// database).
        /// </summary>
        private bool saveNeeded = false;

        /// <summary>
        /// Called whenever a card is added. This indicates that the user should
        /// save the database.
        /// </summary>
        private void NotifySaveNeeded()
        {
            this.Text = this.Text + "*";
            saveNeeded = true;
        }

        /// <summary>
        /// Called whenever the user indicates to save the database. This removes the
        /// asterisk from the title and saves the database.
        /// </summary>
        private void NotifySaveDone()
        {
            this.Text = this.Text.TrimEnd('*');
            saveNeeded = false;

            inventoryBindingSource.EndEdit();
            inventoryTableAdapter.Update(inventoryDataSet.Inventory);
        }

        /// <summary>
        /// Called as the form is closing. If there changes to the databse that
        /// weren't saved, prompts the user to double check if they want to exit
        /// via a DialogResult box. If yes, exits without saving, if no, stops
        /// the form from closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saveNeeded)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to close without saving? " +
                    "Your cards will not be saved", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            //Serialize price data if it has changed.
            TcgPlayerHttpClient.SerializeCardPrices();
        }

        /// <summary>
        /// Clears the textbox, sets condition selection to NM and quantity to 1.
        /// </summary>
        private void ResetCardParameters()
        {
            cardNameToAdd.Text = "";
            conditionSelection.SelectedIndex = 0;
            quantitySelection.Value = 1;
            FoilCheckBox.Checked = false;
        }

    }

    public class PriceFetcherWorker
    {
        public void UpdatePrices()
        {

        }
    }
}
