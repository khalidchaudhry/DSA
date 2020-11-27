using System;
using System.Collections.Generic;
using System.Text;

namespace HashSet
{
    class _447
    {
        //https://leetcode.com/problems/number-of-boomerangs/discuss/92920/C-HashTable-solution-O(n2)-time-O(n)-space-with-explaination
        public int NumberOfBoomerangs(int[][] points)
        {
            int result = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < points.Length; i++)
            {
                // Keep a lookup of the distance from p0 to all other points
                // if you find another point with same distance give that distance
                // a count of 1 (one other point), if you see another point of this
                // distance move count to 2 and so on.  
                for (int j = 0; j < points.Length; j++)
                {
                    if (i == j) //  point distance to itself is  no distance hence excluding it. 
                        continue;
                    int distance = CalculateDistance(points[i], points[j]);
                    if (map.ContainsKey(distance))
                    {
                        ++map[distance];
                    }
                    else
                    {
                        map.Add(distance, 0);
                    }
                }
                foreach (var value in map.Values)
                {
                    // count number of combinations for groups of equally distanced points
                    /*
                    algorithm actually sets groupCount to zero for the first point, 1 for the second point etc 
                    So, if N == groupCount + 1                    
                    == N * (N - 1)
                    == (groupCount + 1) * ((groupCount + 1) - 1)
                    == (groupCount + 1) * (groupCount)
                    == groupCount * (groupCount + 1)
                    */
                    /*
                    For every i, we capture the number of points equidistant from i.
                    Now for this i, we have to calculate all possible permutations of(j, k) from these equidistant points.
                    Total number of permutations of size 2 from n different points is
                    nP2 = n!/ (n - 2)! = n * (n - 1)
                    */
                    result += value * (value + 1);
                }
                map.Clear();
            }

            return result;
        }

        private int CalculateDistance(int[] a, int[] b)
        {
            // Can overflow happened without square root ?

            // Actual formula to calculate distance between two points is 
            //Distance=sqrt(sqr(x2-x1)+sqr(y2-y1))
            // However in the example  https://leetcode.com/problems/number-of-boomerangs/discuss/92920/C-HashTable-solution-O(n2)-time-O(n)-space-with-explaination
            // it is represented as sqr(x2-x1)+sqr(y2-y1)

            //TODO: need to find out why its working without square root ?
            int x = a[0] - b[0];
            int y = a[1] - b[1];
            return (x * x) + (y * y);
        }


    }
}
