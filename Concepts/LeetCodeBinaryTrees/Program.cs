using LeetCodeBinaryTrees.Easy;
using LeetCodeBinaryTrees.Medium;
using System;
using System.Collections.Generic;

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

            //_110._110Main();

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


            //_236._236Main();

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

            //_107._107Main();

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

            //var p = new TreeNode(236);
            //p.right = new TreeNode(701);
            //p.left = new TreeNode(104);

            //p.right.right = new TreeNode(911);

            //p.left.right = new TreeNode(227);

            //_530 MinimumAbsoluteDiff = new _530();
            //MinimumAbsoluteDiff.GetMinimumDifference(p);

            /********559. Maximum Depth of N-ary Tree****************************/
            //Node node2 = new Node(2);
            //Node node3 = new Node(3);
            //Node node4 = new Node(4);
            //Node node5 = new Node(5);
            //Node node6 = new Node(6);

            //Node root = new Node(1);
            //root.children = new List<Node>();
            //root.children.Add(node3);
            //root.children.Add(node2);
            //root.children.Add(node4);

            //node3.children = new List<Node>();
            //node3.children.Add(node5);
            //node3.children.Add(node6);


            //_559 maxDepth = new _559();

            //maxDepth.MaxDepth2(root);

            /********589. N-ary Tree Preorder Traversal********************/
            //Node node2 = new Node(2);
            //Node node3 = new Node(3);
            //Node node4 = new Node(4);
            //Node node5 = new Node(5);
            //Node node6 = new Node(6);

            //Node root = new Node(1);
            //root.children = new List<Node>();
            //root.children.Add(node3);
            //root.children.Add(node2);
            //root.children.Add(node4);

            //node3.children = new List<Node>();
            //node3.children.Add(node5);
            //node3.children.Add(node6);

            //_589 PreOrder = new _589();

            //PreOrder.Preorder2(root);

            /********270.Closest Binary Search Tree Value********************/

            //_270 CBSTV = new _270();

            /*

                 4
                / \
               2   5
              / \
             1   3                        
             */

            //var p = new TreeNode(4);

            //p.left = new TreeNode(2);

            //p.right = new TreeNode(5);

            //p.left.left = new TreeNode(1);
            //p.left.right = new TreeNode(3);


            //double target = 3.714286;


            //Console.WriteLine(CBSTV.ClosestValue2(p,target));

            /********783. Minimum Distance Between BST Nodes********************/
            /*

               4
              / \
             2   6
            / \
            1   3                        
            */

            //var p = new TreeNode(4);

            //p.left = new TreeNode(2);

            //p.right = new TreeNode(6);

            //p.left.left = new TreeNode(1);
            //p.left.right = new TreeNode(3);

            //_783 MinDiff = new _783();

            //MinDiff.MinDiffInBST(p);

            /********700.Search in a Binary Search Tree****************/
            /*

             4
            / \
            2   7
            / \
            1   3                        
            */

            //var p = new TreeNode(4);

            //p.left = new TreeNode(2);

            //p.right = new TreeNode(7);

            //p.left.left = new TreeNode(1);
            //p.left.right = new TreeNode(3);
            /*
                2
               / \
              1   3                                  
            */


            //_700 SearchBST = new _700();

            //var p = new TreeNode(2);

            //p.left = new TreeNode(1);

            //p.right = new TreeNode(3);

            //var val =SearchBST.SearchBST(p, 5);
            /*
                  2
                 / \
                2   5
                   / \
                  5   7                                  
            */
            //var p = new TreeNode(2);

            //p.left = new TreeNode(2);

            //p.right = new TreeNode(5);

            //p.right.left = new TreeNode(5);
            //p.right.right = new TreeNode(7);


            /*
                 2
                / \
               2   2

            */

            //var p = new TreeNode(2);

            //p.left = new TreeNode(2);

            //p.right = new TreeNode(2147483647);

            //_671 SecondMin =new _671();
            //SecondMin.FindSecondMinimumValue(p);

            /********590.N - ary Tree Postorder Traversal**********************/
            //Node node2 = new Node(2);
            //Node node3 = new Node(3);
            //Node node4 = new Node(4);
            //Node node5 = new Node(5);
            //Node node6 = new Node(6);

            //Node root = new Node(1);
            //root.children = new List<Node>();
            //root.children.Add(node3);
            //root.children.Add(node2);
            //root.children.Add(node4);

            //node3.children = new List<Node>();
            //node3.children.Add(node5);
            //node3.children.Add(node6);

            //_590 PostOrderTraversal = new _590();
            //PostOrderTraversal.Postorder(root);
            /*
                    3
                   / \
                  4   5
                 / \
                1   2
               /
              0

                 4 
                / \
               1   2


            */
            //var t = new TreeNode(3);

            //t.left = new TreeNode(4);
            //t.left.left = new TreeNode(1);
            //t.left.left.left = new TreeNode(0);
            //t.left.right = new TreeNode(2);
            ////t.left.right.left = new TreeNode(0);

            //t.right = new TreeNode(5);

            //var t2 = new TreeNode(4);
            //t2.left = new TreeNode(1);
            //t2.right = new TreeNode(2);
            //_572 treeSubset = new _572();
            //var ans=treeSubset.IsSubtree1(t, t2);

            //_96 UniqueBinarySearchTree = new _96();
            //UniqueBinarySearchTree.NumTrees(3);

            //var root = new TreeNode(7);

            //root.left = new TreeNode(3);

            //root.right = new TreeNode(15);
            //root.right.left = new TreeNode(9);
            //root.right.right = new TreeNode(20);

            //BSTIterator iterator = new BSTIterator(root);

            //iterator.Next();    // return 3
            //iterator.Next();    // return 7
            //iterator.HasNext(); // return true
            //iterator.Next();    // return 9
            //iterator.HasNext(); // return true
            //iterator.Next();    // return 15
            //iterator.HasNext(); // return true
            //iterator.HasNext();    // return 20
            //iterator.HasNext(); // return false

            //_105 ConstructBinaryTree = new _105();
            //int[] preOrder = new int[] { 3, 9, 20, 15, 7 };
            //int[] inOrder = new int[] { 9, 3, 15, 20, 7 };

            //var ans=ConstructBinaryTree.BuildTree(preOrder,inOrder);

            //_894 FBT = new _894();
            //var result=FBT.allPossibleFBT(3);

            //_654 MaxBinaryTree = new _654();

            //int[] nums = new int[]{};

            //var ans=MaxBinaryTree.ConstructMaximumBinaryTree(nums);

            //var t = new TreeNode(3);
            //var five = new TreeNode(5);
            //var one = new TreeNode(1);


            //t.left = five;
            //t.left.left = new TreeNode(6);
            //t.left.right = new TreeNode(2);
            //t.left.right.left = new TreeNode(7);
            //t.left.right.right = new TreeNode(4);
            //t.right= one;
            //t.right.left = new TreeNode(0);
            //t.right.right = new TreeNode(8);
            //////t.left.right.left = new TreeNode(0);

            //_236 LCA = new _236();

            //LCA.LowestCommonAncestor2(t,five,one);

            //_199._199Main();


            //_250._250Main();

            //_1522._1522Main();

            // _545._545Main();

            //_314._314Main();

            //_993._993Main();

            //_450._450Main();

            _701._701Main();
            Console.ReadLine();
        }
    }
}


