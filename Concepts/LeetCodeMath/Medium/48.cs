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
            TransposeMatrix(matrix);
            ReverseRows(matrix);
        }
        public void Rotate90ByAntiClockWise(int[][] matrix)
        {
            TransposeMatrix(matrix);
            ReverseColumns(matrix);
        }
        private void TransposeMatrix(int[][] matrix)
        {

            for (int r = 0; r < matrix.Length; ++r)
            {
                for (int c = r + 1; c < matrix[0].Length; ++c)
                {
                    int temp = matrix[r][c];
                    matrix[r][c] = matrix[c][r];
                    matrix[c][r] = temp;
                }
            }
        }
        private void ReverseRows(int[][] matrix)
        {

            for (int row = 0; row < matrix.Length; ++row)
            {
                int i = 0;
                int j = matrix[row].Length - 1;
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
        private void ReverseColumns(int[][] matrix)
        {
            for (int column = 0; column < matrix[0].Length; ++column)
            {
                int i = 0;
                int j = matrix[0].Length;

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
