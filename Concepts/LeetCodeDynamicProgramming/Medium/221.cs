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
        //! Difference between this and below dp solution is that we are creating extra row and column for dp array so that
        //! we don't have to explictly copy first column and first row into dp array .
        //! Also we can remove out of bounds checks 
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
                    maximalLength = Math.Max(maximalLength,dp[i+1][j+1]);
                }
            }

            return maximalLength * maximalLength;
        }




        /// <summary>
        //! DP Solution
        //! Intuition here is to check  matrix in opposite direction like
        //           ^       ^
        //            \     |
        //             \     |
        //              \   |
        //        <-------- 
        // from index 1,1 we will check up,left and diagonal left     
        //   0 1 
        //0  1 1 
        //1  1 1
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>

        public int MaximalSquare1(char[][] matrix)
        {
            int length = matrix.Length;
            //! intially we forgot about below check 
            if (length == 0)
                return 0;
            int maxSquare = int.MinValue;

            int[][] dp = new int[length][];

            for (int i = 0; i < length; i++)
            {
                dp[i] = new int[matrix[i].Length];
            }

            for (int row = 0; row < matrix.Length; ++row)
            {
                for (int column = 0; column < matrix[row].Length; column++)
                {
                    //! to avoid out of bound exception below
                    if (row == 0 || column == 0)
                    {
                        if (matrix[row][column] == '1')
                        {
                            dp[row][column] = 1;
                        }
                    }
                    //! We only proceed if matrix current index is 1 because in case of 0 it will not be a sqaure
                    else if (matrix[row][column] != '0')
                    {
                        //1 0 1 0 0
                        //1 0 1 1 1
                        //1 1 1 1 1
                        //1 0 0 1 0
                        // We are checking three values for one index (Up,Upleft,left) to get minimum. In case of 0 , it will not make square
                        dp[row][column] = Math.Min(Math.Min(dp[row - 1][column], dp[row - 1][column - 1]), dp[row][column - 1]) + 1;
                    }

                    maxSquare = Math.Max(maxSquare, dp[row][column]);
                }
            }
            return maxSquare * maxSquare;
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
