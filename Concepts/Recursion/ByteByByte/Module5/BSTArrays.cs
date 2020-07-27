using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module5
{
    public class BSTArrays
    {
        public List<List<int>> AllBSTOrders(TreeNode root)
        {
            List<List<int>> result = new List<List<int>>();
            HashSet<TreeNode> available = new HashSet<TreeNode>(new List<TreeNode>() { root });
            AllBSTOrders(available, new List<int>(), result);
            return result;
        }

        private void AllBSTOrders(HashSet<TreeNode> avaiable, List<int> path, List<List<int>> result)
        {
            if (avaiable.Count == 0)
            {
                result.Add(new List<int>(path));
            }

            foreach (TreeNode node in new HashSet<TreeNode>(avaiable))
            {
                avaiable.Remove(node);
                if (node.left != null) avaiable.Add(node.left);
                if (node.right != null) avaiable.Add(node.right);
                path.Add(node.val);
                AllBSTOrders(avaiable, path, result);
                path.RemoveAt(path.Count - 1);
                if (node.left != null) avaiable.Remove(node.left);
                if (node.right != null) avaiable.Remove(node.right);
                avaiable.Add(node);
            }
        }
    }
}
