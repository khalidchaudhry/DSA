using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Medium
{
    public class _48
    {

        public static void _48Main()
        {
            _48 Rotate = new _48();
            int[][] matrix = new int[3][] {
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{7,8,9}
            };

            Rotate.Rotate90ByAntiClockWise(matrix);
            Console.ReadLine();

        }
        // To  rotate anticlock wise or rotate by 180 see below link
        //https://leetcode.com/problems/rotate-image/discuss/401356/Rotate-90-clockwise-anti-clockwise-and-rotate-180-degree

        //https://afteracademy.com/blog/rotate-matrix       
        public void Rotate90ByClockWise(int[][] matrix)
        {

            int rows = matrix.Length;
            int columns = matrix[0].Length;

            //Transpose the matrix
            for (int row = 0; row < rows; ++row)
            {
                for (int column = row + 1; column < columns; ++column)
                {
                    int temp = matrix[row][column];
                    matrix[row][column] = matrix[column][row];
                    matrix[column][row] = temp;
                }
            }

            // Reverse all  the rows
            for (int row = 0; row < rows; ++row)
            {
                int i = 0;
                int j = columns - 1;
                while (i < j)
                {
                    int temp = matrix[row][i];
                    matrix[row][i] = matrix[row][j];
                    matrix[row][j] = temp;
                    ++i;
                    --j;
                }
            }
        }

        public void Rotate90ByAntiClockWise(int[][] matrix)
        {

            int rows = matrix.Length;
            int columns = matrix[0].Length;

            //Transpose the matrix
            for (int row = 0; row < rows; ++row)
            {
                for (int column = row + 1; column < columns; ++column)
                {
                    int temp = matrix[row][column];
                    matrix[row][column] = matrix[column][row];
                    matrix[column][row] = temp;
                }
            }

            // Reverse all  the columns
            for (int column = 0; column < columns; ++column)
            {
                int i = 0;
                int j = rows - 1;
                while (i < j)
                {
                    int temp = matrix[i][column];
                    matrix[i][column] = matrix[j][column];
                    matrix[j][column] = temp;
                    ++i;
                    --j;
                }
            }
        }


    }
}
