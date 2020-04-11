using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Arrays
{
    class _22
    {
        public int BinarySearch(int[] list, int first, int last, int key)
        {
            if (first > last)
            {
                return -1;
            }

            else
            {
                int mid = (first + last) / 2;

                if (key == list[mid])
                {
                    return mid;
                }
                else if (key < list[mid])
                {
                    return BinarySearch(list, first, mid - 1, key);
                }
                else
                {
                    return BinarySearch(list, mid + 1, last, key);
                }
            }
        }

    }
}
