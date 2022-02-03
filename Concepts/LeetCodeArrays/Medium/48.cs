using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeArrays.Medium
{
    public class _48
    {

        // To  Frotate anticlock wise or rotate by 180 see below link
        //https://leetcode.com/problems/rotate-image/discuss/401356/Rotate-90-clockwise-anti-clockwise-and-rotate-180-degree
        
        //https://afteracademy.com/blog/rotate-matrix         
        public void Rotate(int[][] matrix)
        {
            // since its nXn grid , number of rows and columns are equal
            int rows = matrix.Length;
            int columns = matrix.Length;

            //! First step we are transposing matrix. Transposing means make rows as columns and columns as rows 
            //! if grid is not n*n than below method of transposing the matrix will not work
            for (int r = 0; r < rows; r++)
            {
                // ! initializing r with one more as swapping across the diagonal will transpose the matrix
                // ! Not adding by one will give wrong result
                for (int c = r + 1; c < columns; c++)
                {
                    //!  row becomes column and column become row acorss the  diagonal 
                    int temp = matrix[r][c];
                    matrix[r][c] = matrix[c][r];
                    matrix[c][r] = temp;
                }
            }

            //! second step:  Reverse each row of the matrix
            for (int r = 0; r < rows; r++)
            {
                int start = 0;
                int end = columns-1;
                while (start < end)
                {
                    int temp=matrix[r][start];
                    matrix[r][start] = matrix[r][end];
                    matrix[r][end] = temp;
                    ++start;
                    --end;
                }
            }
        }    
    }
}
