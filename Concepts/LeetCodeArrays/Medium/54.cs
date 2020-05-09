using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _54
    {

        /// <summary>
        //https://leetcode.com/problems/spiral-matrix/solution/
        //[1, 2, 3, 4],        
        //[5, 6, 7, 8],
        //[9,10,11,12]
        // !c from c1......c2
        // !r from r1+1 .......r2
        // !c from c2-1 ........c1+1
        // !r from r2..........r1+1
        //! Time complexity=O(n) where n is the number of elements in an array. 
        //! Space complexity=O(1) not considering result list else its O(n)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public IList<int> SpiralOrder0(int[][] matrix)
        {

            List<int> result = new List<int>();

            if (matrix.Length == 0)
                return result;

            int r1 = 0;
            int r2 = matrix.Length - 1;

            int c1 = 0;
            int c2 = matrix[0].Length - 1;

            //! r1 <= r2 && c1 <= c2 -----To make sure that there are elements tobe printed in an array. 
            while (r1 <= r2 && c1 <= c2)
            {
                //copy the first row
                //! We are traversing the first row but moving column one at a time
                for (int c = c1; c <= c2; c++)
                {
                    result.Add(matrix[r1][c]);
                }

                // copy the last column excluding value at matrix[r1][c2] as its already copied previously. 
                // That is the reason we are setting r=r1+1
                for (int r = r1 + 1; r <= r2; r++)
                {
                    result.Add(matrix[r][c2]);
                }
                // if there is only one row or one column... .. no need to copy last row or last column 
                // as its already copied by above loops 
                //e.g. matrix=[1] or 
                // matrix={[1]
                //        [2]}
                if (r1 < r2 && c1 < c2)
                {
                    //!copy the last row excluding the value at first cloumn(c>c1) as below loop will copy it
                    for (int c = c2 - 1; c > c1; --c)
                    {
                        result.Add(matrix[r2][c]);
                    }
                    // copy the first column 
                    for (int r = r2; r > r1; --r)
                    {
                        result.Add(matrix[r][c1]);
                    }
                }

                ++r1;
                --r2;
                ++c1;
                --c2;

            }


            return result;

        }
        public IList<int> SpiralOrder(int[][] matrix)
        {

            List<int> result = new List<int>();
            int length = matrix.Length;

            if (length == 0)
                return result;
            if (length == 1)
            {
                result.AddRange(matrix[0]);
            }
            // i represents the last column index
            for (int i = 0; i < length; i++)
            {
                int firstColumIndex = i;
                int lastColumnIndex = matrix[i].Length - 1 - i;
                int lastRowIndex = length - 1 - i;

                // copy the first row
                for (int j = firstColumIndex; j <= lastColumnIndex && lastRowIndex != 0; j++)
                {
                    result.Add(matrix[i][j]);
                }
                // copy the last column 
                for (int k = i + 1; k <= lastRowIndex; k++)
                {
                    result.Add(matrix[k][lastColumnIndex]);
                }
                // copy the last row 
                //! if first row ==last row than no need to copy last row i!=lastRowIndex
                for (int l = lastColumnIndex - 1; l >= firstColumIndex && i != lastRowIndex; l--)
                {
                    result.Add(matrix[lastRowIndex][l]);
                }

                // copy the first column 
                for (int m = lastRowIndex - 1; m > i && lastColumnIndex != 0; m--)
                {
                    result.Add(matrix[m][firstColumIndex]);
                }
            }
            return result;
        }


    }
}
