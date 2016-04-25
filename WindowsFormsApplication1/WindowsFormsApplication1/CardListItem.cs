using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalInventory
{
    public class CardListItem
    {

        private string card, set;

        private int quantity;

        public CardListItem(string card, string set, int quantity)
        {
            this.card = card;
            this.set = set;
            this.quantity = quantity;
        }

        public override string ToString()
        {
            return card + "\n" + set + "    " + Convert.ToString(quantity);
        }
    }
}
