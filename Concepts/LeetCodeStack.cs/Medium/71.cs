using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStack.Medium
{
    public class _71
    {


        /// <summary>
        //!. --> do nothing. you are in current directory 
        //!.. --> move the control to the parent of current directory
        //!e.g. /a/./b/../../c/    encounter . , you are in current directory. See below line for the result
        //! /a/b/../../c/   encouter .. , move to the parent of b
        //! /a/../c/       encouter .. , move to the parent of a which is root
        //!/c/             final result 
        //! Tokenize the string based on the '/'
        //! Go through the tokenize words. If we encouter . , we don't do anything. If we we encounter .., we remove last element from intermediate string. 
        //! In the end we build up final result, by scanning intermediate string and appending /
        //! Based on idea in Kua's class
        /// </summary>       
        public string SimplifyPath0(string path)
        {
            //! Tokenize based on the '/'
            //! there will be empty string(s) in the tokens e.g. /home will produce ["",home] as there is nothing on left side
            string[] tokens = path.Split('/');

            List<string> interResult = new List<string>();

            foreach (string token in tokens)
            {
                if (token.Equals(".") || token.Equals(string.Empty))
                {
                    continue;
                }
                else if (token.Equals(".."))
                {
                    if (interResult.Count != 0)//! incase list is empty. we can't remove
                        interResult.RemoveAt(interResult.Count - 1);
                }
                else
                {
                    interResult.Add(token);
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (string s in interResult)
            {
                sb.Append('/');
                sb.Append(s);
            }

            //! incase there is nothing e.g.  "/../" we still need to output with /
            if (sb.Length == 0) sb.Append('/');

            return sb.ToString();
        }

        //https://www.youtube.com/watch?v=AOD1VYQnUP4
        //https://www.youtube.com/watch?v=qcl2yd4JSyo
        public string SimplifyPath(string path)
        {
            string[] p = path.Split('/');
            Stack<string> stk = new Stack<string>();
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i].Equals(".."))
                {
                    if (stk.Count > 0)
                        stk.Pop();
                }
                else if (!p[i].Equals(".") && !p[i].Equals(""))
                {
                    stk.Push(p[i]);
                }
            }

            List<string> list = new List<string>();


            StringBuilder sb = new StringBuilder();
            while (stk.Count != 0)
            {
                //! Need to pay attention . How are we handling it  Inserting at the beginning. 
                //! Insert is an expensive opeation 
                sb.Insert(0, "/" + stk.Pop());

            }

            return sb.Length == 0 ? "/" : sb.ToString();

        }


    }
}
