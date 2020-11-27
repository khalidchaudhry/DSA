using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeHeap.Medium
{
    class _1167
    {
        public int ConnectSticks(int[] sticks)
        {
            

            SortedSet<(int length, int index)> ss = new SortedSet<(int length, int index)>();
            Populate(sticks, ss);
            return CalculateMinCost(ss);

        }


        private void Populate(int[] sticks, SortedSet<(int length, int index)> ss)
        {
            for (int i = 0; i < sticks.Length; ++i)
            {
                ss.Add((sticks[i], i));
            }
        }

        private int CalculateMinCost(SortedSet<(int length, int index)> ss)
        {

            int minCost = 0;
            int allSticks = ss.Count;
            while (ss.Count != 1)
            {
                (int length1, int index1) = ss.Min;
                ss.Remove(ss.Min);
                (int length2, int index2) = ss.Min;
                ss.Remove(ss.Min);
                int cost = length1 + length2;
                minCost += cost;
                //! Very important allSticks++. We need to push new calculation at very end
                ss.Add((cost, allSticks++));
            }

            return minCost;
        }
    }
}
