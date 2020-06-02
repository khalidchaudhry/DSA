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
        //! Quick select algorithm
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest0(int[] nums, int k)
        {
            int requiredIndex = nums.Length - k;
            int left = 0;
            int right = nums.Length-1;
            int pti = 0;
            while (left < right)
            {
                pti = PivotIndex(nums, left, right);

                if (pti == requiredIndex)
                {
                    break;
                }

                else if (pti > requiredIndex)
                {
                    right = pti - 1;
                }
                else
                {
                    left = pti + 1;
                }

            }

            return nums[requiredIndex];

        }

        private int PivotIndex(int[] nums, int left, int right)
        {
            int pti = left;
            for (int i = left; i < right; i++)
            {
                //!<= for duplicate condition
                if (nums[i] <= nums[right])
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
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k)
        {

            SortedDictionary<int, int> heap = new SortedDictionary<int, int>();
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
            Array.Sort<int>(nums, new Comparison<int>(
                      (i1, i2) => i2.CompareTo(i1)));

            return nums[k - 1];

        }


    }
}
