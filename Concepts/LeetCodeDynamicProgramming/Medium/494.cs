using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _494
    {
        int target = 0;

        public static void _494Main()
        {
            int[] nums = new int[] { 1, 1, 1, 1, 1 };
            int S = 3;
            _494 FindTargetSumWays = new _494();

            var ans = FindTargetSumWays.FindTargetSumWays1(nums, S);

        }

        /// <summary>
        //! DP with memoization 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="S"></param>
        /// <returns></returns>
        public int FindTargetSumWays1(int[] nums, int S)
        {
            target = S;
            Dictionary<string, int> cache = new Dictionary<string, int>();
            return FindTargetSumWays1(nums, 0, 0, cache);
        }

        /// <summary>
        //! Brute Force
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="S"></param>
        /// <returns></returns>
        public int FindTargetSumWays2(int[] nums, int S)
        {
            target = S;
            return FindTargetSumWays2(nums, 0, 0);
        }

        private int FindTargetSumWays2(int[] nums, int i, int sum)
        {
            if (i == nums.Length)
            {
                if (sum == target)
                    return 1;
                else
                {
                    return 0;
                }
            }
            int postive = FindTargetSumWays2(nums, i + 1, sum + nums[i]);
            int negative = FindTargetSumWays2(nums, i + 1, sum - nums[i]);
            return postive + negative;
        }

        private int FindTargetSumWays1(int[] nums, int i, int sum, Dictionary<string, int> cache)
        {
            if (i == nums.Length)
            {
                if (sum == target)
                    return 1;
                else
                {
                    return 0;
                }
            }

            string key = $"{sum}${i}";
            if (cache.ContainsKey(key))
            {
                return cache[key];
            }
            else
            {

                int postive = FindTargetSumWays1(nums, i + 1, sum + nums[i], cache);
                int negative = FindTargetSumWays1(nums, i + 1, sum - nums[i], cache);

                cache[key] = postive + negative;

                return cache[key];
            }
        }
    }
}
