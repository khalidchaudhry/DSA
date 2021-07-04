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
            var result = CoinChange.CoinChange0(new int[] { 27, 40, 244, 168, 383 }, 6989);

        }
        /// <summary>
        //! Include/exclude pattern 
        //! similar approach followed in 45
        /// </summary>
        public int CoinChange0(int[] coins, int amount)
        {

            Dictionary<(int idx, int target), int> memo = new Dictionary<(int idx, int target), int>();
            int minCoins = CoinChange0(coins, 0, amount, memo);

            return minCoins == int.MaxValue ? -1 : minCoins;

        }

        private int CoinChange0(int[] coins, int idx, int target, Dictionary<(int idx, int target), int> memo)
        {
            if (target == 0)
                return 0;
            if (target < 0 || idx == coins.Length)
                return int.MaxValue;

            if (memo.ContainsKey((idx, target)))
                return memo[(idx, target)];

            int exclude = CoinChange0(coins, idx + 1, target, memo);
            int include = CoinChange0(coins, idx, target - coins[idx], memo);

            if (include != int.MaxValue)
                include += 1;

            return memo[(idx, target)] = Math.Min(include, exclude);

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
