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
            var comparer = Comparer<PQData>.Create((x, y) => {
                if (x.Value == y.Value)
                {
                    if (x.Row == y.Row)
                    {
                        return x.Col.CompareTo(y.Col);
                    }
                    return x.Row.CompareTo(y.Row);
                }
                return x.Value.CompareTo(y.Value);

            });

            PQ<PQData> pq = new PQ<PQData>(comparer);
            HashSet<(int r, int c)> visited = new HashSet<(int r, int c)>();
            pq.Add(new PQData(matrix[0][0], 0, 0));
            visited.Add((0, 0));
            int kthSmallest = 0;
            while (pq.Size > 0 && k > 0)
            {
                PQData top = pq.Poll();
                --k;
                kthSmallest = top.Value;
                foreach ((int nr, int nc) in new List<(int r, int c)>() { (top.Row + 1, top.Col), (top.Row, top.Col + 1) })
                {
                    if (nr >= matrix.Length || nc >= matrix.Length || visited.Contains((nr, nc)))
                    {
                        continue;
                    }
                    visited.Add((nr, nc));
                    pq.Add(new PQData(matrix[nr][nc], nr, nc));
                }
            }
            return kthSmallest;
        }
    }
    public class PQData
    {
        public int Value;
        public int Row;
        public int Col;
        public PQData(int val, int row, int col)
        {
            Value = val;
            Row = row;
            Col = col;
        }
    }
}
