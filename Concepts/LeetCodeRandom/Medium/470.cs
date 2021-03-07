using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRandom.Medium._470
{
    public class _470
    {


    }
    //! Rejection sampling
    //! 4  key concepts used in the problem
    //! 1. Making Zero Based sampling from 1 .... to n
    //! 2. Expanding a zero-based
    //! 3. Discarding and Rolling again
    //! 4. Folding to map    
    //https://www.youtube.com/watch?v=XyF-Wrkj4Hg
    //https://leetcode.com/problems/implement-rand10-using-rand7/discuss/338395/In-depth-straightforward-detailed-explanation.-(Short-Java-solution)
    //https://leetcode.com/problems/implement-rand10-using-rand7/discuss/150301/Three-line-Java-solution-the-idea-can-be-generalized-to-%22Implement-RandM()-Using-RandN()%22

    public class Solution //: SolBase
    {
        Random random = new Random();
        public int Rand10()
        {
            int x, y, m = 7, num = 40;
            //!how we come up with 40?using formula (7^2/10)*10
            //! start from 7^1 ,7^2,7^3.......till its less than 10. 
            //! Moment its greater then 10 we stop and that is our number 
            //! 7^1>10 --reject
            //! 7^2>10 ---accept 
            //! (49/10)*10=40
            while (num >= 40) //!Discarding and rolling again
            {
                //!Making Zero Based sampling and then expanding Zero Based
                x = Rand7() - 1;  //[0,6]
                y = Rand7() - 1;  //[0,6]
                                  //[0 to 48 will have equal possiblity ]
                                  //![0-6]*7+[0-6]
                num = x * m + y;
            }
            // +1 because num contains values from 0 to n-1 and we need to map them to 1 to n  
            //!Folding to Map
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
