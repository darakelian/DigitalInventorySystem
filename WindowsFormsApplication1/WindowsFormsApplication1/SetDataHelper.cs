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
                return setDictionary[code.ToUpper()];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public string getDefaultSet(string name)
        {
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

        public int getIdForNameSet(string name)
        {
            return getIdForNameSet(name, getDefaultSet(name));
        }

        public int getIdForNameSet(string name, string set)
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

        public string parseBracketTagAsSet(string s)
        {
            string conditionOrSet = s.Contains("[") ? s.Trim(new char[] { '[', ']' }) : s.Trim(new char[] { '(', ')' });
            conditionOrSet = conditionOrSet.ToLower();
            return conditionOrSet.ToUpper();
        }

        public string parseBracketTag(string s)
        {
            string conditionOrSet = s.Contains("[") ? s.Trim(new char[] { '[', ']' }) : s.Trim(new char[] { '(', ')' });
            conditionOrSet = conditionOrSet.ToLower();
            return conditionOrSet;
        }
    }
}
