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
        /// <summary>
        //! At every day we will try to  sell stock. 
        //! If we have profit then we will reset min to that day stock value and go to next day 
        //! else we will go to next day
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit2(int[] prices)
        {
            if (prices.Length == 0)
                return 0;

            int min_so_far = prices[0];

            int totalProfit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                min_so_far = Math.Min(min_so_far, prices[i]);
                int currentProfit = prices[i] - min_so_far;
                if (currentProfit > 0)
                {
                    totalProfit += currentProfit;
                    min_so_far = prices[i];
                }
            }
            return totalProfit;
        }

    }
}
