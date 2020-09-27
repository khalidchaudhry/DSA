using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _718
    {

        public static void _718Main()
        {

            _718 Length = new _718();
            int[] A = new int[] { 0, 0, 0, 0, 1 };
            int[] B = new int[] { 1, 0, 0, 0, 0 };
            var ans = Length.FindLength2(A, B);
            Console.ReadLine();

        }

        /// <summary>
        //! DP with tabulation
        //! longest suffix ending at that location
        //! We need to know longest suffix ending at each location
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int FindLength0(int[] A, int[] B)
        {
            int ans = 0;
            int[][] dp = new int[A.Length + 1][];

            for (int i = 0; i < dp.Length; ++i)
            {
                dp[i] = new int[B.Length + 1];
            }

            for (int i = 0; i < A.Length; ++i)
            {
                for (int j = 0; j < B.Length; ++j)
                {
                    if (A[i] == B[j])
                    {
                        dp[i + 1][j + 1] = dp[i][j] + 1;
                        ans = Math.Max(ans, dp[i + 1][j + 1]);
                    }

                }
            }

            return ans;
        }


        /// <summary>
        // !Binary serach implementation
        //! We are searching for the max length between A and B 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int FindLength2(int[] A, int[] B)
        {
            int maxLength = 0;

            int lo = 0;            
            int hi = Math.Min(A.Length, B.Length) + 1;
            //! <= otherwise some lengths  will be missed
            //!e.g in case of arrays of length 5 , 3 will be missed
            while (lo <= hi)
            {
                int mid = lo + ((hi - lo) / 2);
                if (Check(mid, A, B))
                {
                    maxLength = Math.Max(maxLength, mid);
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }

            return maxLength;

        }

        private bool Check(int k, int[] A, int[] B)
        {
            HashSet<string> seen = new HashSet<string>();

            for (int i = 0; i + k <= A.Length; ++i)
            {
                //! Taking k elements every time
                var kItems = A.Skip(i).Take(k);
                string kItemsString = string.Join(string.Empty, kItems.Select(p => p.ToString()));
                seen.Add(kItemsString);
            }

            for (int i = 0; i + k <= B.Length; ++i)
            {
                var kItems = B.Skip(i).Take(k);
                string kItemsString = string.Join(string.Empty, kItems.Select(p => p.ToString()));
                if (seen.Contains(kItemsString))
                {
                    return true;
                }

            }

            return false;
        }

        /// <summary>
        //! Brute Force
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int FindLength1(int[] A, int[] B)
        {
            int ans = 0;
            for (int i = 0; i < A.Length; ++i)
            {
                for (int j = 0; j < B.Length; ++j)
                {
                    int k = 0;
                    while (i + k < A.Length && j + k < A.Length && A[i + k] == B[j + k])
                    {
                        ++k;
                    }
                    ans = Math.Max(ans, k);
                }
            }

            return ans;
        }


    }
}
