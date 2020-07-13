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
