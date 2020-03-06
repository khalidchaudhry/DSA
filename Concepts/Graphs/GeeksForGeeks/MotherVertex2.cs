using Graphs.GraphRepresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GeeksForGeeks
{
    public class MotherVertex2
    {
        public int count { get; }
        public Dictionary<int, int>[] adj { get; }

        public MotherVertex2(int cnt)
        {
            count = cnt;
            adj = new Dictionary<int, int>[count];
            for (int i = 0; i < count; i++)
            {
                adj[i] = new Dictionary<int, int>();
            }
        }
        public void AddDirectedEdge(int src, int dst)
        {
            var dictionary = adj[src];
            dictionary.Add(dst, 1);
            adj[src] = dictionary;
        }
        public void AddDirectedEdge(int src, int dst, int cst)
        {
            var dictionary = adj[src];
            dictionary.Add(dst, cst);
            adj[src] = dictionary;
        }
        public void DFSUtil(int v,bool[] visited)
        {
            // Mark the current node as visited
            visited[v] = true;
            foreach (int key in adj[v].Keys)
            {
                if (!visited[key])
                {
                    visited[key] = true;
                    DFSUtil(key,visited);
                }
            }
        }
        public int FindMother()
        {
            // visited[] is used for DFS. Initially all are 
            // initialized as not visited 
            bool[] visited = new bool[count];
            for (int i = 0; i < count; i++)
            {
                visited[i] = false;
            }
            // To store last finished vertex (or mother vertex) 
            int v = 0;

            // Do a DFS traversal and find the last finished 
            // vertex   
            for (int i = 0; i < count; i++)
            {
                if (visited[i] == false)
                {
                    DFSUtil(i, visited);
                    v = i;
                }
            }

            // If there exist mother vertex (or vetices) in given 
            // graph, then v must be one (or one of them) 

            // Now check if v is actually a mother vertex (or graph 
            // has a mother vertex).  We basically check if every vertex 
            // is reachable from v or not. 

            // Reset all values in visited[] as false and do  
            // DFS beginning from v to check if all vertices are 
            // reachable from it or not. 
             for (int i = 0; i < count; i++)
            {
                visited[i] = false;
            }
            DFSUtil(v, visited);
            for (int i = 0; i < count; i++)
                if (visited[i] == false)
                    return -1;

            return v;
        }

    }
}
