using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Medium
{
    public class _1004
    {

        //https://www.youtube.com/watch?v=TAMLsfGiyOg
        public int LongestOnes(int[] A, int K)
        {
            int maxConsectiveOnes = 0;
            int zeros = 0;
            int i = 0;
            for (int j = 0; j < A.Length; ++j)
            {
                if (A[j] == 0)
                    ++zeros;
                //! Once window invalid shrink it to make valid
                while (zeros > K)
                {
                    if (A[i] == 0)
                        --zeros;
                    ++i;
                }
                maxConsectiveOnes = Math.Max(maxConsectiveOnes, j - i + 1);
            }

            return maxConsectiveOnes;
        }

    }
}
