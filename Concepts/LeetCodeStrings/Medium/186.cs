using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _186
    {

        public static void _186Main()
        {
            var test = new _186();
            test.ReverseWords(new char[] { 'a',' ','b'});
        }
        public void ReverseWords(char[] s)
        {
            int n = s.Length;
            Reverse(s, 0, n - 1);

            int i = 0;
            while (i < n)
            {
                int start = i;
                while (i < n && s[i] != ' ')
                {
                    ++i;
                }
                Reverse(s, start, i - 1);
                ++i;
            }
        }
        private void Reverse(char[] s, int left, int right)
        {
            while (left < right)
            {
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                ++left;
                --right;
            }
        }



    }
}
