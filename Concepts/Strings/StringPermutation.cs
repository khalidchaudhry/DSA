using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class StringPermutation
    {
        public List<string> StringPermutations(string s)
        {
            List<string> result = new List<string>();
            StringPermutations("", s, result);
            return result;
        }

        private void StringPermutations(string prefix, string suffix, List<string> results)
        {
            if (suffix.Length == 0)
            {
                results.Add(prefix);
            }
            else
            {
                for (int i = 0; i < suffix.Length; i++)
                {
                    //startIndex is less than zero or greater than the length of this instance.
                   var test=suffix.Substring(i + 1);
                  StringPermutations(prefix + suffix[i], suffix.Substring(0, i) + suffix.Substring(i + 1),results);
                }
            }
        }



    }
}
