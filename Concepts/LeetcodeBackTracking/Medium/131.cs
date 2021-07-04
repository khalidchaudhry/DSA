using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Medium
{
    public class _131
    {


        
        //  # <image url="$(SolutionDir)\Images\131.jpg"  scale="0.4"/>

        /// <summary>
        //! Time= 3n * 2^n=n*2^n
        //! Space=n *2^n(to store result) 
        /// </summary>
        public IList<IList<string>> Partition(string s)
        {
            List<IList<string>> result = new List<IList<string>>();
            Partition(s, 0, new List<string>(), result);
            return result;
        }
        private void Partition(string s, int start, List<string> path, List<IList<string>> result)
        {
            if (start == s.Length)
            {
                result.Add(new List<string>(path));//! O(n)
                return;
            }

            for (int i = start; i < s.Length; ++i)  //!2^n
            {
                //! we can also precompute to find all the substrings that are palindrome 
                if (!IsPalindrome(s, start, i)) //!O(n)
                    continue;

                path.Add(s.Substring(start, i - start + 1)); //!O(n) for substring
                Partition(s, i + 1, path, result);
                path.RemoveAt(path.Count - 1);
            }

        }

        private bool IsPalindrome(string s, int start, int end)
        {
            while (start < end)
            {
                if (s[start] != s[end])
                    return false;

                ++start;
                --end;
            }

            return true;
        }


        bool[,] isPalindrome;
        public IList<IList<string>> Partition1(string s)
        {
            isPalindrome = new bool[s.Length, s.Length];
            CalculatePalindrome(s);

            List<IList<string>> result = new List<IList<string>>();
            Partition1(s, 0, new List<string>(), result);
            return result;
        }

        private void Partition1(string str, int s, List<string> path, List<IList<string>> result)
        {
            if (s == str.Length)
            {
                result.Add(new List<string>(path));
                return;
            }

            for (int i = s; i < str.Length; ++i)
            {
                if (isPalindrome[s, i])
                {
                    string pre = str.Substring(s, i - s + 1);
                    path.Add(pre);
                    Partition1(str, i + 1, path, result);
                    path.RemoveAt(path.Count - 1);
                }
            }

        }

        private void CalculatePalindrome(string s)
        {
            int n = s.Length;

            for (int len = 1; len <= n; ++len)
            {
                for (int start = 0; start <= n - len; ++start)
                {
                    int end = start + len - 1;

                    if (start == end)
                    {
                        isPalindrome[start, end] = true;
                    }
                    else if (len == 2)
                    {
                        isPalindrome[start, end] = s[start] == s[end];
                    }
                    else
                    {
                        isPalindrome[start, end] = s[start] == s[end] && isPalindrome[start + 1, end - 1];
                    }
                }
            }
        }
    }
}
