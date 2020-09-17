using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _1277
    {




        public static void _1277Main()
        {
            int[][] matrix = new int[3][]
            {
                new int[]{1,0,1},
                new int[]{1,1,0 },
                new int[]{1,1,0 }
            };

            _1277 CountSquares = new _1277();
            var ans = CountSquares.CountSquares0(matrix);
            Console.ReadLine();
        }
        public int CountSquares0(int[][] matrix)
        {
            int rows = matrix.Length;
            int columns = matrix[0].Length;

            if (rows == 0)
                return 0;
            int[][] dp = new int[rows + 1][];

            for (int i = 0; i < dp.Length; ++i)
            {
                dp[i] = new int[columns + 1];
            }

            int totalSquares = 0;
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    if (matrix[i][j] == 0)
                    {
                        continue;
                    }

                    dp[i + 1][j + 1] = 1 + Math.Min(dp[i][j + 1],//up
                                           Math.Min(dp[i + 1][j],// left side
                                                    dp[i][j])); // diagonal
                    totalSquares += dp[i + 1][j + 1];
                }
            }

            return totalSquares;
        }


        /// <summary>
        //! Brute force
        //! 
        //! https://leetcode.com/problems/count-square-submatrices-with-all-ones/discuss/441414/C%2B%2B-Intuitive-Solution-Recursion-With-Memoization
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int CountSquares2(int[][] matrix)
        {
            if (matrix.Length == 0)
                return 0;

            int ans = 0;
            for (int i = 0; i < matrix.Length; ++i)
            {
                for (int j = 0; j < matrix[0].Length; ++j)
                {
                    ans += CountSquares2(matrix, i, j);

                }
            }

            return ans;
        }

        private int CountSquares2(int[][] matrix, int i, int j)
        {
            if (i == matrix.Length || j == matrix[0].Length)
                return 0;
            if (matrix[i][j] == 0)
                return 0;
            return 1 + Math.Min(CountSquares2(matrix, i, j + 1), //! right
                       Math.Min(CountSquares2(matrix, i + 1, j), //!down
                                CountSquares2(matrix, i + 1, j + 1))); //! diagonal
        }
    }
}
