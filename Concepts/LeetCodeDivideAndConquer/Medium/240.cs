using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDivideAndConquer.Medium
{
    public class _240
    {

        public static void _240Main()
        {
            int[][] grid = new int[5][]
            {
                new int[] {1, 4, 7, 11, 15 },
                new int[] {2, 5, 8, 12, 19 },
                new int[] {3, 6, 9, 16, 22 },
                new int[] {10, 13, 14, 17, 24 },
                new int[] {18, 21, 23, 26, 30 }
            };

            var test = new _240();
            var ans = test.SearchMatrix0(grid, 5);
            Console.ReadLine();


        }
        /// <summary>
        //! Starting from  first row and last column. Same as in question 1428,1351
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix0(int[][] matrix, int target)
        {
            int rows = matrix.Length;
            int columns = matrix[0].Length;

            int r = 0;
            int c = columns - 1;
            while (r < rows && c >= 0)
            {
                if (matrix[r][c] == target)
                    return true;

                else if (matrix[r][c] < target)
                    ++r;

                else
                    --c;
            }

            return false;
        }


        /// <summary>
        //! We will start our search from lastRow and first colum . Then increase/decrease lastRow/firstColumn based on what we got from result. 
        //! Excellent explanation: https://www.youtube.com/watch?v=FOa55B9Ikfg 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix1(int[,] matrix, int target)
        {
            int lastRow = matrix.GetLength(0) - 1;
            int columnsCount = matrix.GetLength(1);
            int firstColumn = 0;

            while (lastRow >= 0 && firstColumn < columnsCount)
            {
                if (matrix[lastRow, firstColumn] == target)
                    return true;
                else if (matrix[lastRow, firstColumn] > target)
                {
                    --lastRow;
                }
                else if (matrix[lastRow, firstColumn] < target)
                {
                    ++firstColumn;
                }
            }

            return false;

        }

        /// <summary>
        //! Using binary search
        /// </summary>

        public bool SearchMatrix2(int[,] matrix, int target)
        {
            bool result = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (IsValueExist(matrix, i, target))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private bool IsValueExist(int[,] arr, int row, int target)
        {

            bool result = false;
            int low = 0;

            int high = arr.GetLength(1) - 1;

            while (low <= high)
            {
                int midPoint = low + ((high - low) / 2);

                int value = arr[row, midPoint];
                if (value == target)
                {
                    return true;
                }
                else if (value > target)
                {
                    high = midPoint - 1;
                }
                else
                {
                    low = midPoint + 1;
                }

            }

            return result;
        }


    }
}
