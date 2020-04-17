using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryAlgorithms.DFS
{
    public class DepthFirstSearchAdjacencyListRecursive
    {
        public long DFS(int at, bool[] visited, Dictionary<int, List<Edge>> graph)
        {
            if (visited[at])
                return 0;
            visited[at] = true;

            long count = 1;
            // Visit all edges adjacent to where we're at
            graph.TryGetValue(at, out List<Edge> neighbours);

            if (neighbours != null)
            {
                foreach (Edge neighbour in neighbours)
                {
                    count += DFS(neighbour.to, visited, graph);
                }
            }

            return count;
        }
    }   
}
