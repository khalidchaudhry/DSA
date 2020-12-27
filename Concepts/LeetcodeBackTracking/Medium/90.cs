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
            var ans = DistinctSubSet.SubsetsWithDup0(nums);
            Console.ReadLine();
        }


        /// <summary>
        //https://leetcode.com/problems/subsets-ii/discuss/169226/Java-Two-Way-of-Recursive-thinking
        //https://youtu.be/0ElTC4XiDvc?t=150
        //! Top down approach... Building up results as we go from top to bottom
        // //  # <image url="$(SolutionDir)\Images\90.png"  scale="0.5"/>


        //   # <image url="$(SolutionDir)\Images\90.jpg"  scale="0.5"/>   
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>

        public IList<IList<int>> SubsetsWithDup0(int[] nums)
        {

            Array.Sort(nums);
            List<IList<int>> res = new List<IList<int>>();
            SubsetsWithDup0(nums, 0, new List<int>(), res);
            return res;
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

        private void SubsetsWithDup0(int[] nums, int index, List<int> path, List<IList<int>> res)
        {
            res.Add(new List<int>(path));

            for (int i = index; i < nums.Length; ++i)
            {
                //! Skip the same number at a certain depth
                if (i > index && nums[i - 1] == nums[i]) continue; 
                path.Add(nums[i]);
                SubsetsWithDup0(nums, i + 1, path, res);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
