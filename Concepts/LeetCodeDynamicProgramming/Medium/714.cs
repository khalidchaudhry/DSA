using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium

{
    public class _714
    {
        /// <summary>
        //! DP with memoization  
        /// </summary>
        public int MaxProfit0(int[] prices, int fee)
        {

            Dictionary<(int idx, int fee, bool bought), int> memo = new Dictionary<(int idx, int fee, bool bought), int>();
            return MaxProfit0(prices, 0, fee, false, memo);
        }
        private int MaxProfit0(int[] prices, int idx, int fee, bool bought, Dictionary<(int idx, int fee, bool bought), int> memo)
        {
            if (idx == prices.Length)
                return 0;
            if (memo.ContainsKey((idx, fee, bought)))
                return memo[(idx, fee, bought)];

            int skip = MaxProfit0(prices, idx + 1, fee, bought, memo);

            if (bought)
            {
                int sell = prices[idx] - fee + MaxProfit0(prices, idx + 1, fee, false, memo);
                return memo[(idx, fee, bought)] = Math.Max(sell, skip);
            }
            else
            {
                int buy = -prices[idx] + MaxProfit0(prices, idx + 1, fee, true, memo);
                return memo[(idx, fee, bought)] = Math.Max(buy, skip);
            }
        }

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
