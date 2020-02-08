using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _832
    {
        public int[][] FlipAndInvertImage(int[][] A)
        {
            // iterate based on the lenght of array(Outer array)
            for (int i = 0; i < A.Length; i++)
            {
                int start = 0;
                // calculating end of of ith row. 
                int end = A[i].Length - 1;
                // Making <= than < because we need to ensure that we Invert middle element
                while (start <= end)
                {
                    Swap(A, i, start, end);
                    Invert(A, i, start, end);
                    ++start;
                    --end;
                }
            }
            return A;
        }

        // leetcode solution : good one 
        //https://leetcode.com/problems/flipping-an-image/discuss/148272/Easy-Understand-One-pass-Java-Solution-absolutely-beat-100
        // The idea is simple.For each row, use two pointers.One is going forward and the other is going backward.
        // (1). If the two elements are the same, then make a slight change like this 0 -> 1 or 1 -> 0.
        //(2). If the two elements are different, DON'T do anything. Just let it go.

        public int[][] FlipAndInvertImage2(int[][] A)
        {
            // iterate based on the lenght of array(Outer array)
            for (int i = 0; i < A.Length; i++)
            {
                int start = 0;
                // calculating end of of ith row. 
                int end = A[i].Length - 1;
                // ith value from the left = inverse of the ith value from the right.
                while (start <= end)
                {
                    if (A[i][start] == A[i][end])
                    {
                        A[i][start] = 1 - A[i][start];
                        A[i][end] = A[i][start];
                    }

                    ++start;
                    --end;
                }
            }
            return A;
        }
        public void PrintArray(int[][] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < A[i].Length; j++)
                {
                    Console.Write($"{A[i][j]} ");
                }

                Console.WriteLine();
            }
        }
        private void Swap(int[][] A, int row, int start, int end)
        {
            int temp = A[row][start];
            A[row][start] = A[row][end];
            A[row][end] = temp;
        }

        private void Invert(int[][] A, int row, int start, int end)
        {
            //if start==end than we are in middle and don't need to invert 
            // both start and end. Only one needs to be inverted either start or end
            if (start == end)
            {
                A[row][start] = A[row][start] == 1 ? 0 : 1;
            }
            else
            {
                A[row][start] = A[row][start] == 0 ? 1 : 0;
                A[row][end] = A[row][end] == 0 ? 1 : 0;
            }
        }
    }
}
