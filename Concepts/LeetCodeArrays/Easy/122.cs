using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _122
    {
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                maxProfit += Math.Max(0,prices[i]-prices[i-1]);
            }

            return maxProfit;
        }
    }
}
