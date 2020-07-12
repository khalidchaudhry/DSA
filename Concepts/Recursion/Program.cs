using Recursion.ByteByByte.Module1;
using Recursion.ByteByByte.Module2;
using Recursion.ByteByByte.Module3;
using Recursion.ByteByByte.Module4;
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
            //int[] arr = new int[] {1,2,3 };
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
            //int[] n = new int[] { 0, 1, 2, 3 };
            //int targetLen = 2;
            //var result=lengthCombinations.CombinationOfLengthBuildUp(n, targetLen);

            //InterleaveStrings interleave = new InterleaveStrings();
            //string s1 = "ab";
            //string s2 = "cd";
            //var ans=interleave.Interleave2(s1,s2);       

            TargetSum targetSum = new TargetSum();

            int[] nums = new int[]{1,2,3};
            int target = 4;
            var ans=targetSum.TagetSumPassedVariable(nums, target);
            
            Console.ReadLine();
        }
    }
}
