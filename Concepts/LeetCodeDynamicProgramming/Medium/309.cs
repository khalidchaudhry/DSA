using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _309
    {

        //! Does not work for this input [1,2,4]
        public int MaxProfit(int[] prices)
        {
            int totalProfit = 0;
            int minValue = int.MaxValue;

            for (int i = 0; i < prices.Length; i++)
            {
                minValue = Math.Min(minValue,prices[i]);

                int profit = prices[i] - minValue;

                if (profit > 0)
                {
                    totalProfit += profit;
                    if (i + 1 < prices.Length)
                    {
                        minValue = prices[i + 1];
                    }
                    ++i;                   
                }

            }
            return totalProfit;
        }
    }
}
