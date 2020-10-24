using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1245
    {


        public static void _1245Main()
        {
            _1245 TreeDiameter = new _1245();
            int[][] edges = new int[2][]
            {
              new int[]{0,1 },
              new int[]{0,2 }
            };

            var ans = TreeDiameter.TreeDiameter(edges);

            Console.ReadLine();

        }
        public int TreeDiameter(int[][] edges)
        {

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            BuildGraph(graph, edges);

            bool[] visited = new bool[graph.Count];

            (int root, int distance) = FindFurthest(graph, visited, 0);

            //! incase of one node , the diameter is 0

            visited = new bool[graph.Count];

            (int furthestNode, int maxDistance) = FindFurthest(graph, visited, root);

            return maxDistance;
        }

        private (int node, int distance) FindFurthest(Dictionary<int, List<int>> map, bool[] visited, int at)
        {
            visited[at] = true;

            int maxDistance = 0;
            int furthestNode = at;

            List<int> neighbours = map[at];
            foreach (int neighbour in neighbours)
            {
                if (!visited[neighbour])
                {
                    (int node, int distance) = FindFurthest(map, visited, neighbour);
                    if (maxDistance < distance + 1)
                    {
                        maxDistance = distance+1;
                        furthestNode = node;
                    }
                }
            }

            return (furthestNode, maxDistance);
        }

        private void BuildGraph(Dictionary<int, List<int>> graph, int[][] edges)
        {
            for (int i = 0; i <= edges.Length; ++i)
            {
                graph[i] = new List<int>();
            }

            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
        }
    }
}
