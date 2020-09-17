using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Medium
{
    public class _46
    {
        public static void _46Main()
        {




        }
        public IList<IList<int>> Permute0(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            bool[] used = new bool[nums.Length];
            Permute0(nums, used, new List<int>(), result);
            return result;


        }
        /// <summary>
        ///https://www.youtube.com/watch?v=idmgLLNIC2U
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="path"></param>
        /// <param name="result"></param>
        private void Permute0(int[] nums, bool[] used, List<int> path, List<IList<int>> result)
        {
            if (path.Count == nums.Length)
            {
                result.Add(new List<int>(path));
                return;
            }

            for (int i = 0; i < nums.Length; ++i)
            {
                if (used[i]) continue;
                used[i] = true;
                path.Add(nums[i]);
                Permute0(nums, used, path, result);
                path.RemoveAt(path.Count - 1);
                used[i] = false;
            }
        }

        /// <summary>
        //! Sams byte by byte
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute1(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            Permute1(nums, 0, new List<int>(), result);

            return result;
        }

        private void Permute1(int[] nums, int i, List<int> path, List<IList<int>> result)
        {
            if (i == nums.Length)
            {
                result.Add(new List<int>(path));
            }

            for (int j = i; j < nums.Length; ++j)
            {
                Swap(nums, i, j);
                path.Add(nums[i]);
                Swap(nums, i, j);
                path.RemoveAt(path.Count - 1);
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];

            nums[i] = nums[j];
            nums[j] = temp;
        }


    }
}
