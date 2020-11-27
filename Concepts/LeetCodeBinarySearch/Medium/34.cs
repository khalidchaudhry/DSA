using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    public class _34
    {
        public int[] SearchRange(int[] nums, int target)
        {
            int[] result = new int[] { -1, -1 };
            bool firstOccurance = true;
            Search(nums, target, result, firstOccurance);
            Search(nums, target, result, !firstOccurance);
            return result;
        }

        private void Search(int[] nums, int target, int[] result, bool firstOccurance)
        {
            int lo = 0;
            int hi = nums.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + ((hi - lo) / 2);

                if (nums[mid] == target)
                {
                    if (firstOccurance)
                    {
                        result[0] = mid;
                        hi = mid - 1;
                    }
                    else
                    {
                        result[1] = mid;
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
