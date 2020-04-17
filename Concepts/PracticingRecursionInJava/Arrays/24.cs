using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Arrays
{
    public class _24
    {
        public int CountStringItem(string item, string[] arr, int size)
        {
            if (size !=0)
            {
                int count = 0;

                if (arr[size - 1].Equals(item))
                {
                    ++count;
                }

                count += CountStringItem(item,arr,size-1);
                return count;
            }

            return 0;
        }

    }
}
