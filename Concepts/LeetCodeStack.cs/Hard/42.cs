using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Hard
{
    public class _42
    {



        public int Trap0(int[] height)
        {

            int n = height.Length;
            if (n == 0)
            {
                return 0;
            }

            int[] maxRight = new int[n];
            int max = 0;
            for (int i = n - 1; i >= 0; --i)
            {
                max = Math.Max(max, height[i]);
                maxRight[i] = max;
            }

            int waterTapped = 0;
            int maxLeft = height[0];
            for (int i = 1; i < n - 1; ++i)
            {
                waterTapped += Math.Max(0, Math.Min(maxLeft, maxRight[i + 1]) - height[i]);
                maxLeft = Math.Max(maxLeft, height[i]);
            }
            return waterTapped;

        }

        /// <summary>
        /// https://www.youtube.com/watch?v=zdDeV5v_iUE
        // !Below video explains how to solve in constant space
        /// https://www.youtube.com/watch?v=XqTBrQYYUcc
        /// </summary>        
        public int Trap(int[] height)
        {

            if (height.Length == 0) return 0;

            int[] maxLeftHeight = new int[height.Length];
            int[] maxRightHeight = new int[height.Length];

            maxLeftHeight[0] = 0;
            for (int i = 1; i < maxLeftHeight.Length; ++i)
            {
                maxLeftHeight[i] = Math.Max(maxLeftHeight[i - 1], height[i - 1]);
            }

            maxRightHeight[0] = 0;
            for (int i = maxLeftHeight.Length - 2; i >= 0; --i)
            {
                maxRightHeight[i] = Math.Max(maxLeftHeight[i + 1], height[i + 1]);
            }
            int sum = 0;
            for (int i = 0; i < height.Length; ++i)
            {
                int min = Math.Min(maxLeftHeight[i], maxRightHeight[i]);
                int waterHold = min - height[i];
                sum += waterHold < 0 ? 0 : waterHold;
            }
            return sum;
        }


    }
}
