﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Medium
{
    public class _672
    {
        //https://leetcode.com/problems/bulb-switcher-ii/discuss/107269/Java-O(1)
        public int FlipLights(int n, int m)
        {
            if (m == 0) return 1;
            if (n == 1) return 2;
            if (n == 2 && m == 1) return 3;
            if (n == 2) return 4;
            if (m == 1) return 4;
            if (m == 2) return 7;
            if (m >= 3) return 8;
            return 8;
        }

    }
}
