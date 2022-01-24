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

            if (pIndex == p.Length)
            {
                memo[(pIndex, sIndex)] = sIndex == s.Length;
                return memo[(pIndex, sIndex)];
            }

            if (sIndex > s.Length)
            {
                memo[(pIndex, sIndex)] = false;
                return memo[(pIndex, sIndex)];
            }

            bool isFirstMatch = p[pIndex] == '.' || (sIndex < s.Length && s[sIndex] == p[pIndex]);

            if (pIndex + 1 < p.Length && p[pIndex + 1] == '*')
            {
                //! In below line we are not matching any character in string . Our sub problem become
                //! sIdx -------s.Length
                //! pIdx+2-------p.Length
                memo[(pIndex, sIndex)] = IsMatch(s, p, sIndex, pIndex + 2, memo);
                if (memo[(pIndex, sIndex)])
                {
                    return memo[(pIndex, sIndex)];
                }
                if (isFirstMatch)
                {
                    //! We are matching 1 character in string hence sIdx+1
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
