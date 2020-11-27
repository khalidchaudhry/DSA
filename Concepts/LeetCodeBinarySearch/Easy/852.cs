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
