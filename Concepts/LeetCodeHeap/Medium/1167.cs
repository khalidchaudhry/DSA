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

            PQ<int> pq = new PQ<int>();
            for (int i = 0; i < n; ++i)
            {
                pq.Add(sticks[i]);
            }

            int minCost = 0;
            while (pq.Size != 1)
            {
                int stk1Len = pq.Poll();
                int stk2Len = pq.Poll();
                minCost += stk1Len + stk2Len;
                pq.Add(stk1Len + stk2Len);
            }

            return minCost;
        }
        


      
    }
}
