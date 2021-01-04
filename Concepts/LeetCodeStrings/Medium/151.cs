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
        


    }
}
