using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _894
    {

        /// <summary>
        /// https://leetcode.com/problems/all-possible-full-binary-trees/discuss/216853/Java%3A-Easy-with-Examples
        /// https://leetcode.com/problems/all-possible-full-binary-trees/discuss/167402/c%2B%2B-c-java-and-pything-recursive-and-iterative-solutions.-Doesn't-create-Frankenstein-trees
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public IList<TreeNode> AllPossibleFBT(int N)
        {
            // Recursive: build all possible FBT of leftSubTree and rightSubTree with number n
            //! For starters a full BST must have an odd number of nodes. So any even N is trivial empty return.
            if (N <= 0 || N % 2 == 0) return new List<TreeNode>();

            //1. if N = 3 , the number of nodes combination are as follows
            //      left    root    right
            //       1       1        1 
            //--------------N = 3, res = 1----------

            //2. if N = 5 , the number of nodes combination are as follows
            //      left    root    right
            //       1       1        3 (recursion)
            //       3       1        1 
            //  --------------N = 5, res = 1 + 1 = 2----------

            //3. if N = 7 , the number of nodes combination are as follows
            //      left    root    right
            //       1       1        5 (recursion)
            //       3       1        3 
            //       5       1        1
            //  --------------N = 7, res = 2 + 1 + 2 = 5----------

           
            List<TreeNode> res = new List<TreeNode>();
            if (N == 1)
            {
                res.Add(new TreeNode(0));
                return res;
            }
            //4. in order to make full binary tree, the node number must increase by 2
            for (int i = 1; i < N; i += 2)
            {
                IList<TreeNode> leftSubTrees = AllPossibleFBT(i);
                IList<TreeNode> rightSubTrees = AllPossibleFBT(N - i - 1);
                foreach (TreeNode l in leftSubTrees)
                {
                    foreach (TreeNode r in rightSubTrees)
                    {
                        TreeNode root = new TreeNode(0);
                        root.left = l;
                        root.right = r;
                        res.Add(root);
                    }
                }
            }
            return res;
        }


    }
}
