using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Medium
{
    class _244
    {


    }
    public class WordDistance
    {
        Dictionary<string, List<int>> _map;
        public WordDistance(string[] words)
        {
            _map = new Dictionary<string, List<int>>();

            for (int i = 0; i < words.Length; ++i)
            {
                if (!_map.ContainsKey(words[i]))
                {
                    _map.Add(words[i], new List<int>() { });
                }
                _map[words[i]].Add(i);
            }
        }
        public int Shortest(string word1, string word2)
        {
            List<int> list1 = _map[word1];
            List<int> list2 = _map[word2];
            int i = 0;
            int j = 0;
            int minDistance = int.MaxValue;
            while (i < list1.Count && j < list2.Count)
            {
                int dist = Math.Abs(list1[i] - list2[j]);
                minDistance = Math.Min(minDistance, dist);
                if (list1[i] < list2[j])
                {
                    ++i;
                }
                else
                {
                    ++j;
                }
            }
            return minDistance;
        }
    }

}
