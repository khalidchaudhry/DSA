using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{

    /// <summary>
    /// https://www.youtube.com/watch?v=75Jrba2uGFM
    /// </summary>
    public class TwoMissingNumbers
    {
        public int[] TwoMissing(int[] arr)
        {
            int n = arr.Length + 2;
            long totalSum = (n * (n + 1)) / 2;
            long arrSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                arrSum += arr[i];
            }

            int pivot = (int)((totalSum - arrSum) / 2);

           
            int totalLeftXor = 0;
            int totalRightXor = 0;

            for (int i = 1; i <= n; i++)
            {
                if (i <= pivot)
                {
                    totalLeftXor ^= i;
                }
                else
                {
                    totalRightXor ^= i;
                }
            }

            int arrLeftXor = 0;
            int arrRightXor = 0;

            foreach (int item in arr)
            {
                if (item <= pivot)
                {
                    arrLeftXor ^= item;
                }
                else
                {
                    arrRightXor ^= item;
                }
            }

            return new int[] { totalLeftXor ^ arrLeftXor, totalRightXor ^ arrRightXor };

        }
    }
}
