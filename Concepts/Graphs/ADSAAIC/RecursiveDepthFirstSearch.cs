using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.ADSAAIC
{
    public class RecursiveDepthFirstSearch
    {
        int vertex;
        List<int>[] adjList;
        bool[] visited;
        int time = 0;
        int[] discoveryTime;
        int[] finishingTime;
        public RecursiveDepthFirstSearch(int v)
        {
            vertex = v;
            visited = new bool[vertex];
            time = 0;

            adjList = new List<int>[vertex];
            for (int i = 0; i < vertex; i++)
            {
                adjList[i] = new List<int>();
            }

            discoveryTime = new int[vertex];
            for (int i = 0; i < vertex; i++)
            {
                discoveryTime[i] = 0;
            }

            finishingTime = new int[vertex];
            for (int i = 0; i < vertex; i++)
            {
                finishingTime[i] = 0;
            }
        }
        public void AddEdge(int src, int dest)
        {
            adjList[src].Add(dest);
        }

        public void DFSTraversal(int start)
        {
            DFSUtil(start);

            for (int i = 0; i < vertex; i++)
            {
                Console.WriteLine($"Vertex: {i} ");
                Console.Write($"Discovery Time: {discoveryTime[i]} ");
                Console.WriteLine($"Finishing TIme: {finishingTime[i]} ");

            }


        }
        private void DFSUtil(int src)
        {
            visited[src] = true;
            discoveryTime[src] =++time;
            foreach (int neighbour in adjList[src])
            {
                if (!visited[neighbour])
                {
                    DFSUtil(neighbour);
                }
            }
            finishingTime[src] = ++time;
        }
    }
}
