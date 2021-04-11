using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _1375
    {
        //https://www.youtube.com/watch?v=2M3WSSyyRLY
        //! Idea is to keep track of right max
        //https://leetcode.com/problems/bulb-switcher-iii/discuss/532762/simple-java-o-1-with-explaination
        public int NumTimesAllBlue(int[] light)
        {
            int rightMax =-1;
            int ans = 0;
            for (int i = 0; i < light.Length; ++i)
            {
                if (light[i] > rightMax)
                    rightMax = light[i];

                if (i + 1 == rightMax)
                {
                    ++ans;
                }
            }
            return ans;

        }




    }
}
