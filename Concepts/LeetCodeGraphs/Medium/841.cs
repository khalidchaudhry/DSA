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
            if (rooms.Count == 0)
                return false;
            HashSet<int> seen = new HashSet<int>();

           //! how to cast IList to list
            DFS(0, rooms.Cast<List<int>>().ToList() , seen);

            return seen.Count == rooms.Count;
        }

        private void DFS(int at, List<List<int>> rooms, HashSet<int> seen)
        {
            seen.Add(at);

            List<int> neighbours = rooms[at];
            foreach (int neighbour in neighbours)
            {
                if (!seen.Contains(neighbour))
                {
                    DFS(neighbour, rooms, seen);
                }
            }
        }

    }
}
