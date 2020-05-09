using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class MatrixRollOut
    {

        public List<int> MatricRollOut(int[][] matrix)
        {
            List<int> result = new List<int>();
            int length = matrix.Length;
            // i represents the last column index
            for (int i = 0; i < length; i++)
            {
                int firstColumIndex = i;
                int lastColumnIndex = length -1- i;
                int lastRowIndex = length - 1 - i;

                // copy the first row
                for (int j = firstColumIndex; j <= lastColumnIndex; j++)
                {
                    result.Add(matrix[i][j]);
                }
                // copy the last column 
                for (int k = i + 1; k <= lastRowIndex; k++)
                {
                    result.Add(matrix[k][lastColumnIndex]);
                }
                // copy the last row 
                for (int l = lastColumnIndex - 1; l >= firstColumIndex; l--)
                {
                    result.Add(matrix[lastRowIndex][l]);
                }

                // copy the first column 
                for (int m = lastRowIndex-1;  m > i; m--)
                {
                    result.Add(matrix[m][firstColumIndex]);
                }
            } 

            return result;

        }

        public List<int> MatricRollOut2(int[][] matrix)
        {
            
            List<int> result = new List<int>();

            // ToList() time complexity 
            List<int> list = matrix.SelectMany(T => T).ToList();

            return result;

        }

    }
}
