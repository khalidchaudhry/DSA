using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Easy
{

    public class NumArray
    {

        int[] prefixSum;
        public NumArray(int[] nums)
        {
            prefixSum = new int[nums.Length + 1];
            for (int i = 1; i < prefixSum.Length; ++i)
            {
                prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
            }
        }

        public int SumRange(int i, int j)
        {
            j = j + 1;
            return prefixSum[j] - prefixSum[i];
        }
    }

    /**
     * Your NumArray object will be instantiated and called as such:
     * NumArray obj = new NumArray(nums);
     * int param_1 = obj.SumRange(i,j);
     */
}
