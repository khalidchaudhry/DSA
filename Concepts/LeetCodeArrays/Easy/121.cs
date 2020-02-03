using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _121
    {
        public int MaxProfit(int[] prices)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                minPrice = Math.Min(minPrice,prices[i]);
                maxProfit = Math.Max(maxProfit,prices[i]-minPrice);
            }

            return maxProfit;
        }


    }
}
