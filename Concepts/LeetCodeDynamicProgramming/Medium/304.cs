using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _304
    {

        public static void _304Main()
        {
            int[][] matrix = new int[4][] {

                new int[]{2,0,-3,4 },
                new int[]{6,3,2,-1 },
                new int[]{5,4,7,3 },
                new int[]{2,-6,8,1 }
            };

            NumMatrix numMatrix = new NumMatrix(matrix);


        }


    }

    public class NumMatrix
    {

        int[,] _prefix;
        /// <summary>
        /// # <image url="$(SolutionDir)\Images\304(2).png"  scale="0.4"/>
        /// </summary>
        /// <param name="matrix"></param>
        public NumMatrix(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            _prefix = new int[rows + 1, cols + 1];
            for (int r = 1; r < rows + 1; ++r)
            {
                for (int c = 1; c < cols + 1; ++c)
                {
                    _prefix[r, c] = matrix[r - 1][c - 1] + _prefix[r - 1, c] + _prefix[r, c - 1] - _prefix[r - 1, c - 1];
                }
            }
        }

        /// <summary>       
        /// # <image url="$(SolutionDir)\Images\304.png"  scale="0.4"/>

        /// </summary>
        /// <param name="row1"></param>
        /// <param name="col1"></param>
        /// <param name="row2"></param>
        /// <param name="col2"></param>
        /// <returns></returns>
        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            ++row1;
            ++col1;
            ++row2;
            ++col2;

            return _prefix[row2, col2] - _prefix[row1 - 1, col2] - _prefix[row2, col1 - 1] + _prefix[row1 - 1, col1 - 1];
        }
    }
}
