using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _17
    {
        List<string> results = new List<string>();
        Dictionary<string, string> phone = new Dictionary<string, string>() {
        {"2", "abc" },
        { "3", "def" },
        { "4", "ghi" },
        { "5", "jkl" },
        { "6", "mno" },
        { "7", "pqrs" },
        { "8", "tuv"},
        { "9", "wxyz" }
        };

        //https://leetcode.com/problems/letter-combinations-of-a-phone-number/
        //! Based on core pattern define in byte by byte
        public IList<string> LetterCombinations0(string digits)
        {
            List<string> result = new List<string>();
            if (string.IsNullOrEmpty(digits))
            {
                return result;
            }
            Dictionary<char, string> map = new Dictionary<char, string>() {
                {'2', "abc" },
                {'3', "def" },
                {'4', "ghi" },
                {'5', "jkl" },
                {'6', "mno" },
                {'7', "pqrs" },
                {'8', "tuv"},
                {'9', "wxyz" }
            };

            LetterCombinations0(digits, 0, new StringBuilder(), map, result);

            return result;
        }

        private void LetterCombinations0(string digits,
                                         int i,
                                         StringBuilder path,
                                         Dictionary<char, string> map,
                                         List<string> result)
        {
            if (i == digits.Length)
            {
                result.Add(path.ToString());
                return;
            }

            foreach (char letter in map[digits[i]])
            {
                path.Append(letter);
                LetterCombinations0(digits, i + 1, path, map, result);
                path.Length--;
            }
        }
    }
}
