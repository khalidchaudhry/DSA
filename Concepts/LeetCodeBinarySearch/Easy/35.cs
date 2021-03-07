using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinarySearch.Easy
{
    class _35
    {
        public int SearchInsert(int[] nums, int target)
        {

            int lo = 0;
            int hi = nums.Length - 1;
            // very important .. Condition should be <= else it will not return the correct index but why ?
            while (lo <= hi)
            {
                //https://stackoverflow.com/questions/6735259/calculating-mid-in-binary-search
                //https://ai.googleblog.com/2006/06/extra-extra-read-all-about-it-nearly.html
                // to avoid overflow (i+j) / 2; will cause overflow.
                int mid = lo + ((hi - lo) / 2);
                if (nums[mid] == target)
                {
                    return mid;
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

            return lo;
        }

        public int SearchInsert0(int[] nums, int target)
        {
            int lo = -1;
            int hi = nums.Length - 1;
            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (OK(nums, mid, target))
                {
                    hi = mid;
                }
                else
                {
                    lo = mid;
                }
            }

            return target > nums[hi] ? nums.Length : hi;
        }

        /// <summary>
        //! is the number at i index greater than or equal to target
        //! FFFF'T'TTTTT
        /// </summary>
        private bool OK(int[] nums, int index, int target)
        {
            return nums[index] >= target;
        }
    }
}
