using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Medium
{
    public class _216
    {
        public static void _216Main()
        {

            _216 CombinationSum = new _216();
            int k = 3;
            int n = 7;

            var result = CombinationSum.CombinationSum3(k, n);

            Console.ReadLine();

        }

        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            int[] nums = new int[9];
            for (int i = 0; i < 9; ++i)
            {
                nums[i] = i + 1;
            }

            List<IList<int>> result = new List<IList<int>>();

            CombinationSum3(nums, 0, k, n, new List<int>(), result);

            return result;
        }

        private void CombinationSum3(int[] nums, int start, int targetLen, int targetSum, List<int> path, List<IList<int>> result)
        {
            if (targetSum < 0) return;
            if (targetSum == 0 && path.Count != targetLen) return;
            if (targetSum == 0)
            {
                result.Add(new List<int>(path));
            }

            for (int j = start; j < nums.Length; ++j)
            {
                path.Add(nums[j]);
                CombinationSum3(nums, j + 1, targetLen, targetSum - nums[j], path, result);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
