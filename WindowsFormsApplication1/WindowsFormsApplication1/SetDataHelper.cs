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
        private Dictionary<string, int> multiverseDictionary;

        public SetDataHelper(HashSet<string> cards, Dictionary<string, string[]> setDictionary, Dictionary<string, int> multiverseDictionary)
        {
            this.cards = cards;
            this.setDictionary = setDictionary;
            this.multiverseDictionary = multiverseDictionary;
        }

        public bool CardExists(string card)
        {
            return cards.Contains(card);
        }

        public bool CardInSet(string name, string code)
        {
            string[] set = SetForCode(code);
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

        public string[] SetForCode(string code)
        {
            try
            {
                return setDictionary[code.ToUpper()];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public string DefaultSet(string name)
        {
            string[] sets = setDictionary.Keys.ToArray();
            foreach (string set in sets)
            {
                if (CardInSet(name, set))
                {
                    return set.ToUpper();
                }
            }
            return "TST";
        }

        public int IdForNameSet(string name)
        {
            return IdForNameSet(name, DefaultSet(name));
        }

        public int IdForNameSet(string name, string set)
        {
            try
            {
                return multiverseDictionary[name + set];
            }
            catch (KeyNotFoundException)
            {
                return 1;
            }
        }

        public float getPrice(string card)
        {
            return 2.00F;
        }

    }
}
