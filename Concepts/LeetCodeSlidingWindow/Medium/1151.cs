using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Medium
{
    public class _1151
    {

        /// <summary>
        //! This is kind of problem where window size is not given. Based on the data , need to determine what is the window size
        //! Fixed size window
        //!Algorithm. 
        //! ! Based on number of 1's determine window size 
        //! Determine k based on number of zero's in first window. Slide and adjust zeros count based on number of zeros 
        /// </summary>
      
        public int MinSwaps(int[] data)
        {
            int k = WindowSize(data);
            if (k == 0) return 0;
            int zerosCount = CountZeros(data, k);
            int min = zerosCount;
            for (int i = k; i < data.Length; ++i)
            {
                if (data[i - k] == 0)
                    --zerosCount;

                if (data[i] == 0)
                    ++zerosCount;

                min = Math.Min(min, zerosCount);
            }

            return min;

        }

        /// <summary>
        //!Kuai's idea
        //! minimum number of swaps=minimizing number of zeros in window= maximizing the number of 1's = maximum sum in window of size k
        /// </summary>
        public int MinSwaps2(int[] data)
        {
            int total = Sum(data);

            return total - MaxSum(data,total);
            
        }

        private int MaxSum(int[] data, int k)
        {
            int sum = 0;
            for (int i = 0; i < k; ++i)
            {
                sum += data[i];
            }

            int maxSum = sum;

            for (int i = k; i < data.Length; ++i)
            {
                sum = sum - data[i - k] + data[i];
                maxSum = Math.Max(maxSum,sum);
            }

            return maxSum;
        }

        private int WindowSize(int[] data)
        {
            int k = 0;
            for (int i = 0; i < data.Length; ++i)
            {
                if (data[i] == 1)
                    ++k;
            }
            return k;
        }

        private int CountZeros(int[] nums, int k)
        {
            int zerosCount = 0;
            for (int i = 0; i < k; ++i)
            {
                if (nums[i] == 0)
                    ++zerosCount;
            }

            return zerosCount;
        }

        private int Sum(int[] data)
        {
            int total = 0;
            for (int i = 0; i < data.Length; ++i)
            {
                total += data[i];                
            }

            return total;
        }
    }
}
