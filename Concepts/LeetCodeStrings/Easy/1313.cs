using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Easy
{
    public class _1313
    {

        public static void _1313Main()
        {
            int[] nums = new int[] { 1, 1, 2, 3 };

            _1313 Decompress = new _1313();

            var result=Decompress.DecompressRLElist(nums);

            Console.ReadLine();
        }

        public int[] DecompressRLElist(int[] nums)
        {

            List<int> result = new List<int>();

            for (int i = 0; i < nums.Length; i += 2)
            {
                int frequency = nums[i];
                int value = nums[i + 1];
                for (int j = 1; j <= frequency; ++j)
                {
                    result.Add(value);
                }
            }

            return result.ToArray();

        }





    }
}
