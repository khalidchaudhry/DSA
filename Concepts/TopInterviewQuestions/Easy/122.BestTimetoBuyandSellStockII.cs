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
            int maxProfit = 0;

            if (prices.Length == 0 || prices.Length == 1)
            {
                return maxProfit;
            }

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i]>prices[i-1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }

            }
            return maxProfit;
        }


    }
}
