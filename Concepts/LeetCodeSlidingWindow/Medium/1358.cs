using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Medium
{
    public class _1358
    {


        /// <summary>
        //! Variable size sliding window 
        /// </summary>
        public int NumberOfSubstrings(string s)
        {
            int total = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();

            int i = 0;
            for (int j = 0; j < s.Length; ++j)
            {
                AddToMap(s[j], map);
                while (IsValid(map))
                {
                    total += s.Length - j;
                    AdjustMap(s[i], map);
                    ++i;
                }
            }

            return total;
        }

        public int numberOfSubstrings1(string s)
        {
            int[] count = new int[3];
            int res = 0;
            int i = 0;
            for (int j = 0; j < s.Length; ++j)
            {
                ++count[s[j] - 'a'];
                while (count[0] > 0 && count[1] > 0 && count[2] > 0)
                {
                    --count[s[i] - 'a'];
                    ++i;
                }
                res += i;
            }
            return res;
        }

        private void AddToMap(char c, Dictionary<int, int> map)
        {
            if (map.ContainsKey(c))
            {
                ++map[c];
            }
            else
            {
                map.Add(c, 1);
            }
        }
        private bool IsValid(Dictionary<int, int> map)
        {
            if (map.ContainsKey('a') && map.ContainsKey('b') && map.ContainsKey('c'))
                return true;

            return false;
        }
        private void AdjustMap(char c, Dictionary<int, int> map)
        {
            --map[c];
            if (map[c] == 0)
            {
                map.Remove(c);
            }
        }
    }
}
