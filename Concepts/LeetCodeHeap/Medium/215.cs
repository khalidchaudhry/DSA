﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeHeap.Medium
{
    public class _215
    {
        /// <summary>
        /// https://www.youtube.com/watch?v=MZaf_9IZCrc
        //!  Guranteed O(N)
        /// https://efficientcodeblog.wordpress.com/2017/12/04/quick-select/#:~:text=It%20is%20related%20to%20the%20quicksort%20sorting%20algorithm.&text=However%2C%20instead%20of%20recursing%20into,of%20O(n2).
        //! Quick select algorithm. Same as in question 973
        /// </summary>
        public int FindKthLargest0(int[] nums, int k)
        {
            //! The index where final answer will reside
            int requiredIndex = nums.Length - k;
            return Find(nums, requiredIndex);
        }

        private int Find(int[] nums, int requiredIndex)
        {
            int left = 0;
            int right = nums.Length - 1;
            Random random = new Random();
            while (left <= right)
            {
                //! We are randomly picking an index &  
                //! place element at that index to its correct position
                int pivotIndex = random.Next(left, right + 1);
                //! Below function returns the index of the element( at pivot index returns by above method)  after placing it at its correct position
                int index = Partition(nums, left, right, pivotIndex);
                if (index == requiredIndex)
                    break;
                else if (index > requiredIndex)
                    right = index - 1;
                else
                    left = index + 1;
            }
            return nums[requiredIndex];
        }
               
        private int Partition(int[] nums, int left, int right, int pivotIndex)
        {            
            int pivotElemenet = nums[pivotIndex];
            //! swap the pivot element with the right element . Setting aside the pivot
            Swap(nums, right, pivotIndex);
            
            // !pivot tail index
            int pti = left;
            for (int i = left; i < right; i++)
            {
                //!<= for duplicate condition
                if (nums[i] <= pivotElemenet)
                {
                    Swap(nums, i, pti);
                    ++pti;
                }
            }
            //!Swap 
            Swap(nums, pti, right);
            // pti is the correct position of the element which was previously at pivotIndex position
            return pti;
        }
        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];

            arr[i] = arr[j];

            arr[j] = temp;
        }


        /// <summary>
        //! heap sort brings down complexity from O(nlog(n)) for sorting to O(nlogK) 
        //! n total elements and k heap size
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k)
        {
            PQ<(int val, int idx)> pq = new PQ<(int val, int idx)>();

            for (int i = 0; i < nums.Length; ++i)
            {
                pq.Add((nums[i], i));

                if (pq.Size > k)
                {
                    pq.Poll();
                }
            }

            return pq.Poll().val;


        }

        public int FindKthLargest2(int[] nums, int k)
        {

            // Sort the arr from last to first. 
            // compare every element to each other 

            int n = nums.Length;
            Array.Sort(nums);
            return nums[n - k];

        }


    }
}
