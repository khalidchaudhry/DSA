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

        int[][] dp;
        /// <summary>
        /// # <image url="$(SolutionDir)\Images\304.jpg"  scale="0.2"/>
        /// </summary>
        /// <param name="matrix"></param>
        public NumMatrix(int[][] matrix)
        {
            int rows = matrix.Length;
            int columns = matrix.Length == 0 ? 0 : matrix[0].Length;
            dp = new int[rows + 1][];

            for (int i = 0; i < dp.Length; ++i)
            {
                dp[i] = new int[columns + 1];
            }
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    dp[i + 1][j + 1] = matrix[i][j] + //current matrix value
                                       dp[i][j + 1] + //rectangle on the top
                                       dp[i + 1][j] - //rectangle on the left
                                       dp[i][j];     //subtracting diagonal as its added twice. 
                }
            }
        }

        /// <summary>       
        /// # <image url="https://assets.leetcode.com/users/hiepit/image_1578762431.png" scale="0.3" />

        //https://www.youtube.com/watch?v=PwDqpOMwg6U
        /// </summary>
        /// <param name="row1"></param>
        /// <param name="col1"></param>
        /// <param name="row2"></param>
        /// <param name="col2"></param>
        /// <returns></returns>
        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            //! adding 1 because we re working against the dp array where we add additional element
            return dp[row2 + 1][col2 + 1] //! whole matrix 
                   - dp[row1][col2 + 1] // !upper rectangle
                   - dp[row2 + 1][col1]  //!left rectangle
                   + dp[row1][col1];//! add  diagonal because  its subtracted twice  
        }
    }
}
