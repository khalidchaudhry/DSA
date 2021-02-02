using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _918
    {

        public static void _918Main()
        {
            int[] array = new int[] { -2, -3, -1 };
            _918 CircularSum = new _918();

            var ans = CircularSum.MaxSubarraySumCircular(array);
            Console.ReadLine();

        }



//      # <image url="$(SolutionDir)\Images\918.png"  scale="0.8"/>
        /// <summary>
        //! Apply Kadane's algorithm for getting max sum for non-circular case &  max subarray sum for circular 
        //! Answer=Max(maxSubArray sum non-circular ,maxSubArray sum circular)
        //! How to calculate "maxSubArray sum circular"=(sum - min sub array sum)
        //! min sub array sum
        //! 1. Negate all sub array elements  
        //! 2. Apply Kandanes algorithm to calculate max sub array sum
        //! 3. Negate maxsub array sum to get min sub array sum
        /// </summary>

        public int MaxSubarraySumCircular(int[] A)
        {
            int maxSumSoFarCircular = -A[0];
            int maxSumCircular = -A[0];
            int maxSumSoFarNonCircular = A[0];
            int maxSumNonCircular = A[0];

            int totalSum = A[0];

            for (int i = 1; i < A.Length; ++i)
            {
                totalSum += A[i];
                int negate = -A[i];

                maxSumSoFarCircular = Math.Max(negate, negate + maxSumSoFarCircular);
                maxSumCircular = Math.Max(maxSumCircular, maxSumSoFarCircular);

                maxSumSoFarNonCircular = Math.Max(A[i], A[i] + maxSumSoFarNonCircular);
                maxSumNonCircular = Math.Max(maxSumSoFarNonCircular, maxSumNonCircular);
            }
            maxSumCircular = totalSum - (-maxSumCircular);
            //! circularSum == 0 is for boundary case where all the numbers are negative 
            if (maxSumCircular == 0)
            {
                return maxSumNonCircular;
            }
            
            return Math.Max(maxSumNonCircular, maxSumCircular);
        }

    }
}
