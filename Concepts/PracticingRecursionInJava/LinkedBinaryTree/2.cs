using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedBinaryTree
{
    public class _2
    {
        public int CountZeroNodes(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            int count = 0;
            if (root.data == 0)
            {
                ++count;
            }
            count += CountZeroNodes(root.left);
            count += CountZeroNodes(root.right);

            return count;
        }

    }
}
