using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Easy
{
    public class _997
    {
        public int FindJudge0(int N, int[][] trust)
        {

            Dictionary<int, int[]> graph = new Dictionary<int, int[]>();
            for (int i = 1; i <= N; ++i)
            {
                graph[i] = new int[2];
            }

            for (int i = 0; i < trust.Length; ++i)
            {
                int personA = trust[i][0];
                int personB = trust[i][1];

                ++graph[personA][1];

                ++graph[personB][0];
            }

            foreach (var keyValue in graph)
            {
                if (graph[keyValue.Key][0] == N - 1 && graph[keyValue.Key][1] == 0)
                {
                    return keyValue.Key;
                }
            }

            return -1;

        }

        /*
          Create map that will hold indegree and outdegree of all the vertices 
          //if any vertex with indgree = 0 and outdegree=N-1 than that vertex is judege 
         // else no judge 
             
        */
        public int FindJudge(int N, int[][] trust)
        {
            Dictionary<int, (int indegree, int outdegree)> degree = new Dictionary<int, (int indegree, int outdegree)>();
            //! without initialization, it will return return -1 for test case n=1,trust=[] 
            for (int i = 1; i <= N; ++i)
            {
                degree[i] = (0, 0);
            }

            foreach (int[] t in trust)
            {
                int from = t[0];
                int to = t[1];
                (int fIndegree, int fOutdegree) = degree[from];
                (int tIndegree, int tOutdegree) = degree[to];

                degree[from] = (fIndegree, ++fOutdegree);
                degree[to] = (++tIndegree, tOutdegree);
            }

            foreach (var keyValue in degree)
            {
                if (keyValue.Value.indegree == N - 1 && keyValue.Value.outdegree == 0)
                    return keyValue.Key;
            }
            return -1;
        }

    }
    public class Degree
    {
        private int indegree;
        private int outdegree;

        public int InDegree
        {
            get => indegree;
            set => indegree = value;
        }

        public int OutDegree
        {
            get => outdegree;
            set => outdegree = value;
        }
    }
}
