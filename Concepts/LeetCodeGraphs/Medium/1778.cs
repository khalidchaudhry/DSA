using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1778
    {




        /// <summary>
        //! Brute force giving TLE 
        /// </summary>
        public int FindShortestPath(GridMaster master)
        {

            int distance = Solve(master, ' ');
            return distance == int.MaxValue ? -1 : distance;

        }
        private int Solve(GridMaster master, char parentDirection)
        {
            if (master.isTarget())
            {
                return 0;
            }

            int minDistance = int.MaxValue;
            foreach (char direction in new List<char>() { 'U', 'D', 'L', 'R' })
            {
                if (master.canMove(direction))
                {
                    if (parentDirection == 'U' && direction == 'D' ||
                       parentDirection == 'D' && direction == 'U' ||
                       parentDirection == 'R' && direction == 'L' ||
                       parentDirection == 'L' && direction == 'R'
                      )
                    {
                        continue;
                    }
                    master.move(direction);
                    int distance = Solve(master, direction);
                    if (distance != int.MaxValue)
                    {
                        ++distance;
                    }
                    minDistance = Math.Min(minDistance, distance);
                }
            }
            return minDistance;
        }
    }


    // This is the GridMaster's API interface.
    // You should not implement it, or speculate about its implementation
    public class GridMaster
    {
        public bool canMove(char direction) {
            return true;
        }
        public void move(char direction)
        {


        }
        public bool isTarget()
        {
            return true;
        }
    }
}

