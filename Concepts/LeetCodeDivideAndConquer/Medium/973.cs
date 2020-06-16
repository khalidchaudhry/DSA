using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDivideAndConquer.Medium
{
    public class _973
    {

        /// <summary>
        //! Quick select algorithm
        //! tail--->Pivot--->Head
        //! All the elements till Pivot will be sorted
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>        
        public int[][] KClosest0(int[][] points, int K)
        {

            int[][] result = new int[K][];
            //! The index where Kth closest point will be
            int requiredIndex = K - 1;

            int left = 0;
            int right = points.Length - 1;
            //!Pivot tail index
            int pti = 0;
            while (left < right)
            {
                pti = PivotIndex(points, left, right);

                if (pti == requiredIndex)
                {
                    break;
                }

                else if (pti > requiredIndex)
                {
                    right = pti - 1;
                }
                else
                {
                    left = pti + 1;
                }

            }

            for (int i = 0; i < K; i++)
            {
                result[i] = new int[]
                {
                    points[i][0],
                    points[i][1]
                };
            }

            return result;
        }
        public int[][] KClosest(int[][] points, int K)
        {

            int n = points.Length;
            double[] pointsDistance = new double[n];
            int[][] result = new int[K][];

            for (int i = 0; i < n; i++)
            {
                int x = points[i][0];
                int y = points[i][1];
                double distance = CalculateEuclideanDistance(x, y);
                pointsDistance[i] = distance;
            }

            Array.Sort(pointsDistance);

            double target = pointsDistance[K - 1];
            int j = 0;

            for (int i = 0; i < n; i++)
            {
                int x = points[i][0];
                int y = points[i][1];
                if (CalculateEuclideanDistance(x, y) <= target)
                {
                    result[j] = new int[2];
                    result[j][0] = x;
                    result[j][1] = y;
                    ++j;
                }
            }

            return result;
        }


        /// <summary>
        // ! The correct location of  the pivot(It is the element in the array that is at index right)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private int PivotIndex(int[][] points, int left, int right)
        {
            // !pivot tail index
            int pti = left;
            //!rightElement is a pivot 
            double rightElementDistance = CalculateEuclideanDistance(points[right][0], points[right][1]);

            for (int i = left; i < right; i++)
            {               
                double currentElementDistance = CalculateEuclideanDistance(points[i][0], points[i][1]);
                //!<= for duplicate condition
                if (currentElementDistance <= rightElementDistance)
                {
                    Swap(points, i, pti);
                    ++pti;
                }
            }
            
            //!Swap to ensure that pivot is at its correct position in an array?
            Swap(points, pti, right);
            //! all the elements before pti index are smaller than or equal to the element at pti index 
            return pti;
        }

        private void Swap(int[][] arr, int i, int j)
        {
            int[] temp = arr[i];

            arr[i] = arr[j];

            arr[j] = temp;
        }


        private double CalculateEuclideanDistance(int x, int y)
        {
            return Math.Sqrt((x * x) + (y * y));
        }
    }
}
