using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DigitalInventory
{
    public class TcgPlayerHttpClient
    {
        public static Dictionary<string, DateTime> cachedPrices = new Dictionary<string, DateTime>();

        public static float RetrievePrice(string cardName, string setCode)
        {
            return RetrievePrice(cardName, setCode, false);
        }

        public static float RetrievePrice(string cardName, string setCode, bool foil)
        {
            if (SetDataHelper.CardExists(cardName) && SetDataHelper.SetForCode(setCode) != null)
            {
                string tcgPlayerUrl = SetDataHelper.CreateTCGPlayerURL(cardName, setCode);
                string[] prices = new string[6];
                int numPricesFound = 0;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(tcgPlayerUrl);
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                request.Host = "shop.tcgplayer.com";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.112 Safari/537.36";
                request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
                request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                request.Referer = TCGPlayerRefererURL(cardName, setCode);
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(new Cookie("D_SID", "144.118.76.251:xbbaYJ2RKfeFhMwmw3MJdFZsoi++1D9Igzev3NrvhF4") { Domain = "shop.tcgplayer.com" });
                request.CookieContainer.Add(new Cookie("__utma", "1.1252528496.1452803276.1452803276.1452803276.1") { Domain = "shop.tcgplayer.com" });
                request.CookieContainer.Add(new Cookie("__utmz", "1.1452803276.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)") { Domain = "shop.tcgplayer.com" });
                request.CookieContainer.Add(new Cookie("tcgpartner", "PK=mtgtcg&M=1") { Domain = "shop.tcgplayer.com" });
                request.CookieContainer.Add(new Cookie("TCGAuthTicket_Product", "14D88BEF695BCD9708B4FA51A3D6FE282D64514ECEB3E0C782C8E5F5BE32CC6704C9D291564F3D6FC6C93A447C0CA02BD99627AC87831A0AD51B71B9AABF85E9446B7DDBBB4B9C24C53066D346FDB6A07FE6BEA48793C84304D7E29AA7506ED7E7B7637AF1C7AE6AE5DB6F174BA6F8FC19D4AED4D27CA5E0AB8AED1C10D3CFD5B4447A549EB33A920DB93EF26AB109FA73AA79DA") { Domain = "shop.tcgplayer.com" });
                request.CookieContainer.Add(new Cookie("ASP.NET_SessionId", "fthhqn0z55ropmxvamjlgcx0") { Domain = "shop.tcgplayer.com" });
                request.CookieContainer.Add(new Cookie("setting", "CD=US&M=1") { Domain = "shop.tcgplayer.com" });
                request.CookieContainer.Add(new Cookie("StoreCart_PRODUCTION", "CK=7651c1ff42c94c1e8eaf577299a6d085&Ignore=true") { Domain = "shop.tcgplayer.com" });
                request.CookieContainer.Add(new Cookie("valid", "set=true") { Domain = "shop.tcgplayer.com" });
                request.CookieContainer.Add(new Cookie("SearchCriteria", "M=1&WantGoldStar=False&WantCertifiedHobbyShop=False&WantDirect=False&WantSellersInCart=False&magic_MinQuantity=1&GameName=Magic&BySeller=&all_MinQuantity=0&Magic_Language=&Magic_Printing=") { Domain = "shop.tcgplayer.com" });
                request.CookieContainer.Add(new Cookie("TCG_Data", "M=1&SearchGameNameID=magic") { Domain = "shop.tcgplayer.com" });
                request.CookieContainer.Add(new Cookie("D_PID", "65B66C68-6EC9-3B18-99EC-5F2B8F8D3C20") { Domain = "shop.tcgplayer.com" });
                request.CookieContainer.Add(new Cookie("D_IID", "98CADAE7-816C-3EDE-A19A-902338E2717A") { Domain = "shop.tcgplayer.com" });
                request.CookieContainer.Add(new Cookie("D_UID", "E2565D17-04C9-3E50-A068-1E16D7CAB573") { Domain = "shop.tcgplayer.com" });
                request.CookieContainer.Add(new Cookie("D_HID", "z4tM0DxpQOwi396gBCr3y+vWhD3748dMg5fRVbHCaIY") { Domain = "shop.tcgplayer.com" });
                request.CookieContainer.Add(new Cookie("valid", "set=true") { Domain = "shop.tcgplayer.com" });
                request.CookieContainer.Add(new Cookie("X-Mapping-fjhppofk", "1D90B0366A2F3DF8AD85BC0FC32CD406") { Domain = "shop.tcgplayer.com" });
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;
                    string data = "";
                    using (var receiveStream = response.GetResponseStream())
                    {
                        if (response.CharacterSet == null)
                        {
                            readStream = new StreamReader(receiveStream);
                        }
                        else
                        {
                            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                        }
                        using (readStream)
                        {
                            data = readStream.ReadToEnd();
                        }
                    }
                    /*HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                    htmlDoc.LoadHtml(data);
                    if (htmlDoc.ParseErrors != null && htmlDoc.ParseErrors.Count() > 0)
                    {
                        // Handle any parse errors as required
                        foreach (HtmlAgilityPack.HtmlParseError e in htmlDoc.ParseErrors)
                        {
                            Console.WriteLine(e.Reason);
                        }
                    }
                    else
                    {
                        if (htmlDoc.DocumentNode != null)
                        {
                            Console.WriteLine("Document is legit");
                            HtmlAgilityPack.HtmlNodeCollection pNodes = htmlDoc.DocumentNode.SelectNodes("//p");
                            if (pNodes != null)
                            {
                                Console.WriteLine("Pnodes are legit");
                                foreach (HtmlAgilityPack.HtmlNode node in pNodes)
                                {
                                    Console.WriteLine("Found a tag");
                                    if (node.InnerText.Contains("$"))
                                    {
                                        prices[numPricesFound] = node.InnerText;
                                        numPricesFound++;
                                    }
                                }
                            }
                        }
                    }*/
                }
                Console.WriteLine(prices[0] + " " + prices[1]);
            }
            return 2f;
        }

        public static string TCGPlayerRefererURL(string cardName, string setCode)
        {
            string set = SetDataHelper.SetNameForCode(setCode);
            cardName = cardName.Replace(" ", "+");
            return String.Format("http://shop.tcgplayer.com/magic/product/show?ProductName={0}&newSearch=false&ProductType=All&IsProductNameExact=true", cardName);
        }
    }

    public class CustomWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            return request;
        }
    }
}
