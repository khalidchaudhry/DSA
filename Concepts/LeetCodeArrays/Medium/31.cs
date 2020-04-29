using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _31
    {
        /// <summary>
        /// https://www.youtube.com/watch?v=PYXl_yY-rms
        //!We have permutation divided into 2 parts 
        //!1. Prefix(left side) and suffix(right side)
        //!To get next permutation we need to fix prefix and suffix 
        //! 
        /// </summary>
        /// <param name="nums"></param>
        public void NextPermutation(int[] nums)
        {
            //!we are taking length-2 because the last spot that is length-1 is already permuted means we cannot permutate the last position right
            int k = nums.Length - 2;

            //! We are moving from right to left till left element is greater than k
            //! It is to find the longest descreasing suffix 
            //! nums[k] >= nums[k + 1] ---   >= is important incase there are duplicate elements  like [2,3,1,3,3]
            while (k >= 0 && nums[k] >= nums[k + 1])
            {
                --k;
            }
            //! special case where given permutation is the last permutation than we just sort in ascending order
            //! if its last permutation than elements will be in descending order so we can just reverse the array and return 
            if (k == -1)
            {
                Reverse(nums,0,nums.Length-1);
                return;
            }
            //!We need to find the smallest element suffix which are bigger than element at k index and swap it with k index
            for (int l = nums.Length - 1; l > k; l--)
            {
                if (nums[l] > nums[k])
                {
                    int temp = nums[l];
                    nums[l] = nums[k];
                    nums[k] = temp;
                    break;
                }
            }
            //! Last step we need to do is to fix suffix by reversing the elements 
            Reverse(nums,k+1,nums.Length-1);

        }
        private void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                ++start;
                --end;
            }
        }
    }
}
