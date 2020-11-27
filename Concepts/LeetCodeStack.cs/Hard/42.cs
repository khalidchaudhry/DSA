using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Hard
{
    public class _42
    {

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
