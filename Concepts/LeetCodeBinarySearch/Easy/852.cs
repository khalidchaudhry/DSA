using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Easy
{
    public class _852
    {

        /// <summary>
        //! Intuition: Is the current element greater than the element to the left of it ?
        //! Same as question 162. Exact copy paste code. 
        //!Based on Roger template 
        /// </summary>
        public int PeakIndexInMountainArray0(int[] arr)
        {
            int lo = 0;
            int hi = arr.Length;

            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (OK(arr, mid))
                {
                    lo = mid;
                }
                else
                {
                    hi = mid;
                }
            }
            return lo;
        }

        private bool OK(int[] arr, int index)
        {
            return arr[index] > arr[index - 1];
        }
        /// <summary>
        //! compare with neighbours to determine either we go on left side or right.  
        /// </summary>
        public int PeakIndexInMountainArray(int[] arr)
        {
            int lo = 0;
            int hi = arr.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (arr[mid] > arr[mid + 1] && arr[mid] > arr[mid - 1])
                {
                    return mid;
                }

                else if (arr[mid + 1] > arr[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }
            return -1;

        }
        /// <summary>
        //! Brute force. You find maximum and then return its index 
        /// </summary>
        public int PeakIndexInMountainArray2(int[] arr)
        {

            int max = int.MinValue;
            int maxIndex = -1;
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }


    }
}
