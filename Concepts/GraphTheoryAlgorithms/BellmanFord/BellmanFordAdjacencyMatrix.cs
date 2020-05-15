using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryAlgorithms.BellmanFord
{
    //! not producing the correct output
    class BellmanFordAdjacencyMatrix
    {
        private int n, start;
        private bool solved;
        private double[] dist;
        private int[] prev;
        private double[][] matrix;

        /**
       * An implementation of the Bellman-Ford algorithm. The algorithm finds the shortest path between
       * a starting node and all other nodes in the graph. The algorithm also detects negative cycles.
       * If a node is part of a negative cycle then the minimum cost for that node is set to
       * Double.NEGATIVE_INFINITY.
       *
       * @param graph - An adjacency matrix containing directed edges forming the graph
       * @param start - The id of the starting node
       */
        public BellmanFordAdjacencyMatrix(int start, double[][] matrix)
        {
            this.n = matrix.Length;
            this.start = start;
            this.matrix = new double[n][];
            prev = Enumerable.Repeat(int.MaxValue, n).ToArray();


            // Copy input adjacency matrix.

            for (int i = 0; i < n; i++)
            {
                this.matrix[i] = new double[n];
                this.matrix[i] = matrix[i];
            }          

        }
        public double[] GetShortestPaths()
        {
            if (!solved) Solve();
            return dist;
        }

        public List<int> ReconstructShortestPath(int end)
        {
            if (!solved) Solve();
            List<int> path = new List<int>();
            if (dist[end] == double.MaxValue) return path;
            for (int at = end; prev[at] != int.MaxValue; at = prev[at])
            {
                // Return null since there are an infinite number of shortest paths.
                if (prev[at] == -1) return null;
                path.Add(at);
            }
            path.Add(start);
            return path;
        }

        public void Solve()
        {
            if (solved) return;
            //! Initialize the distance to all nodes to be infinity
            //! except for the start node which is zero as we are already there
            dist = Enumerable.Repeat(double.PositiveInfinity, n).ToArray();
            dist[start] = 0;

            // Initialize prev array which will allows for shortest path
            // reconstruction after the algorithm has terminated.
            prev = new int[n];

            // !For each vertex, apply relaxation for all the edges
            for (int k = 0; k < n - 1; k++)
            {              
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        //! relax edge with shorter path
                        //! the edges don't need tobe chosen in any specific order. 
                        if (dist[i] + matrix[i][j] < dist[j])
                        {
                            dist[j] = dist[i] + matrix[i][j];
                            prev[j] = i;
                        }
                    }
                }
            }
            // !Run algorithm a second time to detect which nodes are part
            //! of a negative cycle. A negative cycle has occurred if we
            // !can find a better path beyond the optimal solution.
            for (int k = 0; k < n - 1; k++)
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if (dist[i] + matrix[i][j] < dist[j])
                        {
                            dist[j] = double.NegativeInfinity;
                            prev[j] = -1;
                        }

            solved = true;
        }

    }
}