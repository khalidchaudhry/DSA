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
            Dictionary<string, string> containedBy = new Dictionary<string, string>();


            foreach (IList<string> region in regions)
            {
                for (int i = 1; i < region.Count; i++)
                {
                    containedBy.Add(region[i], region[0]);
                }
            }
            //!Build the ancesstory for region 1
            HashSet<string> visited = new HashSet<string>();
            string parentRegion1 = region1;
            while (containedBy.ContainsKey(parentRegion1))
            {
                visited.Add(parentRegion1);
                parentRegion1 = containedBy[parentRegion1];
            }
            //! start searching region 2 in ancesstory list we build . The first match will be the first 
            string parentRegion2 = region2;
            while (containedBy.ContainsKey(parentRegion2))
            {
                if (visited.Contains(parentRegion2))
                {
                    return parentRegion2;
                }
                parentRegion2 = containedBy[parentRegion2];
            }
            return parentRegion2;
        }
    }
}
