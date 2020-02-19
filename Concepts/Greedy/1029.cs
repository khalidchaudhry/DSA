using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greedy
{
    class _1029
    {
        public int TwoCitySchedCost(int[][] costs)
        {
            int minCost = 0;
            int cityACount = 0;
            int cityBCount = 0;
            int totalCandidates = costs.Length;

            for (int i = 0; i < costs.Length; i++)
            {
                // if cost of city A is less 
                if (costs[i][0] <= costs[i][1])
                {
                    if (cityACount < totalCandidates / 2)
                    {
                        minCost += costs[i][0];
                        ++cityACount;
                    }
                    else
                    {
                        minCost += costs[i][1];
                        ++cityBCount;
                    }
                }
                // if city B cost is less
                else
                {
                    if (cityBCount < totalCandidates / 2)
                    {
                        minCost += costs[i][1];
                        ++cityBCount;
                    }
                    else
                    {
                        minCost += costs[i][0];
                        ++cityACount;

                    }
                }
            }

            return minCost;

        }

        public int TwoCitySchedCost2(int[][] costs)
        {

            Array.Sort(costs, new CompareClass());
            var n = costs.Length / 2;

            var totalCost = 0;
            for (var i = 0; i < n; ++i)
                totalCost += costs[i][0] + costs[i + n][1];
            return totalCost;
        }

        public int TwoCitySchedCost3(int[][] costs)
        {
            int total = 0;
            // Sort by a gain which company has 
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
        public class CompareClass : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                var x = (int[])a;
                var y = (int[])b;
                return (x[0] - x[1]) - (y[0] - y[1]);
            }
        }
    }
}
