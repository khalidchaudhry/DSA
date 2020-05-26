using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryAlgorithms.BridgesArticulationPoints
{
    public class BridgesAdjacencyList
    {


        private bool _solved;
        private int _n;
        //! to get id of the node. Incremented every time as we move
        private int _id;
        //!to store the low link value. low-link value of a node is defined as the smallest[lowest] id reachable from that node
        //!using forward and backward edges.
        private int[] _low;
        //!to store ids of the nodes
        private int[] _ids;
        private bool[] _visited;
        private List<List<int>> _graph;
        //!To store bridges 
        private List<int> _bridges;

        public BridgesAdjacencyList(List<List<int>> graph, int n)
        {
            this._graph = graph;
            this._n = n;
        }

        // Returns a list of pairs of nodes indicating which nodes form bridges.
        // The returned list is always of even length and indexes (2*i, 2*i+1) form a
        // pair. For example, nodes at indexes (0, 1) are a pair, (2, 3) are another
        // pair, etc...
        public List<int> FindBridges()
        {
            //!initialization
            _id = 0;
            _low = new int[_n];
            _ids = new int[_n];
            _visited = new bool[_n];

            _bridges = new List<int>();
            // Finds all bridges in the graph across various connected components.
            for (int i = 0; i < _n; i++)
            {
                if (!_visited[i])
                {
                    DFS(i,-1);
                }
            }

            _solved = true;
            return _bridges;
         }

        private void DFS(int at,int parent)
        {
            //!housekeeping stuff
            _visited[at] = true;                     
            _ids[at] = _id;
            _low[at] = _id;
            //!incrementing an id
            ++_id;

            foreach (int neighbour in _graph[at])
            {
                //!Since there is an undirected graph there is bound tobe an edge that directly returns the node  that we were just prevously at 
                //! which is the parent node which we want to avoid so we continue on those cases. 
                if (neighbour == parent)
                {
                    continue;
                }
                //!id next node we are going to is not visited we are recursively calling DFS method
                if (!_visited[neighbour])
                {
                    DFS(neighbour,at);
                    //!Happens at call back 
                    _low[at] = Math.Min(_low[at],_low[neighbour]);
                    if (_ids[at] < _low[neighbour])
                    {
                        _bridges.Add(at);
                        _bridges.Add(neighbour);
                    }
                }
                else
                {
                    //! When tries to visit already visited node. 
                    _low[at] = Math.Min(_low[at],_ids[neighbour]);
                }

            }


        }

    }
}
