using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class PreorderToTree
    {
        // https://algorithms.tutorialhorizon.com/construct-binary-search-tree-from-a-given-preorder-traversal-using-stack-without-recursion/
        public Node ConstructTree(int[] preorder)
        {
            //      10
            //   /     \
            //  5       15
            // / \     /  \
            // 2  7   12  20

            Stack<Node> s = new Stack<Node>();
            //First element in the preorder[] will definitely be the root
            Node root = new Node(preorder[0]);
            s.Push(root);
            for (int i = 1; i < preorder.Length; i++)
            {
                Node x = null;
                //If ‘data’ is greater than the top item in the stack then 
                // keep popping out the nodes from the stack, keep storing it in temp node 
                //till the top node in stack is less than the ‘data’

                while (s.Count!=0 && preorder[i] > s.Peek().data)
                {
                    x = s.Pop();
                }
                if (x != null)
                {
                    //create a node with ‘data’ and 
                    //add it to the right of temp node and push the temp node to stack.
                    x.right = new Node(preorder[i]);
                    s.Push(x.right);
                }
                else
                {
                    // If ‘data’ is less than the top item in the stack 
                    //then create a node with ‘data’ and add it to the left of top node in stack and push it in the stack
                    s.Peek().left = new Node(preorder[i]);
                    s.Push(s.Peek().left);
                }
            }
            return root;
        }
    }
}
