using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Easy
{
    public class _997
    {
        /// <summary>
        //! Edges cases 
        //! If n=1 and trust=[] answer is 1
        //! if n=2 and trust=[] answer is -1
        /// </summary>
        public int FindJudge0(int N, int[][] trust)
        {

            Dictionary<int, Degree> nodeDegree = new Dictionary<int, Degree>();
            for (int i = 1; i <= N; ++i)
            {
                nodeDegree.Add(i, new Degree());
            }
            for (int i = 0; i < trust.Length; ++i)
            {
                int from = trust[i][0];
                int to = trust[i][1];
                ++nodeDegree[from].OutDegree;
                ++nodeDegree[to].InDegree;
            }

            foreach (var keyValue in nodeDegree)
            {
                if (keyValue.Value.OutDegree == 0 &&
                    keyValue.Value.InDegree == N - 1
                  )
                {
                    return keyValue.Key;
                }
            }
            return -1;

        }
    }
    public class Degree
    {
        public int InDegree;
        public int OutDegree;
        public Degree()
        {
            InDegree = 0;
            OutDegree = 0;
        }
    }
}
