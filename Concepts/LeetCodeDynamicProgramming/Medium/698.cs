﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _698
    {
        /// <summary>
        /// https://github.com/bephrem1/backtobackswe/blob/master/Dynamic%20Programming%2C%20Recursion%2C%20%26%20Backtracking/PartitionIntoKEqualSumSubsets/PartitionIntoKEqualSumSubsets.java
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            int sum = 0;
            bool[] used = new bool[nums.Length];
            /*
              Get the sum of all items in the array. We will use this to
              divide by k to get the sum that each bucket needs to hit
             */
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            /*
              1.) k can not be negative or 0 because we can not fill 0
              or negative buckets
              2.) k can not be greater than the length of the array,
              we can't partition more buckets than there are elements
              in the array
              3.) sumOfAllArrayItems % k must be 0. If it is not then
              we would have to have to fill buckets to a floating point
              sum which would be impossible with only integers
            */
            if (k <= 0 ||k>nums.Length || sum % k != 0)
                return false;

            return CanPartition(0, nums, used, k, 0, sum / k);
        }

        private bool CanPartition(int startIndex, int[] nums, bool[] used, int k, int inProgressBucketSum, int targetBucketSum)
        {
            
            /*
              If we have filled all k - 1 buckets up to this point and we are now on
              our last bucket, we can stop and be finished.
      
              Example:
              arr = [4, 3, 2, 3, 5, 2, 1]
              k = 4
              targetBucketSum = 5
              If we get to the point in our recursion that k = 1 that means we have filled
              k - 1 buckets (4 - 1 = 3). 3 buckets have been filled, each a value of 5 meaning
              we have "eaten" 15 "points" of value from an array that sums to 20.
              This means we have 5 "points" to extract from the array and that for sure will fill
              the last bucket. So at the point there is 1 bucket left, we know we can complete the
              partitioning (we don't have to though, we just want to know whether we can or not).
              */
            if (k == 1)
                return true;
            /*
             Bucket full. continue the recursion with k - 1 as the new k value, BUT the
            targetBucketSum stays the same. We just have 1 less bucket to fill.
            */
            if (inProgressBucketSum == targetBucketSum)
            {
                return CanPartition(0, nums, used, k - 1, 0, targetBucketSum);
            }
            /*
              Try all values from 'iterationStart' to the end of the array ONLY if:

              1.) They have not been used up to this point in the recursion's path
              2.) They do not overflow the current bucket we are filling
              */

            for (int i = startIndex; i < nums.Length; i++)
            {
                if (!used[i] && inProgressBucketSum + nums[i] <= targetBucketSum)
                {
                    used[i] = true;
                    /*
                         See if we can partition from this point with the item added
                        to the current bucket progress
                      */
                    if (CanPartition(i + 1, nums, used, k, inProgressBucketSum + nums[i], targetBucketSum))
                    {
                        return true;
                    }
                    used[i] = false;
                }
            }
            /*
                See if we can partition from this point with the item added
                to the current bucket progress
            */
            return false;
        }
    }
}
