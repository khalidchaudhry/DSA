using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _1428
    {

        /// <summary>
        //! Approach is very similar to what followed in leetcode 240 
        /// </summary>
        public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
        {
            IList<int> dimensions = binaryMatrix.Dimensions();
            int rows = dimensions[0];
            int columns = dimensions[1];
            int minColumn = columns;
            int column = columns - 1;
            int row = 0;
            while (row < rows && column >= 0)
            {
                if (binaryMatrix.Get(row, column) == 0)
                    ++row;
                else
                {
                    minColumn = Math.Min(minColumn, column);
                    --column;
                }
            }

            return minColumn == columns ? -1 : minColumn;
        }

    }


    public class BinaryMatrix
    {
        public int Get(int row, int col)
        {
            return 0;
        }
        public IList<int> Dimensions()
        {
            return new List<int>();
        }
    }
}
