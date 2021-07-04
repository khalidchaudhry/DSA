using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _634
    {
        int mod = (int)1e9 + 7;
        public int FindDerangement(int n)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>();
            return FindDerangement(n, memo);
        }

        private int FindDerangement(int n, Dictionary<int, int> memo)
        {
             //!if there is 1 element we can't generate any permutation that does not appears in its original position.
            if (n == 1)
            {
                return 0;
            }
            if (n == 2)
            {
                return 1;
            }

            if (memo.ContainsKey(n))
            {
                return memo[n];
            }
            //!For swap recurrence relationship in F(n-2)
            //! For not swap recurrence relationship is F(n-1)
            //! We can do above operation with n-1 times
            long ans = (((long)n - 1) * (FindDerangement(n - 2, memo) + FindDerangement(n - 1, memo))) % mod;
            return memo[n] = (int)ans;
        }


    }
}
