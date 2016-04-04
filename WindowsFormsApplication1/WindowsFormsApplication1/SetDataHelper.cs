using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalInventory
{
    class SetDataHelper
    {
        private HashSet<string> cards;
        private Dictionary<string, string[]> setDictionary;

        public SetDataHelper(HashSet<string> cards, Dictionary<string, string[]> setDictionary)
        {
            this.cards = cards;
            this.setDictionary = setDictionary;
        }

        public bool cardExists(string card)
        {
            return cards.Contains(card);
        }

        public bool cardInSet(string name, string code)
        {
            string[] set = getSetForCode(code);
            if (set == null)
            {
                return false;
            }
            foreach (string card in set)
            {
                if (card.ToLower().Equals(name.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public string[] getSetForCode(string code)
        {
            try
            {
                return setDictionary[code.ToLower()];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public string getDefaultSet(string name)
        {
            /*foreach (SetInfo set in sets)
            {
                if (cardInSet(name, set.code))
                {
                    return set.code;
                }
            }*/
            string[] sets = setDictionary.Keys.ToArray();
            foreach (string set in sets)
            {
                if (cardInSet(name, set))
                {
                    return set.ToUpper();
                }
            }
            return "TST";
        }
    }
}
