using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _71
    {
        //https://www.youtube.com/watch?v=AOD1VYQnUP4
        //https://www.youtube.com/watch?v=qcl2yd4JSyo
        public string SimplifyPath(string path)
        {
            string[] p = path.Split("/");
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
