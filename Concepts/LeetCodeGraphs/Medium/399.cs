﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _399
    {
        /// <summary>
        // # of equations - m
        //# of queries - n
        //# of variables - v <= 2 * m
        //!Build Graph: O(E(# of Equations))
        //Assume there are K queries:
        //Evaluate one query: O(V+E) 
        // totaltime:Evaulate K queries+Build Graph
        //!total time: O(K* (V+E)+E)
        //Space:
        //!Graph: O(V+2E)
        //!visited set: O(V)
        //!total space: O(2*E + 2*V)
        /// </summary>

        //https://leetcode.com/problems/evaluate-division/discuss/171649/1ms-DFS-with-Explanations
        public double[] CalcEquation(
            IList<IList<string>> equations,
            double[] values,
            IList<IList<string>> queries)
        {
            double[] result = new double[queries.Count];
            var graph = new Dictionary<string, Dictionary<string, double>>();
            CreateGraph(equations, values, graph);
            int i = 0;
            foreach (List<string> query in queries)
            {
                result[i++] = GetPathWeight(query[0], query[1], graph, new HashSet<string>());
            }

            return result;
        }

        private double GetPathWeight(
            string start,
            string end,
            Dictionary<string, Dictionary<string, double>> graph,
            //! Main reason for using visited set is use case where query can be ["x2","x2"]. Without it we will stuck in cycle
            HashSet<string> visited)
        {
            // rejection case
            if (!graph.ContainsKey(start) || visited.Contains(start))
            {
                return -1;
            }
            /* Accepting case. */
            if (graph[start].ContainsKey(end))
            {
                return graph[start][end];
            }

            visited.Add(start);
            foreach (var neighbour in graph[start])
            { 
                double productWeight = GetPathWeight(neighbour.Key, end, graph, visited);

                if (productWeight != -1)
                {
                    return neighbour.Value * productWeight;
                }
            }

            return -1.0;
        }



        /*
             Input
             equations = [ ["a", "b"], ["b", "c"] ],
             values = [2.0, 3.0],
             Graph:
              a      [{b:2.0}]
              b      [{a:0.5},{c:3.0}]
              c      [{b:1/3}]               
         */
        private void CreateGraph(
            IList<IList<string>> equations,
            double[] values,
            Dictionary<string, Dictionary<string, double>> graph)
        {
            for (int i = 0; i < equations.Count; i++)
            {
                string u = equations[i][0];
                string v = equations[i][1];

                if (!graph.ContainsKey(u))
                {
                    graph.Add(u, new Dictionary<string, double>());
                }

                graph[u].Add(v, values[i]);

                if (!graph.ContainsKey(v))
                {
                    graph.Add(v, new Dictionary<string, double>());
                }

                graph[v].Add(u, (1 / values[i]));
            }
        }
    }
}
