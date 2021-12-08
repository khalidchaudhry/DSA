using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeHeap.Medium
{
    class _1057
    {
        /// <summary>        
        //! Time Complexity=O(m*n)
        //!Space Complexity = O(1999*W*B)+O(W)+O(B) 
        /// </summary>
        public int[] AssignBikes0(int[][] workers, int[][] bikes)
        {

            int n = workers.Length;
            //!1999 because that's the maximimum possible manhatan distance based on question constraint
            //! Possible worker indexes=0 <= xi, yi < 1000
            //! Possible bike indexes=0 <= xj, yj < 1000
            int maxDistance = 1999;
            List<WorkerBikeIndex>[] distance = new List<WorkerBikeIndex>[maxDistance];
            for (int i = 0; i < maxDistance; ++i)
            {
                distance[i] = new List<WorkerBikeIndex>();
            }

            for (int w = 0; w < n; ++w)
            {
                for (int b = 0; b < bikes.Length; ++b)
                {
                    int wbDistance = Distance(workers[w], bikes[b]);
                    WorkerBikeIndex data = new WorkerBikeIndex(w, b);
                    distance[wbDistance].Add(data);
                }
            }

            int[] result = new int[n];
            HashSet<int> bikesIdxs = new HashSet<int>();
            HashSet<int> workerIdxs = new HashSet<int>();

            foreach (List<WorkerBikeIndex> item in distance)
            {
                foreach (WorkerBikeIndex data in item)
                {
                    if (bikesIdxs.Contains(data.BIdx) || workerIdxs.Contains(data.WIdx))
                    {
                        continue;
                    }
                    result[data.WIdx] = data.BIdx;
                    bikesIdxs.Add(data.BIdx);
                    workerIdxs.Add(data.WIdx);
                }
            }
            return result;
        }

        /// <summary>
        //! Giving TLE in Leetcode . Good from interview perspective 
        //! Time complexity=O(wblogwb) where w number of worker and b number of bikes
        //!Space complexity=O(w)+O(b)+O(wb) where O(w) for workers hashset O(b) fior bikes hashset and O(wb) the elements in pq 
        /// </summary>
        public int[] AssignBikes(int[][] workers, int[][] bikes)
        {

            int n = workers.Length;
            var comparer = Comparer<Data>.Create((x, y) =>
            {

                if (x.Distance != y.Distance)
                    return x.Distance.CompareTo(y.Distance);
                else if (x.WIdx != y.WIdx)
                    return x.WIdx.CompareTo(y.WIdx);
                else
                    return x.BIdx.CompareTo(y.BIdx);

            });

            PQ<Data> pq = new PQ<Data>(comparer);

            for (int w = 0; w < n; ++w)
            {
                for (int b = 0; b < bikes.Length; ++b)
                {
                    int distance = Distance(workers[w], bikes[b]);
                    Data data = new Data(w, b, distance);
                    pq.Add(data);
                }
            }
            int[] result = new int[n];
            HashSet<int> bikesIdx = new HashSet<int>();
            HashSet<int> workersIdx = new HashSet<int>();

            while (pq.Size != 0)
            {
                Data data = pq.Poll();
                int wIdx = data.WIdx;
                int bIdx = data.BIdx;

                if (bikesIdx.Contains(bIdx) || workersIdx.Contains(wIdx))
                    continue;

                result[wIdx] = bIdx;
                workersIdx.Add(wIdx);
                bikesIdx.Add(bIdx);
            }
            return result;
        }
        private int Distance(int[] w, int[] b)
        {
            return Math.Abs(b[0] - w[0]) + Math.Abs(b[1] - w[1]);
        }
    }

    public class Data
    {
        public int WIdx;
        public int BIdx;
        public int Distance;
        public Data(int wIdx, int bIdx, int distance)
        {
            WIdx = wIdx;
            BIdx = bIdx;
            Distance = distance;
        }
    }
    public class WorkerBikeIndex
    {
        public int WIdx;
        public int BIdx;

        public WorkerBikeIndex(int wIdx, int bIdx)
        {
            WIdx = wIdx;
            BIdx = bIdx;
        }
    }

}
