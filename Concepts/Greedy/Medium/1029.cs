using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greedy
{
    class _1029
    {
        public static void _1029Main()
        {

            int[][] costs = new int[2][]
            {
                new int[]{10,20},
                new int[]{30,200}
            };
            _1029 TwoCities = new _1029();
            TwoCities.TwoCitySchedCost1(costs);

        }
        public int TwoCitySchedCost0(int[][] costs)
        {
            int total = 0;
            //!Sort by a gain which company has 
            // by sending a person to city A and not to city B
            //// To optimize the company expenses,
            //values at the beginning of the sorted array will have the lowest cost for city A, 
            //and those nearing the end will have the lowest cost for city B.

            var sortedCost = costs.OrderBy(c => (c[0] - c[1]));
            int n = 0;
            // To optimize the company expenses,
            // send the first n persons to the city A
            // and the others to the city B
            foreach (int[] cost in sortedCost)
            {
                if (n >= costs.Length / 2)
                {
                    total += cost[1];
                }
                else
                {
                    total += cost[0];
                }

                ++n;
            }


            return total;
        }
        /// <summary>
        //! using custom sorting as input
        /// </summary>
        /// <param name="costs"></param>
        /// <returns></returns>
        public int TwoCitySchedCost1(int[][] costs)
        {

            var comparer = Comparer<int[]>.Create((x, y) =>
            {
                return (x[0] - x[1]) - (y[0] - y[1]);
            });

            Array.Sort(costs, comparer);
            var n = costs.Length / 2;

            var totalCost = 0;
            for (var i = 0; i < n; ++i)
                totalCost += costs[i][0] + costs[i + n][1];
            return totalCost;
        }
        
    }
}
