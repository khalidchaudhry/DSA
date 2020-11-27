using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Easy
{

    public class NumArray2
    {

        int[] sum;
        public NumArray2(int[] nums)
        {

            sum = new int[nums.Length];

            if (nums.Length != 0)
                sum[0] = nums[0];

            for (int i = 1; i < sum.Length; ++i)
            {
                sum[i] += sum[i - 1] + nums[i];
            }
        }

        public int SumRange(int i, int j)
        {

            if (sum.Length == 0) return 0;

            if (i == 0) return sum[j];

            return sum[j] - sum[i - 1];
        }
    }

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
