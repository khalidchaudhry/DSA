using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefixSum.GeeksForGeeks
{
    public class PrintLeaders
    {
        public void printLeaders(int[] arr)
        {
            int n = arr.Length;

            int maxRight = int.MinValue;
            for (int i = n - 1; i >= 0; --i)
            {
                if (arr[i] > maxRight)
                {
                    Console.WriteLine(arr[i]);
                }
                maxRight = Math.Max(maxRight, arr[i]);
            }
        }
    }
}
