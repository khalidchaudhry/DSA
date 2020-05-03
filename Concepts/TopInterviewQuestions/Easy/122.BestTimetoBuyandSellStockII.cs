using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _122
    {
        public int MaxProfit(int[] prices)
        {
            int minValue = Int32.MaxValue;
            int profit = 0;
            int totalProfit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                minValue = Math.Min(minValue, prices[i]);
                profit = prices[i] - minValue;
                if (profit > 0)
                {
                    totalProfit += profit;
                    profit = 0;
                    minValue = prices[i];
                }
            }

            return totalProfit;
        }


    }
}
