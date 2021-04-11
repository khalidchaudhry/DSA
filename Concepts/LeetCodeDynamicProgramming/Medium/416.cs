using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _416
    {
        /// <summary>
        //! Using include/exclude pattern 
        /// </summary>
         public bool CanPartition0(int[] nums)
        {

            int sum = nums.Sum();

            if (sum % 2 == 1)
            {
                return false;
            }

            Dictionary<(int, int), bool> memo = new Dictionary<(int, int), bool>();
            return CanPartition0(nums, 0, (sum / 2), memo);
        }

        private bool CanPartition0(int[] nums, int s, int target, Dictionary<(int, int), bool> memo)
        {
            if (target == 0)
            {
                return true;
            }
            if (target < 0 || s == nums.Length)
            {
                return false;
            }

            if (memo.ContainsKey((s, target)))
            {
                return memo[(s, target)];
            }

            //bool include=CanPartition(nums,s+1,target-nums[s],memo);
            //bool exclude=CanPartition(nums,s+1,target,memo);


            return memo[(s, target)] = CanPartition(nums, s + 1, target - nums[s], memo) || CanPartition(nums, s + 1, target, memo);

        }



        /// <summary>
        //!  
        /// </summary>
        public bool CanPartition(int[] nums)
        {

            int sum = nums.Sum();

            if (sum % 2 == 1)
            {
                return false;
            }

            Dictionary<(int, int), bool> memo = new Dictionary<(int, int), bool>();
            return CanPartition(nums, 0, (sum / 2), memo);
        }

        private bool CanPartition(int[] nums, int s, int target, Dictionary<(int, int), bool> memo)
        {
            if (target == 0)
            {
                return true;
            }
            if (target < 0)
            {
                return false;
            }

            if (memo.ContainsKey((s, target)))
            {
                return memo[(s, target)];
            }

            for (int i = s; i < nums.Length; ++i)
            {

                if (CanPartition(nums, i + 1, target - nums[i], memo))
                {
                    return memo[(s, target)] = true;
                }
            }
            return memo[(s, target)] = false;

        }


    }
}
