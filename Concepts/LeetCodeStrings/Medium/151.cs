using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _151
    {
        /* Two pointer approach 
         Keep moving end pointer till u encounter  space. If enconter than take take substring from start till end
         Keep incrementing end till it is space         
         */
        public string ReverseWords(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            // Trim string to remove trailing spaces from string. 
            s = s.Trim();
            
            int start = 0;
            int end = 0;
            Stack<string> stk = new Stack<string>();
            while (end < s.Length)
            {

                if (s[end].Equals(' '))
                {
                    string word=s.Substring(start,(end-1)-start+1);
                    // ! Push the whole word into stack rather than character
                    stk.Push(word);
                    // Keep incrementing end till it is space
                    while (s[end].Equals(' '))
                    {
                        ++end;
                    }
                    start = end;
                }
                ++end;
            }
            // ! Push the last word into the stack
            string lastWord = s.Substring(start,(end-1)-start+1);
            stk.Push(lastWord);

            StringBuilder sb = new StringBuilder();

            while (stk.Count != 0)
            {
                sb.Append(stk.Pop());
                // ! If stack count is zero than it means last word and we don't need to append 
                if (stk.Count > 0)
                {
                    sb.Append(' ');
                }
            }

            return sb.ToString();

        }
    }
}
