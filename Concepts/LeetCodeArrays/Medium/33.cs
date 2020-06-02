using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _33
    {
        /// <summary>
        //https://www.youtube.com/watch?v=oTfPJKGEHcc
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;

            while (low <= high)
            {
                int mid = low + ((high - low) / 2);

                if (nums[mid] == target)
                {
                    return mid;
                }
                //!if left half is having uniformly increasing values 
                else if (nums[low] <= nums[mid])
                {
                    //! target value exists in left and mid range
                    if (target>=nums[low] && target<=nums[mid])
                    {
                        high = mid - 1;
                    }
                    //!target value exists on the mid+1 and right range 
                    else
                    {
                        low = mid + 1;
                    }
                }
                //!if left side is not increasing than right side must have uniformly increasing values
                else
                {   //! //! target value exists in mid and high range
                    if (target>=nums[mid] && target<=nums[high])
                    {
                        low = mid + 1;
                    }
                    //! target value exists on the low and mid-1  range 
                    else
                    {
                        high = mid - 1;
                    }
                }
            }

            return -1;
        }

    }
}
