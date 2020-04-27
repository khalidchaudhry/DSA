using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _221
    {
        public int MaximalSquare(char[][] matrix)
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
            // Populate the first row of dp 
            for (int i = 0; i < matrix[0].Length; i++)
            {
                //! Initially we forgot to conver to int 
                dp[0][i] = (int)char.GetNumericValue(matrix[0][i]);
                maxSquare = Math.Max(maxSquare, dp[0][i]);
            }
            // Populate the first column of dp
            for (int i = 0; i < matrix.Length; i++)
            {
                dp[i][0] = (int)char.GetNumericValue(matrix[i][0]);
                maxSquare = Math.Max(maxSquare, dp[i][0]);
            }



            for (int row = 1; row < matrix.Length; ++row)
            {
                for (int column = 1; column < matrix[row].Length; column++)
                {
                    //! We only proceed if matrix current index is 1 because in case of 0 it will not be a sqaure
                    if (matrix[row][column] != '0')
                    {
                        //1 0 1 0 0
                        //1 0 1 1 1
                        //1 1 1 1 1
                        //1 0 0 1 0
                        // We are checking three values for one index (Up,Upleft,left) to get minimum. In case of 0 , it will not make square
                        dp[row][column] = Math.Min(Math.Min(dp[row - 1][column], dp[row - 1][column - 1]), dp[row][column - 1]) + 1;
                        maxSquare = Math.Max(maxSquare, dp[row][column]);
                    }
                }
            }
            return maxSquare * maxSquare;
        }

        public int MaximalSquare2(char[][] matrix)
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
    }
}
