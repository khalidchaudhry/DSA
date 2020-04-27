using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _332
    {
        // origin -> list of destinations
        private Dictionary<string, List<string>> flightMap = new Dictionary<string, List<string>>();
        Dictionary<string, bool[]> visitBitmap = new Dictionary<string, bool[]>();
        int flights = 0;
        List<string> result = new List<string>();

        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            if (tickets == null || tickets.Count == 0) return result;
            // Step 1). build the graph first           
            for (int i = 0; i < tickets.Count; ++i)
            {
                if (!flightMap.ContainsKey(tickets[i][0]))
                {
                    // create a new list
                    List<string> list = new List<string>();
                    list.Add(tickets[i][1]);
                    flightMap.Add(tickets[i][0], list);
                }
                else
                {
                    // add to existing list
                    flightMap[tickets[i][0]].Add(tickets[i][1]);
                }
            }
            // Step 2). order the destinations and initialize the visit bitmap
            foreach (KeyValuePair<string, List<string>> entry in flightMap)
            {
                entry.Value.Sort();

                visitBitmap.Add(entry.Key, new bool[entry.Value.Count]);
            }

            flights = tickets.Count;
            List<string> route = new List<string>();
            route.Add("JFK");
            // Step 3). backtracking
            BackTracking("JFK", route);
            return result;
        }

        /// <summary>
        /// Approach 2: Hierholzer's Algorithm
        /// </summary>
        /// <param name="tickets"></param>
        /// <returns></returns>
        public List<string> FindItinerary2(IList<IList<string>> tickets)
        {
            //! Step 1). build the graph first
            foreach (List<string> ticket in tickets)
            {
                String origin = ticket[0];
                String dest = ticket[1];
                if (flightMap.ContainsKey(origin))
                {
                    List<string> destList = flightMap[origin];
                    destList.Add(dest);
                }
                else
                {
                    List<string> destList = new List<string>();
                    destList.Add(dest);
                    flightMap.Add(origin, destList);
                }
            }

            //! Step 2). order the destinations
            foreach (KeyValuePair<string, List<string>> entry in flightMap)
            {
                entry.Value.Sort();
            }

            this.result = new List<string>();
            //! Step 3). post-order DFS
            DFS("JFK");

            return result;
        }

        /// <summary>
        /// https://leetcode.com/problems/reconstruct-itinerary/discuss/78791/C-Iterative-version-with-detail-comments
        /// https://www.youtube.com/watch?v=9zDe18pAku8
        /// </summary>
        /// <param name="tickets"></param>
        /// <returns></returns>
        public IList<string> FindItinerary3(IList<IList<string>> tickets)
        {
            LinkedList<string> res = new LinkedList<string>();
            //invalid input
            if (tickets == null || tickets.Count == 0)
                return res.ToList();

            //Build a hashtable/dict for route. 
            //key is the source city, value are all the destination city from source city.
            var routeDict = new Dictionary<string, List<string>>();

            // !Step 1). build the graph first           
            for (int i = 0; i < tickets.Count; ++i)
            {
                if (!routeDict.ContainsKey(tickets[i][0]))
                {
                    // create a new list
                    List<string> list = new List<string>();
                    list.Add(tickets[i][1]);
                    routeDict.Add(tickets[i][0], list);
                }
                else
                {
                    // add to existing list
                    routeDict[tickets[i][0]].Add(tickets[i][1]);
                }
            }

            //! Step 2). order the destinations and initialize the visit bitmap
            foreach (KeyValuePair<string, List<string>> entry in routeDict)
            {
                entry.Value.Sort();
            }

            //!Step 3: need a stack as like a backtracking route from final.
            Stack<string> stack = new Stack<string>();
            stack.Push("JFK");    //Add start city
            while (stack.Any())
            {
                while (routeDict.ContainsKey(stack.Peek()) && routeDict[stack.Peek()].Any())
                {
                    var next = routeDict[stack.Peek()].First();  //the next city from the source city in lexical order
                    routeDict[stack.Peek()].RemoveAt(0);         //remove the next city from the hash table.(since List<T> doesn't has Poll/Pop/Dequeue)
                    stack.Push(next);                            //push next city into the stack
                }
                res.AddFirst(stack.Pop());                      //Pop all the city from stack, Add them in the head of res.
            }
            return res.ToList();
        }

        private void DFS(String origin)
        {
            // Visit all the outgoing edges first.
            if (flightMap.ContainsKey(origin))
            {
                List<string> destList = this.flightMap[origin];
                while (destList.Count != 0)
                {
                    //!while we visit the edge, we trim it off from graph.
                    var next = destList.First();  //the next city from the source city in lexical order
                    destList.RemoveAt(0);
                    DFS(next);
                }
            }
            // add the airport to the head of the itinerary
            this.result.Insert(0, origin);
        }
        private bool BackTracking(String origin, List<string> route)
        {
            if (route.Count == flights + 1)
            {
                result = route.GetRange(0, route.Count);
                return true;
            }

            if (!flightMap.ContainsKey(origin))
                return false;

            int i = 0;
            bool[] bitmap = visitBitmap[origin];

            foreach (string dest in flightMap[origin])
            {
                if (!bitmap[i])
                {
                    bitmap[i] = true;
                    route.Add(dest);
                    bool ret = BackTracking(dest, route);
                    // remove the last element
                    route.RemoveAt(route.Count - 1);
                    bitmap[i] = false;

                    if (ret)
                        return true;
                }
                ++i;
            }

            return false;
        }
    }
}
