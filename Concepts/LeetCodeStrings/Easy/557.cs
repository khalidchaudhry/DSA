using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Easy
{
    class _557
    {
        public string ReverseWords(string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;
            if (s.Length == 1)
                return s;
            StringBuilder sb = new StringBuilder();
            string[] words = s.Split(" ");

            for (int i = 0; i < words.Length; i++)
            {
                char[] charArray = words[i].ToCharArray();
                Array.Reverse(charArray);
                sb.Append(charArray);
                if (i != words.Length - 1)
                {
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }

        public string ReverseWords2(string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;
            if (s.Length == 1)
            {
                return s;
            }
            StringBuilder sb = new StringBuilder();
            // important to convert it to StringBuilder as 
            // we will not be able to manipulate string as its immuatable 
            sb.Append(s.ToCharArray());
            int start = 0;
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] == ' ' || i == sb.Length - 1)
                {
                    int end = i == sb.Length - 1 ? i : i - 1;
                    Swap(sb, start, end);
                    start = i + 1;
                }
            }
            return sb.ToString();
        }
        private void Swap(StringBuilder sb, int start, int end)
        {
            while (start < end)
            {
                char temp = sb[start];
                sb[start] = sb[end];
                sb[end] = temp;
                ++start;
                --end;
            }
        }

    }
}
