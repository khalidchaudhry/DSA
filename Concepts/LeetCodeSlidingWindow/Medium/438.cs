using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Medium
{
    public class _438
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            
            int k = p.Length;
            List<int> indices = new List<int>();
            if (k > s.Length)
            {
                return indices;
            }
            Dictionary<char, int> pMap = new Dictionary<char, int>();
            Dictionary<char, int> sMap = new Dictionary<char, int>();
            CaculateFreq(p, pMap);

            for (int i = 0; i < s.Length; ++i)
            {
                Add(sMap, s[i]);
                if (i >= k - 1)
                {
                    if (AreEqual(sMap, pMap))
                    {
                        indices.Add(i - k + 1);
                    }
                    Update(sMap, s[i - k + 1]);
                }
            }
            return indices;
        }

        private void CaculateFreq(string s, Dictionary<char, int> map)
        {
            foreach (char c in s)
            {
                Add(map, c);
            }
        }

        private void Add(Dictionary<char, int> map, char c)
        {
            if (!map.ContainsKey(c))
            {
                map.Add(c, 0);
            }
            ++map[c];
        }
        private void Update(Dictionary<char, int> map, char c)
        {
            --map[c];
            if (map[c] == 0)
            {
                map.Remove(c);
            }
        }
        private bool AreEqual(Dictionary<char, int> map1, Dictionary<char, int> map2)
        {
            foreach (var keyValue in map1)
            {
                if (!map2.ContainsKey(keyValue.Key) || map2[keyValue.Key] != keyValue.Value)
                {
                    return false;
                }
            }
            return true;
        }


    }
}
