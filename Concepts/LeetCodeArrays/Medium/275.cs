using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _275
    {

        /// <summary>
        ///https://www.youtube.com/watch?v=QWrGZ9Eq2I8
        /// </summary>
        public int HIndex(int[] citations)
        {
            int n = citations.Length;
            if (citations.Length == 0) return 0;
            int i = 0;
            while (i < citations.Length && n - i > citations[i])
            {
                ++i;
            }

            return n - i;
        }

        public int HIndex2(int[] citations)
        {
            int n = citations.Length;
            if (citations.Length == 0) return 0;
            int lo = 0;
            int hi = citations.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (citations[mid] == n - mid)
                    return n - mid;
                else if (citations[mid] > n - mid)
                    hi = mid - 1;
                else
                    lo = mid + 1;
            }

            return n - lo;

        }

    }
}
