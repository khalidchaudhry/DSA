using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1557
    {
        public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
        {
            List<int> result = new List<int>();
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; ++i)
            {
                graph[i] = new List<int>();
            }

            int[] inDegree = new int[n];
            foreach (List<int> edge in edges)
            {
                int from = edge[0];
                int to = edge[1];
                ++inDegree[to];
            }

            for (int i = 0; i < inDegree.Length; ++i)
            {
                if (inDegree[i] == 0)
                {
                    result.Add(i);
                }
            }

            return result;
        }

    }
}
