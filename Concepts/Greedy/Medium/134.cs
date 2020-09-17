using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Medium
{
    public class _134
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {

            int start_location = 0;
            int current_tank = 0;
            int total_tank = 0;

            int n = gas.Length;
            for (int i = 0; i < n; ++i)
            {

                total_tank += gas[i] - cost[i];
                current_tank += gas[i] - cost[i];

                if (current_tank < 0)
                {
                    current_tank = 0;
                    start_location = i + 1;
                }
            }

            return total_tank >= 0 ? start_location : -1;

        }
    }
}

