using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBitManipulation.Medium
{
    public class _397
    {
        public static void _397Main()
        {

            _397 IntegerReplacement = new _397();
            int num = 8;

            var result = IntegerReplacement.IntegerReplacement1(num);

            Console.ReadLine();

        }
        /// <summary>
        //! Optimzation rather then going both with n+1 and n-1 , we go with the one that turns out tobe even
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>

        public int IntegerReplacement0(int n)
        {
            return IntegerReplacement0((long)n);
        }

        private int IntegerReplacement0(long n)
        {
            if (n <= 1)
                return 0;
            //! Special case when n=3 otherwise it will pick up n+1 where as n-1 results in less steps
            //! n=3  4-->2-->1
            //!      2->1
            if (n == 3)
                return 2;

            int min = 0;
            // For even divide by 2 else take minimum of n+1 and n-1
            if (n % 2 == 0)
                min = 1 + IntegerReplacement0(n / 2);
            else
            {               
                if (((n + 1) / 2) % 2 == 0)
                {
                    min = 1 + IntegerReplacement0(n + 1);
                }
                else
                {
                    min = 1 + IntegerReplacement0(n - 1);
                }
            }
            return min;
        }

        /// <summary>
        //!DP Memoization
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int IntegerReplacement1(int n)
        {
            Dictionary<long, int> map = new Dictionary<long, int>();
            return IntegerReplacement1(n, map);
        }
        private int IntegerReplacement1(long n, Dictionary<long, int> map)
        {
            if (n <= 1)
                return 0;

            if (map.ContainsKey(n))
            {
                return map[n];
            }
            else
            {
                int min = 0;
                // For even divide by  2 else take minimum of n+1 and n-1
                if (n % 2 == 0)
                {
                    min = 1 + IntegerReplacement1(n / 2, map);
                }
                else
                {
                    min = 1 + Math.Min(IntegerReplacement1(n + 1, map), IntegerReplacement1(n - 1, map));
                }

                map[n] = min;

                return map[n];
            }
        }

        /// <summary>
        //! Brute Force 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int IntegerReplacement2(int n)
        {
            return IntegerReplacement2((long)n);
        }


        public int IntegerReplacement2(long n)
        {
            if (n <= 1)
                return 0;
            int min = 0;
            // For even divide by  2 else take minimum of n+1 and n-1
            if (n % 2 == 0)
                min = 1 + IntegerReplacement2(n / 2);
            else
                min = 1 + Math.Min(IntegerReplacement2(n + 1), IntegerReplacement2(n - 1));
            return min;
        }

    }
}
