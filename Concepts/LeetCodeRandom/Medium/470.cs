using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRandom.Medium
{
    public class _470
    {


    }

    public class Solution2
    {
        //https://www.youtube.com/watch?v=XyF-Wrkj4Hg
        //https://leetcode.com/problems/implement-rand10-using-rand7/discuss/338395/In-depth-straightforward-detailed-explanation.-(Short-Java-solution)
        //https://leetcode.com/problems/implement-rand10-using-rand7/discuss/150301/Three-line-Java-solution-the-idea-can-be-generalized-to-%22Implement-RandM()-Using-RandN()%22

        public class Solution //: SolBase
        {
            Random random = new Random();
            public int Rand10()
            {
                int x, y, m = 7, num = 40;
                //!how we come up with 40?
                //! https://leetcode.com/problems/implement-rand10-using-rand7/discuss/150301/Three-line-Java-solution-the-idea-can-be-generalized-to-%22Implement-RandM()-Using-RandN()%22 
                //! ((N^i)/M) * M where N^i is smallest Math.pow(N,i) for i >= 1 greater than M
                //! 7^1>10 --reject
                //! 7^2>10 ---accept 
                //! (49/10)*10=40
                while (num >= 40)// keep generating till num >=40 
                {

                    x = Rand7() - 1;  //[0,6]
                    y = Rand7() - 1;  //[0,6]
                                      //[0 to 48 will have equal possiblity ]
                    num = x * m + y;
                }
                // +1 because num contains values from 0 to n-1 and we need to map them to 1 to n   
                return num % 10 + 1;
            }
            //!This method will be in leetcode base class ,generating random number from 1 to 7
            private int Rand7()
            {
                //! upper bound is exclusive hence we are using 8 rather than 7
                return random.Next(1, 8);
            }
        }
    }
}
