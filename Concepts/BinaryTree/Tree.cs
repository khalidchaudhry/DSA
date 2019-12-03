using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
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
    }
}
