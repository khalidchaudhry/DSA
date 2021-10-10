using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _841
    {

        //!Iterative version
        public bool CanVisitAllRooms0(IList<IList<int>> rooms)
        {
            if (rooms.Count == 0)
                return false;
            HashSet<int> seen = new HashSet<int>();

            Stack<int> stk = new Stack<int>();

            stk.Push(0);

            //! how to avoid casting ?
            List<List<int>> castedRooms=rooms.Cast<List<int>>().ToList();

            while (stk.Count != 0)
            {
                //!DFS magic spell
                //! 1. Pop top 
                int curr = stk.Pop();
                //! 2. Mark the top as visited
                seen.Add(curr);

                List<int> neighbours = castedRooms[curr];

                foreach (int neighbour in neighbours)
                {
                    //!3. Fetch top all all unvisited neighbours 
                    if (!seen.Contains(neighbour))
                    {
                        //!4. Push unvisited neighbours to the stack
                        stk.Push(neighbour);
                    }
                }
            }           

            return seen.Count == rooms.Count;
        }



        //! Recursive version 
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            HashSet<int> visited = new HashSet<int>();
            Solve(rooms, 0, visited);
            return visited.Count == rooms.Count;
        }

        private void Solve(IList<IList<int>> rooms, int start, HashSet<int> visited)
        {
            if (visited.Contains(start) || start >= rooms.Count)
            {
                return;
            }

            visited.Add(start);
            foreach (int neighbor in rooms[start])
            {
                Solve(rooms, neighbor, visited);
            }
        }

    }
}
