using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _785
    {
        public bool IsBipartite(int[][] graph)
        {

            List<List<int>> g = BuildGraph(graph);
            Dictionary<int, int> color = new Dictionary<int, int>();

            for (int i = 0; i < graph.Length; i++)
            {
                color.Add(i, -1);
            }

            for (int i = 0; i < graph.Length; i++)
            {
                if (color[i] == -1)
                {
                    bool result = BFS(i, g,color);
                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool BFS(int i, List<List<int>> g, Dictionary<int, int> color)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(i);
            color[i] = 0;
            while (queue.Count != 0)
            {
                int curr = queue.Dequeue();
                foreach (int neighbour in g[curr])
                {
                    if (color[neighbour] == color[curr])
                    {
                        return false;
                    }

                    if (color[neighbour] == -1)
                    {
                        queue.Enqueue(neighbour);
                        color[neighbour] = 1 - color[curr];
                    }
                }
            }
            return true;
        }

        private List<List<int>> BuildGraph(int[][] graph)
        {
            List<List<int>> g = new List<List<int>>();

            for (int i = 0; i < graph.Length; i++)
            {
                g.Add(new List<int>());
            }

            for (int i = 0; i < graph.Length; i++)
            {

                g[i].AddRange(graph[i]);                
            }

            return g;

        }
    }
}
