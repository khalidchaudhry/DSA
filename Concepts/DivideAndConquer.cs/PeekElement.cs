using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideAndConquer.cs
{
    public class PeekElement
    {
        public int FindPeekElement(int[] arr)
        {
            int lo = 0;
            int hi = arr.Length - 1;
            if (arr.Length == 1) return arr[0];
            return FindPeekElement(arr, lo, hi);

        }
        private int FindPeekElement(int[] arr, int lo, int hi)
        {
            if (lo > hi)
                return -1;
            int mid = lo + ((hi - lo) / 2);

            if (
                (mid == 0 || arr[mid] > arr[mid - 1]) &&
                (mid == arr.Length - 1 || arr[mid] > arr[mid + 1])
               )
            {
                return arr[mid];
            }
            else if (arr[mid + 1] > arr[mid])
            {
                return FindPeekElement(arr, mid + 1, hi);
            }
            else
            {
                return FindPeekElement(arr, lo, mid - 1);
            }
        }
    }
}
