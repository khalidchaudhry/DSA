using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Hard
{
    public class _765
    {

        public static void _765Main()
        {
            int[] row = new int[] {1, 4, 0, 5, 8, 7, 6, 3, 2, 9 };
            var test = new _765();
            test.MinSwapsCouples0(row);
            Console.ReadLine();


        }

        /// <summary>
        ///https://www.youtube.com/watch?v=WY6qloZPZ00 
        /// </summary>
        public int MinSwapsCouples0(int[] row)
        {
            Dictionary<int, int> numIdx = new Dictionary<int, int>();
            int n = row.Length;
            for (int i = 0; i < n; ++i)
            {
                numIdx.Add(row[i], i);
            }

            int minSwaps = 0;
            for (int i = 0; i < n; i += 2)
            {
                int first = row[i];
                int second = row[i] % 2 == 0 ? first + 1 : first - 1;
                if (second != row[i + 1])
                {
                    Swap(row, i + 1, numIdx[second], numIdx);
                    ++minSwaps;
                }
            }
            return minSwaps;
        }
        private void Swap(int[] row, int idx1, int idx2, Dictionary<int, int> numIdx)
        {
            int temp = row[idx1];
            row[idx1] = row[idx2];
            row[idx2] = temp;
            numIdx[row[idx1]] = idx1;
            numIdx[row[idx2]] = idx2;
        }

        public int MinSwapsCouples(int[] row)
        {

            int n = row.Length;
            UF uf = new UF(n);
            for (int i = 0; i < n; i += 2)
            {
                int u = row[i];
                int v = row[i + 1];
                uf.Union(u, v);
            }
            int mismatches = 0;
            for (int i = 0; i < n; i += 2)
            {
                int pu = uf.FindSet(i);
                int pv = uf.FindSet(i + 1);
                if (pu != pv)
                {
                    ++mismatches;
                    uf.Union(pu, pv);
                }
            }

            return mismatches;
        }

    }
}
