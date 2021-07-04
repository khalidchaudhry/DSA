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

             //https://www.youtube.com/watch?v=dI2FGXiL4Js&t=343s
            /// </summary>
        public int[][] IntervalIntersection(int[][] A, int[][] B)
        {

            List<int[]> intersection = new List<int[]>();
            int fIdx = 0;
            int sIdx = 0;

            while (fIdx < A.Length && sIdx < B.Length)
            {
                int[] e1 = A[fIdx];
                int[] e2 = B[sIdx];
                int e1Start = e1[0];
                int e1End = e1[1];
                int e2Start = e2[0];
                int e2End = e2[1];

                int start = Math.Max(e1Start, e2Start);
                int end = Math.Max(e1End, e2End);
                //! If Intervals overlapping, take intersection of them. 
                //! Interval will only overlap if e2.Start<=e1.End  && e1.Start<=e2.End
                if (start<=end)
                {                    
                    intersection.Add(new int[] { start, end });
                }
                //! Drop the event that finishes earlier because that interval is not going to overlap with others
                if (e1End < e2End)
                {
                    ++fIdx;
                }
                else
                {
                    ++sIdx;
                }
            }
            return intersection.ToArray();
        }


    }
}
