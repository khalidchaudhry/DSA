using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Medium
{
    public class _90
    {
        public static void _90Main()
        {
            _90 DistinctSubSet = new _90();
            int[] nums = new int[] { 1, 2, 2 };
            var ans = DistinctSubSet.SubsetsWithDup(nums);
            Console.ReadLine();
        }
        /// <summary>
        //https://leetcode.com/problems/subsets-ii/discuss/169226/Java-Two-Way-of-Recursive-thinking
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {

            Array.Sort(nums);
            List<IList<int>> res = new List<IList<int>>();
            SubsetsWithDup(nums, 0, false, new List<int>(), res);
            return res;
        }
        /// <summary>
        //https://leetcode.com/problems/subsets-ii/discuss/169226/Java-Two-Way-of-Recursive-thinking
        //! Top down approach... Building up results as we go from top to botton
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>

        public IList<IList<int>> SubsetsWithDup2(int[] nums)
        {

            Array.Sort(nums);
            List<IList<int>> res = new List<IList<int>>();
            SubsetsWithDup2(nums, 0, new List<int>(), res);
            return res;
        }

        private void SubsetsWithDup(int[] nums, int i, bool choosePre, List<int> path, List<IList<int>> result)
        {
            if (i == nums.Length)
            {
                result.Add(new List<int>(path));
                return;
            }

            //!exclude           
            SubsetsWithDup(nums, i + 1, false, path, result);

            if (i >= 1 && nums[i] == nums[i - 1] && !choosePre) return;

            //! include
            path.Add(nums[i]);
            SubsetsWithDup(nums, i + 1, true, path, result);
            path.RemoveAt(path.Count - 1);
        }

        private void SubsetsWithDup2(int[] nums, int i, List<int> path, List<IList<int>> res)
        {
            res.Add(new List<int>(path));

            for (int j = i; j < nums.Length; ++j)
            {
                if (j > i && nums[j - 1] == nums[j]) continue;
                path.Add(nums[j]);
                SubsetsWithDup2(nums, j + 1, path, res);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
