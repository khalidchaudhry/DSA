using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRecursion.Medium
{
    public class _247
    {
        List<(char first, char second)> lst;
        /// <summary>
        //! This problem is inspired from IsStringPalindrome 125  
        /// </summary>
        public IList<string> FindStrobogrammatic(int n)
        {
            lst = new List<(char, char)>();
            lst.Add(('0', '0'));
            lst.Add(('1', '1'));
            lst.Add(('6', '9'));
            lst.Add(('9', '6'));
            lst.Add(('8', '8'));

            char[] charArray = new char[n];
            List<string> result = new List<string>();
            Helper(charArray, 0, n - 1, result);
            return result;
        }
        private void Helper(char[] charArray, int start, int end, List<string> result)
        {
            //! incase the length is even , start will pass end and we can add char array to result
            if (start > end)
            {
                result.Add(new string(charArray));
                return;
            }
            //! in case length is odd, we need to add  characters in middle position 
            if (start == end)
            {
                foreach (char c in new char[] { '0', '1', '8' })
                {
                    charArray[start] = c;
                    result.Add(new string(charArray));
                }
                return;
            }

            //! since we can't have 0 at the beggining  , we are skipping it
            int idx = start == 0 ? 1 : 0;
            for (int i = idx; i < lst.Count; ++i)
            {
                charArray[start] = lst[i].first;
                charArray[end] = lst[i].second;
                Helper(charArray, start + 1, end - 1, result);
            }
        }


    }
}
