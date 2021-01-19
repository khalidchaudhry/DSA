using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Hard
{
    public class _44
    {


        public static void _44Main()
        {
            string s = "acdcb";
            string p = "a*c?b";

            var test = new _44();
            var result=test.IsMatch(s,p);

            Console.ReadLine();

        }

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
            if (p[pIndex] == '?' || (sIndex < s.Length && s[sIndex] == p[pIndex]))
            {
                memo[(pIndex, sIndex)] = IsMatch(s, p, sIndex + 1, pIndex + 1, memo);
                return memo[(pIndex, sIndex)];
            }
            if (p[pIndex] == '*')
            {
                memo[(pIndex, sIndex)] = IsMatch(s, p, sIndex, pIndex + 1, memo) || IsMatch(s, p, sIndex + 1, pIndex, memo);
                return memo[(pIndex, sIndex)];
            }

            memo[(pIndex, sIndex)] = false;

            return memo[(pIndex, sIndex)];
        }
    }
}
