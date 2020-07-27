using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    public class _437
    {

        public static void _437Main()
        {



        }

        //https://www.youtube.com/watch?v=x87RihNvRaY
        public int PathSum(TreeNode root, int sum)
        {
            List<int> path = new List<int>();
            ResultWrapper wrapper = new ResultWrapper();
            PathSum(root, sum, path, wrapper);
            return wrapper.Count;
        }

        private void PathSum(TreeNode root, int sum, List<int> path, ResultWrapper wrapper)
        {
            if (root == null)
                return;

            path.Add(root.val);

            PathSum(root.left, sum, path, wrapper);
            PathSum(root.right, sum, path, wrapper);

            int currentSum = 0;

            for (int i = path.Count - 1; i >= 0; --i)
            {
                currentSum += path[i];

                if (currentSum == sum)
                {
                    ++wrapper.Count;
                }
            }
            path.RemoveAt(path.Count - 1);
        }



        //! My effort for solving it. The issue is that once once i take a path , i don't consider it but we have to consider it again 

        public int PathSum2(TreeNode root, int sum)
        {

            ResultWrapper wrapper = new ResultWrapper();
            PathSum2(root, sum, 0, wrapper);


            return wrapper.Count;
        }

        private void PathSum2(TreeNode node, int target, int parentVal, ResultWrapper wrapper)
        {
            if (node == null)
                return;

            int sum = parentVal + node.val;

            int passedValue;

            if (sum == target)
            {
                ++wrapper.Count;
                passedValue = 0;
            }
            else if (sum > target)
            {
                passedValue = 0;
            }
            else
            {
                passedValue = sum;
            }

            PathSum2(node.left, target, passedValue, wrapper);
            PathSum2(node.right, target, passedValue, wrapper);
        }

        public class ResultWrapper
        {
            public int Count { get; set; }

        }
    }


}
