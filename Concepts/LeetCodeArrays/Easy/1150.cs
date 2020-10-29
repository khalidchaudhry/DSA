using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    public class _1150
    {
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
    }
}
