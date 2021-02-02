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
            int[] buckets = new int[k];
            int sum = nums.Sum();
            nums = nums.OrderByDescending(x => x).ToArray();
            if (sum % k != 0) return false;

            int target = sum / k;

           
            return CanPartitionKSubsets(nums, 0, k, target, buckets);
        }
       
        private bool CanPartitionKSubsets(int[] nums, int numsIdx, int totalBuckets, int target, int[] buckets)
        {
            if (numsIdx == nums.Length)
            {
                return true;
            }

            for (int bucket = 0; bucket < totalBuckets; ++bucket)   // Choices 
            {
                //!Short circut .If bucket size + current item > target don't go in recursion. 
                if (buckets[bucket] + nums[numsIdx] > target) continue;
                
                buckets[bucket] = buckets[bucket] + nums[numsIdx];
                if (CanPartitionKSubsets(nums, numsIdx + 1, totalBuckets, target, buckets))
                    return true;
                buckets[bucket] = buckets[bucket] - nums[numsIdx];
            }

            return false;
        }

        public bool CanPartitionKSubsets0(int[] nums, int k)
        {
            int[] buckets = new int[k];
            return Helper(nums, buckets, 0);
        }
        private bool Helper(int[] nums, int[] buckets, int idx)
        {
            //!explicitly checking that sum of all the elements in buckets are equal
            //! Optimized version does not do it. Before assigning value to the bucket we check if adding item to the bucket excceds our targer
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

