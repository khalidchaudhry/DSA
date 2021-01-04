using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGeometry.Medium
{
    public class _963
    {
        public static void _963Main()
        {
            _963 Main = new _963();
            int[][] points = new int[4][]
              {
                  new int[]{1,2},
                  new int[]{2,1},
                  new int[]{1,0 },
                  new int[]{0,1}
              };

            var ans = Main.MinAreaFreeRect(points);

            Console.ReadLine();

        }



        /// <summary>
        //! If two line segments bisects each other and have same mid point and length than they belong to the rectangle 
        //! https://leetcode.com/problems/minimum-area-rectangle-ii/discuss/869489/C%3A-Simple-Intuitive-Code-with-Explanation
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public double MinAreaFreeRect(int[][] points)
        {
            double minAreaRectangle = double.MaxValue;

            Dictionary<(double x, double y, double length), List<(int[] point1, int[] point2)>> map =
                new Dictionary<(double x, double y, double length), List<(int[] point1, int[] point2)>>();


            for (int i = 0; i < points.Length; ++i)
            {
                for (int j = i + 1; j < points.Length; ++j)
                {
                    int[] p1 = points[i];
                    int[] p2 = points[j];

                    //! MidPoint Formula=(x1+x2)/2,(y1+y2)/2
                    double midPointX = (p1[0] + p2[0]) / 2.0;
                    double midPointY = (p1[1] + p2[1]) / 2.0;
                    //!Length formula between two points=sqrt((x2-x1)^2 + (y2-y1)^2)
                    //! we are ignoring sqrt as we are not consdering for all the points(taking sqr of the distance) 
                    double length = Math.Pow(p2[0] - p1[0], 2) + Math.Pow(p2[1] - p1[1], 2);

                    if (!map.ContainsKey((midPointX, midPointY, length)))
                    {
                        map.Add((midPointX, midPointY, length), new List<(int[] point1, int[] point2)>());
                    }

                    map[(midPointX, midPointY, length)].Add((p1, p2));
                }
            }
            //! Determine which has the greatest area

            foreach (var allPoints in map.Values)
            {
                for (int i = 0; i < allPoints.Count; ++i)
                {
                    for (int j = i + 1; j < allPoints.Count; ++j)
                    {
                        int[] point1 = allPoints[i].point1;
                        int[] point2 = allPoints[i].point2;
                        int[] point3 = allPoints[j].point1;
                        //int[] point4 = allPoints[j].point2;
                        //Length formula between two points = sqrt((x2 - x1) ^ 2 + (y2 - y1) ^ 2)
                        //double len1 = Math.Sqrt(Math.Pow(point2[0] - point1[0], 2) + Math.Pow(point2[1] - point1[1], 2));
                        //double len2 = Math.Sqrt(Math.Pow(point4[0] - point3[0], 2) + Math.Pow(point4[1] - point3[1], 2));
                        double firstSidelen = Math.Sqrt(Math.Pow(point1[0] - point3[0],2)  + Math.Pow(point1[1] - point3[1],2));
                        double secondSideLen = Math.Sqrt(Math.Pow(point2[0] - point3[0],2)  + Math.Pow(point2[1] - point3[1],2));

                        //!rectangle area=l*w
                        double area = firstSidelen * secondSideLen;
                        //double area = len1 * len2;
                        minAreaRectangle = Math.Min(minAreaRectangle, area);
                    }
                }
            }

            return minAreaRectangle == double.MaxValue ? 0.0 : minAreaRectangle;

        }

    }
}
