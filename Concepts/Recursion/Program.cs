using Recursion.ByteByByte.Module1;
using Recursion.ByteByByte.Module2;
using Recursion.ByteByByte.Module3;
using Recursion.ByteByByte.Module4;
using Recursion.ByteByByte.Module5;
using Recursion.GeeksForGeeks;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            //ByteByByteExamples b = new ByteByByteExamples();
            ////var arr = new int[5] {1,2,3,4,5 };
            ////b.CountEvenBuiltUp(arr);

            ////insert item at the bottom of the stack
            //Stack<int> s = new Stack<int>();
            //s.Push(1);
            //s.Push(2);
            //s.Push(3);
            //s.Push(4);
            //s.Push(5);

            //b.InsertItemAtStackBottom(s);

            //foreach (var one in s)
            //{
            //    Console.WriteLine($"{one} ");
            //}
            //int[] arr = new int[] {1,2};
            //var result=Combinations.CombinationsGlobal(arr);
            //var result = Combinations.CombinationsBuiltUp(arr);

            //GenerateAllSubstrings substrings = new GenerateAllSubstrings();

            //var result=substrings.IterativeTwoLoop("abcd");

            //var result = substrings.Recursive("abcd");

            //Homework homework = new Homework();
            //int[] arr = new int[] { 4, 6, 2, 8, 1, 11, 3 };
            //var result = homework.MinMax(arr);

            //Homework homework = new Homework();

            //int[][] arr = new int[][]
            //    {
            //        new int[]{1,2,3 },
            //        new int[]{4},
            //        new int[]{5,6},
            //    };

            //var result = homework.FlattenRecursive(arr);

            //Homework hm = new Homework();

            //hm.Substrings("abcd");

            //StairStep stairStep = new StairStep();
            //var result=stairStep.StairSteps(3);

            //var module3 = new ByteByByte.Module3.Homework();

            //bool[][] arr = new bool[3][]
            //{
            //  new bool[]{false,true,false,true},
            //  new bool[]{true,true,true,true},
            //  new bool[]{false,true,true,false }
            //};

            //var ans = module3.SquareSubmatrixRecursive(arr);
            //var module3 = new ByteByByte.Module3.Homework();

            //var result=module3.Moves(3);
            //foreach (Move move in result)
            //{
            //    Console.WriteLine(move);
            //}

            //LengthCombinations lengthCombinations = new LengthCombinations();
            //int[] n = new int[] {1, 2, 3 };
            //int targetLen = 2;
            //var result = lengthCombinations.CombinationOfLengthPassedVariable(n, targetLen);

            //InterleaveStrings interleave = new InterleaveStrings();
            //string s1 = "ab";
            //string s2 = "cd";
            //var ans=interleave.Interleave2(s1,s2);       

            //TargetSum targetSum = new TargetSum();

            //int[] nums = new int[]{1,2,3};
            //int target = 4;
            //var ans=targetSum.TagetSumPassedVariable(nums, target);

            //var KnapsackBuiltUp = new ByteByByte.Module4.Homework();

            //Item[] arr = new Item[4]
            //    {
            //        new Item(5,10),
            //        new Item(4,40),
            //        new Item(6,30),
            //        new Item(3,50)
            //    };

            //var ans=KnapsackBuiltUp.KnapsackBuiltUp(arr,10);


            //var Permutation = new Permutations();
            //int[] nums = new int[] { 1, 2, 3 };

            //var result=Permutation.PermutationsSimple(nums);           

            //var coinChange = new ByteByByte.Module4.Homework();
            //int[] coins = new int[] { 1, 5, 10, 25 };
            //var ans=coinChange.MakingChange2(coins, 49);

            //StringPermutation stringPermutation = new StringPermutation();
            //var result = stringPermutation.PermuteWithSwap("abc");

            //Permutations permutations = new Permutations();
            //int[] nums = new int[] { 1, 2, 3 };
            //var ans=permutations.PermutationWithSwap(nums);

            //PermutationLength permutationLength = new PermutationLength();

            //HashSet<int> items = new HashSet<int>() { 1, 2, 3 };
            //int[] items2 = new int[] { 1, 2, 3 };
            //int length = 2;
            //var result = permutationLength.PermutationOfSetLengthSwap(items2, length);

            //PermutationWithDuplicates permutationWithDuplicates = new PermutationWithDuplicates();
            //int[] items = new int[] { 1, 2,3,1 };
            //var ans = permutationWithDuplicates.PermutationsWithoutHashMap(items);

            //NDigitNumbers ndigitNumbers = new NDigitNumbers();

            //var result = ndigitNumbers.NDigitNumberSum(9, 10);
            //BSTArrays bstarrays = new BSTArrays();
            //TreeNode node = new TreeNode(2);
            //node.left = new TreeNode(1);
            //node.right = new TreeNode(3);
            //var result=bstarrays.AllBSTOrders(node);

            //ByteByByte.Module5.Homework arrayOfArrays = new ByteByByte.Module5.Homework();

            //int[][] arr = new int[3][] {
            //    new int[] {1,2},
            //    new int[]{3},
            //    new int[]{4,5 }
            //};
            //var result=arrayOfArrays.ArrayOfArrays(arr);
            //int[] arr = new int[3] { 3, 2, 1 };
            //ByteByByte.Module5.Homework SortedPermuation = new ByteByByte.Module5.Homework();
            //var result=SortedPermuation.SortedPermutations(arr);
            //ByteByByte.Module5.Homework SeatingChart = new ByteByByte.Module5.Homework();
            //Dictionary<int, int> map = new Dictionary<int, int>();
            //map.Add(1, 3);
            //map.Add(3, 1);
            //var result=SeatingChart.Arrangements(3, map);                       

            //StandfordCourse course = new StandfordCourse();
            //course.PrintAllBinary(2);
            int[][] arr = new int[3][] 
            {
                new int[] {1,2,3},
                new int[] {4},
                new int[] {5,6,7},
            };

            TraverseMatrix.TraverseMatrixWithRecursion(arr);

            Console.ReadLine();
        }
    }
}
