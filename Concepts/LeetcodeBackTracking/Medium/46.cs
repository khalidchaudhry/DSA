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
            Permute0(nums, new List<int>(), result);
            return result;


        }

        private void Permute0(int[] nums, List<int> path, List<IList<int>> result)
        {
            if (path.Count == nums.Length)
            {
                result.Add(new List<int>(path));
                return;
            }

            for (int i = 0; i < nums.Length; ++i)
            {
                if (path.Contains(nums[i])) continue;
                path.Add(nums[i]);
                Permute0(nums, path, result);
                path.RemoveAt(path.Count - 1);
            }
        }

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
                Swap(nums,i,j);
                path.Add(nums[i]);
                Swap(nums, i, j);
                path.RemoveAt(path.Count-1);
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];

            nums[i] =nums[j];
            nums[j] = temp;
        }

       
    }
}
