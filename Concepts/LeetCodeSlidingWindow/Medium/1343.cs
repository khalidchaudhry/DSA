using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Medium
{
    class _1343
    {
        //! Using fixed size window
        public int NumOfSubarrays(int[] arr, int k, int threshold)
        {
            int numberOfSubArrays = 0;
            int windowSum = 0;
            for (int i = 0; i < k; ++i)
            {
                windowSum += arr[i];
            }
            if (windowSum / k >= threshold)
            {
                numberOfSubArrays += 1;
            }
            for (int i = k; i < arr.Length; ++i)
            {
                windowSum = windowSum - arr[i - k] + arr[i];
                if (windowSum / k >= threshold)
                    numberOfSubArrays += 1;
            }
            return numberOfSubArrays;
        }

        //! Using variable size window
        public int NumOfSubarrays2(int[] arr, int k, int threshold)
        {

            int subArrayCount = 0;
            int sum = 0;

            int i = 0;
            for (int j = 0; j < arr.Length; ++j)
            {
                sum += arr[j];
                if (j - i + 1 == k)
                {
                    if ((sum / k) >= threshold)
                        ++subArrayCount;

                    sum = sum - arr[i];
                    ++i;
                }
            }

            return subArrayCount;

        }


    }
}
