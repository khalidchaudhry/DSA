using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _886
    {
        /// <summary>
        //! Same as Leetcode 785 
        /// </summary>
        public bool PossibleBipartition(int N, int[][] dislikes)
        {
            Dictionary<int, List<int>> graph = BuildGraph(N, dislikes);
            Dictionary<int, int> color = new Dictionary<int, int>();

            for (int i = 1; i <= N; ++i)
            {
                color[i] = -1;
            }

            foreach (var keyValue in graph)
            {
                if (color[keyValue.Key] == -1)
                {
                    bool result = BFS(keyValue.Key, graph, color);
                    if (!result)
                        return false;
                }
            }

            return true;
        }

        private bool BFS(int start,
                         Dictionary<int, List<int>> graph,
                         Dictionary<int, int> color
                        )
        {
            Queue<int> queue = new Queue<int>();
            color[start] = 0;
            queue.Enqueue(start);

            while (queue.Count != 0)
            {
                int curr = queue.Dequeue();
                List<int> neighbors = graph[curr];

                foreach (int neighbor in neighbors)
                {
                    if (color[neighbor] == color[curr])
                    {
                        return false;
                    }

                    if (color[neighbor] == -1)
                    {

                        color[neighbor] = 1 - color[curr];
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return true;
        }

        private Dictionary<int, List<int>> BuildGraph(int n, int[][] dislikes)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 1; i <= n; ++i)
            {
                graph.Add(i, new List<int>());
            }
            foreach (int[] dislike in dislikes)
            {
                graph[dislike[0]].Add(dislike[1]);
                graph[dislike[1]].Add(dislike[0]);
            }

            return graph;
        }
    }
}
