using System.Runtime.Serialization;

namespace WindowsFormsApplication1
{

    public class SetInfo
    {
        public string name { get; set; }
        public string code { get; set; }
        public string gathererCode { get; set; }
        public string magicCardsInfoCode { get; set; }
        public string releaseDate { get; set; }
        public string border { get; set; }
        public string type { get; set; }
        public object[] booster { get; set; }
        public string mkm_name { get; set; }
        public int mkm_id { get; set; }
        public Card[] cards { get; set; }
        public Translations translations { get; set; }
        public string[] magicRaritiesCodes { get; set; }
        public string block { get; set; }
        public string oldCode { get; set; }
        public bool onlineOnly { get; set; }
    }

    public class Translations
    {
        public string de { get; set; }
        public string fr { get; set; }
        public string it { get; set; }
        public string es { get; set; }
        public string pt { get; set; }
        public string jp { get; set; }
        public string cn { get; set; }
        public string ru { get; set; }
        public string tw { get; set; }
        public string ko { get; set; }
        public string zhhant { get; set; }
        public string zhhans { get; set; }
    }

    public class Card
    {
        public string artist { get; set; }
        public float cmc { get; set; }
        public string[] colorIdentity { get; set; }
        public string[] colors { get; set; }
        public string flavor { get; set; }
        public string id { get; set; }
        public string imageName { get; set; }
        public string layout { get; set; }
        public string manaCost { get; set; }
        public string mciNumber { get; set; }
        public int multiverseid { get; set; }
        public string name { get; set; }
        public string power { get; set; }
        public string rarity { get; set; }
        public string[] subtypes { get; set; }
        public string text { get; set; }
        public string toughness { get; set; }
        public string type { get; set; }
        public string[] types { get; set; }
        public bool reserved { get; set; }
        public string[] supertypes { get; set; }
        public int[] variations { get; set; }
        public string number { get; set; }
        public string releaseDate { get; set; }
        public string border { get; set; }
        public int loyalty { get; set; }
        public int hand { get; set; }
        public int life { get; set; }
        public string[] names { get; set; }
        public bool starter { get; set; }
        public string watermark { get; set; }
        public bool timeshifted { get; set; }

        public override string ToString()
        {
            return name;
        }
    }

}
