using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Greedy.Medium
{
    public class _452
    {
        public static void _452Main()
        {
            int[][] points = new int[4][]
                {
                    new int[2]{10,16},
                    new int[2]{2,8},
                    new int[2]{1,6},
                    new int[2]{7,12 }
                };

            _452 Points = new _452();

            Points.FindMinArrowShots(points);

            Console.ReadLine();
        }
        public int FindMinArrowShots(int[][] points)
        {
            int n = points.Length;

            if (n <= 1)
            {
                return n;
            }

            int[][] sortedPoints=points.OrderBy(x=>x[0]).ToArray();

            int min = sortedPoints[0][0];
            int max = sortedPoints[0][1];
            int minArrows = 1;

            for (int i = 1; i < n; ++i)
            {
                if (sortedPoints[i][0] >= min && sortedPoints[i][0] <= max)
                {                    
                    min = Math.Max(sortedPoints[i][0], min);
                    max = Math.Min(sortedPoints[i][1], max);
                }
                else
                {
                    ++minArrows;
                    min = sortedPoints[i][0];
                    max = sortedPoints[i][1];
                }

            }

            return minArrows;
        }

    }
}
