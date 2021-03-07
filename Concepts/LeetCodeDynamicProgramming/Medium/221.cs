using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _221
    {

        /// <summary>
        //! Question is very similar to 1227
        //! Intuition here is to check  matrix in opposite direction like
        //           ^       ^
        //            \     |
        //             \     |
        //              \   |
        //        <-------- 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>      
        public int MaximalSquare0(char[][] matrix)
        {
            int[,] dp = new int[matrix.Length + 1, matrix[0].Length + 1];
            int maxLength = 0;
            for (int i = 1; i < dp.GetLength(0); ++i)
            {
                for (int j = 1; j < dp.GetLength(1); ++j)
                {
                    if (matrix[i - 1][j - 1] == '1')
                    {
                        dp[i, j] = 1 + (Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]));
                        maxLength = Math.Max(maxLength, dp[i, j]);
                    }
                }
            }
            return maxLength * maxLength;
        }

      
        /// <summary>
        //! Brute Force apprach from Sam recursion course
        //! Time limit excceded
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaximalSquare(char[][] matrix)
        {
            int maxLength = 0;
            for (int i = 0; i < matrix.Length; ++i)
            {
                for (int j = 0; j < matrix[0].Length; ++j)
                {
                    maxLength = Math.Max(maxLength, MaximalSquare(matrix, i, j));
                }
            }

            return maxLength * maxLength;
        }

        private int MaximalSquare(char[][] matrix, int i, int j)
        {
            if (i == matrix.Length || j == matrix[0].Length)
            {
                return 0;
            }
            if (matrix[i][j] == '0')
                return 0;

            return 1 + Math.Min(MaximalSquare(matrix, i, j + 1),//right
                       Math.Min(MaximalSquare(matrix, i + 1, j),  //down
                                MaximalSquare(matrix, i + 1, j + 1))); //diagonal
        }
    }
}
