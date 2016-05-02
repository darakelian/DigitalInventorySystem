using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalInventory
{
    [Serializable]
    public class Price
    {
        private string name, set;

        private float low, med, high, foil;

        /// <summary>
        /// Use this constructor to create a Price object for searching existing
        /// prices.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="set"></param>
        public Price(string name, string set)
        {
            this.name = name;
            this.set = set;
        }

        public Price(string name, string set, float low, float med, float high, float foil)
        {
            this.name = name;
            this.set = set;
            this.low = low;
            this.med = med;
            this.high = high;
            this.foil = foil;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Set
        {
            get
            {
                return set;
            }
        }

        public float Low
        {
            get
            {
                return low;
            }
        }

        public float Med
        {
            get
            {
                return med;
            }
        }

        public float High
        {
            get
            {
                return high;
            }
        }

        public float Foil
        {
            get
            {
                return foil;
            }
        }

        /// <summary>
        /// Determines if 2 Price objects are equal by comparing the names and
        /// sets associated with the object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if they are equal</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Price))
            {
                return false;
            }
            bool names = this.name.Equals(((Price)obj).name);
            bool sets = this.set.Equals(((Price)obj).set);
            return names && sets;
        }
    }
}
