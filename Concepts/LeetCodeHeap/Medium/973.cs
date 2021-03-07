using LeetCodeHeap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDivideAndConquer.Medium
{
    public class _973
    {


        //!Sort the points by distance, then take the closest K points.

        public int[][] KClosest1(int[][] points, int K)
        {
            Comparer<int[]> comparer = Comparer<int[]>.Create((x, y) =>
            {
                int distance1 = x[0] * x[0] + x[1] * x[1];
                int distance2 = y[0] * y[0] + y[1] * y[1];
                return distance1.CompareTo(distance2);
            });

            Array.Sort(points, comparer);

            int[][] result = new int[K][];

            for (int i = 0; i < result.Length; ++i)
            {
                result[i] = points[i];
            }

            return result;
        }

        /// <summary>
        //! Using Priority queue 
        /// </summary>
        
        public int[][] KClosest2(int[][] points, int K)
        {
            PQ<(int dis, int x, int y)> pq = new PQ<(int dis, int x, int y)>();
            foreach (int[] point in points)
            {
                int x = point[0];
                int y = point[1];
                int distance = x * x + y * y;
                pq.Add((distance, x, y));
            }
            int[][] result = new int[K][];

            while (K != 0)
            {
                (int distance, int x, int y) = pq.Poll();
                result[K - 1] = new int[] { x, y };
                --K;
            }
            return result;
        }
        /// <summary>
        /// https://www.youtube.com/watch?v=hGK_5n81drs&t=731s
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
                       
            int pti = CalculatePivotIndex(points,requiredIndex);            

            for (int i = 0; i < K; i++)
            {
                result[i] = points[i];
            }

            return result;
        }

        private int CalculatePivotIndex(int[][] points,int requiredIndex)
        {
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
            return requiredIndex;
        }
        private int PivotIndex(int[][] points, int left, int right)
        {
            // !pivot tail index
            int pti = left;
            //!rightElement is a pivot 
            double rightElementDistance = CalculateDistance(points[right][0], points[right][1]);

            for (int i = left; i < right; i++)
            {
                double currentElementDistance = CalculateDistance(points[i][0], points[i][1]);
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
        private int CalculateDistance(int x, int y)
        {
            return ((x * x) + (y * y));
        }
    }
}
