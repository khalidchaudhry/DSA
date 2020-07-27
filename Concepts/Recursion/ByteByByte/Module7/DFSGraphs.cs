using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module7
{
    public class DFSGraphs
    {
        public static void DFSGraphsMain()
        {
            GraphNode[] graph = new GraphNode[6];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new GraphNode(i);
            }

            graph[0].neighbors = new GraphNode[] { graph[1], graph[2], graph[3] };
            graph[1].neighbors = new GraphNode[] { graph[1], graph[4] };
            graph[2].neighbors = new GraphNode[] { graph[2] };
            graph[3].neighbors = new GraphNode[] { graph[1] };
            graph[4].neighbors = new GraphNode[] { graph[1], graph[2], graph[3] };
            graph[5].neighbors = new GraphNode[] { };

            Console.WriteLine(PathExists(graph[0], graph[4]));
        }

        public static bool PathExists(GraphNode src, GraphNode dest)
        {
            return PathExists(src, dest, new HashSet<GraphNode>());
        }

        public List<List<GraphNode>> Paths(GraphNode src, GraphNode dest)
        {
            List<List<GraphNode>> paths = new List<List<GraphNode>>();
            Paths(src, dest, new HashSet<GraphNode>(), new List<GraphNode>(), paths);

            return paths;
        }
        /// <summary>
        //! Only works for graphs that don't have cycles
        /// </summary>
        /// <param name="curr"></param>
        /// <param name="dest"></param>
        /// <param name="visited"></param>
        /// <param name="path"></param>
        /// <param name="paths"></param>
        private void Paths(GraphNode curr, GraphNode dest, HashSet<GraphNode> visited, List<GraphNode> path, List<List<GraphNode>> paths)
        {
            if (visited.Contains(curr)) return;
            if (curr == dest)
            {
                path.Add(curr);
                paths.Add(new List<GraphNode>(path));
                path.RemoveAt(path.Count - 1); //! Backtracking to remove it from the path
            }

            visited.Add(curr);

            foreach (GraphNode neighbor in curr.neighbors)
            {
                Paths(neighbor, dest, visited, path, paths);
            }

            path.RemoveAt(path.Count - 1);//! Backtrack 
            //!Key we have to remove the node from our visted list because visited will will change for the every different path  
            visited.Remove(curr);
        }

        private static bool PathExists(GraphNode curr, GraphNode dest, HashSet<GraphNode> visited)
        {
            if (visited.Contains(curr)) return false;
            if (curr == dest) return true;

            visited.Add(curr);
            foreach (GraphNode n in curr.neighbors)
            {
                if (PathExists(n, dest, visited)) return true;
            }
            return false;
        }
    }
}
