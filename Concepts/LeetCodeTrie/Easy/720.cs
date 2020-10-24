using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTrie.Easy
{
    public class _720
    {

        /// <summary>
        /// https://leetcode.com/problems/longest-word-in-dictionary/
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public string LongestWord(string[] words)
        {
            Array.Sort(words);
            string result = string.Empty;

            HashSet<string> hs = new HashSet<string>();

            for (int i = 0; i < words.Length; ++i)
            {
                string curr = words[i];
                int currLength = curr.Length;
                if (currLength == 1 || hs.Contains(curr.Substring(0, curr.Length - 1)))
                {
                    if (currLength > result.Length)
                    {
                        result = curr;
                    }

                    hs.Add(curr);
                }
            }

            return result;
        }


    }
}
