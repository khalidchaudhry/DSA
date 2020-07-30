using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _769
    {
        public int MaxChunksToSorted(int[] arr)
        {
            int maxChunks = 0;
            int maxRight = 0;

            for (int i = 0; i < arr.Length; ++i)
            {
                maxRight = Math.Max(maxRight,arr[i]);
                if (i == maxRight)
                {
                    ++maxChunks;
                }
            }

            return maxChunks;


        }


    }
}
