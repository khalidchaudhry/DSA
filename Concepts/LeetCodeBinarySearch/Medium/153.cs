using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    public class _153
    {
        /// <summary>
        /// // # <image url="https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/Figures/153/153_Minimum_Rotated_Sorted_Array_3.png" scale="0.6" />  
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin(int[] nums)
        {

            if (nums.Length == 1) return nums[0];
            int pivotIndex = FindPivotIndex(nums);
            return nums[pivotIndex + 1];
        }
        private int FindPivotIndex(int[] nums)
        {
            int lo = 0;
            int hi = nums.Length - 1;

            while (lo < hi)
            {
                int mid = lo + ((hi - lo) / 2);

                if (nums[mid] > nums[mid + 1])
                {
                    return mid;
                }
                //!its strictly increasing and we need to search the other half
                else if (nums[lo] < nums[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid;
                }

            }

            return -1;
        }

    }
}
