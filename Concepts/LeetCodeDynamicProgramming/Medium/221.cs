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
            if (matrix.Length == 0)
                return 0;
            int rows = matrix.Length;
            int columns = matrix[0].Length;

            //! creating dp array of one size bigger both for columns and rows so that we don't have to 
            //! explictly handle boundary cases.  
            int[][] dp = new int[rows + 1][];
            int maximalLength = 0;
            for (int i = 0; i < dp.Length; ++i)
            {
                dp[i] = new int[columns + 1];
            }

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    if (matrix[i][j] == '0')
                    {
                        continue;
                    }
                    dp[i + 1][j + 1] = 1 + Math.Min(dp[i][j + 1],//up 
                                           Math.Min(dp[i][j],//diagonal
                                                   dp[i + 1][j]));//left
                    maximalLength = Math.Max(maximalLength, dp[i + 1][j + 1]);
                }
            }

            return maximalLength * maximalLength;
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
