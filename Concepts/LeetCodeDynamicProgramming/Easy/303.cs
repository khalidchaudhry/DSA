using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Easy
{
    public class NumArray
    {

        int[] result;
        public NumArray(int[] nums)
        {
            result = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                result[i + 1] = result[i] + nums[i];
            }
        }

        public int SumRange(int i, int j)
        {
            if (i > j || i < 0 || j >= (result.Length - 1))
                return 0;

            return (result[j + 1] - result[i]);

        }
    }

    /**
     * Your NumArray object will be instantiated and called as such:
     * NumArray obj = new NumArray(nums);
     * int param_1 = obj.SumRange(i,j);
     */
}
