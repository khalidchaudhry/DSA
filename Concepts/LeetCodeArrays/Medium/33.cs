using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _33
    {
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0)
                return -1;
            int low = 0, high = nums.Length - 1;

            int mid = low + ((high - low) / 2);

            if (nums[mid] == target)
                return mid;

            if (nums[mid] > nums[high])
            {
                low = mid + 1;
            }
            else if (nums[mid] < nums[high])
            {
                high = mid;
            }

            while (low <= high)
            {
                if (nums[low] == target)
                    return low;
                ++low;
            }

            return -1;
        }

    }
}
