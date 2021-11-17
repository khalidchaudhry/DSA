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
            string s = "adceb";
            string p = "*a*b";

            var test = new _44();
            var result = test.IsMatch(s, p);

            Console.ReadLine();

        }

        public bool IsMatch(string s, string p)
        {
            Dictionary<(int sIdx, int pIdx), bool> memo = new Dictionary<(int sIdx, int pIdx), bool>();
            return IsMatch(s, 0, p, 0, memo);
        }
        private bool IsMatch(string s, int sIdx, string p, int pIdx, Dictionary<(int sIdx, int pIdx), bool> memo)
        {

            //! if pattern exhaust,we are certain about matching but not other way around(string exhausted ) 
            //! s=a  p=a* returns true
            //! s=a  p=a*b returns false

            if (pIdx == p.Length)
            {
                return sIdx == s.Length;
            }        

            if (memo.ContainsKey((sIdx, pIdx)))
                return memo[(sIdx, pIdx)];
            //! We need to ensure that we have some characters left in string to match hence sIdx < s.Length
            if (sIdx < s.Length && p[pIdx] == '?' || (s[sIdx] == p[pIdx]))
            {
                return memo[(sIdx, pIdx)] = IsMatch(s, sIdx + 1, p, pIdx + 1, memo);
            }

            //! if we have * in pattern then we have 2 possibilities 
            //! 1. We don't match anything  we will increment pattern(pIdx+1) to skip *
            //! 2. We match * with >=1  characer in string and increment string(sIdx) to skip character in string

            if (p[pIdx] == '*')
            {
                return memo[(sIdx, pIdx)] =
                    //! 1. We don't match anything in the string we will increment pattern(pIdx+1) to skip *
                    IsMatch(s, sIdx, p, pIdx + 1, memo) ||
                    //!2. We have some character left to match in string hence sIdx<s.Length && 
                    //!We match * with  1  character in string and increment string(sIdx) to skip character in string
                    (sIdx < s.Length && IsMatch(s, sIdx + 1, p, pIdx, memo));
            }
            return memo[(sIdx, pIdx)] = false;
        }
    }
}
