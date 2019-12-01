﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion
{
    class ByteByByteExamples
    {

        public int CountEvenBuiltUp(int[] arr)
        {
            return CountEvenBuiltUp(arr,0);


        }

        private int CountEvenBuiltUp(int[] arr, int i)
        {
            if (i >= arr.Length) return 0;
            int result = CountEvenBuiltUp(arr, i + 1);
            if (arr[i] % 2 == 0) result++;
            return result;
        }


    }
}
