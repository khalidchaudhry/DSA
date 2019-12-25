using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _121
    {
        public int MaxProfit(int[] prices)
        {

            int maxProfit = 0;
            int minValue = int.MaxValue;

            for (int i = 0; i < prices.Length; i++)
            {
                minValue = Math.Min(prices[i],minValue);
                maxProfit = Math.Max(maxProfit,prices[i]-minValue);
            }

            return maxProfit;

        }
    }
}
