using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _66
    {
        public int[] PlusOne(int[] digits)
        {
            for (int digit = digits.Length - 1; digit >= 0; --digit)
            {
                if (digits[digit] < 9)
                {
                    ++digits[digit];
                    return digits;
                }
                digits[digit] = 0;
            }

            int[] result = new int[digits.Length + 1];

            result[0] = 1;

            return result;
        }

    }
}
