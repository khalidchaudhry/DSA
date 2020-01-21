using LeetCodeBinaryTrees.Easy;
using System;

namespace LeetCodeBinaryTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            /****************Same Tree***********************************/
            // /*
            //        1
            //       / \
            //      2   3            

            //     1 
            //    / \
            //   2   3
            //*/


            // var p = new TreeNode(1);

            // p.left = new TreeNode(2);
            // //p.right = new TreeNode(3);


            // var q = new TreeNode(1);

            // //q.left = new TreeNode(2);
            // q.right = new TreeNode(2);

            // //_100 SameTree=new _100();

            // Console.WriteLine(SameTree.IsSameTree(p,q));

            /****************Balanced Binary Tree***********************************/

            ///*
            //        3
            //       / \
            //      9  20
            //     / \
            //    15  7                    

            //*/

            //var p = new TreeNode(3);
            //p.left = new TreeNode(9);
            //p.left.left = new TreeNode(15);
            //p.left.right = new TreeNode(7);

            //p.right = new TreeNode(20);

            /*

                1
               / \
              2   2
             / \
            3   3
            / \
            4   4

            */
            //var p = new TreeNode(1);

            //p.left = new TreeNode(2);
            //p.left.left = new TreeNode(3);
            //p.left.right = new TreeNode(3);
            //p.left.left.left = new TreeNode(4);
            //p.left.left.right = new TreeNode(4);                              

            //p.right = new TreeNode(2);

            //_110 IsBalanced = new _110();

            //Console.WriteLine(IsBalanced.IsBalanced(p));

            /****************Trim a Binary Search Tree***********************************/
            /*
              1
             / \
            0   2               
            */

            //var p = new TreeNode(1);
            //p.left = new TreeNode(0);
            //p.right = new TreeNode(2);


            /*
                     3
                    / \
                   0   4
                    \
                     2
                    /
                    1  

            */

            //var p = new TreeNode(3);
            //p.left = new TreeNode(0);
            //p.right = new TreeNode(4);

            //p.left.right= new TreeNode(2);

            //p.left.right.left = new TreeNode(1);

            //_669 TrimTree = new _669();
            //var val = TrimTree.TrimBST2(p, 1, 3);

            /****************************************938.Range Sum of BST**********************/
            /*
                     3
                    / \
                   0   4
                    \
                     2
                    /
                    1  
            */

            //var p = new TreeNode(3);
            //p.left = new TreeNode(0);
            //p.right = new TreeNode(4);

            //p.left.right = new TreeNode(2);

            //p.left.right.left = new TreeNode(1);

            //_938 rangeSumBST = new _938();
            //Console.WriteLine(rangeSumBST.RangeSumBST(p, 1, 3));                       

            /****************************************235. Lowest Common Ancestor of a Binary Search Tree**********************/
            /*
                     3
                    / \
                   0   4
                    \
                     2
                    /
                    1  
            */
            //TreeNode p = new TreeNode(2);
            //TreeNode q = new TreeNode(1);



            //var treeNode = new TreeNode(3);
            //treeNode.left =new TreeNode(0);
            //treeNode.right = new TreeNode(4);

            //treeNode.left.right = p;//new TreeNode(2);

            //treeNode.left.right.left = q;// new TreeNode(1);

            //_235 LCA = new _235();

            //var node=LCA.LowestCommonAncestor3(treeNode,p,q);


            /****************************************Print all root to the leaf paths**********************/
            /*
                     3
                    / \
                   0   4
                    \
                     2
                    /
                    1  
            */

            //var p = new TreeNode(3);
            //p.left = new TreeNode(0);
            //p.right = new TreeNode(4);

            //p.left.right = new TreeNode(2);

            //p.left.right.left = new TreeNode(1);

            //PrintAllPaths printAllPaths = new PrintAllPaths();

            //printAllPaths.PrintAllRootToLeafPaths(p);



            /****************************************112. Path Sum**********************/
            /*
                        3
                       / \
                      0   4
                       \
                        2
                       /
                       1  
            */

            var p = new TreeNode(3);
            p.left = new TreeNode(0);
            p.right = new TreeNode(4);

            p.left.right = new TreeNode(2);

            p.left.right.left = new TreeNode(1);

            _112 PathSum = new _112();
            Console.WriteLine(PathSum.HasPathSum(p,6));
            Console.ReadLine();

        }
    }
}


