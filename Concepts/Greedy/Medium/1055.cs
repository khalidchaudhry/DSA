using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Medium
{
    class _1055
    {
        public int ShortestWay(string source, string target)
        {
            Dictionary<char, int> sMap = new Dictionary<char, int>();
            Dictionary<char, int> tMap = new Dictionary<char, int>();
            BuildMap(source, sMap);
            BuildMap(target, tMap);
            if (IsNotPossible(sMap, tMap))
            {
                return -1;
            }
            //!we need atleast one subsequence e.g. 
            //! source="abc"  and target="abc" then we need atleast one subsequence of source to make target
            int subsequences = 1;

            int sIdx = 0;
            int tIdx = 0;
            while (tIdx < target.Length)
            {
                if (sIdx == source.Length)
                {
                    ++subsequences;
                    sIdx = 0;
                }

                if (source[sIdx] == target[tIdx])
                {
                    ++sIdx;
                    ++tIdx;
                }
                else
                {
                    ++sIdx;
                }
            }
            return subsequences;
        }
        private void BuildMap(string s, Dictionary<char, int> map)
        {
            foreach (char c in s)
            {
                if (!map.ContainsKey(c))
                {
                    map.Add(c, 0);
                }
                ++map[c];
            }
        }
        private bool IsNotPossible(Dictionary<char, int> sMap, Dictionary<char, int> tMap)
        {
            foreach (var keyValue in tMap)
            {
                if (!sMap.ContainsKey(keyValue.Key))
                    return true;
            }

            return false;
        }


    }
}
