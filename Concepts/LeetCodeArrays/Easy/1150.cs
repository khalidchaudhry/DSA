using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    public class _1150
    {

        /// <summary>
        //! Using binary search logn solution  
        /// </summary>
        public bool IsMajorityElement(int[] nums, int target)
        {
            int[] indexes = new int[] { -1, -1 };

            //Apply binary search to get first occurance of target
            FindIndexes(nums, target, indexes, true);
            //Apply binary search to get last occurance of target
            FindIndexes(nums, target, indexes, false);
            //! we are not able to find target, return false 
            if (indexes[0] == -1 || indexes[1] == -1)
                return false;
            //how many times target appears 
            int count = indexes[1] - indexes[0] + 1;

            if (count > (nums.Length / 2))
                return true;
            else
                return false;
        }
        private void FindIndexes(int[] nums, int target, int[] indexes, bool isFirstOccurance)
        {
            int lo = 0;
            int hi = nums.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (nums[mid] == target)
                {
                    if (isFirstOccurance)
                    {
                        indexes[0] = mid;
                        hi = mid - 1;
                    }
                    else
                    {
                        indexes[1] = mid;
                        lo = mid + 1;
                    }
                }
                else if (nums[mid] > target)
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }
        }

        /// <summary>
        //! Using Boyer Moore voting algorithm  
        /// </summary>
        public bool IsMajorityElement2(int[] nums, int target)
        {
            int c1 = FindCandidate(nums);

            if (!IsMajority(nums, c1))
                return false;

            if (c1 == target)
                return true;

            return false;
        }

        private int FindCandidate(int[] nums)
        {
            int c1 = 0;
            int c1Count = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (c1 == nums[i])
                    ++c1Count;
                else if (c1Count == 0)
                {
                    c1 = nums[i];
                    c1Count = 1;
                }
                else
                {
                    --c1Count;
                }
            }
            return c1;

        }

        private bool IsMajority(int[] nums, int candidate)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] == candidate)
                    ++count;
            }

            if (count <= nums.Length / 2) return false;
            return true;
        }

    }
}
