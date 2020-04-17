using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Arrays
{
    public class _23
    {
        public int TernarySearch(int[] list, int key, int first, int last)
        {
            int mid1, mid2;
            if (first > last)
            {
                return -1;
            }

            mid1 = first + (last - first) / 3;
            mid2 = last + (last - first) / 3;

            if (list[mid1] == key)
            {
                return mid1;
            }
            else if (list[mid2] == key)
            {
                return mid2;
            }
            else if (key < list[mid1])
                return TernarySearch(list, key, first, mid1 - 1);
            else if (key > list[mid2])
                return TernarySearch(list, key, mid2 + 1, last);
            else
                return TernarySearch(list, key, mid1 + 1, mid2 - 1);
        }

    }
}
