using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greedy.Medium
{
    public class _1094
    {

        public bool CarPooling(int[][] trips, int capacity)
        {

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < trips.Length; ++i)
            {
                int startLocation = trips[i][1];
                int endLocation = trips[i][2];
                int numberOfPassengers = trips[i][0];

                //! inflow
                if (map.ContainsKey(startLocation))
                {
                    map[startLocation] = map[startLocation] + numberOfPassengers;
                }
                else
                {
                    map[startLocation] = numberOfPassengers;
                }
                //!outflow
                if (map.ContainsKey(endLocation))
                {
                    map[endLocation] = map[endLocation] - numberOfPassengers;
                }
                else
                {
                    map[endLocation] = -numberOfPassengers;
                }
            }

            map = map.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            int usedCapacity = 0;
            for (int i = 0; i < map.Count; ++i)
            {
                usedCapacity+=map.ElementAt(i).Value;
                if (usedCapacity > capacity)
                    return false;
            }

            return true;
        }
    }
}
