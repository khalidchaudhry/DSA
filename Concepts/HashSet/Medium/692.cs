using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeHashTable.Medium
{
    public class _692
    {

        public IList<string> TopKFrequent(string[] words, int k)
        {
            List<string> result = new List<string>();

            Dictionary<string, int> map = new Dictionary<string, int>();

            SortedSet<string>[] bucket = new SortedSet<string>[words.Length + 1];

            for (int i = 0; i < words.Length; i++)
            {
                if (map.ContainsKey(words[i]))
                {
                    map[words[i]]++;
                }
                else
                {
                    map.Add(words[i], 1);
                }
            }

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new SortedSet<string>();
            }

            foreach (KeyValuePair<string, int> keyValue in map)
            {
                bucket[keyValue.Value].Add(keyValue.Key);
            }

            int topK = 0;

            for (int i = bucket.Length - 1; i >= 0 && topK < k; --i)
            {
                if (bucket[i].Count > 0)
                {
                    foreach (string item in bucket[i])
                    {
                        //! safeguarding against corner case
                        if (topK >= k)
                        {
                            break;
                        }

                        result.Add(item);
                        ++topK;
                    }
                }
            }

            return result;
        }


    }
}
