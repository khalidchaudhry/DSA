using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.GeeksForGeeks
{
    public class StringPermutation
    {
        /// <summary>
        ////////////////////////////////////////////////////////////////////////////////////////
        //! Time complexity=branching_factor^recursion_depth * work_per_recursive_call
        //! where n is the string length.
        //! branching_factor= n --- we have loop which iterate over string length
        //! recursion_depth=n--- we go deep till string length(look at the base condition). 
        //! work per recursive call= n^2 -- n for path.ToArray() and n for new string(char[] chars)
        //! Time complexity=O(n^n)*O(n^2)=O(n!*n^2)
        ////////////////////////////////////////////////////////////////////////////////////////
        //! Space complexity=recursion_depth*space_per_recursive_call
        //! recursion_depth=n
        //! space_per_recursive_call=O(n) because we create string of size n when hit our base case 
        //! Space_Complexity=O(n)*O(n)=O(n2)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public List<string> PermuteWithSwap(string s)
        {
            List<string> result = new List<string>();

            PermuteWithSwap(s.ToCharArray(), 0, new List<char>(), result);
            return result;
        }

        private void PermuteWithSwap(char[] s, int i, List<char> path, List<string> result)
        {
            if (i == s.Length)
            {

                result.Add(new string(path.ToArray()));
                return;
            }

            for (int j = i; j < s.Length; j++)
            {
                Swap(s, i, j);
                path.Add(s[i]);
                PermuteWithSwap(s, i + 1, path, result);
                Swap(s, i, j);
                path.RemoveAt(path.Count - 1);
            }
        }

        private void Swap(char[] s, int i, int j)
        {
            char temp = s[i];
            s[i] = s[j];
            s[j] = temp;
        }
    }
}
