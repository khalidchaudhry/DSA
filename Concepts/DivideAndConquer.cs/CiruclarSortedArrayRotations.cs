using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideAndConquer.cs
{
    /// <summary>
    /// https://www.techiedelight.com/find-number-rotations-circularly-sorted-array/
    /// </summary>
    public class CiruclarSortedArrayRotations
    {

        public int CircularRotations(int[] arr)
        {
            int lo = 0;
            int hi = arr.Length - 1;         
            return CircularRotations(arr, lo, hi);
        }

        private int CircularRotations(int[] arr, int lo, int hi)
        {
            //array is already rotated
            if (arr[lo] < arr[hi])
                return 0;

            if (lo > hi)
            {
                return 0;
            }

            int mid = lo + (hi - lo) / 2;

            //! Number of rotations=
            //! Number of elements before minimum element of the array or 
            //! Index of the minimum element
            if (arr[mid] > arr[mid + 1])
            {
                return mid + 1;
            }
            else if (arr[lo] < arr[mid])
            {
                return CircularRotations(arr, mid + 1, hi);
            }
            else
            {
                return CircularRotations(arr, lo, mid);
            }
        }
    }
}
