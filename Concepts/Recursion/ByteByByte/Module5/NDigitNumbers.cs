using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module5
{
    public class NDigitNumbers
    {
        public List<int> NDigitNumberSum(int n, int targetSum)
        {
            List<int> toReturn = new List<int>();
            List<List<int>> result = new List<List<int>>();

            NDigitNumberSum(n, targetSum, 0, new List<int>(), result);
            for (int i = 0; i < result.Count; i++)
            {
                toReturn.Add(ListToInteger(result[i]));
            }

            return toReturn;
        }

        private int ListToInteger(List<int> lst)
        {
            int sum = 0;
            for (int i = 0; i < lst.Count; i++)
            {
                sum += lst[i] * (int)Math.Pow(10, lst.Count - 1 - i);
            }
            return sum;

        }

        private void NDigitNumberSum(int n, int target, int sum, List<int> path, List<List<int>> result)
        {
            if (sum > target) return;

            if (n == 0)
            {
                if (target == sum)
                {
                    result.Add(new List<int>(path));
                }
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                if (sum == 0 && i == 0) continue;
                path.Add(i);
                NDigitNumberSum(n - 1, target, sum + i, path, result);
                path.RemoveAt(path.Count - 1);
            }
        }



    }
}
