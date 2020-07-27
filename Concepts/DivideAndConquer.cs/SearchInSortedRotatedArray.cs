using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideAndConquer.cs
{
    public class SearchInSortedRotatedArray
    {
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0)
                return -1;

            int lo = 0;
            int hi = nums.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (nums[mid] == target)
                    return mid;
                else if (nums[lo] < nums[mid])
                {
                    if (nums[lo] <= target && nums[mid] >= target)
                    {
                        hi = mid - 1;
                    }
                    else
                    {
                        lo = mid + 1;
                    }
                }
                else
                {
                    if (nums[mid] >= target && nums[hi] <= target)
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        hi = mid - 1;
                    }
                }
            }

            return -1;
        }
    }
}
