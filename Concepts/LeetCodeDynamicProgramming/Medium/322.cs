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

        public int CoinChange1(int[] coins, int amount)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>();
            int result=MakingChange1(coins, amount, memo);
            result=result == int.MaxValue ? -1 : result;
            return result;
        }

        private int MakingChange1(int[] coins, int amount, Dictionary<int, int> memo)
        {
            if (amount == 0) return 0;

            if (memo.ContainsKey(amount)) return memo[amount];

            int min = int.MaxValue;
            for (int i = 0; i < coins.Length; ++i)
            {
                if (coins[i] > amount) continue;
                int minCoins = MakingChange1(coins, amount - coins[i], memo);
                min = Math.Min(minCoins, min);
            }
            //memoize the minimum for current total/current amount.
            memo[amount] = min == int.MaxValue ? min : min + 1;
            return memo[amount];
        }



        /// <summary>
        //! https://www.youtube.com/watch?v=Kf_M7RdHr1M 
        /// </summary>
        public int CoinChange2(int[] coins, int amount)
        {
            int result = MakingChange2(coins, amount);
            return result == int.MaxValue ? -1 : result;
        }
        private int MakingChange2(int[] coins, int amt)
        {
            //! if amount is zero than we need 0 coins or no coins 
            if (amt == 0)
            {
                return 0;
            }

            //! we need to find out which coins gives us best result so we are initializing min  with max
            int min = int.MaxValue;

            for (int i = 0; i < coins.Length; ++i)
            {
                //If coin is greater then amount, there is no point in continuing
                if (coins[i] > amt) continue;
                //recurse with total - coins[i] as new total
                int coinsNeeded = MakingChange2(coins, amt - coins[i]);
                //if val we get from picking coins[i] as first coin for current total is less
                // than value found so far make it minimum.
                min = Math.Min(min, coinsNeeded);
            }
            //if min is MAX_VAL dont change it. Just result it as is. 
            //!Otherwise add 1 to it to include the current coin in it
            return min == int.MaxValue ? min : min + 1;
        }
    }
}
