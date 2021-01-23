using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Medium
{
    class _904
    {

        /// <summary>
        //! Kuai's 
        //! Our goal is to find longest subarray with at most 2 distinct chracters
        /// </summary>
        public int TotalFruit(int[] tree)
        {

            Dictionary<int, int> map = new Dictionary<int, int>();
            int longest = 0;
            int i = 0;
            for (int j = 0; j < tree.Length; ++j)
            {
                Add(tree[j], map);
                while (map.Count > 2)
                {
                    Update(tree[i], map);
                    ++i;
                }

                longest = Math.Max(longest, j - i + 1);
            }
            return longest;
        }

        private void Add(int item, Dictionary<int, int> map)
        {
            if (!map.ContainsKey(item))
            {
                map.Add(item, 0);
            }

            ++map[item];
        }

        private void Update(int item, Dictionary<int, int> map)
        {
            --map[item];
            if (map[item] == 0)
            {
                map.Remove(item);
            }
        }
    }
}
