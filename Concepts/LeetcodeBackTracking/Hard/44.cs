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
        private bool IsMatch(string s, int i, string p, int j, Dictionary<(int sIdx, int pIdx), bool> memo)
        {

            //! if pattern exhaust, we need to ensure that string exhaust too
            //! s=a  p=a* returns true
            //! s=a  p=a*b returns false

            if (j == p.Length)
            {
               return i == s.Length;
            }

            if (i > s.Length)
            {
                return false;
            }

            if (memo.ContainsKey((i, j)))
                return memo[(i, j)];

            if (p[j] == '?' || (i < s.Length && s[i] == p[j]))
            {
                return memo[(i, j)] = IsMatch(s, i + 1, p, j + 1, memo);
            }

            //! if we have * in pattern then we have 2 possibilities 
            //! 1. We don't match anything  we will increment pattern(j) to skip *
            //! 2. We match * with characer in string and increment string(i) to skip character in string

            if (p[j] == '*')
            {
                return memo[(i, j)] = IsMatch(s, i + 1, p, j, memo) ||  
                                      IsMatch(s, i, p, j + 1, memo); 
            }
            return memo[(i, j)] = false;
        }
    }
}
