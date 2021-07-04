using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Hard
{
    public class _123
    {
        public int MaxProfit(int[] prices)
        {

            Dictionary<(int idx, int k, bool bought), int> memo = new Dictionary<(int idx, int k, bool bought), int>();
            return MaxProfit(prices, 0, 2, false, memo);
        }

        private int MaxProfit(int[] prices, int idx, int k, bool bought, Dictionary<(int idx, int k, bool bought), int> memo)
        {
            if (idx == prices.Length || k == 0)
            {
                return 0;
            }
            if (memo.ContainsKey((idx, k, bought)))
            {
                return memo[(idx, k, bought)];
            }

            int skip = MaxProfit(prices, idx + 1, k, bought, memo);

            if (bought)
            {
                int sell = prices[idx] + MaxProfit(prices, idx + 1, k - 1, false, memo);
                return memo[(idx, k, bought)] = Math.Max(skip, sell);
            }
            else
            {
                int buy = -prices[idx] + MaxProfit(prices, idx + 1, k, true, memo);
                return memo[(idx, k, bought)] = Math.Max(skip, buy);
            }
        }


    }
}
