using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module3
{
    public class Homework
    {

        //Question 1: Write a function that computes the 
        //Greatest Common Divisor (GCD) of two numbers.
        public int GCD(int a, int b)
        {
            if (b == 0)
                return a;

            return GCD(b, a % b);
        }
        //Question 2:Given a 2D boolean array, find the largest square subarray of true values.
        //The return value should be the side length of the largest square subarray subarray
        public int SquareSubmatrixIterative(bool[][] arr)
        {
            //Total rows and columns 
            int rows = arr.Length;
            int columns = arr[0].Length;

            int[][] aux = new int[rows][];
            //Initialize every row in the array with an array
            for (int i = 0; i < rows; i++)
            {
                aux[i] = new int[columns];
            }

            //Copy first row and first column as is in auxiliary array 
            for (int i = 0; i < columns; i++)
            {
                //First row
                aux[0][i] = arr[0][i] == true ? 1 : 0;
            }

            for (int i = 1; i < columns; i++)
            {
                //First column
                aux[i][0] = arr[i][0] == true ? 1 : 0;
            }
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < columns; j++)
                {
                    if (arr[i][j])
                    {
                        //aux[i][j - 1] --left
                        //aux[i - 1][j]--up
                        //aux[i - 1][j - 1] --diagonal up
                        //  0(i-1,j-1)   1(i-1,j)

                        //  1(i,j-1)     1(i,j)

                        aux[i][j] = Math.Min(aux[i][j - 1], aux[i - 1][j]) + 1;
                    }
                }
            }
            int largestSquareSubArea = aux[0][0];
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    largestSquareSubArea = Math.Max(largestSquareSubArea, aux[i][j]);
                }
            }

            return largestSquareSubArea;
        }

        //Implement Towers of Hanoi to find the moves required to move N disks from the source to destination.
        public List<Move> Moves(int n)
        {
            return Moves(n, Position.SRC, Position.DEST, Position.AUX);
        }

        private List<Move> Moves(int n, Position src, Position dest, Position aux)
        {
            List<Move> result = new List<Move>();
            if (n == 1)
            {
                result.Add(new Move(n, src, dest));
                return result;
            }
            //! Move n-1 disks from src to aux rods using dest rod as aux  
            result.AddRange(Moves(n - 1, src, aux, dest));
            //! Move the current disk from src to dest rod
            result.Add(new Move(n, src, dest));
            //! Move n-1 disks from aux to dest  rods using src rod as aux 
            result.AddRange(Moves(n - 1, aux, dest, src));

            return result;
        }

        //! Sam version
        //Question 3:Given a 2D boolean array, find the largest square subarray of true values.
        //The return value should be the side length of the largest square subarray subarray
        public int SquareSubmatrix(bool[][] arr)
        {
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[0].Length; j++)
                {
                    max = Math.Max(max, SquareSubmatrix(arr, i, j));
                }
            }

            return max;
        }

        private int SquareSubmatrix(bool[][] arr, int i, int j)
        {
            if (i == arr.Length || j == arr[0].Length)
            {
                return 0;
            }

            if (!arr[i][j])
                return 0;

            return 1 + Math.Min(Math.Min(SquareSubmatrix(arr, i + 1, j), SquareSubmatrix(arr, i + 1, j + 1)),
                                SquareSubmatrix(arr, i, j - 1));
        }

        //Question 3:Given a 2D boolean array, find the largest square subarray of true values.
        //The return value should be the side length of the largest square subarray subarray
        public int SquareSubmatrixRecursive(bool[][] arr)
        {
            //Total rows and columns 
            int rows = arr.Length;
            int columns = arr[0].Length;

            int[][] aux = new int[rows][];
            //Initialize every row in the array with an array
            for (int i = 0; i < rows; i++)
            {
                aux[i] = new int[columns];
            }

            //Copy first row and first column as is in auxiliary array 
            for (int i = 0; i < columns; i++)
            {
                //First row
                aux[0][i] = arr[0][i] == true ? 1 : 0;
            }

            for (int i = 1; i < rows; i++)
            {
                //First column
                aux[i][0] = arr[i][0] == true ? 1 : 0;
            }
            SquareSubmatrixRecursive(arr, aux, 1, 1, rows, columns);
            int largestSquareSubArea = aux[0][0];
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    largestSquareSubArea = Math.Max(largestSquareSubArea, aux[i][j]);
                }
            }

            return largestSquareSubArea;
        }

        //Question 3:Given a 2D boolean array, find the largest square subarray of true values.
        //The return value should be the side length of the largest square subarray subarray
        private static void SquareSubmatrixRecursive(bool[][] arr, int[][] aux, int row, int column, int rows, int columns)
        {
            if (row == rows) // end of the recursion 
            {
                return;
            }

            if (column == columns)
            {
                SquareSubmatrixRecursive(arr, aux, row + 1, 1, rows, columns);
                return;
            }

            if (arr[row][column])
            {
                aux[row][column] = Math.Min(aux[row][column - 1], aux[row - 1][column]) + 1;
            }
            // Go to the next column 
            SquareSubmatrixRecursive(arr, aux, row, column + 1, rows, columns);
        }

    }


    public class Move
    {
        int disk;
        Position src;
        Position dest;
        public Move(int disk, Position src, Position dest)
        {
            this.disk = disk;
            this.src = src;
            this.dest = dest;
        }
        public override string ToString()
        {
            return $"Disk:{this.disk} Source:{this.src} Destination:{this.dest}";
        }
    }

    public enum Position
    {
        SRC,
        DEST,
        AUX
    }
}