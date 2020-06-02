using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    public class _624
    {
        /// <summary>
        /// https://medium.com/@Zack123456/624-maximum-distance-in-arrays-ab285c171304
        /// </summary>
        /// <param name="arrays"></param>
        /// <returns></returns>
        public int MaxDistance(IList<IList<int>> arrays)
        {
            int maxDistance = 0;

            int minHead = arrays[0][0];
            int maxTail = arrays[0][arrays[0].Count - 1];

            for (int i = 1; i < arrays.Count; i++)
            {
                int currMin = arrays[i][0];
                int currMax = arrays[i][arrays[i].Count - 1];
                //!keep a track of the maximum distance found so far.
                maxDistance = Math.Max(maxDistance,Math.Max(Math.Abs(minHead - currMax), Math.Abs(maxTail - currMin)));
                //!keep a track of the element with minimum value(minHead) and the one with maximum value(maxTail) found so far.
                minHead = currMin < minHead ? currMin : minHead;
                maxTail = currMax > maxTail ? currMax : maxTail;

            }

            return maxDistance;
        }
        /// <summary>
        /// https://leetcode.com/problems/maximum-distance-in-arrays/solution/
        /// Brute force
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int MaxDistance2(IList<IList<int>> list)
        {
            int res = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    res = Math.Max(res, Math.Abs(list[i][0] - list[j][list[j].Count - 1]));
                    res = Math.Max(res, Math.Abs(list[j][0] - list[i][list[i].Count - 1]));
                }
            }
            return res;
        }


    }
}
