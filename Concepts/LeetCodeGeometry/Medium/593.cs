using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGeometry.Medium
{
    class _593
    {
        /// <summary>
        //!  https://leetcode.com/problems/valid-square/discuss/450879/C-Solution
        //! Put all the sides and diagonal  in hashset. If entry not equal to 2, it means we don't have valid square 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <returns></returns>
        public bool ValidSquare0(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            HashSet<int> hs = new HashSet<int>()
            {
                Distance(p1,p2),
                Distance(p1,p3),
                Distance(p1,p4),
                Distance(p2,p3),
                Distance(p2,p4),
                Distance(p3,p4)
            };
            //For any square, lenght of all sides should be the same a and the length of two diagonals 
            //should be the same b and a != b.So out of the 6 lengths, there should be 2 unique lengths(also a!= 0 and b!= 0).
            //!hs.Contains(0) because if distance is zero among the points than they can't be line
            return !hs.Contains(0) && hs.Count == 2; 
        }


        /// <summary>
        // // # <image url="https://leetcode.com/problems/valid-square/Figures/593_Valid_Square_1.PNG" scale="0.5" />  
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <returns></returns>
        public bool ValidSquare1(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            int[][] array = new int[4][];
            array[0] = p1;
            array[1] = p2;
            array[2] = p3;
            array[3] = p4;

            var sortedPoints = array.OrderBy(x => x[0]).ThenBy(x => x[1]).ToArray();

            bool foursquareSides = Distance(sortedPoints[0], sortedPoints[1]) != 0 &&
                                   Distance(sortedPoints[0], sortedPoints[1]) == Distance(sortedPoints[1], sortedPoints[3]) &&
                                   Distance(sortedPoints[1], sortedPoints[3]) == Distance(sortedPoints[3], sortedPoints[2]) &&
                                   Distance(sortedPoints[3], sortedPoints[2]) == Distance(sortedPoints[2], sortedPoints[0]);


            bool diagonal = Distance(sortedPoints[0], sortedPoints[3]) == Distance(sortedPoints[1], sortedPoints[2]);

            return foursquareSides & diagonal;

        }
        private int Distance(int[] p1, int[] p2)
        {
            return (int)(Math.Pow(p1[0] - p2[0], 2) + Math.Pow(p1[1] - p2[1], 2));
        }

    }
}
