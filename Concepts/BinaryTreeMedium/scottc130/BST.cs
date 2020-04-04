using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeMedium.scottc130
{
    public class BST
    {
        TreeNode root;

        public void Insert(int key)
        {
            this.root = InsertRec(this.root, key);
        }

        private TreeNode InsertRec(TreeNode currentNode, int key)
        {
            /*
            If the current node we are at is not null, we move down the left or right of the tree, 
            updating on each recursive call. Once we reach a null value, or a value that is equal to 
            what we wish to insert, we move up the recursive stack, updating as we go, 
            ending with a fully updated tree with the new node inserted.        
           */
            if (currentNode == null)
            {
                currentNode = new TreeNode(null, null, key);
                return currentNode;
            }
            else
            {
                if (key < currentNode.Value)
                {
                    currentNode.Left = InsertRec(currentNode.Left, key);
                }
                else if (key > currentNode.Value)
                {
                    currentNode.Right = InsertRec(currentNode.Right, key);
                }
            }

            return currentNode;
        }

        public void Remove(int key)
        {
            RemoveRec(this.root, key);
        }
        private TreeNode RemoveRec(TreeNode current, int key)
        {
            if (current == null)
                return current;
            // We need to first locate the value we wish to remove inside of the tree.
            // We do this by starting at the root and moving left or right 
            // depending on if the current value is smaller or larger than the value we want.

            if (key < current.Value)
            {
                current.Left = RemoveRec(current.Left, key);
            }
            else if (key > current.Value)
            {
                current.Right = RemoveRec(current.Right, key);
            }
            // Once we find the value, we remove it from the tree, updating all the previous nodes through recursion.
            // Doing so will give us an updated tree with the targeted node removed.
            else
            {
                // When  the node has only one value linked to it, the remove is easy. 
                // We simply replace with the value that exists, either the left or right.
                if (current.Left == null)
                {
                    return current.Right;
                }
                else if (current.Right == null)
                {
                    return current.Left;
                }
                // If there is both a left and right, 
                // then we need to find the smallest node that exists to the right of the node we want to remove
                current.Value = MinValue(current.Right);
                // Recursively call the function to update the right-hand side to link based 
                // on the smallest value that succeeds the one being removed. 
                current.Right = RemoveRec(current.Right, current.Value);
            }

            return current;
        }

        private int MinValue(TreeNode current)
        {
            int minValue = current.Value;

            while (current.Left != null)
            {
                minValue = current.Left.Value;
                current = current.Left;
            }
            return minValue;
        }
    }
}
