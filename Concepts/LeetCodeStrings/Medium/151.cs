using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _151
    {

        /// <summary>
        //! First reverse the words in the string 
        //! Reverse the whole string
        /// </summary>
        public string ReverseWords(string s)
        {
            int strStartIdx = 0;
            int strEndIdx = s.Length;
            StringBuilder reversed = new StringBuilder();
            while (strStartIdx < strEndIdx)
            {
                //! skipping leading spaces
                while (strStartIdx < strEndIdx && s[strStartIdx] == ' ')
                {
                    ++strStartIdx;
                }

                int leftIdx = reversed.Length;  //left boundray index in  string builder from where we will reverse  

                int wordEndIdx = strStartIdx;  //right boundary for word in string

                while (wordEndIdx < strEndIdx && s[wordEndIdx] != ' ')
                {
                    reversed.Append(s[wordEndIdx]);
                    ++wordEndIdx;
                }

                Reverse(reversed, leftIdx, reversed.Length - 1);
                strStartIdx = wordEndIdx;
                reversed.Append(' ');
            }
            //! Remove leading spaces
            while (reversed[reversed.Length - 1] == ' ')
            {
                --reversed.Length;
            }

            Reverse(reversed, 0, reversed.Length - 1);

            return reversed.ToString();
        }
        private void Reverse(StringBuilder sb, int left, int right)
        {
            while (left < right)
            {
                char temp = sb[left];

                sb[left] = sb[right];
                sb[right] = temp;
                ++left;
                --right;
            }
        }

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
