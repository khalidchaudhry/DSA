using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _70
    {
        public int ClimbStairs(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 2;
            }
            return ClimbStairs(n-1)+ClimbStairs(n-2);

        }

        public int ClimbStairs2(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            //n+1=because we are not considering index 0
            int[] numberOfWays = new int[n + 1];
            // number of ways to go to step1 is 1 
            // number of ways to go to step2 is 2 
            //i.e. One way=1 step and 1 step
            //i.e  Second way=2 step
            numberOfWays[1] = 1;
            numberOfWays[2] = 2;

            for (int i = 3; i <= n; i++)
            {
                numberOfWays[i] = numberOfWays[i - 1] + numberOfWays[i - 2];
            }

            return numberOfWays[n];


        }


    }
}
