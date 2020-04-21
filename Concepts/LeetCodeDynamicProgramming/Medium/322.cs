using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _322
    {
        // Brute force approach 
        public int CoinChange(int[] coins, int amount)
        {
            if (coins.Length == 1 && coins[0] > amount)
            {
                if (amount == 0)
                    return 0;
                return -1;
            }

            if (coins.Length == 1 && coins[0] < amount)
            {
                if (amount % coins[0] != 0)
                    return -1;
                else
                    return amount / coins[0];
            }

            // base condition 
            if (amount == 0)
                return 0;
            // to store number of coin counts 
            int result = int.MaxValue;

            foreach (int coin in coins)
            {
                if (coin <= amount)
                {
                    // It check whether the current result is the minimum value 
                    // or the different coin combination with this amount is the minimum value. 
                    result = Math.Min(result, CoinChange(coins, amount - coin) + 1);
                }
            }

            return result;
        }

        public int CoinChange2(int[] coins, int amount)
        {
           
            // Initiliazing dp array with maximum value because we want to find the minimum coints required to generate an amount
            int[] dp = Enumerable.Repeat(amount + 1, amount + 1).ToArray();
            // Base condition for amount 0 there is zero coins required 
           
            dp[0] = 0;
            // Loop for ampunt
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

    }
}
