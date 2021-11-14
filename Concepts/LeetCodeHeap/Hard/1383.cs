using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeHeap.Hard
{
    public class _1383
    {
        public int MaxPerformance(int n, int[] speed, int[] efficiency, int k)
        {
            /*
             input:
                   n=
                   k=select at most k engineers out of n enginners
                   speed=[] length is n
                   efficiency=[] length is n

             output maxPerformance      
                   Performance=(sum of  k engineer speed)* min efficiency
            */

            /*
               We want to maximize the preformance 
               maximize the minimum efficiency 
               1. We will sort input by desc order based on efficiency
               2. We will calculate the performance 
               3. Will remove min speed when team size >k     
            */

            /*
              s[2,10,3,1,5,8]
              e[5, 4,3,9,7,2]

               [(2,5),(10,4),(3,3),(1,9),(5,7),(8,2)]

               [(1,9),(5,7),(2,5),(10,4),(3,3),(8,2)]
                                   ^
           k=3    
           s        =1,5,2,10
           e        =9,7,5,4
           pq       =
           speedSum =1,6,8,18,17

           maxPerf  =0,9,42


            */
            int mod = (int)Math.Pow(10, 9) + 7;
            List<(int s, int e)> speedEff = new List<(int s, int e)>();
            for (int i = 0; i < n; ++i)
            {
                speedEff.Add((speed[i], efficiency[i]));
            }

            var comparer = Comparer<(int s, int e)>.Create((x, y) => {
                return y.e.CompareTo(x.e);
            });

            speedEff.Sort(comparer);

            var pqComparer = Comparer<int>.Create((x, y) => {
                return x.CompareTo(y);
            });

            PQ<int> pq = new PQ<int>(pqComparer);

            long maxPerf = 0;
            long speedSum = 0;
            foreach ((int s, int e) in speedEff)
            {
                pq.Add(s);
                speedSum += s;
                while (pq.Size > k)
                {
                    int minspeed = pq.Poll();
                    speedSum -= minspeed;
                }
                maxPerf = Math.Max(maxPerf, speedSum * e);
            }
            return (int)(maxPerf % mod);

        }
    }
}

