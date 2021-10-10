using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1135
    {
        public int MinimumCost(int n, int[][] connections)
        {

            var comparer = Comparer<int[]>.Create((x, y) => {

                return x[2].CompareTo(y[2]);
            });

            Array.Sort(connections, comparer);

            UF uf = new UF(n + 1);
            int count = n;
            int minCost = 0;
            for (int i = 0; i < connections.Length; ++i)
            {
                int u = connections[i][0];
                int v = connections[i][1];
                int cost = connections[i][2];

                int pu = uf.FindSet(u);
                int pv = uf.FindSet(v);

                if (pu != pv)
                {
                    minCost += cost;
                    --count;
                    uf.Union(pu, pv);
                }
            }
            return count == 1 ? minCost : -1;
        }
    }
}

