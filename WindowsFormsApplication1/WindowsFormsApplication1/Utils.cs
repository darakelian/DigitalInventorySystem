using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalInventory
{

    /// <summary>
    /// Helper class with various static methods to improve code readability and
    /// reusability.
    /// </summary>
    class Utils
    {

        /// <summary>
        /// Checks to see if a tag is a set or condition tag. This is determined
        /// by checking if it contains a [ or ( which are the two most common
        /// ways people will denote a tag.
        /// </summary>
        /// <param name="tag">The tag being checked.</param>
        /// <returns></returns>
        public static bool IsSetOrCondition(string tag)
        {
            return tag.Contains("[") || tag.Contains("(");
        }

        public static bool IsTagCondition(string tag)
        {
            return tag.Equals("nm") || tag.Equals("lp") || tag.Equals("mp") || tag.Equals("hp");
        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        public static string ParseBracketTag(string s)
        {
            string conditionOrSet = s.Contains("[") ? s.Trim(new char[] { '[', ']' }) : s.Trim(new char[] { '(', ')' });
            conditionOrSet = conditionOrSet.ToUpper();
            return conditionOrSet;
        }
    }
}
