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
    public partial class TradeEditForm : Form
    {
        public TradeEditForm(CardListItem cardEditing)
        {
            InitializeComponent();

            this.nameLabel.Text = cardEditing.Name;
            this.quantitySelect.Value = cardEditing.Quantity;
            this.setComboBox.Items.AddRange(SetDataHelper.AllSetsForCard(cardEditing.Name));
            this.setComboBox.SelectedItem = cardEditing.SetCode;
            this.saveEdits.Click += (sender, e) =>
            {
                cardEditing.Quantity = Convert.ToInt32(quantitySelect.Value);
                cardEditing.SetCode = this.setComboBox.SelectedItem.ToString();
                this.Close();
            };
        }
    }
}
