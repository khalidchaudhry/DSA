using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.BinarySearch
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
                    if (target >= nums[low] && target <= nums[mid])
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
                    if (target > nums[mid] && target <= nums[high])
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
        /// <summary>
        //! 1. Find pivot first 
        //!2. search the portion of an array
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search2(int[] nums, int target)
        {
            int n = nums.Length - 1;

            if (nums.Length == 0)
                return -1;

            if (nums[0] <= nums[n]) //!array is already sorted
                return BinarySearch(nums, 0, n, target);

            int pivotIndex = FindPivotIndex(nums);
            if (nums[pivotIndex] == target)
                return pivotIndex;
            else if (target >= nums[0] && target < nums[pivotIndex])
                return BinarySearch(nums, 0, pivotIndex - 1, target);
            else
                return BinarySearch(nums, pivotIndex + 1, n, target);
        }
        private int FindPivotIndex(int[] nums)
        {
            int low = 0;
            int pivotIndex = -1;
            int high = nums.Length - 1;

            while (low <= high)
            {
                int mid = low + ((high - low) / 2);
                //! pivot element is one having left element  and right element  less than it.
                //! pivot element is the largest element in an array
                //! Comparing only on the right side is enough
                if (nums[pivotIndex] > nums[pivotIndex + 1])
                {
                    return mid;
                }
                // !Pivot element always present in the non uniformly increasing part
                //! if first element is less than pivot index element than it means its strictly increasing 
                //! we need to search on  right side as its non uniformly increasing part
                else if (nums[low] <= nums[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    //! why mid and why not mid-1? 
                    //!because element at pivot index can also be the part of the non uniformly increasing 
                    high = mid;
                }
            }
            return pivotIndex;

        }

        private int BinarySearch(int[] nums, int lo, int hi, int target)
        {
            while (lo <= hi)
            {
                int mid = lo + ((hi - lo) / 2);

                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                    hi = mid - 1;
                else
                    lo = mid + 1;
            }

            return -1;
        }

    }
}
