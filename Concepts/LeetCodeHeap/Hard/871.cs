using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeHeap.Hard
{
    public class _871
    {
        public int MinRefuelStops(int target, int startFuel, int[][] stations)
        {

            var comparer = Comparer<int>.Create((x, y) => {

                return y.CompareTo(x);

            });

            PQ<int> pq = new PQ<int>(comparer);
            int ans = 0;
            int tank = startFuel;
            int prev = 0;
            foreach (int[] station in stations)
            {
                int loc = station[0];
                int fuel = station[1];
                tank -= loc - prev;
                //! why tank<0 and not tank<=0
                //! Note that if the car reaches a gas station with 0 fuel left, the car can still refuel there.
                //! If the car reaches the destination with 0 fuel left, it is still considered to have arrived.
                while (pq.Size != 0 && tank < 0)
                { 
                    ++ans;
                    tank += pq.Poll();
                }

                if (tank < 0)
                {
                    return -1;
                }
                prev = loc;
                pq.Add(fuel);
            }

            tank -= target - prev;
            while (pq.Size != 0 && tank < 0)
            {
                ++ans;
                tank += pq.Poll();
            }

            if (tank < 0)
            {
                return -1;
            }

            return ans;
        }
    }
}

