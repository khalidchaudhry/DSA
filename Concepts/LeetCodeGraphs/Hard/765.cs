using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Hard
{
    public class _765
    {
        public int MinSwapsCouples(int[] row)
        {

            int n = row.Length;
            UF uf = new UF(n);
            for (int i = 0; i < n; i += 2)
            {
                int u = row[i];
                int v = row[i + 1];
                uf.Union(u, v);
            }
            int mismatches = 0;
            for (int i = 0; i < n; i += 2)
            {
                int pu = uf.FindSet(i);
                int pv = uf.FindSet(i + 1);
                if (pu != pv)
                {
                    ++mismatches;
                    uf.Union(pu, pv);
                }
            }

            return mismatches;
        }

    }
}
