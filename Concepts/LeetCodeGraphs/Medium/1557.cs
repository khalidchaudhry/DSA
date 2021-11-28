using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1557
    {
        /// <summary>
        //! Time Complexity=O(n) where n are the number of nodes in the graph
        //! Space Compleity=O(n)
        /// </summary>
        public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
        {
            int[] indegree = new int[n];
            foreach (IList<int> edge in edges)
            {
                int from = edge[0];
                int to = edge[1];
                ++indegree[to];
            }
            List<int> result = new List<int>();
            for (int i = 0; i < n; ++i)
            {
                if (indegree[i] == 0)
                {
                    result.Add(i);
                }
            }
            return result;
        }

    }
}
