using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class FindAllAnagrams
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            Dictionary<char, int> lettersNeeded = new Dictionary<char, int>();
            List<int> ans = new List<int>();

            // initialize frequency table for t
            foreach (char c in p)
            {
                if (lettersNeeded.ContainsKey(c))
                {
                    lettersNeeded[c]++;
                }
                else
                {
                    lettersNeeded.Add(c, 1);
                }

            }

            if (s.Length < p.Length || s.Length == 0)
                return ans;

            int begin = 0, end = 0, word_size = p.Length;
            int lettersMissing = lettersNeeded.Count;

            while (end < s.Length)
            {
                char endchar = s[end];

                if (lettersNeeded.ContainsKey(endchar))
                {
                    lettersNeeded[endchar]--;
                    if (lettersNeeded[endchar] == 0)
                        lettersMissing--;
                }

                end++;

                while (lettersMissing == 0)
                {
                    if (end - begin == word_size)
                    {
                        ans.Add(begin);
                    }

                    char beginchar = s[begin];

                    if (lettersNeeded.ContainsKey(beginchar))
                    {
                        lettersNeeded[beginchar]++;

                        if (lettersNeeded[beginchar] > 0)
                        {
                            lettersMissing++;
                        }
                    }

                    begin++;
                }
            }
            return ans;
        }


    }
}
