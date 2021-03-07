using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Hard
{
    public class _132
    {
        public int MinCut(string s)
        {

            Dictionary<int, int> cache = new Dictionary<int, int>();
            bool[,] isPalindromes = new bool[s.Length, s.Length];
            PreComputePalindromes(s, isPalindromes);
            return MinCut(s, 0, cache, isPalindromes);

        }

        private int MinCut(string s, int start, Dictionary<int, int> cache, bool[,] isPalindromes)
        {

            if (start == s.Length)
            {
                return 0;
            }

            if (cache.ContainsKey(start))
                return cache[start];

            cache[start] = int.MaxValue;

            for (int i = start; i < s.Length; ++i)
            {
                if (!isPalindromes[start, i])
                    continue;

                int currCuts = i == s.Length - 1 ? 0 : 1;
                cache[start] = Math.Min(cache[start], currCuts + MinCut(s, i + 1, cache, isPalindromes));
            }

            return cache[start];
        }
        /// <summary>
        //! We are iterating over the length of substring to caculate the palindromic permutation
        //! Sliding window of size 1......n 
        /// </summary>
        private void PreComputePalindromes(string s, bool[,] isPalindromes)
        {
            for (int l = 1; l <= s.Length; ++l)
            {
                for (int start = 0; start <= s.Length - l; ++start)
                {
                    int end = start + l - 1;
                    if (start == end)
                        isPalindromes[start, end] = true;
                    else if (l == 2)
                        isPalindromes[start, end] = s[start] == s[end];
                    else
                        isPalindromes[start, end] = isPalindromes[start + 1, end - 1] && s[start] == s[end];
                }
            }
        }

    }
}
