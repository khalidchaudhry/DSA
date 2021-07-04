using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Easy
{
    class _455
    {

        public int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);
            int n1 = g.Length;
            int n2 = s.Length;
            int idx1 = 0;
            int idx2 = 0;

            int max = 0;
            while (idx1 < n1 && idx2 < n2)
            {
                if (g[idx1] <= s[idx2])
                {
                    ++max;
                    ++idx1;
                    ++idx2;
                }
                else
                {
                    ++idx2;
                }
            }
            return max;
        }
    }

    
}
