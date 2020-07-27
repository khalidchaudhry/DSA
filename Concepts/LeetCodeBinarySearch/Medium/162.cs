using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    public class _162
    {

        /// <summary>
        ///https://www.techiedelight.com/find-peak-element-array/ 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindPeakElement(int[] nums)
        {
            int lo = 0;
            int hi = nums.Length - 1;
            if (nums.Length == 1) return 0;
            return FindPeekElement(nums, lo, hi);
        }
        
        private int FindPeekElement(int[] nums, int lo, int hi)
        {
            if (lo > hi)
                return -1;
            int mid = lo + ((hi - lo) / 2);

            if (
                (mid == 0 || nums[mid] > nums[mid - 1]) &&
                (mid == nums.Length - 1 || nums[mid] > nums[mid + 1])
               )
            {
                return mid;
            }
            else if (nums[mid + 1] > nums[mid])
            {
                return FindPeekElement(nums, mid + 1, hi);
            }
            else
            {
                return FindPeekElement(nums, lo, mid - 1);
            }
        }

        public int FindPeakElement2(int[] nums)
        {
            int n = nums.Length;
            if (n == 1)
                return 0;

            int lo = 0;
            int high = n - 1;

            while (lo < high)
            {
                int mid = lo + ((high - lo) / 2);

                if (nums[mid] > nums[mid + 1])
                {
                    return mid;
                }
                else if (nums[mid] < nums[mid + 1])
                {
                    lo = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }

            }

            return -1;
        }
    }
}
