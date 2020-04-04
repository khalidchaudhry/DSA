using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Easy
{
    public class _997
    {
        /*
          Create map that will hold indegree and outdegree of all the vertices 
          //if any vertex with indgree = 0 and outdegree=N-1 than that vertex is judege 
         // else no judge 
             
        */ 
        public int FindJudge(int N, int[][] trust)
        {
            int answer = -1;
            Degree[] degrees = new Degree[N];

            for (int i = 0; i < N; i++)
            {
                degrees[i] = new Degree();
            }

            for (int i = 0; i < trust.Length; i++)
            {
                ++degrees[trust[i][0] - 1].OutDegree;
                ++degrees[trust[i][1] - 1].InDegree;
            }

            for (int i = 0; i < N; i++)
            {
                if (degrees[i].InDegree == N - 1 && degrees[i].OutDegree == 0)
                {
                    answer = i + 1;
                    break;
                }
            }

            return answer;
        }

    }
    // In leetcode solution one submission using  array rather than creating additional classs
    // Check this out 
    // https://leetcode.com/problems/find-the-town-judge/discuss/244198/Java-Straight-forward-solution
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
