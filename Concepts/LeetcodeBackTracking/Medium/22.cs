using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeBackTracking.Medium
{
    public class _22
    {



        public IList<string> GenerateParenthesis0(int n)
        {
            IList<string> result = new List<string>();
            Helper(n, 0, 0, new StringBuilder(), result);
            return result;
        }

        private void Helper(int n,
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
            Helper(n, openingBracketsCount + 1, closingBracketsCount, path, result);
            --path.Length; //! unchoose 


            path.Append(')');  //! choose
            Helper(n, openingBracketsCount, closingBracketsCount + 1, path, result);
            --path.Length;//! unchoose

        }

    }

}

