using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideAndConquer.cs
{
    public class FirstAndLastOccurance
    {
        public int[] SearchRange(int[] nums, int target)
        {
            int[] result = new int[] { -1, -1 };
            if (nums.Length == 0)
            {
                return result;
            }
            int lo = 0;
            int hi = nums.Length - 1;
            SearchRange(nums, lo, hi, target, result, true);

            lo = 0;
            hi = nums.Length - 1;

            SearchRange(nums, lo, hi, target, result, false);
            return result;
        }

        private void SearchRange(int[] nums, int lo, int hi, int target, int[] result, bool loRange)
        {
            if (lo > hi) return;
            int mid = lo + (hi - lo) / 2;

            if (nums[mid] == target)
            {
                if (loRange)
                {
                    //! Setting the mid index(not value at mid index) as the result
                    result[0] = mid;
                    SearchRange(nums, lo, mid - 1, target, result, loRange);
                }
                else
                {
                    //! Setting the mid index as the result
                    result[1] = mid;                   
                    SearchRange(nums, mid + 1, hi, target, result, loRange);
                }
            }
            else if (nums[mid] > target)
            {
                SearchRange(nums, lo, mid - 1, target, result, loRange);
            }
            else
            {
                SearchRange(nums, mid + 1, hi, target, result, loRange);
            }
        }
    }
}
