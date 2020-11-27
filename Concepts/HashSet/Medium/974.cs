using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeHashTable.Medium
{
    public class _974
    {


        public static void _974Main()
        {

            var test = new _974();
            int[] A = new int[] { 4, 5, 0, -2, -3, 1 };
            var ans = test.subarraysDivByK(A, 5);
            Console.ReadLine();

        }

        /// <summary>
        /// https://www.youtube.com/watch?v=ufXxc8Vty9A
        /// </summary>

        public int subarraysDivByK(int[] A, int K)
        {
            //! Key is the remainder and value is the number of subarrays that has that remainder
            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(0, 1);
            int count = 0, runningSum = 0;
            for (int i = 0; i < A.Length; ++i)
            {

                runningSum += A[i];
                int remainder = runningSum % K;

                if (remainder < 0) remainder += K;  // Because -1 % 5 = -1, but we need the positive mod 4
                if (map.ContainsKey(remainder))
                {
                    count += map[remainder];
                }
                if (!map.ContainsKey(remainder))
                {
                    map.Add(remainder, 0);
                }

                ++map[remainder];

            }
            return count;
        }


    }
}
