using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    public class _867
    {
        public int[][] Transpose(int[][] A)
        {

            int rows = A.Length;
            int columns = A[0].Length;

            int[][] result = new int[columns][];

            for (int i = 0; i < columns; ++i)
            {
                result[i] = new int[rows];
            }

            for (int row = 0; row < rows; ++row)
            {
                for (int column = 0; column < columns; ++column)
                {
                    result[column][row] = A[row][column];
                }
            }
            return result;
        }


    }
}
