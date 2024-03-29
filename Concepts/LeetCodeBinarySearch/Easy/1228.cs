﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinarySearch.Easy
{
    public class _1228
    {

        public static void _1228Main()
        {
            _1228 Test = new _1228();
            int[] n = new int[] { 15, 13, 12 };
            var ans = Test.MissingNumber1(n);
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
            int diff = (arr[n-1] - arr[0]) / n;

            int nextNumber = arr[0];

           for (int i=0;i<arr.Length;++i)
            {
                if (nextNumber != arr[i])
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
            int lo = 0;
            int hi = n;
            while (lo + 1 < hi)
            {
                int mid = (lo + hi) / 2;
                if (OK(arr, mid, d))
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
        //!is the number at the given index at its  correct position? 
        /// </summary>

        private bool OK(int[] arr, int index, int d)
        {
            return arr[index] == arr[0] + d * index;
        }

    }
}
