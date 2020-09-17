using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _236
    {

        public static void _236Main()
        {

            /*
                     3
                    / \
                   0   4
                    \
                     2
                    /
                    1  
            */
            TreeNode p = new TreeNode(2);
            TreeNode q = new TreeNode(1);



            var treeNode = new TreeNode(3);
            treeNode.left = new TreeNode(0);
            treeNode.right = new TreeNode(4);

            treeNode.left.right = p;//new TreeNode(2);

            treeNode.left.right.left = q;// new TreeNode(1);

            _236 LCA = new _236();

            var node = LCA.LowestCommonAncestor0(treeNode, p, q);
        }

        /// <summary>
        //! Post order traversal 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor0(TreeNode root, TreeNode p, TreeNode q)
        {

            ResultWrapper wrapper = new ResultWrapper();

            LowestCommonAncestor0(root, p, q, wrapper);

            return wrapper.LCA;

        }


        /// <summary>
        /// https://www.youtube.com/watch?v=py3R23aAPCA
        //! PreOrder traversal 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {

            //Our base cases. How our recursion stops. When we have an answer.
            //! 1.) If the node we are holding is null then we can't search...just return null 
            //! 2.) If we find either value return ourselves to the caller
            //Remember, we are "grabbing" / "holding" 'root' in this call.   

            if (root == null)
                return root;

            if (root == p || root == q)
            {
                return root;
            }

            //'root' doesn't satisfy any of our base cases.            
            //Search left and then search right.

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);
            //!If nothing turned up on the left, return whatever we got back on the right. 
            if (left == null)
                return right;
            //!If nothing turned up on the right, return whatever we got back on the left.
            if (right == null)
                return left;

            //!If we reach here that means we got something back on the left AND
            //!right...that means this node is the LCA...because our recursion returns from
            //!bottom to up...so we return what we hold...'root'
            return root;

        }

        /// <summary>
        // ! Iterative(Pre0rder traversal)
        /// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/solution/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
        {
            //Stack for tree traversal
            Stack<TreeNode> stk = new Stack<TreeNode>();
            // Storing parent pointers 
            Dictionary<TreeNode, TreeNode> parent = new Dictionary<TreeNode, TreeNode>();
            //!Ancestors for p including p itself because p can be a parent of itself
            HashSet<TreeNode> ancestors = new HashSet<TreeNode>();

            stk.Push(root);
            parent.Add(root, null);
            //! Iterate until we find both the nodes p and q
            while (!parent.ContainsKey(p) || !parent.ContainsKey(q))
            {
                TreeNode curr = stk.Pop();

                if (curr.left != null)
                {
                    stk.Push(curr.left);
                    parent.Add(curr.left, curr);
                }
                if (curr.right != null)
                {
                    stk.Push(curr.right);
                    parent.Add(curr.right, curr);
                }
            }
            //! Process all ancestors for node p using parent pointers.
            while (p != null)
            {
                //!Ancestors for p including p itself because p can be a parent of itself hence adding p
                ancestors.Add(p);
                p = parent[p];
            }
            // !The first ancestor of q which appears in
            // !p's ancestor set() is their lowest common ancestor.
            while (!ancestors.Contains(q))
            {
                q = parent[q];
            }

            return q;
        }
        private int LowestCommonAncestor0(TreeNode root, TreeNode p, TreeNode q, ResultWrapper wrapper)
        {
            if (root == null)
                return 0;

            int left = LowestCommonAncestor0(root.left, p, q, wrapper);
            int right = LowestCommonAncestor0(root.right, p, q, wrapper);

            int count = left + right;
            if (count == 2 || (count == 1 && root == p || root == q))
            {
                wrapper.LCA = root;
                return 1;
            }

            else if (root == p || root == q)
            {
                ++count;
            }

            return count;

        }

        

        public class ResultWrapper
        {
            public TreeNode LCA { get; set; }
        }


    }
}
