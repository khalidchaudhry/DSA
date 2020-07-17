using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module5
{
    public class Permutations
    {
        public List<List<int>> PermutationsSimple(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();
            HashSet<int> items = new HashSet<int>(nums);
            PermutationsSimple(items, result, new List<int>());
            return result;
        }

        public List<List<int>> PermutationWithSwap(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();
            PermutationWithSwap(nums, 0, new List<int>(), result);
            return result;

        }
        private void PermutationWithSwap(int[] nums, int i, List<int> path, List<List<int>> result)
        {
            if (i == nums.Length)
            {
                result.Add(new List<int>(path));
            }

            for (int j = i; j < nums.Length; j++)
            {
                Swap(nums, i, j);
                path.Add(nums[i]);
                PermutationWithSwap(nums, i + 1, path, result);
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

        private void PermutationsSimple(
            HashSet<int> items,
            List<List<int>> result,
            List<int> path
            )
        {
            if (items.Count == 0)
            {
                result.Add(new List<int>(path));
                return;
            }
            foreach (int item in new HashSet<int>(items))
            {
                items.Remove(item);
                path.Add(item);
                PermutationsSimple(items, result, path);
                items.Add(item);
                path.RemoveAt(path.Count - 1);
            }
        }
    }


}
