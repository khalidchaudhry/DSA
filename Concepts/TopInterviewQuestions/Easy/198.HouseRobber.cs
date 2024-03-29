﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _198
    {

        /// <summary>
        //! Recursion with memoization 
        /// </summary>
        public int Rob0(int[] nums)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>();
            return Rob0(nums, 0, memo);
        }

        private int Rob0(int[] nums, int idx, Dictionary<int, int> memo)
        {
            if (idx >= nums.Length)
                return 0;
            if (memo.ContainsKey(idx))
                return memo[idx];

            int rob = nums[idx] + Rob0(nums, idx + 2, memo);
            int notRob = Rob0(nums, idx + 1, memo);
            return memo[idx] = Math.Max(rob, notRob);
        }

        /// <summary>
        /// https://www.programcreek.com/2014/03/leetcode-house-robber-java/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {

            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            int even = 0, odd = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    even += nums[i];
                    even = Math.Max(even, odd);
                }
                else
                {
                    odd += nums[i];
                    odd = Math.Max(odd, even);
                }
            }

            return Math.Max(even,odd);
        }

        public int Rob2(int[] nums)
        {
            int n = nums.Length;
            if (n == 0)
                return 0;
            if (n == 1)
                return nums[0];

            int[] maxMoney = new int[n];

            maxMoney[0] = nums[0];
            maxMoney[1] = Math.Max(nums[0], nums[1]);

            for (int i = 2; i < n; ++i)
            {
                maxMoney[i] = Math.Max(maxMoney[i - 1], nums[i] + maxMoney[i - 2]);
            }

            return maxMoney[maxMoney.Length - 1];

        }



    }
}
