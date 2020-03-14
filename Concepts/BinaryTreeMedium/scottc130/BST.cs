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
            if (key < current.Value)
            {
                current.Left = RemoveRec(current.Left, key);
            }
            else if (key > current.Value)
            {
                current.Right = RemoveRec(current.Right, key);
            }
            else
            {
                if (current.Left == null)
                {
                    return current.Right;
                }
                else if (current.Right == null)
                {
                    return current.Left;
                }

                current.Value = MinValue(current.Right);
                current.Right = RemoveRec(current.Right,current.Value);
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
