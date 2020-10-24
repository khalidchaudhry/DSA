using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeUnionFind.Hard
{
    public class _128
    {
        //https://leetcode.com/problems/longest-consecutive-sequence/
        public int longestConsecutive(int[] nums)
        {
            UF uf = new UF(nums.Length);
            // Map val to index in nums
            Dictionary<int, int> valToIndex = new Dictionary<int, int> ();

            for (int i = 0; i < nums.Length; i++)
            {
                if (valToIndex.ContainsKey(nums[i]))
                {
                    continue;
                }

                if (valToIndex.ContainsKey(nums[i] - 1))
                {
                    uf.union(i, valToIndex[nums[i] - 1]);
                }

                if (valToIndex.ContainsKey(nums[i] + 1))
                {
                    uf.union(i, valToIndex[nums[i] + 1]);
                }

                valToIndex.Add(nums[i], i);
            }

            return uf.getLargetComponentSize();
        }


        class UF
        {
            private int[] parent;
            private int[] size;

            public UF(int n)
            {
                parent = new int[n];
                size = new int[n];
                for (int i = 0; i < n; i++)
                {
                    parent[i] = i;
                    size[i] = 1;
                }
            }
            public void union(int x, int y)
            { // connected if consecutive
                int rootX = find(x);
                int rootY = find(y);
                if (rootX != rootY)
                {
                    parent[rootX] = rootY;
                    size[rootY] += size[rootX];
                }
            }
            private int find(int x)
            {
                if (parent[x] == x)
                {
                    return x;
                }

                return parent[x] = find(parent[x]);
            }
            public int getLargetComponentSize()
            {
                int maxSize = 0;
                for (int i = 0; i < parent.Length; i++)
                {
                    if (parent[i] == i && size[i] > maxSize)
                    {
                        maxSize = size[i];
                    }
                }

                return maxSize;
            }
        }
    }
}