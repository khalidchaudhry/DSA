using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy
{
    class _1221
    {
        public int balancedStringSplit(String s)
        {
            int count = 0;
            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Equals('R'))
                    ++count;
                else if (s[i].Equals('L'))
                    --count;
                if (count == 0)
                {
                    ++result;
                }
            }

            return result;
        }

    }
}
