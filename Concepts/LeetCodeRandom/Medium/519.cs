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


            Solution sol = new Solution(5, 5);

            sol.Reset();
            var ans = sol.Flip2();
            sol.Reset();
            var ans2 = sol.Flip2();
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
    /// <summary>
    //!Not optimized for space 
    //! As we are filling the values in hashset , then we will increase our calls to random function
    /// </summary>
    public class Solution2
    {

        int rows;
        int columns;
        int total;
        Random random;
        HashSet<int> hs;
        public Solution2(int n_rows, int n_cols)
        {
            rows = n_rows;
            columns = n_cols;
            total = rows * columns;
            random = new Random();
            hs = new HashSet<int>();
        }
        public int[] Flip()
        {
            while (true)
            {
                int value = random.Next(0, total);
                if (!hs.Contains(value))
                {
                    hs.Add(value);
                    return new int[] { value / columns, value % columns };
                }
            }
        }

        public void Reset()
        {
            hs = new HashSet<int>();
        }
    }
}

