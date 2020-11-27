using System;
using System.Collections.Generic;
using System.Text;

namespace HashSet
{
    class _349
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> hs = new HashSet<int>();
            HashSet<int> resultHs = new HashSet<int>();
            // Time Complexity=O(n) --> where n is number of elements in an array nums1
            // Space complexit=O(n) --> where n is number of elements in an array nums1
            for (int i = 0; i < nums1.Length; i++)
            {
                if (!hs.Contains(nums1[i]))
                {
                    hs.Add(nums1[i]);
                }
            }
            // Time Complexity=O(m) --> where m is number of elements in an array nums2
            // Space complexit=O(m) --> where m is number of elements in an array nums1
            for (int i = 0; i < nums2.Length; i++)
            {
                if (hs.Contains(nums2[i]))
                {
                    if (!resultHs.Contains(nums2[i]))
                    {
                        resultHs.Add(nums2[i]);
                    }
                }
            }

            int[] result = new int[resultHs.Count];

            // Time Complexity=O(m) --> where m is number of elements in an array nums2
            resultHs.CopyTo(result);

            // Time complexity =O(n)+O(m)+O(m)=O(n)+O(2m)=O(n+m)
            // Space complexity=O(n)+O(m)=O(n+m)

            return result;
        }

    }
}
