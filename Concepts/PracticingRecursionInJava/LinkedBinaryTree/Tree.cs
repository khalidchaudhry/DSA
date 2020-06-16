using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedBinaryTree
{
    public class Tree
    {
        public Node root;

        public static Tree CreateSimpleTree()
        {
            var t = new Tree();
            t.root = new Node(1);
            t.root.left = new Node(2);
            t.root.right = new Node(3);
            t.root.right.left = new Node(4);
            return t;
        }

        // 1
       // /\
      // 0  3
      //   /
      //  0
        public static Tree CreateSimpleTree2()
        {
            var t = new Tree();
            t.root = new Node(1);
            t.root.left = new Node(0);
            t.root.right = new Node(3);
            t.root.right.left = new Node(0);
            return t;
        }
    }
}
