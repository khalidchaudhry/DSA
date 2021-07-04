using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDivideAndConquer.Medium
{
    public class _1130
    {
        public int MctFromLeafValues(int[] arr)
        {
            Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
            return MctFromLeafValues(arr, 0, arr.Length - 1, memo);
        }

        private int MctFromLeafValues(int[] arr, int s, int e, Dictionary<(int, int), int> memo)
        {
            if (s == e)
            {
                return 0;
            }

            if (memo.ContainsKey((s, e)))
            {
                return memo[(s, e)];
            }

            int min = int.MaxValue;
            for (int i = s; i < e; ++i)
            {
                int leftMax = Max(arr, s, i);
                int rightMax = Max(arr, i + 1, e);
                int product = leftMax * rightMax;
                //!Sum of non-leaf node
                int sumLeft = MctFromLeafValues(arr, s, i, memo);
                int sumRight = MctFromLeafValues(arr, i + 1, e, memo);
                min = Math.Min(min, product + sumLeft + sumRight);
            }
            memo[(s, e)] = min;
            return memo[(s, e)];
        }

        private int Max(int[] arr, int s, int e)
        {
            int max = 0;
            for (int i = s; i <= e; ++i)
            {
                max = Math.Max(arr[i], max);
            }

            return max;
        }
    }
}
