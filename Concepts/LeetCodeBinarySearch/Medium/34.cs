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
            int[] result = new int[2];
            result[0] = -1;
            result[1] = -1;
            int lo = 0;
            int hi = nums.Length - 1;
            //! finding the start of the target
            while (lo <= hi)
            {
                int mid = lo + ((hi - lo) / 2);
                if (nums[mid] == target)
                {
                    result[0] = mid;
                    hi = mid - 1;
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

            lo = 0;
            hi = nums.Length - 1;
            //! finding the end of the target
            while (lo <= hi)
            {
                int mid = lo + ((hi - lo) / 2);
                if (nums[mid] == target)
                {
                    result[1] = mid;
                    lo = mid + 1;
                }
                else if (nums[mid] < target)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }
            
            return result;
        }


    }
}
