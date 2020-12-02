using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _930
    {



        public static void _930Main()
        {
            int[] arr = new int[5] { 0,0,0,0,0 };

            _930 Test = new _930();
            var result=Test.NumSubarraysWithSum(arr,0);
            Console.ReadLine();
        }
        
        /// <summary>
        //! Same  pattern as in 930,1248,560
        /// </summary>
        public int NumSubarraysWithSum(int[] A, int S)
        {
            int numSubArrayWithSum = 0;
            //! Key is the sum and 
            //! value is the number of subarrays that have that that sum
            //! e.g. 3:1 means that there is one subarray having sum of 3 in it
            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(0, 1);
            int currSum = 0;
            for (int i = 0; i < A.Length; ++i)
            {
                currSum += A[i];

                if (map.ContainsKey(currSum - S))
                {
                    numSubArrayWithSum += map[currSum - S];
                }

                if (!map.ContainsKey(currSum))
                {
                    map.Add(currSum, 0);
                }
                ++map[currSum];

            }


            return numSubArrayWithSum;
        }



    }
}
