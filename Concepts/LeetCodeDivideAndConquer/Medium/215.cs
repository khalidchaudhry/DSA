using LeetCodeHeap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDivideAndConquer.Medium
{
    public class _215
    {
        public static void _215Main()
        {
            _215 test = new _215();
            int[] nums = new int[] { 3, 2, 1, 5, 6, 4 };
            test.FindKthLargest0(nums, 2);


        }
        /// <summary>
        //! Quick select algorithm. Same as in question 973
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        /// 
        public int FindKthLargest0(int[] nums, int k)
        {
            int requiredIdx = nums.Length - k;
            return QuickSelect(nums, 0, nums.Length - 1, requiredIdx);
        }
        private int QuickSelect(int[] nums, int s, int e, int k)
        {
            Random random = new Random();
            while (s <= e)
            {
                int pIndex = random.Next(s, e + 1);
                int index = Partition(nums, s, e, pIndex);
                if (index == k)
                {
                    return nums[index];
                }
                else if (index > k)
                {
                    e = index - 1;
                }
                else
                {
                    s = index + 1;
                }
            }

            return -1;
        }
        /// <summary>
        //! All the elements on the left of the partition are < pivot
        //! All the element od the right of the partition are >=pivot
        /// </summary>
        private int Partition(int[] arr, int s, int e, int pIndex)
        {
            //!swap last element in array with pivot essentially keeping it aside
            Swap(arr, e, pIndex);
            int pti = s;
            //! We are doing < e since e has pivot element
            for (int i = s; i < e; ++i)
            {
                if (arr[i] < arr[e])
                {
                    Swap(arr, i, pti);
                    ++pti;
                }
            }
            Swap(arr, pti, e);
            return pti;
        }
        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }


        /// <summary>
        //! heap sort brings down complexity from O(nlog(n)) for sorting to O(nlogK) for k < n
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k)
        {
            PQ<int> pq = new PQ<int>();

            for (int i = 0; i < nums.Length; ++i)
            {
                pq.Add(nums[i]);
                if (pq.Size > k)
                {
                    pq.Poll();
                }
            }
            return pq.Peek();

        }

        public int FindKthLargest2(int[] nums, int k)
        {

            // Sort the arr from last to first. 
            // compare every element to each other 

            int n = nums.Length;
            Array.Sort(nums);
            //! returning an index from the last
            return nums[n - k];

        }


    }
}
