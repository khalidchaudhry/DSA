﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium._518
{
    class _518
    {
        public static void _518Main()
        {


            _518 Change = new _518();
            int[] coins = new int[] { 5, 2, 1 };
            int amount = 5;

            var ans = Change.Change1(coins, amount);
        }

        /// <summary>
        ///https://www.youtube.com/watch?v=DJ4a7cmjZY0
        // # <image url="https://yyc-images.oss-cn-beijing.aliyuncs.com/leetcode_518_using_dp.png" scale="0.4" />  
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int Change0(int amount, int[] coins)
        {
            int[][] dp = new int[coins.Length + 1][];

            for (int i = 0; i < dp.Length; ++i)
            {
                dp[i] = new int[amount + 1];
            }
            //!Ways to make change for amount 0 will be 1
            dp[0][0] = 1;

            for (int i = 1; i <= coins.Length; ++i)
            {
                //!Set it for 1 when solving for amount 0
                dp[i][0] = 1;

                for (int j = 1; j <= amount; ++j)
                {
                    int currentCoinValue = coins[i - 1];
                    //! previous row will have ways not considering this coin
                    int withoutThisCoin = dp[i - 1][j];

                    int withthisCoin = currentCoinValue <= j ? dp[i][j - currentCoinValue] : 0;

                    dp[i][j] = withoutThisCoin + withthisCoin;
                }
            }

            return dp[coins.Length][amount];

        }

        /// <summary>
        //! DP Top down(Memoization)       
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int Change1(int[] coins, int amount)
        {

            Dictionary<(int amount, int coins), int> memo = new Dictionary<(int amount, int coins), int>();

            return Change1(coins, 0, amount, memo);


        }

        private int Change1(int[] coins, int i, int amount, Dictionary<(int amount, int coins), int> memo)
        {
            if (amount < 0)
                return 0;
            if (amount == 0)
                return 1;
            if (i == coins.Length)
                return 0;

            if (memo.ContainsKey((amount, coins[i])))
            {
                return memo[(amount, coins[i])];
            }
            int include = Change1(coins, i, amount - coins[i], memo);

            int exclude = Change1(coins, i + 1, amount, memo);

            memo[(amount, coins[i])] = include + exclude;

            return memo[(amount, coins[i])];

        }



        /// <summary>
        //! Brute Force approach based on Sam Selection pattern.
        //! Time limit excceded
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int Change2(int[] coins, int amount)
        {
            return Change2(coins, 0, amount);
        }

        private int Change2(int[] coins, int i, int amount)
        {

            if (amount == 0) return 1;

            if (amount < 0 || i >= coins.Length) return 0;

            int include = Change2(coins, i, amount - coins[i]);

            int exclude = Change2(coins, i + 1, amount);

            return include + exclude;
        }
    }



}