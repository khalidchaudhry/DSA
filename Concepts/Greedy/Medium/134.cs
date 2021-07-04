using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greedy.Medium
{
    public class _134
    {

        public int CanCompleteCircuit0(int[] gas, int[] cost)
        {
            int n = gas.Length;

            int totalGas = gas.Sum();
            int totalCost = cost.Sum();
            if (totalCost > totalGas) return -1;

            int currGas = 0;
            int idx = 0;
            for (int i = 0; i < 2 * n; ++i)
            {
                int currIdx = i % n;
                currGas += gas[currIdx] - cost[currIdx];
                if (currGas < 0)
                {
                    currGas = 0;
                    idx = currIdx + 1;
                }
            }
            return idx;

        }


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

