using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedBinaryTree
{
    public class _1
    {
        public int CountNodes(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            int left = CountNodes(root.left);
            int right = CountNodes(root.right);
            //1 for the current node we are on. 
            return 1 + left + right;
        }

    }
}
