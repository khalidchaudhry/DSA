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
        //!
        /// </summary>
          
        public int[][] KClosest0(int[][] points, int K)
        {

            int requiredIndex = K - 1;
            return Find(points, requiredIndex);
        }
        private int[][] Find(int[][] points, int requiredIndex)
        {

            int left = 0;
            int right = points.Length - 1;
            Random random = new Random();
            while (left <= right)
            {
                int pivotIndex = random.Next(left, right + 1);
                int index = Partition(points, left, right, pivotIndex);

                if (index == requiredIndex)
                {
                    break;
                }
                else if (index > requiredIndex)
                {
                    right = index - 1;
                }
                else
                {
                    left = index + 1;
                }
            }

            int k = requiredIndex + 1;
            int[][] result = new int[k][];
            for (int i = 0; i < k; ++i)
            {
                result[i] = new int[] { points[i][0], points[i][1] };
            }
            return result;
        }
        private int Partition(int[][] points, int left, int right, int pivotIndex)
        {
            int[] pivotElement = points[pivotIndex];
            int dist2 = pivotElement[0] * pivotElement[0] + pivotElement[1] * pivotElement[1];
            Swap(points, right, pivotIndex);

            int pti = left;
            for (int i = left; i < right; ++i)
            {
                int[] curr = points[i];

                int dist1 = curr[0] * curr[0] + curr[1] * curr[1];

                if (dist1 < dist2)
                {
                    Swap(points, pti, i);
                    ++pti;
                }
            }

            Swap(points, pti, right);
            return pti;
        }

        private void Swap(int[][] points, int i, int j)
        {
            int[] temp = points[i];
            points[i] = points[j];
            points[j] = temp;
        }



    }
}
