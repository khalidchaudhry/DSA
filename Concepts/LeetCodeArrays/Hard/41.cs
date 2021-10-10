using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Hard
{
    public class _41
    {

        public static void _41Main()
        {
            int[] nums = new int[] { 3, 4, -1, 1 };
            _41 test = new _41();
            var ans=test.FirstMissingPositive(nums);
            Console.ReadLine();
        }
        public int FirstMissingPositive(int[] nums)
        {

            int n = nums.Length;

            //! we are marking negative numbers and 0 to  n 
            //! Reason is we need to distinguish numbers which are alredy negative in array vs what we will mark them in below loop
            for (int i = 0; i < n; ++i)
            {
                if (nums[i] <= 0)
                {
                    nums[i] = n + 1;
                }
            }

            for (int i = 0; i < n; ++i)
            {
                int idx = Math.Abs(nums[i]);
                //! We can mark only numbers that are within index array
                if (idx <= n)
                {
                    nums[idx - 1] = -Math.Abs(nums[idx - 1]);
                }
            }

            for (int i = 0; i < n; ++i)
            {
                if (nums[i] > 0)
                {
                    return i + 1;
                }
            }

            return n + 1;
        }

    }
}
