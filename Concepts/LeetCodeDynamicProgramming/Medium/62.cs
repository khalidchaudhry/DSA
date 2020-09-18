using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    class _62
    {

        public static void _62Main()
        {
            _62 UniquePaths = new _62();
            var ans = UniquePaths.UniquePaths1(3, 7);
            Console.ReadLine();
        }


        /// <summary>
        /// https://leetcode.com/problems/unique-paths/discuss/22953/Java-DP-solution-with-complexity-O(n*m)
        // # <image url="https://leetcode.com/problems/unique-paths/Figures/62/inner_cell2.png" scale="0.4" />
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int UniquePaths1(int m, int n)
        {
            if (m == 0)
                return 0;
            int rows = m;
            int columns = n;

            int[][] dp = new int[rows][];

            for (int i = 0; i < dp.Length; ++i)
            {
                dp[i] = new int[columns];
            }

            //! initialize the first rows with 1 as there is only one path to reach out to last cell in first row
            for (int i = 0; i < columns; ++i)
            {
                dp[0][i] = 1;
            }

            //! initialize the first column with 1 as there is only one path to reach out to last cell in first column
            for (int i = 0; i < rows; ++i)
            {
                dp[i][0] = 1;
            }

            for (int i = 1; i < rows; ++i)
            {
                for (int j = 1; j < columns; ++j)
                {
                    dp[i][j] = dp[i - 1][j] + //up
                               dp[i][j - 1]; //left
                }
            }

            return dp[m - 1][n - 1];
        }





        /// <summary>
        // !Brute force solution(Time limit excceded)
        //! Idea is to create matrix based on given m and n and then calculate all the paths from (0,0) to (lastrow,lastColumn)
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int UniquePaths2(int m, int n)
        {
            if (m == 0)
                return 0;

            int[][] matrix = new int[m][];
            for (int i = 0; i < m; ++i)
            {
                matrix[i] = new int[n];
            }

            return UniquePaths2(matrix, 0, 0);

        }

        private int UniquePaths2(int[][] matrix, int i, int j)
        {
            if (i == matrix.Length || j == matrix[0].Length)
            {
                return 0;
            }
            //!last cell(bottom right)
            if (i == matrix.Length - 1 && j == matrix[0].Length - 1)
            {
                return 1;
            }

            return UniquePaths2(matrix, i + 1, j) + //!down
                   UniquePaths2(matrix, i, j + 1);  //! right
        }
    }
}
