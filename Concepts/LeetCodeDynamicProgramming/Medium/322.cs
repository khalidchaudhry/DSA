using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _322
    {

        public static void _322Main()
        {
            _322 CoinChange = new _322();
            var result = CoinChange.CoinChange1(new int[] { 27, 40, 244, 168, 383 }, 6989);

        }
        public int CoinChange0(int[] coins, int amount)
        {

            // Initiliazing dp array with maximum value because we want to find the minimum coints required to generate an amount
            int[] dp = Enumerable.Repeat(amount + 1, amount + 1).ToArray();
            // Base condition for amount 0 there is zero coins required 

            dp[0] = 0;
            // Loop for amount
            for (int i = 1; i <= amount; i++)
                // loop for accessing coin arrray 
                for (int j = 0; j < coins.Length; j++)
                {
                    // amount must be greater than  or equal to the current coin(coins[j])
                    if (i >= coins[j])
                    {
                        //! fill the current index of the dp array with minimum of current dp value or previous dp values 
                        //! previous dp value is the remaining amount index.
                        // ! +1 is becuase we are taking current coin for this amount. 
                        dp[i] = Math.Min(dp[i], 1 + dp[i - coins[j]]);
                    }
                }

            // Final answer would be aviable at the final index that is dp[amount]
            // if dp[amount]==MaxValue it means that we were not able to make combinations for given amount with provided coins hence we return -1 
            // else we retun the number of coins used to make the amount 
            return dp[amount] > amount ? -1 : dp[amount];

        }
        //! Brute Force ---Sam Recursion (selection pattern)
        public int CoinChange1(int[] coins, int amount)
        {
            ResultWrapper resultWrapper = new ResultWrapper();
            resultWrapper.Result = int.MaxValue;
            MakingChange1(coins, 0, amount, new List<int>(), resultWrapper);
            return resultWrapper.Result;

        }


        private void MakingChange1(int[] coins, int i, int amt, List<int> path, ResultWrapper resultWrapper)
        {
            if (amt < 0) return;
            if (amt == 0)
            {
                resultWrapper.Result = Math.Min(resultWrapper.Result, path.Count);
                return;
            }
            if (i == coins.Length) return;

            path.Add(coins[i]);
            MakingChange1(coins, i, amt - coins[i], path, resultWrapper);
            path.RemoveAt(path.Count - 1);
            MakingChange1(coins, i + 1, amt, path, resultWrapper);
        }        
    }
    public class ResultWrapper
    {
        public int Result { get; set; }
    }


}
