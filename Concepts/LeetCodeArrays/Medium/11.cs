using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _11
    {
        public int MaxArea(int[] height)
        {
            int answer = 0;
            int i = 0, j = height.Length - 1;

            while (i < j)
            {
                //! width is j-i not j-i+1. When including boundries we need to include start or end but not both 
                int width = j - i;
                int area = 0;
                if (height[i] < height[j])
                {
                    area = width * height[i];
                    ++i;
                }
                else
                {
                    area = width * height[j];
                    --j;
                }

                answer = Math.Max(answer, area);

            }
            return answer;
        }
    }
}
