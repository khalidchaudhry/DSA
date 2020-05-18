using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _684
    {
        public int[] FindRedundantConnection(int[][] edges)
        {
            int nodesCount = edges.Count();

            int[] parent = new int[nodesCount+1];

            for (int i = 0; i <=nodesCount; i++)
            {
                parent[i] = -1;
            }

            // Iterate through all edges of graph, find subset of both 
            // vertices of every edge, if both subsets are same, then 
            // there is a redundant connection in graph. 

            for (int i = 0; i < edges.Count(); i++)
            {
                int x = Find(parent, edges[i][0]);
                int y = Find(parent, edges[i][1]);
                if (x == y)
                {
                    return new int[] { edges[i][0], edges[i][1] };
                }

                Union(parent, x, y);
            }

            return new int[] { -1, -1 };
        }

        // A utility function to find the subset of an element i 
        private int Find(int[] parent, int i)
        {
            if (parent[i] == -1)
                return i;
            return Find(parent, parent[i]);
        }

        // A utility function to do union of two subsets 
        private void Union(int[] parent, int x, int y)
        {
            int xset = Find(parent, x);
            int yset = Find(parent, y);
            // Making yset parent of xset.
            parent[xset] = yset;
        }



    }
}
