using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTwoPointers.Medium
{
    public class _986
    {
        public int[][] IntervalIntersection(int[][] A, int[][] B)
        {

            List<int[]> result = new List<int[]>();

            int i = 0;
            int j = 0;

            while (i < A.Length && j < B.Length)
            {
                //! Taking Max for lower bound we are taking intersection 
                int lowerBound = Math.Max(A[i][0], B[j][0]);
                //! Taking Min for Upper bound we are taking intersection 
                int upperBound = Math.Min(A[i][1], B[j][1]);
                //! if lower bound <=upper bound we have valid range to add
                if (lowerBound <= upperBound)
                {
                    result.Add(new int[] { lowerBound, upperBound });
                }

                //! increment value which is less
                //!Remove the interval with the smallest endpoint
                if (A[i][1] < B[j][1])
                {
                    ++i;
                }
                else
                {
                    ++j;
                }
            }

            return result.ToArray();

        }


    }
}
