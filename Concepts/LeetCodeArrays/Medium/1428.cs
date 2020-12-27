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
        //! Approach is very similar to what followed in leetcode 240,1351 
        //! Time complexity=O(n+m)
        /// </summary>
        public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
        {
            IList<int> dimensions = binaryMatrix.Dimensions();
            int rows = dimensions[0];
            int columns = dimensions[1];

            int leftMostColumn = -1;
            int row = 0;
            int column = columns - 1;

            while (row < rows && column >= 0)
            {
                int val = binaryMatrix.Get(row, column);

                if (val == 1)
                {
                    leftMostColumn = column;
                    --column;
                }

                else
                {
                    ++row;
                }
            }

            return leftMostColumn;
        }


        /// <summary>        
        //! Binary search on every row to find the first column having value==1
        //! Based on template from Roger
        //! Time complexity=mlog(n)  where m number of rows and n number of columns
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
