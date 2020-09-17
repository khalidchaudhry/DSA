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
        /// <summary>
        /// https://leetcode.com/problems/maximum-sum-circular-subarray/discuss/633401/Kadane-Algorithm-Trick-beats-100-Java-Explained
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
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
            int circularSum = totalSum - (-maxSumCircular);
            //! circularSum == 0 is for boundary case where all the numbers are negative 
            return circularSum == 0? maxSumNonCircular : Math.Max(maxSumNonCircular, circularSum);
        }

    }
}
