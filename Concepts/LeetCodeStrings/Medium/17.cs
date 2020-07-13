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

        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length != 0)
            {
                LetterCombinationsHelper("", digits);
            }
            return results;
        }

        private void LetterCombinationsHelper(string combination, string digits)
        {
            // if there is no more digits to check
            if (digits.Length == 0)
            {
                // the combination is done
                results.Add(combination);
            }
            // if there are still digits to check
            else
            {
                // iterate over all letters which map 
                // the next available digit
                string digit = digits.Substring(0, 1);
                string letters = phone[digit];
                for (int i = 0; i < letters.Length; i++)
                {
                    string letter = phone[digit].Substring(i, 1);
                    // append the current letter to the combination
                    // and proceed to the next digits
                    LetterCombinationsHelper(combination + letter, digits.Substring(1));

                }
            }
        }

        public List<string> LetterCombinations2(string digits)
        {
            string[] table = { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            List<string> combinations = new List<string>();

            if (string.IsNullOrEmpty(digits))
            {
                return combinations;
            }

            combinations.Add("");

            for (int i = 0; i < digits.Length; i++)
            {
                // set list to  last iteration of combination 
                List<string> list = combinations;
                // resetting combinations for every digit 
                combinations = new List<string>();
                foreach (String item in list)
                {
                    //! digits[i] - '0' it will convert it into digit so 2 maps to second entry in table array
                    //! table[digits[i] - '0'].Length wil give length of corresponding entry in the table array
                    for (int j = 0; j < table[digits[i] - '0'].Length; j++)
                    {
                        //! appending item with one character of the string array at one time .
                        //! in next iteration it will already include previous combination
                        // !e.g. a+d for 23
                        combinations.Add(item + table[digits[i] - '0'][j]);
                    }
                }
            }
            return combinations;
        }

    }
}
