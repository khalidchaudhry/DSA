using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _59
    {

        public static void _59Main()
        {

            _59 Generate = new _59();
            var result=Generate.GenerateMatrix(1);

        }


        /// <summary>
        //! Same idea as used in 54 
        /// </summary>
        public int[][] GenerateMatrix(int n)
        {

            int[][] result = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                result[i] = new int[n];
            }

            int rows = result.Length;
            int columns = result[0].Length;
            int top = 0;
            int bottom = rows - 1;
            int left = 0;
            int right = columns - 1;
            int direction = 0;

            int number = 1;
            while (top <= bottom && left <= right)
            {
                if (direction == 0)
                {
                    for (int k = left; k <= right; ++k)
                    {
                        result[top][k] = number;
                        ++number;
                    }
                    ++top;
                }
                if (direction == 1)
                {
                    for (int k = top; k <= bottom; ++k)
                    {
                        result[k][right] = number;
                        ++number;
                    }
                    --right;
                }
                if (direction == 2)
                {
                    for (int k = right; k >= left; --k)
                    {
                        result[bottom][k] = number;
                        ++number;
                    }
                    --bottom;
                }

                if (direction == 3)
                {
                    for (int k = bottom; k >= top; --k)
                    {
                        result[k][left] = number;
                        ++number;
                    }
                    ++left;
                }

                direction = (direction + 1) % 4;
            }

            return result;
        }


    }
}
