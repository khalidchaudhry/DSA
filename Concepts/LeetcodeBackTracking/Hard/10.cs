using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Hard
{
    class _10
    {
        public bool IsMatch(string s, string p)
        {
            Dictionary<(int, int), bool> memo = new Dictionary<(int, int), bool>();
            return IsMatch(s, p, 0, 0, memo);
        }

        private bool IsMatch(string s, string p, int sIndex, int pIndex, Dictionary<(int, int), bool> memo)
        {
            if (memo.ContainsKey((pIndex, sIndex)))
                return memo[(pIndex, sIndex)];
            //! We reach to end of pattern 
            if (pIndex == p.Length)
            {
                //!We need to ensure that we reach to end of string
                memo[(pIndex, sIndex)] = sIndex == s.Length;
                return memo[(pIndex, sIndex)];
            }
           
            //! We are matching one character 
            //! Conditions for matching one character
            //! 1. We have . in pattern or 
            //! 2. Characters in the position matching. 
            bool isFirstMatch = sIndex < s.Length && (p[pIndex] == '.' ||  s[sIndex] == p[pIndex]);
            //! if we have * prceeding character (e.g. a*) , we have two choices 
            //! 1. We match 0 character in string . Our subproblem becomes sIdx,pIdx+2
            //! 2. We match 1 characer in string.  Our subproblem becomes sIdx+1,pIdx
            if (pIndex + 1 < p.Length && p[pIndex + 1] == '*')
            {
                //! 1. We match 0 character in string . Our subproblem becomes sIdx,pIdx+2
                memo[(pIndex, sIndex)] = IsMatch(s, p, sIndex, pIndex + 2, memo);
                if (memo[(pIndex, sIndex)])
                {
                    return memo[(pIndex, sIndex)];
                }
                //! 2. We match 1 characer in string.  Our subproblem becomes sIdx+1,pIdx
                if (isFirstMatch)
                {
                    //! We are matching 1 or more characters in string hence sIdx+1
                    memo[(pIndex, sIndex)] = IsMatch(s, p, sIndex + 1, pIndex, memo);
                    return memo[(pIndex, sIndex)];
                }
            }

            if (isFirstMatch)
            {
                memo[(pIndex, sIndex)] = IsMatch(s, p, sIndex + 1, pIndex + 1, memo);
                return memo[(pIndex, sIndex)];
            }

            memo[(pIndex, sIndex)] = false;

            return memo[(pIndex, sIndex)];
        }


    }
}
