using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Medium
{
    public class PreOrderTraversal
    {
        /// <summary>
        //https://medium.com/leetcode-patterns/leetcode-pattern-1-bfs-dfs-25-of-the-problems-part-1-519450a84353  
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        // DFS magic : initialize stack and do the following 
        // pop top, retrieve neighbours for top, push unvisited neighbours to stack | repeat while stack not empty 
        // because this is a tree no need to keep track of visited as no cycles possible. 
        public List<int> PreOrderTraversalIterative(TreeNode root)
        {
            Stack<TreeNode> stk = new Stack<TreeNode>();
            List<int> result = new List<int>();
            stk.Push(root);

            while (stk.Count != 0)
            {
                // pop top 
                TreeNode curr = stk.Pop();

                if (curr != null) //! Pushing left/Right irrespective  they are null or not hence check  
                {
                    // push unvisited neighbours to stack | order matters here, if you reverse it 
                    // it would still be a DFS but a symmetric one to preorder out of the 6 possible combinations. 
                    stk.Push(curr.Right);
                    stk.Push(curr.Left);

                    result.Add(curr.Value);
                }
            }

            return result;
        }


    }
}
