using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _54
    {

        // //  # <image url="$(SolutionDir)\Images\54.png"  scale="0.5"/>

        //https://www.youtube.com/watch?v=siKFOI8PNKM

        public IList<int> SpiralOrder(int[][] matrix)
        {

            List<int> result = new List<int>();
            int rows = matrix.Length;
            int columns = matrix[0].Length;
            int top = 0;
            int bottom = rows - 1;
            int left = 0;
            int right = columns - 1;
            int direction = 0;

            while (top <= bottom && left <= right)
            {
                if (direction == 0)
                {
                    for (int k = left; k <= right; ++k)
                    {
                        result.Add(matrix[top][k]);
                    }
                    ++top;
                }
                if (direction == 1)
                {
                    for (int k = top; k <= bottom; ++k)
                    {
                        result.Add(matrix[k][right]);
                    }
                    --right;
                }
                if (direction == 2)
                {
                    for (int k = right; k >= left; --k)
                    {
                        result.Add(matrix[bottom][k]);
                    }
                    --bottom;
                }

                if (direction == 3)
                {
                    for (int k = bottom; k >= top; --k)
                    {
                        result.Add(matrix[k][left]);
                    }
                    ++left;
                }

                direction = (direction + 1) % 4;
            }
            return result;
        }
    }
}
