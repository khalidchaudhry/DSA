using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Medium
{
    public class _1151
    {
        public int MinSwaps(int[] data)
        {
            int k = 0;
            //! Number of 1's will tell us window size.
            //!Minimum Swaps=Min Zeros=Max 1's
            for (int i = 0; i < data.Length; ++i)
            {
                if (data[i] == 1)
                    k += data[i];
            }

            int minZeros = 0;
            for (int i = 0; i < k; ++i)
            {
                if (data[i] == 0)
                    ++minZeros;
            }
            int min = minZeros;
            for (int i = k; i < data.Length; ++i)
            {
                if (data[i - k] == 0)
                    --minZeros;
                if (data[i] == 0)
                    ++minZeros;
                min = Math.Min(minZeros, min);
            }

            return min;

        }


    }
}
