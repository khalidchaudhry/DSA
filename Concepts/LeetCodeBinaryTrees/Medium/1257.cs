using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _1257
    {
        public static void _1257Main()
        {

        }
        /// <summary>
        /// https://leetcode.com/problems/smallest-common-region/discuss/430500/JavaPython-3-Lowest-common-ancestor-w-brief-explanation-and-analysis.
        /// </summary>      
        public string FindSmallestRegion(IList<IList<string>> regions, string region1, string region2)
        {
            //! First create the map with CHILD PARENT relation
            Dictionary<string, string> parents = new Dictionary<string, string>();


            foreach (IList<string> region in regions)
            {
                for (int i = 1; i < region.Count; i++)
                {
                    parents.Add(region[i], region[0]);
                }
            }
            //!Build the ancesstory for region 1
            HashSet<string> ancesstory = new HashSet<string>();
            while (parents.ContainsKey(region1))
            {
                ancesstory.Add(region1);
                region1 = parents[region1];
            }
            //! start searching region 2 in ancesstory list we build . The first match will be the first 
            while (parents.ContainsKey(region2))
            {
                if (ancesstory.Contains(region2))
                {
                    return region2;
                }
                region2 = parents[region2];
            }
            return region2;
        }
    }
}
