using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _151
    {

        
        
        
        
        
        
        
        
        /// <summary>
        //! This approach uses stack to reverse order of the words  
        /// </summary>
        public string ReverseWords2(string s)
        {
            string[] words = s.Split(' ');
            Stack<string> stk = new Stack<string>();
            for (int i = 0; i < words.Length; ++i)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    stk.Push(words[i]);
                }
            }
            string result = string.Empty;
            while (stk.Count != 0)
            {
                result = result + stk.Pop() + (stk.Count == 0 ? "" : " ");

            }

            return result;
        }
        public string ReverseWords1(string s)
        {
            s = s.Trim();
            string[] tokens = s.Split(' ');

            StringBuilder sb = new StringBuilder();
            for (int i = tokens.Length - 1; i >= 0; --i)
            {
                if (tokens[i] != String.Empty)
                {
                    sb.Append(tokens[i]);
                    if (i != 0)
                    {
                        sb.Append(' ');
                    }
                }
            }

            return sb.ToString();
        }



    }
}
