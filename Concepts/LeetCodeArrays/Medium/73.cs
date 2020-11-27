using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _73
    {
        /// <summary>
        /// https://www.programcreek.com/2012/12/leetcode-set-matrix-zeroes-java/
        /// </summary>
        
        public void SetZeroes0(int[][] matrix)
        {
            int rows = matrix.Length;
            int columns = matrix[0].Length;

            if (rows == 0) return;

            bool firstRowZero = false;
            bool firstColumnZero = false;

            //!setting up the first column
            for (int row = 0; row < rows; ++row)
            {
                if (matrix[row][0] == 0)
                {
                    firstColumnZero = true;
                    break;
                }
            }
            //!setting up the first first
            for (int column = 0; column < columns; ++column)
            {
                if (matrix[0][column] == 0)
                {
                    firstRowZero = true;
                    break;
                }
            }
            //!Setting the 0 row and 0 column value equal to 0
            for (int row = 1; row < rows; ++row)
            {
                for (int column = 1; column < columns; ++column)
                {
                    if (matrix[row][column] == 0)
                    {
                        matrix[row][0] = 0; //!set first column value to zero
                        matrix[0][column] = 0; //!set first row value to zero
                    }
                }
            }

            //!use mark to set elements
            for (int row = 1; row < rows; ++row)
            {
                for (int column = 1; column < columns; ++column)
                {
                    if (matrix[row][0] == 0 || matrix[0][column] == 0)
                    {
                        matrix[row][column] = 0;
                    }
                }
            }
            //!setting up the first row to zero 
            if (firstRowZero)
            {
                for (int column = 0; column < columns; ++column)
                {
                    matrix[0][column] = 0;
                }
            }

            //!setting up the first column to zero
            if (firstColumnZero)
            {
                for (int row = 0; row < rows; ++row)
                {
                    matrix[row][0] = 0;
                }
            }
        }

        /// <summary>
        //! space=(m+n)
        /// </summary>
        public void SetZeroes1(int[][] matrix)
        {
            int rows = matrix.Length;
            int columns = matrix[0].Length;
            HashSet<int> zeroRows = new HashSet<int>();
            HashSet<int> zeroColumns = new HashSet<int>();

            for (int row = 0; row < rows; ++row)
            {
                for (int column = 0; column < columns; ++column)
                {
                    if (matrix[row][column] == 0)
                    {
                        zeroRows.Add(row);
                        zeroColumns.Add(column);
                    }
                }
            }

            for (int row = 0; row < rows; ++row)
            {
                for (int column = 0; column < columns; ++column)
                {
                    if (zeroRows.Contains(row) || zeroColumns.Contains(column))
                    {
                        matrix[row][column] = 0;
                    }
                }
            }
        }

    }
}
