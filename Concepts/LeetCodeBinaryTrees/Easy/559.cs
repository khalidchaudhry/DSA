using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _559
    {
        public int MaxDepth(Node root)
        {
            if (root == null)
                return 0;

            int maxDepth = 0;
            foreach (var item in root.children)
            {
                if (item == null)
                {
                    ++maxDepth;
                }
            }
            return maxDepth + 1;
        }

        public int MaxDepth2(Node root)
        {
            if (root == null) { return 0; }

            int max = 0;

            if (root.children != null)
            {
                for (int i = 0; i < root.children.Count; i++)
                {
                    max = Math.Max(max, MaxDepth2(root.children[i]));
                }
            }

            return 1 + max;
        }
    }
    
}
