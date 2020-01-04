using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class Merge
    {
        public void merge(int[] arr, int[] arr1)
        {
            int n = arr.Length;
            int m = arr1.Length;
            //int[] arr = new int[] { 1, 5, 9, 10, 15, 20 };
            //int[] arr1 = new int[] { 2, 3, 8, 13 };
            int i, j, small;
            for (i = 0; i < n; i++)
            {
                for (j = m - 1; j >= 0; j--)
                {
                    if (arr1[j] < arr[i])
                    {
                        small = arr[i];
                        arr[i] = arr1[j];
                        arr1[j] = small;
                    }
                }
            }
        }

    }
}
