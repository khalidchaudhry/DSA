using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.GeeksForGeeks
{


    /// <summary>
    /// https://www.geeksforgeeks.org/traverse-a-given-matrix-using-recursion/
    /// </summary>
    public class TraverseMatrix
    {

        static int N = 2;
        static int M = 3;
        // Function to traverse the matrix recursively 
        public static int TraverseMatrixWithRecursion(int[,] arr, int current_row,
                           int current_col)
        {
            // If the entire column is traversed 
            if (current_col >= M)
                return 0;

            // If the entire row is traversed 
            if (current_row >= N)
                return 1;

            // Print the value of the current 
            // cell of the matrix 
            Console.Write(arr[current_row, current_col] + ", ");

            // Recursive call to traverse the matrix 
            // in the Horizontal direction 
            if (TraverseMatrixWithRecursion(arr, current_row,
                               current_col + 1)
                == 1)
                return 1;

            // Recursive call for changing the 
            // Row of the matrix 
            return TraverseMatrixWithRecursion(arr,
                                  current_row + 1,
                                  0);
        }

        public static void TraverseMatrixWithRecursion(int[][] arr)
        {
            TraverseMatrixWithRecursion(arr, 0, 0, new StringBuilder());
        }

        private static void TraverseMatrixWithRecursion(int[][] arr, int i, int j, StringBuilder path)
        {
            if (i == arr.Length) return;

            if (j == arr[i].Length)
            {
                Console.WriteLine(path);
                path.Clear();
                TraverseMatrixWithRecursion(arr, i + 1, 0, path);
                return;
            }
            path.Append(arr[i][j]);
            TraverseMatrixWithRecursion(arr, i, j + 1, path);
        }
    }
}
