using System;
using System.Collections.Generic;
using System.Text;

namespace HashSet
{
    class _205
    {
        public bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, Char> map = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!map.ContainsKey(s[i]))
                {
                    map.Add(s[i],t[i]);
                }
            }

            for (int i = 0; i < t.Length; i++)
            {
                if (!map.ContainsValue(t[i]))
                {
                    return false;
                }
            }

            return true;

        }

    }
}
