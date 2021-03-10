using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs
{
    public class UF
    {
        private int[] _parent;
        public UF(int n)
        {
            _parent = new int[n];
            for (int i = 0; i < n; ++i)
            {
                _parent[i] = i;
            }
        }

        public int FindSet(int u)
        {
            if (_parent[u] == u)
            {
                return u;
            }
            return _parent[u] = FindSet(_parent[u]);
        }

        public void Union(int u, int v)
        {
            int parentu = FindSet(u);
            int parentv = FindSet(v);

            _parent[parentu] = parentv;
        }
    }
}
