using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GeeksForGeeks
{
    public class CountTrees
    {
        int vertex;
        bool[] visited;
        List<int>[] adjList;
        int result;
        public CountTrees(int v)
        {
            vertex = v;
            result = 0;
            visited = new bool[vertex];
            adjList = new List<int>[vertex];
            for (int i = 0; i < vertex; i++)
            {
                adjList[i] = new List<int>();
            }        
        }
        public void AddEdge(int src,int dest)
        {
            adjList[src].Add(dest);
        }
        public int CountTreesInForest()
        {
            for (int i = 0; i < vertex; i++)
            {
                if (visited[i] == false)
                {
                    DFSUtil(i);
                    ++result;
                }
            }

            return result;
        }

        private void DFSUtil(int i)
        {
            visited[i] = true;
            foreach (int neighbour in adjList[i])
            {
                if (!visited[neighbour])
                {
                    DFSUtil(neighbour);
                }
            }
        }



    }
}
