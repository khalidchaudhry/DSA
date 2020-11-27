using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    public class _1228
    {

        public static void _1228Main()
        {
            _1228 Test = new _1228();
            int[] n = new int[] { 15, 13, 12 };
            Test.MissingNumber0(n);
            Console.ReadLine();
        }



        /// <summary>
        //! Brute force 
        /// </summary>
        public int MissingNumber(int[] arr)
        {
            int n = arr.Length;
            // https://www.techiedelight.com/find-missing-term-sequence-ologn-time/
            //(last element in sequence - first element in sequence)/ total elements in sequence
            int diff = Math.Abs(arr[0] - arr[n - 1]) / n;

            int nextNumber = arr[0];

            foreach (int number in arr)
            {
                if (nextNumber != number)
                    break;
                nextNumber += diff;
            }

            return nextNumber;
        }

        /// <summary>
        //! Based on template from Roger 
        //!Same pattern as in question 540
        /// </summary>
        public int MissingNumber1(int[] arr)
        {
            int n = arr.Length;
            int d = (arr[n - 1] - arr[0]) / n;
            int lo = -1;
            int hi = n - 1;
            while (lo + 1 < hi)
            {
                int mid = (lo + hi) / 2;
                if (OK(arr, mid, d))
                    //! When we want pattern like TTT'F' we need to invert. 
                    //! Usually we set one in OK  who is the potiential candidate (among lo and hi . One that is having valid value) 
                    lo = mid;
                else
                    hi = mid;
            }
            return arr[0] + d * hi;

        }

        /// <summary>
        //! using binary search
        //! similar to question 35
        //! https://www.youtube.com/watch?v=hw8pXjHcV2s
        /// </summary>
        public int MissingNumber0(int[] arr)
        {

            int n = arr.Length;
            int d = (arr[n - 1] - arr[0]) / n;
            int lo = 0;
            int hi = n - 1;
            while (lo <= hi)
            {
                int mid = (lo + hi) / 2;
                //! If mid  element is n/2 of the airthematic progression
                //! then missing element lies on right side 
                //! else on left side
                if (arr[mid] == arr[0] + d * mid)
                    lo = mid + 1;
                else
                    hi = mid - 1;
            }
            //! why returning lo why not hi. Because  lo is the potiential valid candidate based on == condition  
            return arr[0] + d * lo;

        }
       

        /// <summary>
        //!TTTT'F'FFFF
        /// </summary>

        private bool OK(int[] arr, int index, int d)
        {
            return arr[index] == arr[0] + d * index;
        }

    }
}
