using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    //! below implementation does not satisfy the requirement of question 
    //!uses O(n) memory, where n is the number of nodes in the tree.
    //Question asked to use O(h) memory, where h is the height of the tree.
    public class BSTIterator
    {

        Queue<TreeNode> queue = new Queue<TreeNode>();

        public BSTIterator(TreeNode root)
        {
            InOrderTraversal(root);
        }

        /** @return the next smallest number */
        public int Next()
        {
            if (queue.Count != 0)
            {
                TreeNode dequeue = queue.Dequeue();
                return dequeue.val;
            }

            return -1;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            if (queue.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void InOrderTraversal(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            InOrderTraversal(node.left);
            queue.Enqueue(node);
            InOrderTraversal(node.right);
        }
    }

    public class BSTIterator2
    {
        // Stack for the recursion simulation
        Stack<TreeNode> stk;

        public BSTIterator2(TreeNode root)
        {
            // Stack for the recursion simulation
            stk = new Stack<TreeNode>();
            // Remember that the algorithm starts with a call to the helper function
            // with the root node as the input
            LeftNodeInOrderTraversal(root);
        }

        /** @return the next smallest number */
        public int Next()
        {
            // Node at the top of the stack is the next smallest element
            TreeNode topMostNode = stk.Pop();
            //! Need to maintain the invariant.The stack top always contains the element to be returned for the next() function call 
            //! If the node has a right child, call the helper function for the right child
            if (topMostNode.right != null)
            {
                LeftNodeInOrderTraversal(topMostNode.right);
            }

            return topMostNode.val;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return stk.Count > 0;
        }

        private void LeftNodeInOrderTraversal(TreeNode node)
        {
            // For a given node, add all the elements in the leftmost branch of the tree
            // under it to the stack.
            while (node!=null)
            {
                this.stk.Push(node);
                node = node.left;
            }
        }
    }
}
