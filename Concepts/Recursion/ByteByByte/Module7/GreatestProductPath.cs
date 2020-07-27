using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module7
{
    public class GreatestProductPath
    {
        public static void GreatestProductPathMain()
        {
            List<int> result = new List<int>();
            result.Add(int.MinValue);

            int[][] matrix = new int[3][]
            {
                new int[3]{1,2,3 },
                new int[3]{4,5,6 },
                new int[3]{7,8,9 },
            };

            GreatestProductPath path = new GreatestProductPath();
            path.GreatestProduct(matrix, 0, 0, 1, result);

            Console.Read();

        }

        public void GreatestProduct(int[][] matrix, int i, int j, int product, List<int> result)
        {
            //!out of bound 
            if (i >= matrix.Length || j >= matrix[0].Length)
            {
                return;
            }          

            product *= matrix[i][j];

            if (i == matrix.Length - 1 && j == matrix[0].Length - 1)
            {

                if (result[0] < product)
                {
                    result[0] = product;
                }
                return;
            }


            GreatestProduct(matrix, i + 1, j, product, result);

            GreatestProduct(matrix, i, j + 1, product, result);

        }


    }
}
