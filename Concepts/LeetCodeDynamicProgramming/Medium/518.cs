using System;
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
        //! DP Top down(Memoization)       
        /// </summary>
        
        public int Change0(int amount, int[] coins)
        {
            Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
            return Change0(coins, 0, amount, memo);
        }

        private int Change0(int[] coins, int idx, int amount, Dictionary<(int, int), int> memo)
        {

            if (amount < 0)
            {
                return 0;
            }
            if (amount == 0)
            {
                return 1;
            }

            if (memo.ContainsKey((idx, amount)))
            {
                return memo[(idx, amount)];
            }

            int totalWays = 0;
            for (int i = idx; i < coins.Length; ++i)
            {
                totalWays += Change0(coins, i, amount - coins[i], memo);
            }

            return memo[(idx, amount)] = totalWays;
        }
        
        
        /// <summary>
        //! DP Top down(Memoization)       
        /// </summary>
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