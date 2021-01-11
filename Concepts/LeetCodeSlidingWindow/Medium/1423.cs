using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Medium
{
    public class _1423
    {



        public static void _1423Main()
        {
            int[] cardPoints = new int[] { 1, 79, 80, 1, 1, 1, 200, 1 };
            _1423 points = new _1423();
            var result = points.MaxScore(cardPoints, 3);

            Console.ReadLine();
            

        }

        /// <summary>
        //! Sliding window. Some part of window is at beggining , other part is at the end 
        //!   // # <image url="https://assets.leetcode.com/users/images/aac454f9-15ca-4617-8877-f429fdf3ad2b_1592777668.0916321.png" scale="0.4" />  
        /// </summary>
        public int MaxScore(int[] cardPoints, int k)
        {
            int windowSum = 0;
            int n = cardPoints.Length;
            for (int i = 0; i < k; ++i)
            {
                windowSum += cardPoints[i];
            }

            int max = windowSum;

            for (int i = 0; i < k; ++i)
            {
                //!k - i - 1 will give the first element in current window
                //! n-i-1 will add the element from the array end in the window
                windowSum = windowSum - cardPoints[k - i - 1] + cardPoints[n - i - 1];

                max = Math.Max(windowSum, max);
            }

            return max;
        }
        /// <summary>
        //! Same approach as in question 643. Here we are going for minimum rather than maximum
        //! Array of size n-k with minimum sum and subtract it from sum
        /// </summary>
        public int MaxScore2(int[] cardPoints, int k)
        {
            int n = cardPoints.Length;

            int totalSum = 0;
            for (int i = 0; i < n; ++i)
            {
                totalSum += cardPoints[i];
            }

            int windowSize = n - k;
            int windowSum = 0;

            for (int i = 0; i < windowSize; ++i)
            {
                windowSum += cardPoints[i];
            }

            int minSum = windowSum;

            for (int i = windowSize; i < n; ++i)
            {
                windowSum = windowSum - cardPoints[i - windowSize] + cardPoints[i];
                minSum = Math.Min(windowSum, minSum);
            }

            return totalSum - minSum;
        }




    }
}
