using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRandom.Medium._519
{
    public class _519
    {
        public static void _519Main()
        {


            Solution sol = new Solution(5,5);

            sol.Reset();
            var ans=sol.Flip2();
            sol.Reset();
            var ans2=sol.Flip2();
            sol.Reset();
            var ans3 = sol.Flip2();

            Console.ReadLine();
        }


    }
    /// <summary>
    /// https://leetcode.com/problems/random-flip-matrix/discuss/155341/Easy-Algorithm-Explanation-Step-By-Step.
    /// </summary>
    public class Solution
    {
        Dictionary<int, int> map;
        Random rand;
        int total;
        int rows;
        int columns;
        public Solution(int n_rows, int n_cols)
        {
            rows = n_rows;
            columns = n_cols;

            total = rows * columns;

            map = new Dictionary<int, int>();

            rand = new Random();
        }

        public int[] Flip()
        {

            int r = rand.Next(total--);
            int x = r;
            if (map.ContainsKey(r))
            {
                x = map[r];
                if (map.ContainsKey(total))
                    map[r] = map[total];
                else
                    map[r] = total;
            }
            else
            {
                if (map.ContainsKey(total))
                    map[r] = map[total];
                else
                    map[r] = total;
            }

            return new int[] { x / columns, x % columns };

        }

        //! Implemented based on Kai's  class
        //! Flatten 2d array into 1-d array
        public int[] Flip2()
        {
            int random = rand.Next(total--);
            int ans = 0;
            if (map.ContainsKey(random))
            {
                int value = map[random];
               
                while (true)
                {
                    if (!map.ContainsKey(value))
                    {
                        break;
                    }
                    value = map[value];
                }

                map.Add(value, total);
                ans = value;
            }
            else
            {
                map.Add(random, total);
                ans = random;
            }

            return new int[] { ans / columns, ans % columns };
        }

        public void Reset()
        {
            map = new Dictionary<int, int>();
            total = rows * columns;
        }
    }
}

