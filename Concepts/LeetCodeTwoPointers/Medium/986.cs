using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTwoPointers.Medium
{
    public class _986
    {

        /// <summary>
        // ///  // # <image url="$(SolutionDir)\Images\986.png"  scale="0.5"/> 
        /// </summary>
        public int[][] IntervalIntersection(int[][] A, int[][] B)
        {

            List<int[]> result = new List<int[]>();
            int i = 0;
            int j = 0;

            while (i < A.Length && j < B.Length)
            {
                int[] e1 = A[i];
                int[] e2 = B[j];
                //! If Intervals overlapping, take intersection of them. 
                //! Interval will only overlap if e2.Start<=e1.End  && e1.Start<=e2.End
                if (e2[0] <= e1[1] && e1[0] <= e2[1])
                {
                    
                    int start = Math.Max(e1[0], e2[0]);
                    int end = Math.Min(e1[1], e2[1]);
                    result.Add(new int[] { start, end });
                }
                //! Drop the event that finishes earlier. 
                if (e1[1] < e2[1])
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
