using System;
using System.Collections.Generic;
using System.Text;

namespace HashSet
{
    class _760
    {
        // Time Complexity=O(2n)=O(n) 2n because A,B have equal lengths  
        // Space Complexity=O(n+m) where n is the number of elements in array B and m for storing index
        public int[] AnagramMappings(int[] A, int[] B)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int[] result = new int[A.Length];
            for (int i = 0; i < B.Length; i++)
            {
                if (!map.ContainsKey(B[i]))
                {
                    map.Add(B[i],i);
                }
            }

            for (int i = 0; i < A.Length; i++)
            {
                result[i]=map[A[i]];
            }

            return result;
        }


    }
}
