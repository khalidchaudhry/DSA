using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _59
    {

        public static void _59Main()
        {

            _59 Generate = new _59();

            var result=Generate.GenerateMatrix(1);

        }
        public int[][] GenerateMatrix(int n)
        {

            int[][] matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
            }

            int firstRow = 0;
            int lastRow = n - 1;
            int firstColumn = 0;
            int lastColumn = n - 1;
            int number = 1;

            while (firstRow <= lastRow && firstColumn <= lastColumn)
            {
                //! copying the first row 
                for (int row = firstColumn; row <= lastColumn; ++row)
                {
                    matrix[firstRow][row] = number++;
                }

                //! Copying the last column
                for (int column = firstRow + 1; column <= lastRow; ++column)
                {
                    matrix[column][lastColumn] = number++;
                }

                if (firstRow < lastRow && firstColumn < lastColumn)
                {
                    //! Copy the last row 
                    for (int row = lastColumn - 1; row > firstColumn; --row)
                    {
                        matrix[lastRow][row] = number++;
                    }
                    //! Copy the first column 
                    for (int column = lastRow; column > firstRow; --column)
                    {
                        matrix[column][firstColumn] = number++;
                    }
                }

                ++firstRow;
                --lastRow;
                ++firstColumn;
                --lastColumn;

            }

            return matrix;
        }
    }
}
