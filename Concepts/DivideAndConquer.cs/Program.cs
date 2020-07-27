using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideAndConquer.cs
{
    /// <summary>
    /// https://medium.com/techie-delight/divide-and-conquer-interview-questions-and-practice-problems-8855e45f4200
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            //Console.WriteLine("Hello World!");
            //Console.ReadKey();

            //CiruclarSortedArrayRotations rotations = new CiruclarSortedArrayRotations();
            //int[] arr = new int[] { 8, 9, 10, 2, 5, 6 };
            //var result=rotations.CircularRotations(arr);

            //FirstAndLastOccurance SelectRange = new FirstAndLastOccurance();

            //int[] arr = new int[] { 8};
            //int target = 8;
            //var result=SelectRange.SearchRange(arr,target);

            //SearchInSortedRotatedArray Search = new SearchInSortedRotatedArray();
            //int[] nums = new int[] {4,5,6,7,0,1,2 };
            //var result=Search.Search(nums,6);

            //FirstSmallestMissingElement SmallestMissing = new FirstSmallestMissingElement();
            //int[] arr = new int[] { 0, 1, 2, 6, 9, 11, 15};
            //var ans=SmallestMissing.FirstMissing(arr);

            ////NumberOccurances occurances = new NumberOccurances();
            ////int[] arr = new int[] { 2, 5, 5, 6, 6, 8, 9, 9, 9 };
            ////int target = 7;
            ////var result=occurances.DuplicateNumberOccurrances(arr,target);

            //FloorAndCeiling floorAndCeiling = new FloorAndCeiling();
            //int[] arr = new int[] { 1, 4, 6, 8, 9 };
            //foreach (int i in new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })
            //{
            //    var ans = floorAndCeiling.FloorAndCeil(arr, i);
            //    Console.WriteLine(string.Join(",", ans));
            //}

            PeekElement peekElement = new PeekElement();
            int[] arr = new int[] { 10,8,6,5,3,2 };
            var ans = peekElement.FindPeekElement(arr);

            Console.ReadLine();
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
