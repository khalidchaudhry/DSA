using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _1428
    {


        public static void _1428Main()
        {

            _1428 Test = new _1428();
            BinaryMatrix binaryMatrix = new BinaryMatrix();
            Test.LeftMostColumnWithOne2(binaryMatrix);
            Console.ReadLine();              
        }
        
        
        
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


        /// <summary>
        //! Based on template from Roger
        /// </summary>      
        public int LeftMostColumnWithOne2(BinaryMatrix binaryMatrix)
        {

            IList<int> dimensions = binaryMatrix.Dimensions();
            int rows = dimensions[0];
            int columns = dimensions[1];
            int smallestIndex = columns;

            for (int row = 0; row < rows; ++row)
            {
                int lo = -1;
                int hi = columns - 1;

                while (lo + 1 < hi)
                {
                    int mid = (lo + hi) / 2;

                    if (binaryMatrix.Get(row, mid) == 1)
                        hi = mid;
                    else
                        lo = mid;

                    if (binaryMatrix.Get(row, hi) == 1)
                    {
                        smallestIndex = Math.Min(smallestIndex, hi);
                    }
                }
            }

            return smallestIndex == columns ? -1 : smallestIndex;
        }

    }

    public class BinaryMatrix
    {
        int[][] matrix = new int[2][]
        {
            new int[2]{0,0 },
            new int[2]{1,1 }
        };
        public int Get(int row, int col)
        {
            return matrix[row][col];
        }
        public IList<int> Dimensions()
        {
            return new List<int>() {matrix.Length,matrix[0].Length };
        }
    }
}
