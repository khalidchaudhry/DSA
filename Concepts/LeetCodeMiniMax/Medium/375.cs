using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMiniMax.Medium
{
    public class _375
    {



        /// <summary>
        //! Memoization
        /// https://www.youtube.com/watch?v=DMsjVzboYnI
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int GetMoneyAmount(int n)
        {
            Dictionary<(int i, int j), int> memo = new Dictionary<(int i, int j), int>();
            return GetMoneyAmount(1, n, memo);

        }

        /// <summary>
        //! Brute Force
        /// https://www.youtube.com/watch?v=DMsjVzboYnI
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int GetMoneyAmount2(int n)
        {

            return GetMoneyAmount2(1, n);

        }
        private int GetMoneyAmount(int start, int end, Dictionary<(int i, int j), int> memo)
        {
            if (start >= end)
                return 0;
            if (memo.ContainsKey((start, end)))
            {
                return memo[(start, end)];
            }

            int output = int.MaxValue;
            //f(1,10)=Min(
            // 1+ f(2,10)
            // 2+ Max(f(3,10),f(1,2))
            // 3+ Max(f(4,10),f(1,2))
            // 4+ Max(f(5,10),f(1,4))
            //...
            //10 + Max(f(1,9))

            for (int i = start; i <= end; ++i)
            {
                //!Min because we are trying to find the minimum amount of money needed to win the game 
                //! Max becuase oponent can come up with the number that would force us to go to other way
                output = Math.Min(output,
                                  i + Math.Max(GetMoneyAmount(i + 1, end, memo),
                                               GetMoneyAmount(start, i - 1, memo)));
               
            }

            memo.Add((start, end), output);

            return memo[(start,end)];

        }


        private int GetMoneyAmount2(int start, int end)
        {
            if (start >= end)
                return 0;

            int output = int.MaxValue;
            //f(1,10)=Min(
            // 1+ f(2,10)
            // 2+ Max(f(3,10),f(1,2))
            // 3+ Max(f(4,10),f(1,2))
            // 4+ Max(f(5,10),f(1,4))
            //...
            //10 + Max(f(1,9))

            for (int i = start; i <= end; ++i)
            {
                //!Min because we are trying to find the minimum amount of money needed to win the game 
                //! Max becuase oponent can come up with the number that would force us to go to other way
                output = Math.Min(output,
                                  i + Math.Max(GetMoneyAmount2(i + 1, end),
                                               GetMoneyAmount2(start, i - 1)));
            }

            return output;

        }
    }
}
