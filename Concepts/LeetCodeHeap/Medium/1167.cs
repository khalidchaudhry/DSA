using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeHeap.Medium
{
    class _1167
    {
        public static void _1167Main()
        {
            _1167 test = new _1167();
            int[] nums = new int[] { 1, 8, 3, 5 };
            var ans = test.ConnectSticks(nums);
            Console.WriteLine();
        }

        public int ConnectSticks(int[] sticks)
        {
            int n = sticks.Length;
            PQ<(int val, int index)> pq = new PQ<(int val, int index)>();
            for (int i = 0; i < n; ++i)
            {
                pq.Add((sticks[i], i));
            }

            int minCost = 0;
            while (pq.Size != 1)
            {
                (int val1, int index1) = pq.Poll();
                (int val2, int index2) = pq.Poll();
                minCost += val1 + val2;
                pq.Add((minCost, index1 + index2));
            }
            return minCost;
        }
        


      
    }
}
