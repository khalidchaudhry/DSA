using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeBackTracking.Medium
{
    public class _22
    {


        //! Same as leetcode question 784, there we have two choices(opening bracket & closing bracket) 
        //! Here we have two choices too. Either we can have opening bracket or closing bracket. 
        public IList<string> GenerateParenthesis0(int n)
        {
            IList<string> result = new List<string>();
            GenerateParenthesis0(n, 0, 0, new StringBuilder(), result);
            return result;
        }

        private void GenerateParenthesis0(int n,
                       int openingBracketsCount,
                       int closingBracketsCount,
                       StringBuilder path,
                       IList<string> result)
        {

            if (openingBracketsCount > n || closingBracketsCount > openingBracketsCount)
                return;
            //!2*n are the total number of positions we have. Once we reach to the positions , we can add them to the result. 
            if (path.Length == 2 * n)
            {
                result.Add(path.ToString());
                return;
            }
            path.Append('('); //! choose
            GenerateParenthesis0(n, openingBracketsCount + 1, closingBracketsCount, path, result);//! Explore 
            --path.Length; //! unchoose 


            path.Append(')');  //! choose
            GenerateParenthesis0(n, openingBracketsCount, closingBracketsCount + 1, path, result);//!Explore
            --path.Length;//! unchoose

        }

    }

}

