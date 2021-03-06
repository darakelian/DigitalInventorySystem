﻿using System;
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
    public partial class TradeForm : Form
    {
        public TradeForm()
        {
            InitializeComponent();
            this.cardAddingTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.cardAddingTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.cardAddingTextBox.AutoCompleteCustomSource = SetDataHelper.AutoCompleteSource;
        }

        private void addCardButton_Click(object sender, EventArgs e)
        {
            string cardname = this.cardAddingTextBox.Text;
            string name = cardname.Substring(0, cardname.LastIndexOf("-"));
            string set = cardname.Substring(cardname.LastIndexOf("-") + 1);
            int quantity = 1;
            if (SetDataHelper.CardExists(name) && SetDataHelper.SetForCode(set) != null)
            {
                CardListItem item = new CardListItem(name, set, quantity);
                dataGridView1.Rows.Add(item);
                dataGridView1.ClearSelection();
            }
        }

        private void addPartnerCardButton_Click(object sender, EventArgs e)
        {
            string cardname = this.cardAddingTextBox.Text;
            string name = cardname.Substring(0, cardname.LastIndexOf("-"));
            string set = cardname.Substring(cardname.LastIndexOf("-") + 1);
            int quantity = 1;
            if (SetDataHelper.CardExists(name) && SetDataHelper.SetForCode(set) != null)
            {
                CardListItem item = new CardListItem(name, set, quantity);
                dataGridView2.Rows.Add(item);
                dataGridView2.ClearSelection();
            }
        }

        /// <summary>
        /// Adds a card to the trade from the existing inventory.
        /// </summary>
        /// <param name="item"></param>
        public void AddCard(CardListItem item)
        {
            dataGridView1.Rows.Add(item);
            dataGridView1.ClearSelection();
            this.quantityToAdd.Focus();
            Console.WriteLine("Added card from existing inventory");
        }

        /// <summary>
        /// Sends the currently selected card over to the partner's side of the trade.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toPartnerButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            if (selectedRow != null)
            {
                DataGridViewRow rowCopy = selectedRow;
                dataGridView1.Rows.Remove(selectedRow);
                dataGridView2.Rows.Add(rowCopy);
                dataGridView2.ClearSelection();
            }
        }

        /// <summary>
        /// Sends the currently selected card over to the user's side of the trade.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toUserButton_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count <= 0)
            {
                return;
            }
            DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
            if (selectedRow != null)
            {
                DataGridViewRow rowCopy = selectedRow;
                dataGridView2.Rows.Remove(selectedRow);
                dataGridView1.Rows.Add(rowCopy);
                dataGridView1.ClearSelection();
            }
        }

        private void removeCardButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                dataGridView1.Rows.Remove(selectedRow);
            }
            if (dataGridView2.SelectedRows.Count >= 1)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                dataGridView2.Rows.Remove(selectedRow);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count >= 1)
            {
                dataGridView2.ClearSelection();
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                dataGridView1.ClearSelection();
            }
        }

        private void beginEditValue(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            DataGridViewRow row = view.Rows[e.RowIndex];
            Console.WriteLine(row.Cells[0].Value);
            try
            {
                DataGridViewCell cell = row.Cells[0];
                CardListItem cardItem = (CardListItem)row.Cells[0].Value;
                TradeEditForm editForm = new TradeEditForm(cardItem);
                editForm.ShowDialog(this);
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }

}
