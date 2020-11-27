using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _945
    {

        /// <summary>
        //! Based on ideas in Kuai's class in Mock interview
        //! We sort the array
        //! if next element is less then or equal to previous element we set its value to 1 more than previous element
        //! and record the difference in an array. 
        /// </summary>
        public int MinIncrementForUnique(int[] A)
        {
            Array.Sort(A);

            int minIncrment = 0;
            for (int i = 1; i < A.Length; ++i)
            {
                if (A[i] <= A[i - 1])
                {
                    int increment = A[i - 1] - A[i] + 1;
                    A[i] += increment;
                    minIncrment += increment;
                }
            }

            return minIncrment;
        }

    }
}
