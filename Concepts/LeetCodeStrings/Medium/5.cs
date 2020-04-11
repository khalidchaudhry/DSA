using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _5
    {

        /*
          http://www.goodtecher.com/leetcode-5-longest-palindromic-substring/
        basic idea is to use dynamic programming to determine whether 
        a substring is palindromic string base on above criteria.
        Approach
           1. Create DP array
           2. First letter =LastLetter
           3. inner word is also palindormic
        */


        public string LongestPalindrome0(string s)
        {
            int length = s.Length;
            if (string.IsNullOrEmpty(s) || s.Length < 2)
            {
                return s;
            }
            bool[,] dp = new bool[length, length];
            int right = 0;
            int left = 0;
            /*
            i is the left index and j is the right index of a word.
            In order to get at least one character of a word, j has been to at least one index after i. 
            If i’s index is 0, then j’s index would be 1.
            For i, its value could start from 0 to j – 1.
            For j, its value could start from 1 to the last character index of the input string(s.length() – 1).
            */
            for (int j = 1; j < length; j++)
            {
                for (int i = 0; i < j; i++)
                {
                    //first letter ==last letter
                    if (s[i] == s[j] &&
                         //inner word is also palindrome 
                         (dp[i + 1, j - 1] ||
                          //for single character 
                          //e.g. aba i=0 and j=2, above condition (dp[i + 1, j - 1]) false but its palindrome
                          j - i <= 2
                         )
                       )
                    {
                        dp[i, j] = true;
                        // to get longest palindrome so far
                        if (j - i > right - left)
                        {
                            left = i;
                            right = j;
                        }
                    }
                }
            }
            return s.Substring(left, right - left + 1);
        }

        private Dictionary<string, string> map = new Dictionary<string, string>();
        // Brute force solution 
        public string LongestPalindrome(string s)
        {

            if (s.Length < 2 || string.IsNullOrEmpty(s))
            {
                return s;
            }
            string longestPalindrome = s[0].ToString();
            int longestPalindromeLength = longestPalindrome.Length;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    string subString = s.Substring(i, j - i + 1);
                    if (IsPalindrome(subString))
                    {
                        if (subString.Length > longestPalindromeLength)
                        {
                            longestPalindromeLength = subString.Length;
                            longestPalindrome = subString;
                        }
                    }
                }
            }

            return longestPalindrome;
        }

        private bool IsPalindrome(string s)
        {
            string reverseString = string.Empty;
            if (map.ContainsKey(s))
            {
                reverseString = map[s];
            }
            else
            {
                char[] array = s.ToCharArray();
                Array.Reverse(array);
                reverseString = new string(array);
                map.Add(s, reverseString);

            }
            if (reverseString == s)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
