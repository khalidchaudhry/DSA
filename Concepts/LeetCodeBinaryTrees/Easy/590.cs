using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _590
    {
        /// <summary>
        //! Post order is the reverse of preorder traversal 
        //! We need to do just pre order traversal and then reverse it
        //! PrOrder=RootleftRight    PostOrder=LeftRightRoot 
        //!1. Reverse the part after Root= Root|RightLeft
        //!2. Reverse what got from above step=LeftRightRoot
        /// </summary>
        public List<int> postorder(Node root)
        {
            List<int> list = new List<int>();
            if (root == null) return list;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count!=0)
            {
                root = stack.Pop();
                list.Add(root.val);
                //!To get post order from preorder we need to process right node first than left. Stack  helps us do it as right node will be the top of stack
                foreach (Node node in root.children)
                {
                    stack.Push(node);
                }
            }
            list.Reverse();
            return list;
        }
        public IList<int> Postorder(Node root)
        {
            List<int> postOrder = new List<int>();

            PostOrderHelper(root, postOrder);

            return postOrder;
        }
        private void PostOrderHelper(Node node, List<int> postOrder)
        {
            if (node != null)
            {
                if (node.children != null)
                {
                    foreach (var child in node.children)
                    {
                        PostOrderHelper(child, postOrder);
                    }
                }
                postOrder.Add(node.val);
            }

        }

    }
}
