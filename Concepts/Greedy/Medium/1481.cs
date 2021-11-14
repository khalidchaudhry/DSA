using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greedy.Medium
{
    public class _1481
    {

        //! more concise code then below
        public int FindLeastNumOfUniqueInts0(int[] arr, int k)
        {
           
            Dictionary<int, int> freqCount = new Dictionary<int, int>();
            foreach (int num in arr)
            {
                if (!freqCount.ContainsKey(num))
                {
                    freqCount.Add(num, 0);
                }
                ++freqCount[num];
            }
            freqCount = freqCount.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            //! We are getting keys seperately. 
            //! If we iterate dictionary and get element from dictionary based on index than it will change as we are deleting elements from dictionary. 

            int[] keys = freqCount.Keys.ToArray();

            foreach (int key in keys)
            {
                int freq = freqCount[key];
                int elementsToRemove = Math.Min(freq, k);
                k -= elementsToRemove;
                freqCount[key] -= elementsToRemove;
                if (freqCount[key] == 0)
                {
                    freqCount.Remove(key);
                }
            }

            return freqCount.Count;
        }
        public int FindLeastNumOfUniqueInts(int[] arr, int k)
        {



            Dictionary<int, int> numFreq = new Dictionary<int, int>();
            foreach (int num in arr)
            {
                if (!numFreq.ContainsKey(num))
                {
                    numFreq.Add(num, 0);
                }
                ++numFreq[num];
            }
            numFreq = numFreq.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            //! We are getting keys seperately. If we iterate dictionary and get element from dictionary based on index than it will change as we are deleting elements from dictionary. 
            var allKeys = numFreq.Keys.ToArray();
            int i = 0;
            while (k > 0)
            {
                int key = allKeys[i];
                int freq = numFreq[key];
                int elementsToDelete = Math.Min(freq, k);
                numFreq[key] = freq - elementsToDelete;
                if (numFreq[key] == 0)
                {
                    numFreq.Remove(key);
                }
                k = k - elementsToDelete;
                ++i;
            }

            return numFreq.Count;

        }

    }
}
