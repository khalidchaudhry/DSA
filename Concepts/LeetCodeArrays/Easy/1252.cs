using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    public class _1252
    {

        public static void _1252Main()
        {

        }

        public int OddCells(int n, int m, int[][] indices)
        {
            int[] rows = new int[n];
            int[] columns = new int[m];
            int result = 0;

            foreach (int[] index in indices)
            {
                rows[index[0]]++;
                columns[index[1]]++;
            }

            for (int row = 0; row < n; ++row)
            {
                for (int column = 0; column < m; ++column)
                    if ((rows[row] + columns[column]) % 2 == 1)
                        ++result;

            }

            return result;
        }
    }
}




