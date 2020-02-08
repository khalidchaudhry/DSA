using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _35
    {
        public int SearchInsert(int[] nums, int target)
        {

            int i = 0;
            int j = nums.Length - 1;
            // very important .. Condition should be <= else it will not return the correct index but why ?
            while (i <= j)
            {
                //https://stackoverflow.com/questions/6735259/calculating-mid-in-binary-search
                //https://ai.googleblog.com/2006/06/extra-extra-read-all-about-it-nearly.html
                // to avoid overflow (i+j) / 2; will cause overflow.
                int mid = i + ((j - i) / 2);
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] > target)
                {
                    j = mid - 1;
                }
                else
                {
                    i = mid + 1;
                }
            }

            return i;
        }


    }
}
