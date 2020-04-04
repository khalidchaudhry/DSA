using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GeeksForGeeks.UnionFindByRankAndPathCompression
{
    class Graph
    {
        public int V, E;
        public Edge[] Edges;

        public Graph(int v, int e)
        {
            this.V = v;
            this.E = e;
            Edges = new Edge[this.E];

            for (int i = 0; i < E; i++)
            {
                Edges[i] = new Edge();
            }
        }

        // The main function to check whether  
        // a given graph contains cycle or not  
        public bool IsCycle(Graph graph)
        {
            int V = graph.V;
            int E = graph.E;

            Subset[] subsets = new Subset[V];
            for (int v = 0; v < V; v++)
            {
                subsets[v] = new Subset();
                // assigning node to parent of self
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }
            for (int e = 0; e < E; e++)
            {
                int x = Find(subsets, graph.Edges[e].src);
                int y = Find(subsets, graph.Edges[e].dest);
                if (x == y)
                {
                    return true;
                }
                Union(subsets, x, y);
            }
            return false;
        }

        // A utility function to find  
        // set of an element i (uses  
        // path compression technique)  
        private int Find(Subset[] subsets, int i)
        {
            // continue till root is not the parent of itself
            if (subsets[i].parent != i)
            {
                subsets[i].parent = Find(subsets, subsets[i].parent);
            }
            // return parent. 
            return subsets[i].parent;
        }
        // A function that does union  
        // of two sets of x and y  
        // (uses union by rank)  
        private void Union(Subset[] subsets, int x, int y)
        {
            int xroot = Find(subsets, x);
            int yroot = Find(subsets, y);
            // if xroot.rank is less than yroot.rank 
            if (subsets[xroot].rank < subsets[yroot].rank)
            {
                // making yroot parent of xroot
                subsets[xroot].parent = yroot;
            }
            // if yroot.rank is less than xroot.rank 
            else if (subsets[yroot].rank < subsets[xroot].rank)
            {
                // making xroot parent of yroot
                subsets[yroot].parent = xroot;
            }
            // of both x and y root ranks are equal
            else
            {
                // make yroot parent of xroot
                subsets[xroot].parent = yroot;
                // increment rank value of yroot
                subsets[yroot].rank++;
            }
        }

    }

    class Subset
    {
        public int parent;
        public int rank;
    }
    class Edge
    {
        public int src;
        public int dest;
    }
}