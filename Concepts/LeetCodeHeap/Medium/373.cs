using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeHeap.Medium
{
    class _373
    {

        //! implemented on idea based on Kuai's class
        //! We are using MinHeap here 
        //! Same as problem 378
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            int n1 = nums1.Length;
            int n2 = nums2.Length;

            List<IList<int>> kSmallestPairs = new List<IList<int>>();

            PQ<(int sum, int x, int y)> pq = new PQ<(int sum, int x, int y)>();
            //! visited to ensure that we don't push same set twice
            HashSet<(int i, int j)> visited = new HashSet<(int i, int j)>();
            pq.Add((nums1[0] + nums2[0], 0, 0));
            visited.Add((0, 0));
            while (pq.Size != 0 && k != 0)
            {
                (int sum, int i, int j) = pq.Poll();
                List<int> lst = new List<int>() { nums1[i], nums2[j] };
                kSmallestPairs.Add(lst);
                --k;
                if (i + 1 < n1 && !visited.Contains((i + 1, j)))
                {
                    pq.Add((nums1[i + 1] + nums2[j], i + 1, j));
                    visited.Add((i + 1, j));
                }
                if (j + 1 < n2 && !visited.Contains((i, j + 1)))
                {
                    pq.Add((nums1[i] + nums2[j + 1], i, j + 1));
                    visited.Add((i, j + 1));
                }
            }

            return kSmallestPairs;

        }

       


    }
}
