using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _717
    {
        public bool IsOneBitCharacter(int[] bits)
        {
            int i = 0;
            while(i<bits.Length)
            {
                if (i == bits.Length - 1)
                {
                    return true;
                }

                if (bits[i] == 1)
                {
                    i = i + 2;
                }
                else
                {
                    ++i;
                }
            }
            return false;
        }
    }
}

