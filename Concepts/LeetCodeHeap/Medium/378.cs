using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeHeap.Medium
{
    public class _378
    {
        
        /// <summary>
        //! Based on idea in Kuai's class  
        /// </summary>
        public int KthSmallest(int[][] matrix, int k)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            var pq = new PQ<(int, int, int)>();
            pq.Add((matrix[0][0], 0, 0));

            while (pq.Size != 0)
            {
                (int val, int r, int c) = pq.Poll();
                --k;
                if (k == 0)
                {
                    return val;
                }

                if (r + 1 < m)
                {
                    pq.AddForDups((matrix[r + 1][c], r + 1, c));
                }

                if (c + 1 < n)
                {
                    pq.AddForDups((matrix[r][c + 1], r, c + 1));
                }
            }
            return -1;
        }
    }
}
