using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    public class _501
    {
        public int[] FindMode(TreeNode root)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            PreOrderTraversal(root, dict);

            var sortedDictionary=dict.OrderByDescending(x=>x.Value);
            int mode = sortedDictionary.FirstOrDefault().Value;

            return dict.Where(x => x.Value == mode).Select(x => x.Key).ToArray();

        }

        private void PreOrderTraversal(TreeNode node, Dictionary<int, int> dict)
        {
            if (node == null)
                return;
            if (dict.ContainsKey(node.val))
            {
                dict[node.val]++;
            }
            else
            {
                dict.Add(node.val,1);
            }

            PreOrderTraversal(node.left,dict);
            PreOrderTraversal(node.right, dict);
        }

    }
}
