using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeStrings.Easy
{
    public class _15
    {


        // # <image url="$(SolutionDir)\Images\15.jpg"  scale="0.5"/>
        public string LongestCommonPrefix(string[] strs)
        {

            strs = strs.OrderBy(x => x.Length).ToArray();

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < strs[0].Length; ++i)
            {
                for (int j = 1; j < strs.Length; ++j)
                {
                    if (strs[0][i] != strs[j][i])
                    {
                        return result.ToString();
                    }
                }
                result.Append(strs[0][i]);
            }
            return result.ToString();



        }


    }
}
