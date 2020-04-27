using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinaryTrees.Easy
{
    public class _572
    {
        /// <summary>
        /// https://leetcode.com/problems/subtree-of-another-tree/discuss/102760/Easy-O(n)-java-solution-using-preorder-traversal
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSubtree2(TreeNode s, TreeNode t)
        {
            if (s == null || t == null)
            {
                return false;
            }

            string sPreOrder = GeneratePreOrderString(s);
            string tPreOrder = GeneratePreOrderString(t);
            return sPreOrder.Contains(tPreOrder);

        }

        private string GeneratePreOrderString(TreeNode root)
        {
            StringBuilder sb = new StringBuilder();
            Stack<TreeNode> stk = new Stack<TreeNode>();
            stk.Push(root);
            while (stk.Count != 0)
            {
                TreeNode poppedItem = stk.Pop();
                if (poppedItem == null)
                {
                    sb.Append(",#"); //// Appending # inorder to handle same values but not subtree cases
                }
                else
                {
                    sb.Append(",");
                    sb.Append($"{poppedItem.val}");

                    stk.Push(poppedItem.right);
                    stk.Push(poppedItem.left);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        //! Using preorder tranversal 
        //Rather than assuming a null value for the childern of the leaf nodes, 
        //!we need to treat the left and right child as a lnull and rnull value respectively
        // !This is done to ensure that the t preOrder doesn't become a substring of s preorder 
        // !even in cases when t isn't a subtree of s.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSubtree1(TreeNode s, TreeNode t)
        {
            if (s == null || t == null)
            {
                return false;
            }

            StringBuilder sSb = new StringBuilder();
            StringBuilder tSb = new StringBuilder();
            PreOrderTraversal(s, sSb);
            PreOrderTraversal(t, tSb);
            return sSb.ToString().Contains(tSb.ToString());

        }

        private void PreOrderTraversal(TreeNode s, StringBuilder sb)
        {
            if (s == null)
            {
                // Without adding null , it will fail for below input 
                //! s=[1,2,3] t=[2,3]
                //! just using null rather than lnull or nuull should also work. 
                // Leet code comment mentioned that it will fail for below however its not the case
                //! s[3,4,5,1,2, null,null, 0] t=[4,1,2]
                sb.Append("null");
               
                return;
            }
            //the trees of the form s:[23, 4, 5] and t:[3, 4, 5] will also give a true result 
            //since the preorder string of the t("23 4 lnull rull 5 lnull rnull") 
            //will be a substring of the preorder string of s("3 4 lnull rull 5 lnull rnull").
            //Adding a '#' before the node's value solves this problem.

            sb.Append("#");
            sb.Append(s.val);
            PreOrderTraversal(s.left, sb);
            PreOrderTraversal(s.right, sb);

        }

        
        
        
        
        
        
        
        
        
        
        
        
        //!  Does not work for below input
        // [3,4,5,1,2,null,null,0]
        // [4,1,2]
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            // In order Traversal 
            List<int> sNodes = new List<int>();
            List<int> tNodes = new List<int>();
            InOrderTraversal(s, sNodes);
            InOrderTraversal(t, tNodes);

            int index = sNodes.LastIndexOf(tNodes.First());

            if (index == -1)
            {
                return false;
            }
            else
            {
                List<int> lst = sNodes.GetRange(index, tNodes.Count);

                if (lst.SequenceEqual(tNodes))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        private void InOrderTraversal(TreeNode s, List<int> nodesList)
        {
            if (s == null)
            {
                //nodesList.Add(int.MaxValue);
                return;
            }

            InOrderTraversal(s.left, nodesList);
            nodesList.Add(s.val);
            InOrderTraversal(s.right, nodesList);
        }


    }
}
