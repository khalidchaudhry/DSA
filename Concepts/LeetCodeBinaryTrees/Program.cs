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

            //var p = new TreeNode(3);
            //p.left = new TreeNode(0);
            //p.right = new TreeNode(4);

            //p.left.right = new TreeNode(2);

            //p.left.right.left = new TreeNode(1);

            //_112 PathSum = new _112();
            //Console.WriteLine(PathSum.HasPathSum(p,6));

            /****************************************Level Order line by line**********************/
            /*
                        3
                       / \
                      0   4
                       \
                        2
                       /
                       1  
            */

            // var p = new TreeNode(3);
            // p.left = new TreeNode(0);
            // p.right = new TreeNode(4);

            // p.left.right = new TreeNode(2);

            // p.left.right.left = new TreeNode(1);

            // LevelOrderLineByLine levelOrderLineByLine = new LevelOrderLineByLine();
            //levelOrderLineByLine.PrintLevelOrderLineByLine(p);

            /****************************************107. Binary Tree Level Order Traversal II**********************/
            /*
                        3
                       / \
                      9  20
                        /  \
                       15   7
            */

            //var p = new TreeNode(3);
            //p.left = new TreeNode(9);
            //p.right = new TreeNode(20);

            //p.right.left = new TreeNode(15);

            //p.right.right = new TreeNode(7);


            //_107 levelOrderTraversal = new _107();

            //levelOrderTraversal.LevelOrderBottom2(p);

            /****************************************257. Binary Tree Paths**********************/
            /*
                      1
                    /   \
                   2     3
                    \
                     5
            */

            //var p = new TreeNode(1);
            //p.left = new TreeNode(2);
            //p.right = new TreeNode(3);

            //p.left.right = new TreeNode(5);

            //_257 BinaryTreePaths = new _257();
            //BinaryTreePaths.BinaryTreePaths(p);


            /****************************************111. Minimum Depth of Binary Tree**********************/
            /*
                      1
                       \
                        3 
            */

            //var p = new TreeNode(1);
            //p.left = new TreeNode(3);

            //_111 minmumDepthOfTree = new _111();
            //minmumDepthOfTree.MinDepth(p);

            /****************************************653.Two Sum IV -Input is a BST**********************/
            /*

                5
               / \
              3   6
             / \   \
            2   4   7                                      
            */

            //var p = new TreeNode(5);
            //p.left = new TreeNode(3);
            //p.right = new TreeNode(6);

            //p.left.left= new TreeNode(2);
            //p.left.right = new TreeNode(4);

            //p.right.right = new TreeNode(7);

            //_653 TwoSum=new _653();

            //Console.Write(TwoSum.FindTarget(p, 100));

            /****************************************687. Longest Univalue Path**********************/
            /*
                  5
                 / \
                4   5
               / \   \
              1   1   5                                  

            */
            /*           
                  1
                 / \
                4   5
               / \   \
              4   4   5


            */

            //_687 longestUniValuePath = new _687();
            //var p = new TreeNode(5);
            //p.left = new TreeNode(4);
            //p.right = new TreeNode(5);

            //p.left.left = new TreeNode(1);
            //p.left.right = new TreeNode(1);

            //p.right.right = new TreeNode(5);

            //var p = new TreeNode(1);
            //p.left = new TreeNode(4);
            //p.right = new TreeNode(5);

            //p.left.left = new TreeNode(4);
            //p.left.right = new TreeNode(4);

            //p.right.right = new TreeNode(5);
            /*           
                  1
                 / \
                2   2
               / \   
              2  2 

            */

            //var p = new TreeNode(1);
            //p.left = new TreeNode(2);
            //p.right = new TreeNode(2);

            //p.left.left = new TreeNode(2);
            //p.left.right = new TreeNode(2);      

            //_687 longestUniValuePath = new _687();
            //Console.WriteLine(longestUniValuePath.LongestUnivaluePath2(p));
            /***************404.Sum of Left Leaves***************************/
            /*           
                   3
                  / \
                 9  20
                   / \
                  15  7
             */

            //var p = new TreeNode(3);
            //p.left = new TreeNode(9);
            //p.right = new TreeNode(20);

            //p.right.left = new TreeNode(15);
            //p.right.right = new TreeNode(7);
            //_404 leftLeafNodes = new _404();
            //Console.WriteLine(leftLeafNodes.SumOfLeftLeaves(p));
            /****************637.Average of Levels in Binary Tree********************/
            /*           
                   3
                  / \
                 9  20
                   / \
                  15  7
            */
            //var p = new TreeNode(3);
            //p.left = new TreeNode(9);
            //p.right = new TreeNode(20);

            //p.right.left = new TreeNode(15);
            //p.right.right = new TreeNode(7);
            //_637 averageLevels = new _637();

            //averageLevels.AverageOfLevels(p);

            /****************606. Construct String from Binary Tree********************/

            /*

                 1
               /   \
              2     3
             /    
            4                 
            */

            //var p = new TreeNode(1);
            //p.left = new TreeNode(2);
            //p.right = new TreeNode(3);

            //p.left.left = new TreeNode(4);

            //_606 StringFromBinaryTree = new _606();
            //Console.WriteLine(StringFromBinaryTree.Tree2str(p));

            /********501.Find Mode in Binary Search Tree**********************************/

            //_501 mode = new _501();
            //var p = new TreeNode(1);
            //p.right = new TreeNode(2);
            //p.right.left = new TreeNode(2);

            //var val = mode.FindMode(null);

            /********872.Leaf - Similar Trees************************************************/
            /*

               1
             /   \
            2     3
            /    
            4                 
            */

            //var p = new TreeNode(1);
            //p.left = new TreeNode(2);
            //p.right = new TreeNode(3);

            //p.left.left = new TreeNode(4);

            //_872 leafSimilar = new _872();

            //leafSimilar.LeafSimilar(p,p);

            /********897. Increasing Order Search Tree**********************************************/
            /*

                         5
                        / \
                       3    6
                      / \    \
                     2   4    8
                    /        / \ 
                   1        7   9

            */

            //var p = new TreeNode(5);
            //p.left = new TreeNode(3);
            //p.right = new TreeNode(6);

            //p.left.left = new TreeNode(2);
            //p.left.right = new TreeNode(4);

            //p.left.left.left = new TreeNode(1);

            //p.right.right = new TreeNode(8);
            //p.right.right.left = new TreeNode(7);
            //p.right.right.right = new TreeNode(9);

            //_897 IncreasingBST = new _897();
            //IncreasingBST.IncreasingBST(p);


            /********563.Binary Tree Tilt****************************/
            /*       
                         1
                       /   \
                      2     3
                     /     /
                    4     5
              
             */

            //var p = new TreeNode(1);
            //p.left = new TreeNode(2);
            //p.right = new TreeNode(3);

            //p.left.left = new TreeNode(4);

            //p.right.left = new TreeNode(5);

            //_563 Tilt = new _563();

            //Tilt.FindTilt(p);

            /********530. Minimum Absolute Difference in BST****************************/
            /*                        
               1
                \
                 3
                /
               2

             236
             /  \
           104  701
            \     \
             227  911
                
            */

            var p = new TreeNode(236);
            p.right = new TreeNode(701);
            p.left = new TreeNode(104);

            p.right.right = new TreeNode(911);

            p.left.right = new TreeNode(227);

            _530 MinimumAbsoluteDiff = new _530();
            MinimumAbsoluteDiff.GetMinimumDifference(p);


            Console.ReadLine();
        }
    }
}


