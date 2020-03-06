using Graphs.GraphRepresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GeeksForGeeks
{
    public class MotherVertex
    {
        bool[] visited;
        Graph3 graph;
        public MotherVertex(Graph3 g)
        {
            visited = new bool[g.count];
            graph = g;          
        }

        public void Initialize(Graph3 g)
        {
            for (int i = 0; i < g.count; i++)
            {
                visited[i] = false;
            }
        }

        public void DFS(int start,int[] count)
        {
            visited[start] = true;
            ++count[0];           
            foreach (int key in graph.adj[start].Keys)
            {
                if (!visited[key])
                {
                    visited[key] = true;
                    DFS(key,count);
                }
            }

        }



    }
}
