using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinarySearch.Medium
{
    public class _74
    {

        public static void _74Main()
        {

            int[][] matrix = new int[3][]
                {
                    new int[]{1,3,5,7 },
                    new int[]{10,11,16,20 },
                    new int[]{23,30,34,50 }
                };

            _74 Search = new _74();
            var ans = Search.SearchMatrix1(matrix, 13);

        }
        /// <summary>
        //! Space=O(m+n)
        //! Time=O(1)
        /// </summary>
       
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            int r = 0;
            int c = cols - 1;

            while (r < rows && c >= 0)
            {
                if (matrix[r][c] == target)
                {
                    return true;
                }
                else if (matrix[r][c] > target)
                {
                    --c;
                }
                else
                {
                    ++r;
                }
            }
            return false;
        }

        /// <summary>
        //! Key intuition here is to visualize it as 1D arrray
        //! Excellent explanation https://www.youtube.com/watch?v=FOa55B9Ikfg
        //! Time=O(logmn)
        //! Space=O(1)
        /// </summary>      
        public bool SearchMatrix0(int[][] matrix, int target)
        {

            int rows = matrix.Length;

            //! important 
            if (rows == 0)
                return false;

            int columns = matrix[0].Length;

            int lo = 0;
            int hi = rows * columns - 1;
            //! lo<=hi
            while (lo <= hi)
            {
                int mid = lo + ((hi - lo) / 2);
                //! translating 1D index into 2D array index 
                int midElement = matrix[mid / columns][mid % columns];

                if (midElement == target)
                    return true;
                else if (midElement > target)
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            return false;
        }
        
        public bool SearchMatrix1(int[][] matrix, int target)
        {

            List<int> elements = new List<int>();

            for (int i = 0; i < matrix.Length; ++i)
            {
                elements.AddRange(matrix[i]);
            }

            int lo = 0;
            int hi = elements.Count - 1;

            while (lo <= hi)
            {

                int mid = lo + ((hi - lo) / 2);

                if (elements[mid] == target)
                {
                    return true;
                }
                else if (elements[mid] > target)
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            return false;
        }

    }
}
