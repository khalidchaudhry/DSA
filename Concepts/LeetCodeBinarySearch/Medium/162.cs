using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    public class _162
    {
        public int FindPeakElement(int[] nums)
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
