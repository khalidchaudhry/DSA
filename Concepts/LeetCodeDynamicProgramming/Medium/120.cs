using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _120
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int rowsCount = triangle.Count;

            if (rowsCount == 0)
            {
                return 0;
            }

            int[][] dp = new int[rowsCount][];

            // initializing do array 
            for (int i = 0; i < rowsCount; i++)
            {
                dp[i] = new int[triangle[i].Count];
            }

            // setting the first value in dp array 
            dp[0][0] = triangle[0][0];

            for (int i = 1; i < rowsCount; i++)
            {
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    int previousRow = 0;
                    // if previous row column is out of bound on left sode just pick the element we have
                    if (j - 1 < 0)
                    {
                        previousRow = dp[i - 1][j];
                    }
                    // if previous row column is out of bound on right side just pick the element we have
                    else if (j > dp[i - 1].Length - 1)
                    {
                        previousRow = dp[i - 1][j - 1];
                    }
                    else
                    {
                        previousRow = Math.Min(dp[i - 1][j], dp[i - 1][j - 1]);
                    }

                    // Setting value in dp array tobe used in next iteration 
                    dp[i][j] = triangle[i][j] + previousRow;
                }
            }

            // minimum value is minimum value in last array of dp array
            int minValue = int.MaxValue;
            for (int i = 0; i < dp[rowsCount - 1].Length; i++)
            {
                minValue = Math.Min(minValue, dp[rowsCount - 1][i]);
            }

            return minValue;
        }

        public int MinimumTotal1(IList<IList<int>> triangle)
        {
            int rowsCount = triangle.Count;

            if (rowsCount == 0)
            {
                return 0;
            }

            for (int i = 1; i < rowsCount; i++)
            {
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    int previousRow = 0;
                    // if previous row column is out of bound on left sode just pick the element we have
                    if (j - 1 < 0)
                    {
                        previousRow = triangle[i - 1][j];
                    }
                    // if previous row column is out of bound on right side just pick the element we have
                    else if (j > triangle[i - 1].Count - 1)
                    {
                        previousRow = triangle[i - 1][j - 1];
                    }
                    else
                    {
                        previousRow = Math.Min(triangle[i - 1][j], triangle[i - 1][j - 1]);
                    }

                    // Setting value in dp array tobe used in next iteration 
                    triangle[i][j] = triangle[i][j] + previousRow;
                }
            }

            // minimum value is minimum value in last array of dp array
            int minValue = int.MaxValue;
            for (int i = 0; i < triangle[rowsCount - 1].Count; i++)
            {
                minValue = Math.Min(minValue, triangle[rowsCount - 1][i]);
            }

            return minValue;
        }

        public int MinimumTotal2(IList<IList<int>> triangle)
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


    }
}
