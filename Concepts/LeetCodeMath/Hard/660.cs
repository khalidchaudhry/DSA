using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Hard
{
    public class _660
    {
        //https://leetcode.com/problems/remove-9/discuss/541287/Accepted-C-Solution
        public int NewInteger(int n)
        {

            Stack<int> stk = new Stack<int>();

            //! convert into base 9 system 
            while (n != 0)
            {
                stk.Push(n % 9);
                n = n / 9;
            }

            //! convet into base 10 for output purose
            int ans = 0;
            while (stk.Count != 0)
            {
                ans += stk.Pop() * (int)Math.Pow(10, stk.Count);

            }
            return ans;


        }
    }
}
