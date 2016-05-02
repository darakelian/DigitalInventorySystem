using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace DigitalInventory
{
    public class TcgPlayerHttpClient
    {
        public static Dictionary<Price, DateTime> cachedPriceTimestamps = new Dictionary<Price, DateTime>();
        public static Dictionary<string, Price> cachedPrices = new Dictionary<string, Price>();
        public const string APIKEY = "MTGDIGITALBINDER";

        /// <summary>
        /// Returns the median price of a card from a given set.
        /// </summary>
        /// <param name="cardName"></param>
        /// <param name="setCode"></param>
        /// <returns>Non foil price</returns>
        public static float RetrievePrice(string cardName, string setCode)
        {
            return RetrievePrice(cardName, setCode, false);
        }

        /// <summary>
        /// Checks to see if the price was already cached within the last day.
        /// If yes, returns the stored price. If no price was cached or it was
        /// more than a day since the last price update, a new price request
        /// is created and sent to the tcgplayer servers.
        /// </summary>
        /// <param name="cardName"></param>
        /// <param name="setCode"></param>
        /// <param name="foil"></param>
        /// <returns></returns>
        public static float RetrievePrice(string cardName, string setCode, bool foil)
        {
            string key = cardName + "-" + setCode;
            if (cachedPrices.ContainsKey(key))
            {
                Price cachedPrice = cachedPrices[key];
                DateTime lastTime = cachedPriceTimestamps[cachedPrice];
                DateTime currentTime = DateTime.Now;
                TimeSpan duration = currentTime - lastTime;
                if (duration.Hours >= 24)
                {
                    return RetrieveTCGPrice(cardName, setCode, foil);
                }
                return foil ? cachedPrice.Foil : cachedPrice.Med != 0 ? cachedPrice.Med : cachedPrice.Foil;
            }
            return RetrieveTCGPrice(cardName, setCode, foil);
        }

        private static float RetrieveTCGPrice(string cardName, string setCode, bool foil)
        {
            WebRequest request = WebRequest.Create(SetDataHelper.CreateTCGPlayerURL(cardName, setCode));
            WebResponse response = request.GetResponse();
            float[] prices = new float[4];
            using (Stream dataStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    string responseString = reader.ReadToEnd();
                    var xml = XDocument.Parse(responseString);
                    var query = from el in xml.Descendants()
                                where el.Name.ToString().Contains("price")
                                select el;
                    int priceIdx = 0;
                    foreach (XElement el in query)
                    {
                        prices[priceIdx] = (float)Convert.ToDouble(el.Value);
                        priceIdx++;
                    }
                }
            }
            Price price = new Price(cardName, setCode, prices[1], prices[2], prices[0], prices[3]);
            cachedPrices[cardName + "-" + setCode] = price;
            cachedPriceTimestamps[price] = DateTime.Now;
            //If not foil (say user forget to specify) but the card only exists
            //in foil, return the foil price.
            Console.WriteLine("Cached price");
            return foil ? price.Foil : price.Med != 0 ? price.Med : price.Foil;
        }
    }
}
