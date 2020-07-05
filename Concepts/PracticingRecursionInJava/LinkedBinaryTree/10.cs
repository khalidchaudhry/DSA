using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedBinaryTree
{
    public class _10
    {
        public void PostOrder(Node root)
        {
            if (root == null)
            {
                return;
            }

            PostOrder(root.left);

            PostOrder(root.right);

            Console.Write(root);

        }


    }
}
