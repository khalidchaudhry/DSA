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
            int profit = 0;
            int balance = -prices[0];
            bool coolDown = false;
            for (int i = 1; i < prices.Length; ++i)
            {
                if (balance + prices[i] > balance && !coolDown)
                {
                    profit += balance + prices[i];
                    coolDown = true;
                }
                else
                {
                    coolDown = false;
                }


                
                balance = Math.Max(balance, profit - prices[i]);

            }
            return profit;
        }
    }
}
