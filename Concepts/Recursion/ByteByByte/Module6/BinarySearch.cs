using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module6
{
    public class BinarySearch
    {
        public bool Contains(int[] arr, int val)
        {
            return Contains(arr, val, 0, arr.Length - 1);

        }

        private bool Contains(int[] arr, int val, int lo, int hi)
        {
            if (lo == hi) return arr[lo] == val;

            int mid = lo + (hi - lo) / 2;

            if (arr[mid] > val) return Contains(arr, val, lo, mid - 1);

            else if (arr[mid] < val) return Contains(arr, val, mid + 1, hi);

            return true;
        }
    }
}
