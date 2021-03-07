using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _120
    {
        public static void _120Main()
        {
            _120 Triangle = new _120();
            List<IList<int>> triangle = new List<IList<int>>()
            {
                new List<int>{2},
                new List<int>{3,4 },
                new List<int>{6,5,7},
                new List<int>{4,1,8,3 }

            };

            Triangle.MinimumTotal1(triangle);
            Console.ReadLine();
        }

        /// # <image url="$(SolutionDir)\Images\120.jpg"  scale="0.4"/>

        /// <summary>
        //! We will populate the current row based on the previous row
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public int MinimumTotal1(IList<IList<int>> triangle)
        {

            if (triangle.Count == 0)
            {
                return 0;
            }

            int[][] dp = new int[triangle.Count][];

            // initializing do array 
            for (int i = 0; i < triangle.Count; i++)
            {
                dp[i] = new int[triangle[i].Count];
            }

            // setting the first value in dp array 
            dp[0][0] = triangle[0][0];

            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 0; j < dp[i].Length; j++)
                {
                    int min = 0;
                    // if previous row column is out of bound on left sode just pick the element we have
                    if (j - 1 < 0)
                    {
                        min = dp[i - 1][j];
                    }
                    // if previous row column is out of bound on right side just pick the element we have
                    else if (j >= dp[i - 1].Length)
                    {
                        min = dp[i - 1][j - 1];
                    }
                    else
                    {
                        min = Math.Min(dp[i - 1][j], dp[i - 1][j - 1]);
                    }

                    // Setting value in dp array tobe used in next iteration 
                    dp[i][j] = triangle[i][j] + min;
                }
            }

            // minimum value is minimum value in last array of dp array
            int minValue = int.MaxValue;
            for (int i = 0; i < dp[dp.Length - 1].Length; i++)
            {
                minValue = Math.Min(minValue, dp[dp.Length - 1][i]);
            }

            return minValue;
        }

        /// <summary>
        //! Calculating from bottom to top but modifying the input array
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public int MinimumTotal3(IList<IList<int>> triangle)
        {
            int rowsCount = triangle.Count;

            if (rowsCount == 0)
            {
                return 0;
            }

            for (int i = rowsCount - 2; i >= 0; i--)
            {
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    triangle[i][j] += Math.Min(triangle[i + 1][j], triangle[i + 1][j + 1]);
                }
            }

            return triangle[0][0];
        }

        //! DP with memoization
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
            return MinimumTotal(triangle, 0, 0, memo);
        }

        private int MinimumTotal(IList<IList<int>> triangle, int row, int col, Dictionary<(int, int), int> memo)
        {
            if (row == triangle.Count)
            {
                return 0;
            }

            if (memo.ContainsKey((row, col)))
            {
                return memo[(row, col)];
            }

            int minTotal = triangle[row][col] + Math.Min(MinimumTotal(triangle, row + 1, col, memo), MinimumTotal(triangle, row + 1, col + 1, memo));

            return memo[(row, col)] = minTotal;
        }
    }
}
