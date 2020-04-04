using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Arrays
{
    public class _2
    {
        public void PrintArrayInReverseOrder(int[] arr, int idx)
        {
            if (idx >=0)
            {
                Console.Write(arr[idx]);
                PrintArrayInReverseOrder(arr,idx-1);
            }
        }

    }
}
