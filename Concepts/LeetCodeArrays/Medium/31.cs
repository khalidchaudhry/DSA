using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _31
    {

        public static void _31Main()
        {
            _31 Test = new _31();
            int[] arr = new int[] { 2, 3, 1 };
            Test.NextPermutation0(arr);
            Console.ReadLine();

        }

        /// <summary>
        /// https://www.youtube.com/watch?v=hPd4MFdg8VU
        //! What:
        //! 1. Scanning from right,find the candidate element less than next element in array
        //! 2. Sort/reverse elements starting next of candidate element so that they are in ascending oder
        //! 3. Swap the first element in sorted array with the element which is greater then the first element 
        /// </summary>
        public void NextPermutation0(int[] nums)
        {
            int j = nums.Length - 2;
            while (j >= 0)
            {
                if (nums[j] < nums[j + 1])
                {
                    Reverse(nums, j + 1);
                    Swap(nums, j);
                    break;
                }
                --j;
            }

            if (j < 0)
                Reverse(nums, 0);
        }


        private void Reverse(int[] nums, int index)
        {
            int i = index;
            int j = nums.Length - 1;
            while (i < j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;

                ++i;
                --j;
            }
        }
        private void Swap(int[] nums, int index)
        {
            int j = index + 1;
            while (j < nums.Length)
            {
                if (nums[j] > nums[index])
                {
                    int temp = nums[index];
                    nums[index] = nums[j];
                    nums[j] = temp;
                    break;
                }
                ++j;
            }
        }


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
            //! nums[k] >= nums[k + 1] ---   >=(equal to) is important incase there are duplicate elements  like [2,3,1,3,3]
            while (k >= 0 && nums[k] >= nums[k + 1])
            {
                --k;
            }
            //! special case where given permutation is the last permutation than we just sort in ascending order
            //! if its last permutation than elements will be in descending order so we can just reverse the array and return 
            if (k == -1)
            {
                Reverse(nums, 0, nums.Length - 1);
                return;
            }
            //!We need to find the smallest element in the suffix which is  bigger than element at k index and swap it with k index
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
            //! change from  decreasing to increasing since that will be the first permuatation 
            Reverse(nums, k + 1, nums.Length - 1);

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
