using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Hard
{
    class _1579
    {
       
        public int MaxNumEdgesToRemove(int n, int[][] edges)
        {

            edges = edges.OrderByDescending(x => x[0]).ToArray();
            int edgesAddedForAlice = 0;
            int edgesAddedForBob = 0;
            int edgesRemoved = 0;

            UF alice = new UF(n + 1);
            UF bob = new UF(n + 1);
            foreach (int[] edge in edges)
            {
                int type = edge[0];
                int u = edge[1];
                int v = edge[2];
                switch (type)
                {
                    case 3:
                        {
                            //! it does not matter either we use Alice or bob UF to find the graph
                            int pu = alice.FindSet(u);
                            int pv = alice.FindSet(v);

                            if (pu != pv)
                            {
                                alice.Union(pu, pv);
                                bob.Union(pu, pv);
                                ++edgesAddedForAlice;
                                ++edgesAddedForBob;
                            }
                            else
                            {
                                ++edgesRemoved;
                            }

                            break;
                        }

                    case 1:
                        {
                            int pu = alice.FindSet(u);
                            int pv = alice.FindSet(v);

                            if (pu != pv)
                            {
                                alice.Union(pu, pv);
                                ++edgesAddedForAlice;
                            }
                            else
                            {
                                ++edgesRemoved;
                            }

                            break;
                        }

                    case 2:
                        {
                            int pu = bob.FindSet(u);
                            int pv = bob.FindSet(v);

                            if (pu != pv)
                            {
                                bob.Union(pu, pv);
                                ++edgesAddedForBob;
                            }
                            else
                            {
                                ++edgesRemoved;
                            }

                            break;
                        }
                }
            }
            return edgesAddedForAlice == n - 1 && edgesAddedForBob == n - 1 ? edgesRemoved : -1;
        }
    }
}

