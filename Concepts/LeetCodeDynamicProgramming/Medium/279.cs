using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _279
    {


        public static void _279Main()
        {
            _279 NumSquares = new _279();
            var result = NumSquares.NumSquares1(12);
            Console.ReadLine();
        }
        /// <summary>
        /// https://leetcode.com/problems/perfect-squares/solution/
        //! Find the shortest path from n to 0        
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumSquares1(int n)
        {
            List<int> squares = new List<int>();
            for (int i = 1; i * i <= n; ++i)
            {
                squares.Add(i * i);
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);
            int level = 0;
            while (queue.Count != 0)
            {
                ++level;
                int count = queue.Count;
                HashSet<int> hs = new HashSet<int>();
                while (count != 0)
                {
                    int dequeue = queue.Dequeue();

                    foreach (int square in squares)
                    {
                        int diff = dequeue - square;
                        //!we reach to the target 0(we started from n)
                        if (diff == 0)
                        {
                            return level;
                        }
                        //! if in negative than this square and rest of them will not reach to the target
                        else if (diff < 0)
                            break;
                        else
                        //! incase of duplicates , we don't need to add more than once 
                        //! hs is just optimizatin . It will still work without it
                            if (!hs.Contains(diff))
                        {
                            queue.Enqueue(diff);
                        }
                    }

                    --count;
                }
            }

            return level;

        }


        /// <summary>
        //! Memoization
        //! not very clear to me
        //https://www.youtube.com/watch?v=qAOXXJPattQ
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumSquares2(int n)
        {
            int[] memo = new int[n + 1];

            var ans = Helper(n, memo);

            return memo[0];
        }
        /// <summary>
        //! Brute force
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumSquares3(int n)
        {
            int sqrt = (int)Math.Sqrt(n);
            //!This element is the perfect square e.g. 9
            if (sqrt * sqrt == n)
            {
                return 1;
            }
            //!least number of perfect square numbers
            //! in a worst case scenrio , all 1 squares will make the number
            //! e.g. 13 =1^2 +1^2+1^2............
            int lnops = n;
            //! sqrt +1 because we need to try sqrt number too like for 12 we need to try 3 too 
            //! < sqrt will only include 1 and 2 but have to include 3 as well 
            for (int i = 1; i < sqrt + 1; ++i)
            {
                lnops = Math.Min(lnops, NumSquares3(n - i * i));
            }

            return lnops + 1;
        }

        private int Helper(int n, int[] memo)
        {
            if (memo[n] != 0)
                return memo[n];

            int sqrt = (int)Math.Sqrt(n);
            //!This element is the perfect square e.g. 9
            if (sqrt * sqrt == n)
            {
                memo[n] = 1;
                return memo[n];
            }
            else
            {
                //!least number of perfect square numbers
                //! in a worst case scenrio , all 1 squares will make the number
                //! e.g. 13 =1^2 +1^2+1^2............
                int lnops = n;
                //! sqrt +1 because we need to try sqrt number too like for 12 we need to try 3 too 
                //! < sqrt will only include 1 and 2 but have to include 3 as well 
                for (int i = 1; i < sqrt + 1; ++i)
                {
                    lnops = Math.Min(lnops, Helper(n - i * i, memo));
                }
                memo[n] = lnops + 1;

                return memo[n];
            }
        }
    }




}
