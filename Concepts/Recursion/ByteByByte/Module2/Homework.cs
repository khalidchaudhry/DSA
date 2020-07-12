using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module2
{
    public class Homework
    {
        //Question 1:Write a recursive function that prints out the odd indices of an integer array 
        public void PrintOdd(int[] arr)
        {
            PrintOdd(arr, 1);
        }

        // Question 2: Write a recursive function that finds the minimum and maximum value in an integer array.
        public int[] MinMax(int[] arr)
        {
            int[] minMax = new int[2] { int.MaxValue, int.MinValue };

            MinMax(arr, 0, minMax);

            return minMax;
        }

        //Question 3: Given an array of arrays, write a function to flatten the 2D array into a 1D array

        //!Iterative
        public List<int> FlattenIterative(int[][] arr)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    result.Add(arr[i][j]);
                }
            }

            return result;
        }
        //! Recursive
        public List<int> FlattenRecursive(int[][] arr)
        {
            List<int> result = new List<int>();

            FlattenRecursive(arr, 0, result);

            return result;
        }
        //Question 4: Write a recursive function that finds all substrings of a string using a single recursive function. 
        //As a reminder,this is the code we looked at in class
        public List<string> Substrings(string s)
        {
            List<string> result = new List<string>();
            Substrings(s, 0, 0, result);
            return result;
        }

        private void PrintOdd(int[] arr, int i)
        {
            if (i == arr.Length)
            {
                return;
            }
            if (i % 3 == 0)
            {
                Console.WriteLine(i);
            }
            PrintOdd(arr, i + 1);
        }

        private void MinMax(int[] arr, int i, int[] minMax)
        {
            if (i == arr.Length)
                return;

            minMax[0] = Math.Min(minMax[0], arr[i]);
            minMax[1] = Math.Max(minMax[1], arr[i]);
            MinMax(arr, i + 1, minMax);
        }

        private void FlattenRecursive(int[][] arr, int i, List<int> result)
        {
            if (i == arr.Length)
            {
                return;
            }
            FlattenRecursiveInner(arr[i], 0, result);

            FlattenRecursive(arr, i + 1, result);
        }
        private void FlattenRecursiveInner(int[] arr, int j, List<int> result)
        {
            if (j == arr.Length)
            {
                return;
            }

            result.Add(arr[j]);

            FlattenRecursiveInner(arr, j + 1, result);
        }
        private void Substrings(string s, int i, int j, List<string> result)
        {
            if (i >= s.Length) return;

            if (j >= s.Length)
            {
                Substrings(s, i + 1, i + 1, result);
                return;
            }

            result.Add(s.Substring(i, j - i + 1));
            Substrings(s, i, j + 1, result);
        }






    }
}
