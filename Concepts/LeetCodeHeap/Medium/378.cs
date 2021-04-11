using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeHeap.Medium
{
    public class _378
    {


        public  static void _378Main()
        {
            int[][] matrix = new int[][]
            {
                new int[3]{3,8,8},
                new int[3]{3,8,8},
                new int[3]{3,9,13},

            };

            var test = new _378();

            test.KthSmallest(matrix,8);



        }
        /// <summary>
        //! Based on idea in Kuai's class  
        //! Same as problem 373
        /// </summary>
        public int KthSmallest(int[][] matrix, int k)
        {
            int n = matrix.Length;

            var comparer = Comparer<(int value, int r, int c)>.Create((a, b) =>
            {
                if (a.value == b.value)
                {
                    return (a.r, a.c).CompareTo((b.r, b.c));
                }

                return a.value.CompareTo(b.value);
            });

            PQ<(int, int, int)> pq = new PQ<(int, int, int)>(comparer);
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            pq.Add((matrix[0][0], 0, 0));
            visited.Add((0, 0));
            int kthSmallest = matrix[0][0];
            while (pq.Size != 0 && k != 0)
            {
                (int value, int r, int c) = pq.Poll();
                --k;
                kthSmallest = matrix[r][c];
                if (r + 1 < n && !visited.Contains((r+1,c)))
                {
                    pq.Add((matrix[r + 1][c], r + 1, c));
                    visited.Add((r + 1, c));
                }
                if (c + 1 < n && !visited.Contains((r, c+1)))
                {
                    pq.Add((matrix[r][c + 1], r, c + 1));
                    visited.Add((r, c+1));
                }
            }

            return kthSmallest;
        }
    }
}
