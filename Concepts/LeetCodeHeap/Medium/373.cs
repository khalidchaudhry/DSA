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
        
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {

            SortedSet<(int, int, int)> ss = new SortedSet<(int, int, int)>();
            //! we need visited set because when we are pushing element into the set , we need to ensure that we don't push duplicates 
            //! 1 1 2
            //! 1 2 3

            List<IList<int>> result = new List<IList<int>>();
            if (nums1.Length == 0 || nums2.Length == 0) return result;

            //! Not needed for sorted set but needed for priority queue
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            ss.Add((nums1[0] + nums1[0], 0, 0));

            //visited.Add((0, 0));

            while (k > 0 && ss.Count != 0)
            {
                (int sum, int nums1Index, int nums2Index) = ss.Min;

                ss.Remove(ss.Min);

                result.Add(new List<int> { nums1[nums1Index], nums2[nums2Index] });

                if (nums1Index + 1 < nums1.Length)// && !visited.Contains((nums1Index + 1, nums2Index)))
                {
                    visited.Add((nums1Index + 1, nums2Index));
                    ss.Add((nums1[nums1Index + 1] + nums2[nums2Index], nums1Index + 1, nums2Index));
                }
                if (nums2Index + 1 < nums2.Length)// && !visited.Contains((nums1Index, nums2Index + 1)))
                {
                    visited.Add((nums1Index, nums2Index + 1));
                    ss.Add((nums1[nums1Index] + nums2[nums2Index + 1], nums1Index, nums2Index + 1));
                }

                --k;
            }

            return result;

            
        }


    }
}
