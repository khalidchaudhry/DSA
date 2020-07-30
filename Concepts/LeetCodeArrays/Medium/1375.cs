using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _1375
    {

        //https://leetcode.com/problems/bulb-switcher-iii/discuss/532762/simple-java-o-1-with-explaination
        public int NumTimesAllBlue(int[] light)
        {
            int mostRightBulb = 0;
            int ans = 0;
            for (int i = 0; i < light.Length; ++i)
            {
                mostRightBulb = Math.Max(mostRightBulb,light[i]);
                if (i + 1 == mostRightBulb)
                {
                    ++ans;

                }
            }
            return ans;

        }




    }
}
