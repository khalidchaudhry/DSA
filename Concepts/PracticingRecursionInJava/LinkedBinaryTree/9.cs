using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedBinaryTree
{
    public class _9
    {
        public void PreOrder(Node root)
        {
            if (root == null)
            {
                return;
            }
            Console.Write(root.data);

            PreOrder(root.left);

            PreOrder(root.right);
        }

    }
}
