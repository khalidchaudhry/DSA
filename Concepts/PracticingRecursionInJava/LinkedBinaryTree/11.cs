using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedBinaryTree
{
    public class _11
    {
        public void IncrementByOne(Node root)
        {
            if (root == null)
            {
                return;
            }

            ++root.data;

            IncrementByOne(root.left);
            IncrementByOne(root.right);

        }

    }
}
