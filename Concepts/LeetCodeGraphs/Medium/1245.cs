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
        /// <summary>
        //! Same as question 1522
        //! Calculate first maximum and second maximum length. Sum of them will give the diameter
        /// </summary>
        public int TreeDiameter0(int[][] edges)
        {

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            BuildGraph(graph, edges);

            bool[] visited = new bool[graph.Count];
            ResultWrapper result = new ResultWrapper();
            DFS(graph, visited, 0, result);

            return result.Diameter;
        }

        private int DFS(Dictionary<int, List<int>> map, bool[] visited, int at, ResultWrapper result)
        {
            if (visited[at])
                return 0;

            visited[at] = true;
            int firstMaxLength = 0;
            int secondMaxLength = 0;

            foreach (int neighbor in map[at])
            {
                if (!visited[neighbor])
                {
                    int length = DFS(map, visited, neighbor, result) + 1;

                    if (length > firstMaxLength)
                    {
                        secondMaxLength = firstMaxLength;
                        firstMaxLength = length;
                    }
                    else if (length > secondMaxLength)
                    {
                        secondMaxLength = length;
                    }
                }
            }
            result.Diameter = Math.Max(result.Diameter, firstMaxLength + secondMaxLength);

            return Math.Max(firstMaxLength, secondMaxLength);
        }

        /// <summary>
        //!Takeaways:
        //! Takeaway 1: Run DFS twice. First to  farthest node and then run DFS from that node to find the distance
        /// </summary>
        public int TreeDiameter(int[][] edges)
        {

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            BuildGraph(graph, edges);

            bool[] visited = new bool[graph.Count];

            (int node, int distance) = FindFurthest(graph, visited, 0);

            //! incase of one node , the diameter is 0

            visited = new bool[graph.Count];

            (int furthestNode, int maxDistance) = FindFurthest(graph, visited, node);

            return maxDistance;
        }



        private (int node, int distance) FindFurthest(Dictionary<int, List<int>> map, bool[] visited, int at)
        {
            if (visited[at])
                return (at, 0);

            visited[at] = true;

            int maxDistance = 0;
            int furthestNode = at;

            List<int> neighbours = map[at];
            foreach (int neighbour in neighbours)
            {
                (int node, int distance) = FindFurthest(map, visited, neighbour);
                if (maxDistance < 1 + distance)
                {
                    maxDistance = 1 + distance;
                    furthestNode = node;
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

    class ResultWrapper
    {
        public int Diameter { get; set; }
    }
}
