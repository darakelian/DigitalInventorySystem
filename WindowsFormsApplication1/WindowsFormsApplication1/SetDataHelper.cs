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
    class SetDataHelper
    {
        private HashSet<string> cardHash;
        private Dictionary<string, string[]> setDictionary;
        private Dictionary<string, string> mciSetDictionary;
        private AutoCompleteStringCollection acsc;

        /// <summary>
        /// Loads all pertinent set information from the JSON file. Still need to
        /// figure out why the program takes up so much RAM.
        /// </summary>
        public SetDataHelper()
        {
            //Load set data
            using (var stream = new MemoryStream(Properties.Resources.AllSetsArray))
            {
                using (var reader = new StreamReader(stream))
                {
                    cardHash = new HashSet<string>(); //Hash of each unique card name
                    setDictionary = new Dictionary<string, string[]>(); //Dictionary of set code and the card names in each set
                    mciSetDictionary = new Dictionary<string, string>(); //Dictionary of set codes and corresponding mci codes
                    List<string> cards = new List<string>();

                    string json = reader.ReadToEnd();
                    List<SetInfo> sets = JsonConvert.DeserializeObject<List<SetInfo>>(json);

                    if (sets != null)
                    {
                        foreach (SetInfo set in sets)
                        {
                            string setCode = set.code.ToUpper(); //Uppercase 3-4 character code of set
                            mciSetDictionary[setCode] = set.magicCardsInfoCode;
                            string[] _cards = new string[set.cards.Length]; //Array of card names in set
                            for (int i = 0; i < set.cards.Length; i++)
                            {
                                Card card = set.cards[i];
                                cards.Add(card.name + "-" + setCode);
                                cardHash.Add(card.name);
                                _cards[i] = card.name;
                            }
                            setDictionary.Add(setCode, _cards);
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
        public bool CardExists(string card)
        {
            return cardHash.Contains(card);
        }

        /// <summary>
        /// Checks to see if a card exists in a set.
        /// </summary>
        /// <param name="name">Name of the card being checked</param>
        /// <param name="code">Code of the set being checked</param>
        /// <returns>True if the card is in the set</returns>
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

        /// <summary>
        /// Returns a string[] containing all the cards in a specific set based
        /// on the provided 3-4 character set code.
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Cards in the set provided by the code</returns>
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

        /// <summary>
        /// Tries to get a set code for a card when a set wasn't specified by the
        /// user. It loops through all the sets and returns the first set that
        /// contains the card.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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
            return "LEA";
        }

        /// <summary>
        /// Converts a Gatherer 3-4 character set code to a magiccards.info set
        /// code in order to retrieve images.
        /// </summary>
        /// <param name="set">Gatherer set code</param>
        /// <returns>magiccards.info set code</returns>
        public string MciSetForSet(string set)
        {
            try
            {
                return mciSetDictionary[set];
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return "al";
            }
        }

        /// <summary>
        /// Gets the price of a card from its default set using TCGPlayer data.
        /// </summary>
        /// <param name="card">Name of card being priced</param>
        /// <returns>Float value of card's price</returns>
        public float GetPrice(string card)
        {
            return GetPrice(card, DefaultSet(card));
        }

        /// <summary>
        /// Gets the price of a card from a specified set using TCGPlayer data.
        /// </summary>
        /// <param name="card">Name of card being priced</param>
        /// <param name="set">Set being used for pricing</param>
        /// <returns></returns>
        public float GetPrice(string card, string set)
        {
            return 2.00F;
        }

        /// <summary>
        /// Public field accessing the AutoCompleteStringCollection that is created
        /// when the data is loaded.
        /// </summary>
        public AutoCompleteStringCollection AutoCompleteSource
        {
            get
            {
                return acsc;
            }
        }

    }
}
