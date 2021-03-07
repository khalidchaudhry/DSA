using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRandom.Medium
{
    public class _528
    {


    }

    /// <summary>
    ///  /// # <image url="$(SolutionDir)\Images\528.png"  scale="0.4"/>A
    /// https://www.youtube.com/watch?v=v-_aEMtgnkIs
    //! Take aways: 
    //! Take away 1: Always pay attention to range for generating random number
    /// </summary>
    public class Solution
    {
        int[] prefixSum;
        Random random;        
        public Solution(int[] w)
        {
            random = new Random();
            prefixSum = new int[w.Length];
            int sum = 0;
            for (int i = 0; i < w.Length; ++i)
            {
                sum += w[i];
                prefixSum[i] = sum;
            }

        }

        public int PickIndex()
        {
            int lastValue = prefixSum[prefixSum.Length - 1];
            //! Random number range is from 1 to sum +1 Why ?
            //! Starting from 1 because we will not have number 0 as given in question constraint
            //! 1 <= w[i] <= 10^5
            //! Logically speaking , if number probability is 0 then it should not be given even 
            int target = random.Next(1, lastValue + 1);
            int lo = -1;
            int hi = prefixSum.Length - 1;

            while (lo + 1 < hi)
            {
                int mid = lo + ((hi - lo) / 2);
                if (OK(mid, target))
                    hi = mid;
                else
                    lo = mid;
            }

            return hi;

        }

        //! First  number >= equal to the target
        //!FFFFF'T'TTTTTTT
        private bool OK(int mid, int target)
        {
            return prefixSum[mid] >= target;
        }


    }
    /// <summary>
    //! Brute force approach
    //! uses too much space
    //! Constructor too heavy
    //! Space Complexity=O(sum(w))
    //! Time Complexity=O(sum(w))
    /// </summary>
    public class Solution2
    {
        List<int> _lst;
        Random _random;
        public Solution2(int[] w)
        {
            _random = new Random();
            _lst = new List<int>();
            for (int i = 0; i < w.Length; ++i)
            {
                for (int j = 0; j < w[i]; ++j)
                {
                    _lst.Add(i);
                }
            }
        }

        public int PickIndex()
        {
            int index = _random.Next(_lst.Count);
            return _lst[index];
        }
    }



}
