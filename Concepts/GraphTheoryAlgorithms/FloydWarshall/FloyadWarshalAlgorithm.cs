using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryAlgorithms.FloydWarshall
{
    public class FloyadWarshalAlgorithm
    {
        private int n;
        private bool solved;
        private double[][] dp;
        private int[][] next;

        private readonly int REACHES_NEGATIVE_CYCLE = -1;

        /**
        * As input, this class takes an adjacency matrix with edge weights between nodes, where
        * POSITIVE_INFINITY is used to indicate that two nodes are not connected.
        *
        * <p>NOTE: Usually the diagonal of the adjacency matrix is all zeros (i.e. matrix[i][i] = 0 for
        * all i) since there is typically no cost to go from a node to itself, but this may depend on
        * your graph and the problem you are trying to solve.
       */
        public FloyadWarshalAlgorithm(double[][] matrix)
        {
            n = matrix.Length;
            dp = new double[n][];
            next = new int[n][];

            for (int i = 0; i < n; i++)
            {
                dp[i] = new double[n];
                next[i] = new int[n];
            }

            // Copy input matrix and setup 'next' matrix for path reconstruction.
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] != double.PositiveInfinity)
                    {
                        //! next node you want to go to from i to j is j by default
                        next[i][j] = j;
                    }
                    dp[i][j] = matrix[i][j];
                }
            }
        }

        /**
        * Runs Floyd-Warshall to compute the shortest distance between every pair of nodes.
        *
        * @return The solved All Pairs Shortest Path (APSP) matrix.
       */
        public double[][] GetApspMatrix()
        {
            Solve();
            return dp;
        }

        // Executes the Floyd-Warshall algorithm.
        public void Solve()
        {
            if (solved) return;
            // Compute all pairs shortest paths.
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        //!dp[i][j]=min(dp[i][j], dp[i][k]+dp[k][j])
                        if (dp[i][k] + dp[k][j] < dp[i][j])
                        {
                            dp[i][j] = dp[i][k] + dp[k][j];
                            next[i][j] = next[i][k];
                        }
                    }
                }
            }

            // Identify negative cycles by propagating the value 'NEGATIVE_INFINITY'
            // to every edge that is part of or reaches into a negative cycle.
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (dp[i][k] + dp[k][j] < dp[i][j])
                        {
                            dp[i][j] = double.NegativeInfinity;
                            next[i][j] = REACHES_NEGATIVE_CYCLE;
                        }
                    }
                }
            }

            solved = true;
        }

        /**
        * Reconstructs the shortest path (of nodes) from 'start' to 'end' inclusive.
        *
        * @return An array of nodes indexes of the shortest path from 'start' to 'end'. If 'start' and
        *     'end' are not connected return an empty array. If the shortest path from 'start' to 'end'
        *     are reachable by a negative cycle return -1.
        */
        public List<int> ReconstructShortestPath(int start, int end)
        {
            Solve();
            List<int> path = new List<int>();
            if (dp[start][end] == double.PositiveInfinity) return path;
            int at = start;
            for (; at != end; at = next[at][end])
            {
                // Return null since there are an infinite number of shortest paths.
                if (at == REACHES_NEGATIVE_CYCLE) return null;
                path.Add(at);
            }
            // Return null since there are an infinite number of shortest paths.
            if (next[at][end] == REACHES_NEGATIVE_CYCLE) return null;
            path.Add(end);
            return path;
        }

        /* Example usage. */

        // Creates a graph with n nodes. The adjacency matrix is constructed
        // such that the value of going from a node to itself is 0.
        public static double[][] createGraph(int n)
        {
            double[][] matrix = new double[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new double[n];
                matrix[i] = Enumerable.Repeat(double.PositiveInfinity, n).ToArray();
                matrix[i][i] = 0;
            }

            return matrix;
        }



    }
}
