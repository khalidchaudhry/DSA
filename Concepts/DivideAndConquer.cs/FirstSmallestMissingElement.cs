using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideAndConquer.cs
{
    /// <summary>
    /// https://www.techiedelight.com/find-smallest-missing-element-sorted-array/
    /// </summary>
    class FirstSmallestMissingElement
    {
        public int FirstMissing(int[] arr)
        {
            int lo = 0;
            int hi = arr.Length - 1;
            return FirstMissing(arr, lo, hi);


        }
        private int FirstMissing(int[] arr, int lo, int hi)
        {
            if (lo > hi)
            {
                return lo;
            }

            int mid = lo + (hi - lo) / 2;

            if (mid == arr[mid])
            {
                return FirstMissing(arr, mid + 1, hi);
            }
            else
            {
                return FirstMissing(arr, lo, mid - 1);
            }


        }

    }
}
