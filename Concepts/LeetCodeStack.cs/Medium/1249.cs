using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Medium
{
    public class _1249
    {

        /// <summary>
        /// https://www.youtube.com/watch?v=MRfP6-RNBjM
        //! For ( bracket , push into the stack  along with the index, 
        //! For closing try to pop if stack is not empty and last pushed element was (. Else push
        //! Also look at this problem  https://leetcode.com/problems/minimum-add-to-make-parentheses-valid/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MinRemoveToMakeValid(string s)
        {
            //! you can optimize the space. Rather than pushing  val, just push the index
            Stack<(char bracket, int index)> stk = new Stack<(char bracket, int index)>();
            GetBracketsToRemove(stk, s);
            HashSet<int> indexesToRemove = new HashSet<int>();
            GetIndexesToRemove(stk, indexesToRemove);
            return PrepareResult(s, indexesToRemove);
        }

        private void GetBracketsToRemove(Stack<(char bracket, int index)> stk, string s)
        {
            //! you can optimize the space. Rather than pushing  val, just push the index          
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == '(')
                {
                    stk.Push((s[i], i));
                }
                if (s[i] == ')')
                {
                    if (stk.Count != 0 && stk.Peek().bracket == '(')
                    {
                        stk.Pop();
                    }
                    else
                    {
                        stk.Push((s[i], i));
                    }
                }
            }
        }

        private void GetIndexesToRemove(Stack<(char bracket, int index)> stk, HashSet<int> indexesToRemove)
        {
            while (stk.Count != 0)
            {
                indexesToRemove.Add(stk.Pop().index);
            }
        }
        private string PrepareResult(string s, HashSet<int> hs)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; ++i)
            {
                if (!hs.Contains(i))
                    sb.Append(s[i]);
            }
            return sb.ToString();
        }


    }
}
