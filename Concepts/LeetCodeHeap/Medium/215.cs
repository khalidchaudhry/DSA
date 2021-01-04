using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDivideAndConquer.Medium
{
    public class _215
    {
        /// <summary>
        //! Quick select algorithm. Same as in question 973
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest0(int[] nums, int k)
        {
            //! The index where final answer will reside
            int requiredIndex = nums.Length - k;
            PlacePivot(nums,requiredIndex);           
            return nums[requiredIndex];

        }

        private void PlacePivot(int[] nums, int requiredIndex)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int pti = PivotIndex(nums, left, right);
                if (pti == requiredIndex)
                    break;
                else if (pti > requiredIndex)
                    right = pti - 1;
                else
                    left = pti + 1;
            }
        }


        /// <summary>
        // ! The correct location of  the pivot(It is the element in the array that is at index left)
        /// </summary>
        private int PivotIndex(int[] nums, int left, int right)
        {
            // !pivot tail index
            int pti = left;
            //! our pivot sits at right
            int pivot = nums[right];

            for (int i = left; i < right; i++)
            {
                //!<= for duplicate condition
                if (nums[i] <= pivot)
                {
                    Swap(nums, i, pti);
                    ++pti;
                }
            }

            //!Swap 
            Swap(nums, pti, right);

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

            //! we want to remove  the smallest element hence we are taking sorted dictionary 
            SortedDictionary<int, int> heap = new SortedDictionary<int, int>();
            //! Count variable is use to track if elements in dictionary are greater than we will 
            // !remove the smallest element from sorted dictionary 
            // ! we are not using sorted dictionary count because  it will contain only distinct element counts 
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (heap.ContainsKey(nums[i]))
                {
                    heap[nums[i]]++;

                }
                else
                {
                    heap.Add(nums[i], 1);
                }

                ++count;
                if (count > k)
                {
                    int minKey = heap.First().Key;
                    if (heap[minKey] == 1)
                    {
                        heap.Remove(minKey);
                    }
                    else
                    {
                        --heap[minKey];
                    }
                    --count;

                }
            }

            return heap.First().Key;

        }

        public int FindKthLargest2(int[] nums, int k)
        {

            // Sort the arr from last to first. 
            // compare every element to each other 

            int n = nums.Length;
            Array.Sort(nums);
            return nums[n-k];

        }


    }
}
