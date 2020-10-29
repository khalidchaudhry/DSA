using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _274
    {

        /// <summary>
        //! Using bucket sort here  
        /// </summary>
        public int HIndex0(int[] citations)
        {
            int n = citations.Length;
            if (citations.Length == 0) return 0;
            int[] buckets = new int[n + 1];

            foreach (int citation in citations)
            {
                if (citation >= buckets.Length)
                {
                    ++buckets[n];
                }
                else
                {
                    ++buckets[citation];
                }
            }
            int count = 0;
            for (int i = buckets.Length - 1; i >= 0; --i)
            {
                count += buckets[i];
                if (count >= i) return i;
            }
            return 0;
        }





        /// <summary>
        /// https://www.youtube.com/watch?v=fVAR6SiATgI
        /// </summary>       
        public int HIndex(int[] citations)
        {
            int n = citations.Length;
            if (citations.Length == 0) return 0;
            Array.Sort(citations);

            int i = 0;
            while (i < citations.Length && n - i > citations[i])
            {
                ++i;
            }

            return n - i;
        }


    }
}
