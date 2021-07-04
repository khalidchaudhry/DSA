using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Hard
{
    class _45
    {

        /// <summary>
        //! Sanme pattern followed in problem 322
        /// </summary>
        public int Jump0(int[] nums)
        {

            Dictionary<int, int> memo = new Dictionary<int, int>();
            return Jump0(nums, 0, memo);
        }

        private int Jump0(int[] nums, int idx, Dictionary<int, int> memo)
        {
            if (idx >= nums.Length)
                return int.MaxValue;
            if (idx == nums.Length - 1)
                return 0;

            if (memo.ContainsKey(idx))
                return memo[idx];

            int minJumps = int.MaxValue;
            for (int i = nums[idx]; i > 0; --i)
            {
                int jumps = Jump0(nums, idx + i, memo);
                //! if value is max , we can't increment as it will cause stack over flow
                if (jumps != int.MaxValue)
                {
                    ++jumps;
                }
                minJumps = Math.Min(minJumps, jumps);
            }

            return memo[idx] = minJumps;
        }
    }
}
