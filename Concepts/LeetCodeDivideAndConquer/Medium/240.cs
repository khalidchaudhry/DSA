using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDivideAndConquer.Medium
{
    public class _240
    {
        /// <summary>
        //! We will start our search from lastRow and first colum . Then increase/decrease lastRow/firstColumn based on what we got from result. 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix0(int[,] matrix, int target)
        {
            int lastRow = matrix.GetLength(0)-1;
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


        //! Below will not work 

        public bool SearchMatrix1(int[,] matrix, int target)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int low = 0;
            int high = rows * columns - 1;
            while (low <= high)
            {
                int midPointIndex = low + ((high - low) / 2);
                int midElement = matrix[midPointIndex / columns, midPointIndex % columns];

                if (midElement == target)
                {
                    return true;
                }
                else if (midElement > target)
                {
                    high = midPointIndex - 1;
                }
                else
                {
                    low = midPointIndex + 1;

                }

            }

            return false;

        }

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
