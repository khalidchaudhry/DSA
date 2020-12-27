using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    public class _162
    {


        public static void _162Main()
        {
            var test = new _162();

            var ans = test.FindPeakElement0(new int[] { 1, 2, 1, 3, 5, 6, 4 });

            Console.ReadLine();

        }

        /// <summary>
        //! Question: Is the current element greater than the element to the left of it?
        //! Same as problem 852. Copy paste 
        //! Based on Roger binary search template 
        /// </summary>
        public int FindPeakElement0(int[] nums)
        {
            int lo = 0;
            int hi = nums.Length;

            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (OK(nums, mid))
                {
                    lo = mid;
                }
                else
                {
                    hi = mid;
                }
            }
            return lo;
        }

        /// <summary>
        //!TTT'T'FFFFF
        //!// Is current number larger than the number towards left of it
        /// </summary>

        private bool OK(int[] nums, int index)
        {
            return nums[index] > nums[index - 1];
        }

        public int FindPeekElement1(int[] nums)
        {
            int lo = 0;
            int hi = nums.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + ((hi - lo) / 2);
                //! in case of mid=0 we don't need to compare on the left side as nothing exists on left side
                //! in case of mid == nums.Length - 1 we don't need to compare right side as nothing exists on right side. 
                if (
                    (mid == 0 || nums[mid] > nums[mid - 1]) &&
                    (mid == nums.Length - 1 || nums[mid] > nums[mid + 1])
                   )
                {
                    return mid;
                }
                else if (nums[mid + 1] > nums[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }

            return -1;
        }

    }
}
