using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _123
    {
        public static void _123Main()
        {
            int[] prices = new int[] { 1 };

            _123 MaxProfit = new _123();
            var result = MaxProfit.MaxProfit(prices);

            Console.ReadLine();

        }
        /// <summary>
        //! O(n) space  O(n) time with 
        //! 
        /// </summary>
        public int MaxProfit1(int[] prices)
        {

            Dictionary<(int start, bool isBought, int k), int> memo = new Dictionary<(int start, bool isBought, int k), int>();
            return Solve(prices, 0, false, 2, memo);
        }
        private int Solve(int[] prices, int start, bool isBought, int k, Dictionary<(int start, bool isBought, int k), int> memo)
        {
            if (start == prices.Length || k == 0)
            {
                return 0;
            }
            if (memo.ContainsKey((start, isBought, k)))
            {
                return memo[(start, isBought, k)];
            }

            int skip = Solve(prices, start + 1, isBought, k, memo);
            int buy = 0;
            int sell = 0;

            if (isBought)
            {
                //! not sell-= because choice is for every day . we are not doing any accumilation
                sell = prices[start] + Solve(prices, start + 1, false, k - 1, memo);
            }
            else
            {
                buy = -prices[start] + Solve(prices, start + 1, true, k, memo);
            }

            return memo[(start, isBought, k)] = Math.Max(skip, Math.Max(buy, sell));
        }



        /// <summary>
        // ! Iterate the array from left to right and then right to left 
        /// </summary>      
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;

            if (n == 0)
                return 0;
            int[] bestProfitSoFar = new int[n];
            int minSoFar = prices[0];
            int profit = 0;
            //! Assume we are making one trade
            for (int i = 0; i < n; ++i)
            {
                minSoFar = Math.Min(minSoFar, prices[i]);
                profit = Math.Max(profit, prices[i] - minSoFar);
                bestProfitSoFar[i] = profit;
            }

            int[] bestProfitBeginAt = new int[n];
            int maxSoFar = prices[n - 1];
            profit = 0;

            //! Assume we are making one trade
            for (int i = n - 1; i >= 0; --i)
            {
                maxSoFar = Math.Max(maxSoFar, prices[i]);
                profit = Math.Max(profit, maxSoFar - prices[i]);
                //! Best profit at day i 
                bestProfitBeginAt[i] = profit;
            }

            int maxProfit = 0;
            for (int i = 0; i < n; ++i)
            {
                maxProfit = Math.Max(maxProfit, bestProfitSoFar[i] + bestProfitBeginAt[i]);
            }

            return maxProfit;

        }












        /// <summary>
        //! Brute force solution 
        //! Time Limit Exceeded
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit1(int[] prices)
        {
            if (prices.Length == 0)
                return 0;

            int maxProfit = 0;

            for (int i = 0; i < prices.Length; ++i)
            {
                int maxProfitOnLeftSide = CalculateProfit(0, i, prices);
                int maxProfitOnRightSide = CalculateProfit(i, prices.Length, prices);
                maxProfit = Math.Max(maxProfit, maxProfitOnLeftSide + maxProfitOnRightSide);
            }

            return maxProfit;
        }

        private int CalculateProfit(int start, int end, int[] prices)
        {
            int maxProfit = 0;
            int minPrice = prices[start];

            for (int i = start; i < end; ++i)
            {
                minPrice = Math.Min(minPrice, prices[i]);
                maxProfit = Math.Max(maxProfit, prices[i] - minPrice);
            }

            return maxProfit;
        }
    }
}
