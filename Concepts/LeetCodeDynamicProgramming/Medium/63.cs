using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _63
    {
        /// <summary>
        //! Prerequisite for this problem is problem 64
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {

            int rows = obstacleGrid.Length;
            int columns = obstacleGrid[0].Length;

            int[][] dp = new int[obstacleGrid.Length][];

            for (int i = 0; i < dp.Length; ++i)
            {
                dp[i] =new int[columns];
            }

            //!intializing first row
            for (int i = 0; i < columns; ++i)
            {
                //! if we encounter obstacle there is no path after that 
                if (obstacleGrid[0][i] == 1)
                {
                    break;
                }
                dp[0][i] = 1;
            }
            //!intializing first column
            for (int i = 0; i < rows; ++i)
            {
                //! if we encounter obstacle there is no path after that 
                if (obstacleGrid[i][0] == 1)
                {
                    break;
                }

                dp[i][0] = 1;
            }

            for (int i = 1; i < rows; ++i)
            {
                for (int j = 1; j < columns; ++j)
                {
                    if (obstacleGrid[i][j] == 1)
                        continue;

                    dp[i][j] = dp[i - 1][j] + //! cell above
                             dp[i][j - 1];    //! cell on left side

                }
            }

            return dp[rows-1][columns-1];

        }


    }
}
