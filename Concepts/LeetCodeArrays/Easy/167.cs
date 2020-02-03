using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _167
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            int[] result = new int[2];

            int start = 0;
            int end = numbers.Length - 1;
            while (start < end)
            {
                if (numbers[start] + numbers[end] > target)
                {
                    --end;
                }
                else if (numbers[start] + numbers[end] < target)
                {
                    ++start;
                }
                else
                {
                    result[0] = start + 1;
                    result[1] = end + 1;
                    break;
                }
            }

            return result;
        }

    }
}
