using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Easy
{
    public class _680
    {

        public static void _680Main()
        {
            //string s = "aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga";

            string s = "abdca";
            _680 ValidPalindrome = new _680();
            var result=ValidPalindrome.ValidPalindrome(s);

            Console.ReadLine();
        }

       //https://leetcode.com/problems/valid-palindrome-ii/discuss/107716/Java-O(n)-Time-O(1)-Space
        public bool ValidPalindrome(string s)
        {
            if (String.IsNullOrEmpty(s))
                return true;

            int i = 0;
            int j = s.Length - 1;
            
            while (i < j)
            {
                if (s[i].Equals(s[j]))
                {
                    ++i;
                    --j;
                }
                else
                    // Deleting the character from the left side
                    // Deleting the character from the right side
                    return Helper(s, i + 1, j) || Helper(s, i, j - 1);                   
                    
            }

            return true;
        }

        private bool Helper(string s, int i, int j)
        {
            while (i < j)
            {
                if (s[i] != s[j])
                return false;
                ++i;
                --j;
            }
            return true;
        }
    }
}
