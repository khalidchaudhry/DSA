using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeHashTable.Medium
{
    public class _451
    {
        public string FrequencySort(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            StringBuilder sb = new StringBuilder();
            List<char>[] bucket = new List<char>[s.Length+1];
            foreach (char c in s)
            {
                if (map.ContainsKey(c))
                {
                    map[c]++;
                }
                else
                {
                    map.Add(c,1);
                }
            }

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<char>();
            }

            foreach (KeyValuePair<char, int> keyValue in map)
            {
                bucket[keyValue.Value].Add(keyValue.Key);
            }

            for (int i = bucket.Length - 1; i > 0; i--)
            {
                if (bucket[i].Count > 0)
                {
                    foreach (char c in bucket[i])
                    {
                        sb.Append(c, i);
                    }
                }
            }
            return sb.ToString();
        }
    }
}
