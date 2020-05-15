using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryAlgorithms.TreeCenter
{
    /*
     ! Notice that the center is always the middle vertex or middle two vertices in every longest path along the tree. 
    */
    public class TreeCenter
    {
        /*
         ! Approach is to find the center is to iteratively pick off each leaf node layer like we were peeling an onion 
         */
        public static List<int> FindTreeCenters(List<List<int>> tree)
        {
            int n = tree.Count;
            int[] degree = new int[n];

            // Find all leaf nodes. Most recent layer of leaf nodes 
            List<int> leaves = new List<int>();
            //! Compute the degree of the node. 
            for (int i = 0; i < n; i++)
            {              
                List<int> edges = tree[i];
                degree[i] = edges.Count;
                // ! if node is having zero or 1  neighbour than its leaf node. 
                if (degree[i] <= 1)
                {
                    leaves.Add(i);
                    degree[i] = 0;
                }
            }
            int processedLeafs = leaves.Count;
            //! Remove leaf nodes and decrease the degree of each node adding new leaf nodes progressively
            // ! until only the center(s) remain.
            //! The way we are going to know that we found center or centers is when we have processed all the nodes in the tree
            while (processedLeafs < n)
            {
                List<int> newLeaves = new List<int>();
                foreach (int node in leaves)
                {
                    foreach (int neighbor in  tree[node])
                    {
                        if (--degree[neighbor] == 1)
                        {
                            newLeaves.Add(neighbor);
                        }
                    }
                    //! every time we finished processing formal leaf node , explicitly give it a degree of 0 to marked it as done 
                    degree[node] = 0;
                }
                processedLeafs += newLeaves.Count;
                leaves = newLeaves;
            }

            return leaves;
        }
    }
}
