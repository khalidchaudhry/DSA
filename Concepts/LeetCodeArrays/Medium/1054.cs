using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _1054
    {
        /// <summary>
        //! Covered in Kai's class. Using bucket sort  
        //!Same pattern as in leetcode question 767,621
        /// </summary>
        public int[] RearrangeBarcodes(int[] barcodes)
        {
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
            foreach (int barcode in barcodes)
            {
                if (!frequencyMap.ContainsKey(barcode))
                {
                    frequencyMap.Add(barcode, 0);
                }

                ++frequencyMap[barcode];
            }

            frequencyMap = frequencyMap.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            int maxCount = frequencyMap.ElementAt(0).Value;

            List<int>[] buckets = new List<int>[maxCount];
            for (int b = 0; b < buckets.Length; ++b)
            {
                buckets[b] = new List<int>();
            }

            int i = 0;
            foreach (var keyValue in frequencyMap)
            {
                for (int j = 0; j < keyValue.Value; ++j)
                {
                    buckets[i % maxCount].Add(keyValue.Key);
                    ++i;
                }
            }
            int[] result = new int[barcodes.Length];

            int index = 0;
            foreach (List<int> bucket in buckets)
            {
                foreach (int element in bucket)
                {
                    result[index] = element;
                    index++;
                }
            }

            return result;
        }

    }
}
