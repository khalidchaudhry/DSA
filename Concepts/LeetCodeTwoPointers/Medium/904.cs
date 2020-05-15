using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTwoPointers.Medium
{
    class _904
    {

        public int TotalFruit(int[] tree)
        {
            if (tree.Length == 0)
                return 0;

            Dictionary<int, int> map = new Dictionary<int, int>();
            int len = int.MinValue;
            int start = 0;
            for (int i = 0; i < tree.Length; i++)
            {
                if (map.ContainsKey(tree[i]))
                {
                    map[tree[i]] = i;
                }
                else
                {
                    map.Add(tree[i], i);

                    if (map.Count > 2)
                    {
                        int minValue = map.Values.Min();
                        int key = map.First(x => x.Value == minValue).Key;
                        map.Remove(key);
                        start = minValue + 1;
                    }
                }
                len = Math.Max(len, i - start + 1);
            }

            return len;
        }


        public int TotalFruit0(int[] tree)
        {
            if (tree.Length == 0)
                return 0;

            int len = 1;
            int start = 0;
            int new_start = 0;
            int type1 = tree[0];
            int type2 = -1;

            for (int i = 1; i < tree.Length; i++)
            {
                if (tree[i] != type1 && type2 == -1)
                {
                    type2 = tree[i];
                }
                else if (type1 != tree[i] && type2 != tree[i])
                {
                    type1 = tree[i - 1];
                    type2 = tree[i];
                    start = new_start;
                }

                len = Math.Max(len, i - start + 1);

                if (tree[i - 1] != tree[i])
                {
                    new_start = i;
                }

            }


            return len;
        }
    }
}
