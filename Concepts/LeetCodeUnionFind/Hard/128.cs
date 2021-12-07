using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeUnionFind.Hard
{
    public class _128
    {


        public int LongestConsecutive(int[] nums)
        {
            int n = nums.Length;
            if (n == 0) return 0;

            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < n; ++i)
            {
                hs.Add(nums[i]);
            }

            int longest = 0;

            for (int i = 0; i < n; ++i)
            {
               
                //! If element is not the first element in the sequence e.g. [1,2,3,4] for 2,3,4 it will continue
                if (hs.Contains(nums[i] - 1))
                    continue;
                //! If we are here , it means that this the first element in the sequence. We need to check how much longer we can go. 
                int currLen = 1;
                int temp = nums[i] + 1;
                while (hs.Contains(temp))
                {
                    ++temp;
                    ++currLen;
                }

                longest = Math.Max(longest, currLen);
            }
            return longest;
        }

        public int LongestConsecutive2(int[] nums)
        {

            int n = nums.Length;
            if (n == 0) return 0;
            Array.Sort(nums);

            int currLongest = 1;
            int maxLongest = 1;
            for (int i = 0; i < n - 1; ++i)
            {
                if (nums[i] == nums[i + 1]) continue;
                if (nums[i] + 1 == nums[i + 1])
                {
                    ++currLongest;
                }
                else
                {
                    maxLongest = Math.Max(maxLongest, currLongest);
                    currLongest = 1;
                }
            }
            return Math.Max(maxLongest, currLongest);
        }




        //https://leetcode.com/problems/longest-consecutive-sequence/
        public int LongestConsecutive3(int[] nums)
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