using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _70
    {


        //!Recursion with memo
        //! Time =O(N) 
        //! Space=O(N)
        public int ClimbStairs(int n)
        {

            Dictionary<int, int> memo = new Dictionary<int, int>();
            return ClimbStairs(n, memo);
        }

        private int ClimbStairs(int n, Dictionary<int, int> memo)  //!Function states n
        {
            if (n <= 1)
            {
                return 1;
            }

            if (memo.ContainsKey(n))
            {
                return memo[n];
            }

            int count = 0;
            count += ClimbStairs(n - 1, memo);
            count += ClimbStairs(n - 2, memo);

            memo[n] = count;

            return memo[n];
        }

        public int ClimbStairs1(int n)
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
