using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedBinaryTree
{
    class _8
    {

        public void TraverseInOrder(Node root)
        {
            if (root == null)
            {
                return;
            }

            TraverseInOrder(root.left);
            Console.WriteLine(root.data);
            TraverseInOrder(root.right);
        }

    }
}
