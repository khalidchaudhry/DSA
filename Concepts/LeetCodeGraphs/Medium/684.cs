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

            int[] parent = new int[nodesCount + 1];

            for (int i = 0; i <= nodesCount; i++)
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
        /// <summary>
        //! using union by rank and path compression
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int[] FindRedundantConnection2(int[][] edges)
        {
            int nodesCount = edges.Count();

            Subset[] subsets = new Subset[nodesCount];

            for (int i = 0; i < nodesCount + 1; i++)
            {
                subsets[i] = new Subset();
                // assigning node to parent of self
                subsets[i].parent = i;
                subsets[i].rank = 0;
            }


            // Iterate through all edges of graph, find subset of both 
            // vertices of every edge, if both subsets are same, then 
            // there is a redundant connection in graph. 

            for (int i = 0; i < edges.Count(); i++)
            {
                int x = Find2(subsets, edges[i][0]);
                int y = Find2(subsets, edges[i][1]);
                if (x == y)
                {
                    return new int[] { edges[i][0], edges[i][1] };
                }

                Union2(subsets, x, y);
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
        //!Utility function to find the subset of an element i(uses PathCompression)
        private int Find2(Subset[] subsets, int i)
        {
            //! continue till root is not the parent of itself
            if (subsets[i].parent != i)
            {
                subsets[i].parent = Find2(subsets, subsets[i].parent);
            }

            // return parent. 
            return subsets[i].parent;
        }

        // A utility function to do union of two subsets 
        private void Union(int[] parent, int x, int y)
        {
            int xset = Find(parent, x);
            int yset = Find(parent, y);
            // Making yset parent of xset.
            parent[xset] = yset;
        }
        //!Union by rank
        //!Both trees have the same rank – the resulting set’s rank is one larger
        //!Both trees have the different ranks – 
        //!the resulting set’s rank is the larger of the two.
        //!Ranks are used instead of height or depth because path compression will change the trees’ heights over time.
        private void Union2(Subset[] subsets, int x, int y)
        {
            int xroot = Find2(subsets, x);
            int yroot = Find2(subsets, y);
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
}
