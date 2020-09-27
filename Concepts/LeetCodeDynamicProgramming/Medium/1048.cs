using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _1048
    {
        /// <summary>
        ///https://leetcode.com/problems/longest-string-chain/discuss/294918/DP-with-HashMap-in-JAVA 
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int LongestStrChain(string[] words)
        {
            if (words == null || words.Length == 0) return 0;
            int res = 0;

            Dictionary<string, int> map = new Dictionary<string, int>();
            var sortedWords = words.OrderBy(x => x.Length);
            foreach (string word in sortedWords)
            {
                if (map.ContainsKey(word)) continue;
                map[word] = 1;

                for (int i = 0; i < word.Length; i++)
                {
                    StringBuilder sb = new StringBuilder(word);
                    sb.Remove(i, 1);
                    string next = sb.ToString();

                    if (map.ContainsKey(next) && map[next] + 1 > map[word])
                    {
                        map[word] = map[next] + 1;
                    }
                }

                if (map[word] > res)
                    res = map[word];
            }

            return res;
        }
    }
}
