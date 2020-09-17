using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Easy
{
    public class _844
    {
        public static void _844Main()
        {
            string S = "ab#c";// "y#fo##f";

            string T = "ad#c";// "y#f#o##f";

            _844 Backspce = new _844();
            var ans = Backspce.BackspaceCompare0(S, T);

            Console.ReadLine();
        }
        /// <summary>
        /// https://www.youtube.com/watch?v=ddyikohCqyo
        /// https://www.youtube.com/watch?v=vgog1EuEJYQ
        /// </summary>
        /// <param name="S"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public bool BackspaceCompare0(string S, string T)
        {

            int i = S.Length - 1;
            int j = T.Length - 1;
             while (i >= 0 || j >= 0)
            {
                i = Helper(S,i);

                j = Helper(T, j);
                
                //! If two actual characters are different
                if (i >= 0 && j >= 0 && S[i] != T[j])
                    return false;
                //! If expecting to compare char vs nothing
                //e.g ac vs a
                if ((i >= 0) != (j >= 0))
                    return false;
                i--;
                j--;

            }
            return true;
        }

        private int Helper(string str, int i)
        {
            int skip = 0;
            while (i >= 0)
            { // Find position of next possible char in string
                if (str[i] == '#')
                {
                    skip++;
                    i--;
                }
                else if (skip > 0)
                {
                    skip--;
                    i--;
                }
                else
                    break;
            }
            return i;

        }

        /// <summary>
        //
        /// </summary>
        /// <param name="S"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public bool BackspaceCompare(string S, string T)
        {

            Stack<char> sStk = new Stack<char>();
            Stack<char> tStk = new Stack<char>();
            PopulateStack(S, sStk);
            PopulateStack(T, tStk);

            if (sStk.Count != tStk.Count)
                return false;

            while (sStk.Count != 0)
            {
                if (sStk.Pop() != tStk.Pop())
                {
                    return false;
                }
            }

            return true;

        }
        private void PopulateStack(string str, Stack<char> stk)
        {
            for (int i = 0; i < str.Length; ++i)
            {
                if (str[i].Equals('#'))
                {
                    if (stk.Count != 0)
                        stk.Pop();
                }
                else
                {
                    stk.Push(str[i]);
                }

            }
        }



    }
}
