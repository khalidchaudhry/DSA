using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module6
{
    public class BSTArrays
    {
        public List<List<int>> AllBSTOrders(Node root)
        {
            if (root == null)
            {
                List<List<int>> toReturn = new List<List<int>>();
                toReturn.Add(new List<int>());
                return toReturn;
            }
            List<List<int>> left = AllBSTOrders(root.left);
            List<List<int>> right = AllBSTOrders(root.right);
            List<List<int>> merged = MergeAll(left, right);
            foreach (List<int> l in merged)
            {
                l.Insert(0, root.val);
            }
            return merged;
        }
        // For each pair of left and right, find every interleaving
        private List<List<int>> MergeAll(List<List<int>> first,
                                                  List<List<int>> second)
        {
            List<List<int>> result = new List<List<int>>();
            foreach (List<int> f in first)
            {
                foreach (List<int> s in second)
                {
                    Merge(f, s, 0, 0, new List<int>(), result);
                }
            }
            return result;
        }

        private void Merge(List<int> first, List<int> second,
                                                 int i, int j, List<int> path,
                                                 List<List<int>> result)
        {
            if (i == first.Count && j == second.Count)
            {
                result.Add(new List<int>(path));
                return;
            }

            if (i != first.Count)
            {
                path.Add(first[i]);
                Merge(first, second, i + 1, j, path, result);
                path.Remove(path.Count - 1);
            }

            if (j != second.Count)
            {
                path.Add(second[j]);
                Merge(first, second, i, j + 1, path, result);
                path.Remove(path.Count - 1);
            }
        }

    }
}
