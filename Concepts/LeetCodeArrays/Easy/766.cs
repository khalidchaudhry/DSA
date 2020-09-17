using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    public class _766
    {

        public static void _766Main()
        {
            //int[][] matrix = new int[3][]
            //{
            //    new int[4] {1,2,3,4 },
            //    new int[4] {5,1,2,3 },
            //    new int[4] {9,5,1,2 }
            //};

            int[][] matrix = new int[2][]
                {
                    new int[] { 1, 2 },
                    new int[] { 2, 2 }
                };

            _766 IsToeplitzMatrix = new _766();
            var result = IsToeplitzMatrix.IsToeplitzMatrix(matrix);

        }

        /*
            [1,2,3,4],
            [5,1,2,3],
            [9,5,1,2]         
         */
        /// <summary>
        //! Key is to compare two rows at a time.
        //! for row and column > 0 we look back at row-1 and column-1
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>

        public bool IsToeplitzMatrix(int[][] matrix)
        {
            int rows, columns;
            rows = matrix.Length;
            columns = matrix[0].Length;

            for (int row = 0; row < rows; ++row)
            {
                for (int column = 0; column < columns; ++column)
                {
                    if (row > 0 && column > 0 && matrix[row][column] != matrix[row - 1][column - 1])
                        return false;
                }
            }
            return true;
        }
    }
}
