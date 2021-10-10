using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1584
    {
        public int MinCostConnectPoints(int[][] points)
        {

            int n = points.Length;
            List<Data> allPoints = new List<Data>();
            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    allPoints.Add(new Data(i, j, Distance(points[i], points[j])));
                }
            }
            allPoints = allPoints.OrderBy(x => x.Distance).ToList();

            UF uf = new UF(n);
            int minCost = 0;
            for (int i = 0; i < allPoints.Count; ++i)
            {
                int u = allPoints[i].SrcPointId;
                int v = allPoints[i].DestPointId;

                int pu = uf.FindSet(u);
                int pv = uf.FindSet(v);
                if (pu != pv)
                {
                    minCost += allPoints[i].Distance;
                    uf.Union(pu, pv);
                }
            }
            return minCost;
        }
        private int Distance(int[] src, int[] dest)
        {
            return Math.Abs(src[0] - dest[0]) + Math.Abs(src[1] - dest[1]);
        }
    }
    public class Data
    {
        public int SrcPointId;
        public int DestPointId;
        public int Distance;
        public Data(int srcPointId, int destPointId, int distance)
        {
            SrcPointId = srcPointId;
            DestPointId = destPointId;
            Distance = distance;
        }
    }
}


