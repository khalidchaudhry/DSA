using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Arrays
{
    public class _1
    {
        public void PrintArray(int[] arr, int idx)
        {
            if (idx < arr.Length)
            {
                Console.Write(arr[idx]);
                PrintArray(arr,idx+1);
            }
        }

    }
}
