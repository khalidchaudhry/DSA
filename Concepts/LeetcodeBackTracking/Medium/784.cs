using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Medium
{
    public class _784
    {
        public static void _784Main()
        {
            


        }
        //https://leetcode.com/problems/letter-case-permutation/discuss/255071/Java-detailed-explanation-of-DFSBacktracking-solution
        public IList<string> LetterCasePermutation(string S)
        {

            List<string> result = new List<string>();
            LetterCasePermutation(S.ToCharArray(), 0, result);

            return result;
        }

        private static void LetterCasePermutation(char[] items, int i, List<string> result)
        {
            if (i == items.Length)
            {
                result.Add(new String(items));
                return;
            }
            if (Char.IsLetter(items[i]))
            {
                items[i] = Char.ToUpper(items[i]);
                LetterCasePermutation(items, i + 1, result);
                items[i] = Char.ToLower(items[i]);
                LetterCasePermutation(items, i + 1, result);
            }
            else
            {
                LetterCasePermutation(items, i + 1, result);
            }
        }
    }
}
