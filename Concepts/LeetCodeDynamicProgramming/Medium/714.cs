using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium

{
    public class _714
    {
        public int MaxProfit(int[] prices, int fee)
        {
            // we have a bought the stock on day 0
            int balance =-prices[0];
            int profit = 0;
           

            for (int i = 1; i < prices.Length; i++)
            {
                // Try to sell a stock at day i
                //!if by selling stock , our profit increase then we will sell the stock ,
                // !otherwise we hold the stock on current day.
                profit = Math.Max(profit,balance+prices[i]-fee);

                // try to buy a stock at day i
                //! we will buy stock if our current balance increases 
                //! else we will keep the current balance. 
                //! we are buying the stock from existing profit.
                balance =Math.Max(balance,profit-prices[i]);
                
            }

            return profit;

        }


    }
}
