using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Hard
{
    public class _76
    {

        public static void _76Main()
        {
            string s = "ADOBECODEBANC";
            string t = "ABC";

            _76 Main = new _76();

            var ans=Main.MinWindow(s,t);
        }

        public string MinWindow(string s, string t)
        {
            if (t.Length > s.Length)
            {
                return string.Empty;
            }

            int start = 0;
            int end = int.MaxValue;

            Dictionary<char, int> tMap = new Dictionary<char, int>();
            BuildMap(t, tMap);

            Dictionary<char, int> sMap = new Dictionary<char, int>();

            int i = 0;
            for (int j = 0; j < s.Length; ++j)
            {
                Add(s[j], sMap);
                while (IsValid(sMap, tMap))
                {
                    if (j - i < end - start)
                    {
                        start = i;
                        end = j;
                    }
                    Update(s[i], sMap);
                    ++i;
                }
            }

            return end == int.MaxValue ? string.Empty : s.Substring(start, end - start + 1);
        }
        private void BuildMap(string s, Dictionary<Char, int> map)
        {
            foreach (char c in s)
            {
                Add(c, map);
            }
        }

        private void Add(char c, Dictionary<char, int> map)
        {
            if (!map.ContainsKey(c))
            {
                map.Add(c, 0);
            }

            ++map[c];
        }

        private bool IsValid(Dictionary<char, int> sMap, Dictionary<char, int> tMap)
        {
            foreach (var keyValue in tMap)
            {
                if (!sMap.ContainsKey(keyValue.Key) || sMap[keyValue.Key] < keyValue.Value)
                {
                    return false;
                }
            }

            return true;
        }

        private void Update(char c, Dictionary<char, int> map)
        {
            --map[c];
            if (map[c] == 0)
            {
                map.Remove(c);
            }
        }



    }
}
