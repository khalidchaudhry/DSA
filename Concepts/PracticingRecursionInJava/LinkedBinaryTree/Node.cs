using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedBinaryTree
{
    public class Node
    {
        public int data;
        public Node left, right;
        public Node(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }
    }
}
