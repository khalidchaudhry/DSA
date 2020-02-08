using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _905
    {
        public int[] SortArrayByParity(int[] A)
        {

            int i = 0;// it will contain index for  odd element 
            int j = A.Length - 1;// it will contain index for  even element 
            while (i < j)
            {
                // search for the odd element on the left side
                // Check the length first . Otherwise index out of bound exception. 
                while (i < A.Length && A[i] % 2 != 1)
                {
                    ++i;
                }
                // search for  the even element on right side. 
                // Check the length first . Otherwise index out of bound exception. 
                while (j >= 0 && A[j] % 2 != 0)
                {
                    --j;
                }

                if (i < j)
                {
                    Swap(A, i, j);
                    ++i;
                    --j;
                }
            }
            return A;
        }

        // Hermant Jain book page 88. 
        public int[] SortArrayByParity2(int[] A)
        {
            int i = 0;
            int j = A.Length - 1;
            while (i < j)
            {
                // increment i if element is even as its already in place
                if (A[i] % 2 == 0)
                {
                    ++i;
                }
                // decrement  j if element is odd as its already in place
                else if (A[j] % 2 == 1)
                {
                    --j;
                }
                // if we reach here it means we have odd element at ith index and even element at jth index
                //  so we need to swap
                else
                {
                    Swap(A, i, j);
                    ++i;
                    --j;
                }
            }

            return A;
        }

        private void Swap(int[] A, int i, int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }
    }
}
