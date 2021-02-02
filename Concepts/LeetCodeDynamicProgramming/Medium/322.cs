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


        /// <summary>
        //! Time Complexity=O(amount)[states] * O(n)[recursion depth]=O(n * states)  
        /// </summary>
        public int CoinChange1(int[] coins, int amount)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>();
            return MakingChange1(coins, amount, memo);

        }

        private int MakingChange1(int[] coins, int target, Dictionary<int, int> memo)
        {
            if (target == 0)
            {
                return 0;
            }

            if (memo.ContainsKey(target))
            {
                return memo[target];
            }

            int minCoins = -1;
            for (int i = 0; i < coins.Length; ++i)
            {
                if (coins[i] > target)
                {
                    continue;
                }
                int count = MakingChange1(coins, target - coins[i], memo);
                if (count != -1)
                {
                    minCoins = minCoins == -1 ? 1 + count : Math.Min(minCoins, 1 + count);
                }
            }
            return memo[target] = minCoins;
        }
        /// <summary>
        //! Time Complexity=O(n*amount)[states] * O(n)[recursion depth]=O(n ^ 2 * target)  
        /// </summary>
        public int CoinChange(int[] coins, int amount)
        {
            Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
            return CoinChange(coins, 0, amount, memo);

        }
        private int CoinChange(int[] coins, int start, int target, Dictionary<(int, int), int> memo)
        {

            if (target == 0)
            {
                return 0;
            }

            if (target < 0)
            {
                return -1; //invalid answer
            }

            if (memo.ContainsKey((start, target)))
            {
                return memo[(start, target)];
            }

            int minCoins = -1;
            for (int i = start; i < coins.Length; ++i)
            {
                int count = CoinChange(coins, i, target - coins[i], memo);
                if (count != -1)
                {
                    //! 
                    minCoins = minCoins == -1 ? 1 + count : Math.Min(minCoins, 1 + count);
                }
            }
            return memo[(start, target)] = minCoins;
        }



    }
}
