using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalInventory
{
    public class SetDataHelper
    {
        private static HashSet<string> cardHash;
        private static Dictionary<string, object[]> setDictionary;
        private static Dictionary<string, int> gathererIdsDictionary;
        private static Dictionary<string, string> rarityDictionary;
        private static AutoCompleteStringCollection acsc;

        /// <summary>
        /// Loads all pertinent set information from the JSON file. Still need to
        /// figure out why the program takes up so much RAM.
        /// </summary>
        public static void Load()
        {
            //Load set data
            using (var stream = new MemoryStream(Properties.Resources.AllSetsArray))
            {
                using (var reader = new StreamReader(stream))
                {
                    cardHash = new HashSet<string>(); //Hash of each unique card name
                    setDictionary = new Dictionary<string, object[]>(); //Dictionary of set code and the card names in each set
                    gathererIdsDictionary = new Dictionary<string, int>(); //Dictionary of gatherer ids
                    rarityDictionary = new Dictionary<string, string>(); //Dictionary of raritys
                    List<string> cards = new List<string>();

                    string json = reader.ReadToEnd();
                    List<SetInfo> sets = JsonConvert.DeserializeObject<List<SetInfo>>(json);

                    if (sets != null)
                    {
                        foreach (SetInfo set in sets)
                        {
                            string setCode = set.code; //Uppercase 3-4 character code of set
                            if (setCode.ElementAt(0).Equals('p'))
                            {
                                continue;
                            }
                            setCode = setCode.ToUpper();
                            string[] _cards = new string[set.cards.Length]; //Array of card names in set
                            for (int i = 0; i < set.cards.Length; i++)
                            {
                                cards.Add(set.cards[i].name + "-" + setCode);
                                if (!gathererIdsDictionary.Keys.Contains(set.cards[i].name.ToLower() + "-" + setCode))
                                {
                                    gathererIdsDictionary[set.cards[i].name.ToLower() + "-" + setCode] = set.cards[i].multiverseid;
                                }
                                if (!rarityDictionary.Keys.Contains(set.cards[i].name.ToLower() + "-" + setCode))
                                {
                                    rarityDictionary[set.cards[i].name.ToLower() + "-" + setCode] = set.cards[i].rarity;
                                }
                                cardHash.Add(set.cards[i].name);
                                _cards[i] = set.cards[i].name;
                            }
                            setDictionary[setCode] = new object[] { set.name, _cards };
                        }
                        acsc = new AutoCompleteStringCollection();
                        acsc.AddRange(cards.ToArray());
                        cards.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// Checks to see if a card was ever printed regardless of its set.
        /// </summary>
        /// <param name="card">Name of the card being checked</param>
        /// <returns>True if the card hash has the card</returns>
        public static bool CardExists(string card)
        {
            return cardHash.Contains(card);
        }

        /// <summary>
        /// Checks to see if a card exists in a set.
        /// </summary>
        /// <param name="name">Name of the card being checked</param>
        /// <param name="code">Code of the set being checked</param>
        /// <returns>True if the card is in the set</returns>
        public static bool CardInSet(string name, string code)
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

        /// <summary>
        /// Returns a string[] containing all the cards in a specific set based
        /// on the provided 3-4 character set code.
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Cards in the set provided by the code</returns>
        public static string[] SetForCode(string code)
        {
            try
            {
                return (string[])setDictionary[code][1];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public static string SetNameForCode(string code)
        {
            try
            {
                return (string)setDictionary[code][0];
            }
            catch (KeyNotFoundException)
            {
                return "alpha-edition";
            }
        }

        /// <summary>
        /// Tries to get a set code for a card when a set wasn't specified by the
        /// user. It loops through all the sets and returns the first set that
        /// contains the card.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string DefaultSet(string name)
        {
            string[] sets = setDictionary.Keys.ToArray();
            foreach (string set in sets)
            {
                if (CardInSet(name, set))
                {
                    return set.ToUpper();
                }
            }
            return "LEA";
        }

        public static int GathererIdForCard(string card, string set)
        {
            if (set == null)
            {
                set = DefaultSet(card);
            }
            try
            {
                return gathererIdsDictionary[card.ToLower() + "-" + set];
            }
            catch (KeyNotFoundException)
            {
                return 1;
            }
        }


        /// <summary>
        /// Gets the price of a card from its default set using TCGPlayer data.
        /// </summary>
        /// <param name="card">Name of card being priced</param>
        /// <returns>Float value of card's price</returns>
        public static float GetPrice(string card)
        {
            return GetPrice(card, DefaultSet(card));
        }

        /// <summary>
        /// Gets the price of a card from a specified set using TCGPlayer data.
        /// </summary>
        /// <param name="card">Name of card being priced</param>
        /// <param name="set">Set being used for pricing</param>
        /// <returns></returns>
        public static float GetPrice(string card, string set)
        {
            return 2.00F;
        }

        /// <summary>
        /// Gets the rarity of a card from it's default set.
        /// </summary>
        /// <param name="card"></param>
        /// <returns>String value of card's rarity</returns>
        public static string GetRarity(string card)
        {
            return GetRarity(card, DefaultSet(card));
        }

        /// <summary>
        /// Gets the rarity of a card from the specified set.
        /// </summary>
        /// <param name="card"></param>
        /// <param name="set"></param>
        /// <returns></returns>
        public static string GetRarity(string card, string set)
        {
            try
            {
                return rarityDictionary[card.ToLower() + "-" + set];
            }
            catch (KeyNotFoundException)
            {
                return "common";
            }
        }

        /// <summary>
        /// Public field accessing the AutoCompleteStringCollection that is created
        /// when the data is loaded.
        /// </summary>
        public static AutoCompleteStringCollection AutoCompleteSource
        {
            get
            {
                return acsc;
            }
        }

        /// <summary>
        /// Converts a fully qualified condition type to the 2 letter code.
        /// Defaults to return NM.
        /// </summary>
        /// <param name="longCondition"></param>
        /// <returns></returns>
        public static string ShortenCondition(string longCondition)
        {
            if (longCondition.Equals("heavily played"))
            {
                return "HP";
            }
            else if (longCondition.Equals("moderately played"))
            {
                return "MP";
            }
            else if (longCondition.Equals("lightly played"))
            {
                return "LP";
            }
            else
            {
                return "MN";
            }
        }

        public static string CreateTCGPlayerURL(string card, string set)
        {
            string name = card.ToLower().Replace(" ", "-");
            string longSet = SetNameForCode(set).ToLower().Replace(" ", "-");
            return String.Format("http://shop.tcgplayer.com/magic/{0}/{1}", longSet, name);
        }

    }

}
