using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Easy
{
    public class _1042
    {
        public int[] GardenNoAdj(int N, int[][] paths)

        {
            int[] answer = new int[N];
            int[] flowerTypes = new int[4] { 1, 2, 3, 4 };
            // map will contain garden(garden id)  and its neighboring gardens
            Dictionary<int, List<int>> graph = BuildGraph(paths);
            // iterating entries in map and assign them flower types
            foreach (var node in graph)
            {
                HashSet<int> hs = new HashSet<int>();
                // Adding flower type to hashset already assigned to neighbour(s)
                // so that we assign garden different flower type than its neighbours 
                foreach (var neighbour in node.Value)
                {
                    if (answer[neighbour - 1] != 0)
                    {
                        hs.Add(answer[neighbour - 1]);
                    }
                }
                // Purpose of below loop is to assign flower type to garden that is not assign to any of its neighbours  
                int choosenFlowerType = 0;
                for (int i = 0; i < flowerTypes.Length; i++)
                {
                    if (!hs.Contains(flowerTypes[i]))
                    {
                        choosenFlowerType = flowerTypes[i];
                        break;
                    }
                }
                // assigning flower type to the garden
                answer[node.Key - 1] = choosenFlowerType;
            }

            // If answer array entries still contains zero it means some gardens are not conencted by paths and 
            // we need to assign any(because they are not connected) flower types to them 
            // Below i am choosing flowerType 1 to them
            for (int i = 0; i < answer.Length; i++)
            {
                if (answer[i] == 0) // only those gardens that don't have flower type assigned to them 
                {
                    // it does not matter what flower type we are assigning to them. 
                    answer[i] = flowerTypes[0];
                }
            }

            return answer;
        }

        private Dictionary<int, List<int>> BuildGraph(int[][] paths)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            foreach (int[] path in paths)
            {
                // ! As the graph is bidirectional , we are adding  both the nodes 
                if (graph.ContainsKey(path[0]))
                {
                    graph[path[0]].Add(path[1]);
                }
                else
                {
                    graph.Add(path[0], new List<int>() { path[1] });
                }

                if (graph.ContainsKey(path[1]))
                {
                    graph[path[1]].Add(path[0]);
                }
                else
                {
                    graph.Add(path[1], new List<int>() { path[0]});
                }
            }

            return graph;
        }      
    }
}
