using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRecursion.Medium
{
    public class _698
    {
        public static void _698Main()
        {
            int[] nums = new int[4] { 1, 3, 1, 3 };
            int k = 2;
            var test = new _698();
            var ans = test.CanPartitionKSubsets(nums, k);
               
        }
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            List<int> buckets = new List<int>();
            int sum = nums.Sum();
            nums = nums.OrderByDescending(x => x).ToArray();
            if (sum % k != 0) return false;

            int target = sum / k;

            for (int i = 0; i < k; ++i)
            {
                buckets.Add(0);
            }
            return Helper(nums, 0, k, target, buckets);
        }

        public bool CanPartitionKSubsets0(int[] nums, int k)
        {
            int[] buckets = new int[k];
            return Helper(nums, buckets, 0);
        }
        private bool Helper(int[] nums, int idx, int k, int target, List<int> buckets)
        {
            if (idx == nums.Length)
            {
                return true;
            }

            for (int i = 0; i < k; ++i)   // Choices 
            {
                //!Short circut .If bucket size + current item greater than target don't go in recursion. 
                if (buckets[i] + nums[idx] > target) continue;
                
                buckets[i] = buckets[i] + nums[idx];
                if (Helper(nums, idx + 1, k, target, buckets))
                    return true;
                buckets[i] = buckets[i] - nums[idx];
            }

            return false;
        }

        private bool Helper(int[] nums, int[] buckets, int idx)
        {
            if (idx == nums.Length)
            {
                for (int i = 1; i < buckets.Length; ++i)
                {
                    if (buckets[i] != buckets[i - 1])
                        return false;
                }
                return true;
            }

            for (int i = 0; i < buckets.Length; ++i) // Choices for nums elements 
            {
                buckets[i] += nums[idx];
                if (Helper(nums, buckets, idx + 1))
                    return true;
                buckets[i] -= nums[idx];
            }

            return false;
        }

    }

}

