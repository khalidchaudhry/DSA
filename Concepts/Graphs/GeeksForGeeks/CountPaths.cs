using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GeeksForGeeks
{
    public class CountPaths
    {
        private int vertex;
        List<int>[] adjList;
        int pathsLength;
        public CountPaths(int v)
        {
            vertex = v;
            pathsLength = 0;
            adjList = new List<int>[vertex];
            for (int i = 0; i < v; i++)
            {
                adjList[i] = new List<int>();
            }
        }
        public void AddEdge(int src,int dest)
        {
            adjList[src].Add(dest);
        }

        public void  CountPathsBetweenNodes(int src, int dest)
        {
            CountPathsUtil(src, dest);
           Console.WriteLine("No of paths between source: " + src
           + " and destination: " + dest + " are:" + pathsLength);
           
        }
        private void CountPathsUtil(int src, int dest)
        {
            if (src == dest)
            {
                ++pathsLength;
            }
            else
            {
                foreach (int neighbour in adjList[src])
                {
                    CountPathsUtil(neighbour, dest);
                }
            }
        }
    }
}
