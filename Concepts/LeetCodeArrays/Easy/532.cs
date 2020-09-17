using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    public class _532
    {

        public static void _532Main()
        {

            int[] nums = new int[] { 3, 1, 4, 1, 5 };
            int k = 2;
            _532 FindPairs = new _532();

            int ans = FindPairs.FindPairs0(nums, k);

            Console.ReadLine();
        }
        /// <summary>
        //https://leetcode.com/problems/k-diff-pairs-in-an-array/solution/
        //! if y-x=k then y=k+x; so for every x we can add k to know that y exists in dictionary
        //! Two cases to look at 
        //!  
        //! when k>0. If there is a key in the hash map which is equal to x+k  increment result
        //! when k==0. If 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindPairs0(int[] nums, int k)
            {
                int n = nums.Length;
                int result = 0;
                if (n == 1) return 0;
                Dictionary<int, int> map = new Dictionary<int, int>();

                /*
                  nums = [2, 4, 1, 3, 5, 3, 1], k = 3
                 hash_map = {
                             1: 2,
                             2: 1,
                             3: 2,
                             4: 1,
                             5: 1
                           }
                  */

                for (int i = 0; i < nums.Length; ++i)
                {
                    if (map.ContainsKey(nums[i]))
                    {
                        ++map[nums[i]];
                    }
                    else
                    {
                        map[nums[i]] = 1;
                    }
                }

                foreach (KeyValuePair<int, int> keyValuePair in map)
                {
                    if (k > 0 && map.ContainsKey(keyValuePair.Key + k))
                    {
                        ++result;
                    }
                    else if (k == 0 && keyValuePair.Value > 1)
                    {
                        ++result;
                    }
                }

                return result;
        }

        public int FindPairs1(int[] nums, int k)
        {
            int n = nums.Length;
            if (n == 1) return 0;

            //! need to sort becuase (1,2) and (2,1) consider as duplicate
            Array.Sort(nums);
            int left = 0;
            int right = 1;

            int result = 0;
            while (left < n && right < n)
            {
                int diff = Math.Abs(nums[right] - nums[left]);
                //! left==right why?
                //! [1,1,3,4,5] k=2 
                //! when difference between 2 consecutive elements equal to the required distance k then we increment both i and j 
                //! and they will point to the same element. 
                if (left == right || diff < k)
                {
                    ++right;
                }
                else if (diff > k)
                {
                    ++left;
                }
                else
                {
                    ++result;
                    //! incrementing only left because there may be other pair 
                    //! e.g. [1,1,1,2,2] with k=0

                    ++left;

                    if (left < n && nums[left] == nums[left - 1])
                    {
                        ++left;
                    }
                }
            }
            return result;

        }
        public int FindPairs2(int[] nums, int k)
        {
            int n = nums.Length;
            if (n == 1) return 0;


            HashSet<(int, int)> hs = new HashSet<(int, int)>();
            //! need to sort becuase (1,2) and (2,1) consider as duplicate
            Array.Sort(nums);
            for (int i = 0; i < n - 1; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    int x = nums[i];
                    int y = nums[j];
                    int pairDiff = Math.Abs(y - x);
                    if (pairDiff == k)
                        hs.Add((x, y));
                }
            }

            return hs.Count;

        }



    }
}
