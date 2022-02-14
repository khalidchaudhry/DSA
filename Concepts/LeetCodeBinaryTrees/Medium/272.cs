using Greedy;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _272
    {

        public static void _272Main()
        {
            //            [3,2,4,1]
            //           2.000000
            //            3
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(2);
            root.right = new TreeNode(4);
            root.left.left = new TreeNode(1);

            _272 test = new _272();
            test.ClosestKValues(root, 2.000000, 3);


        }
        public IList<int> ClosestKValues2(TreeNode root, double target, int k)
        {
            LinkedList<int> ll = new LinkedList<int>();
            InOrder(root, target, k, ll);
            List<int> result = new List<int>();
            while (ll.Count > 0)
            {
                result.Add(ll.First.Value);
                ll.RemoveFirst();
            }
            return result;
        }
        private void InOrder(TreeNode node, double target, int k, LinkedList<int> ll)
        {
            if (node == null)
            {
                return;
            }
            InOrder(node.left, target, k, ll);
            if (ll.Count == k)
            {
                double currNodeDiff = Math.Abs(node.val - target);
                double firstNodeDiff = Math.Abs(ll.First.Value - target);
                if (currNodeDiff < firstNodeDiff)
                {
                    ll.RemoveFirst();
                }
                else
                {
                    return;
                }
            }
            ll.AddLast(node.val);
            InOrder(node.right, target, k, ll);
        }
        /// <summary>
        //! O(nlogk) time
        //! O(nlogk) space
        /// </summary>
        public IList<int> ClosestKValues1(TreeNode root, double target, int k)
        {
            List<int> inorder = new List<int>();
            Inorder(root, inorder);
            var comparer = Comparer<(int val, double diff)>.Create((x, y) =>
            {
                //! Without below condition, it will increment the existing value. We need new value
                if (y.diff == x.diff)
                {
                    return x.val.CompareTo(y.val);
                }
                return y.diff.CompareTo(x.diff);
            });

            PQ<(int val, double diff)> pq = new PQ<(int val, double diff)>(comparer);

            for (int i = 0; i < inorder.Count; ++i)
            {
                double diff = Math.Abs(inorder[i] - target);
                pq.Add((inorder[i], diff));
                if (pq.Size > k)
                {
                    pq.Poll();
                }
            }

            List<int> result = new List<int>();
            while (pq.Size > 0)
            {
                result.Add(pq.Poll().val);
            }

            return result;
        }

        /// <summary>
        //! DO Tree traversal.Then sort array based on the distance 
        //! nlogn        
        /// </summary>
        public IList<int> ClosestKValues(TreeNode root, double target, int k)
        {
            List<int> inorder = new List<int>();
            Inorder(root, inorder);
            var comparer = Comparer<int>.Create((x, y) =>
            {
                return Math.Abs(x - target).CompareTo(Math.Abs(y - target));
            });
            inorder.Sort(comparer);
            List<int> result = new List<int>();
            for (int i = 0; i < k; ++i)
            {
                result.Add(inorder[i]);
            }
            return result;
        }
        private void Inorder(TreeNode node, List<int> inorder)
        {
            if (node == null)
            {
                return;
            }
            Inorder(node.left, inorder);
            inorder.Add(node.val);
            Inorder(node.right, inorder);
        }
    }

}
