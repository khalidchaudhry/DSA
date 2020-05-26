using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDivideAndConquer.Medium
{
    public class _215
    {

        public int FindKthLargest0(int[] nums, int k)
        {

           

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
