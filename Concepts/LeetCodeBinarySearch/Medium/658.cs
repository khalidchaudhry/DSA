using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    public class _658
    {

        public static void _658Main()
        {

            //int[] arr = new int[] { 0, 0, 0, 1, 3, 5, 6, 7, 8, 8 };
            int[] arr = new int[] { 1, 1, 1, 10, 10, 10 };
            int k = 1;
            int x = 9;
            _658 Closest = new _658();

            var ans = Closest.FindClosestElements1(arr, k, x);

            Console.ReadLine();

        }




        /// <summary>
        //! Two pointer approach . Not binary search
        /// https://leetcode.com/problems/find-k-closest-elements/discuss/202785/Very-simple-Java-O(n)-solution-using-two-pointers
        /// </summary>
        public IList<int> FindClosestElements1(int[] arr, int k, int x)
        {
            int lo = 0;
            int hi = arr.Length - 1;
            List<int> result = new List<int>();
            while (hi - lo + 1 > k)
            {

                if (Math.Abs(arr[lo] - x) > Math.Abs(arr[hi] - x))
                {
                    ++lo;
                }
                //! incase difference is same for lo and hi , we will move hi as array is sorted
                else
                {
                    --hi;
                }
            }

            for (int i = lo; i <= hi; ++i)
            {
                result.Add(arr[i]);
            }
            return result;
        }

        public IList<int> FindClosestElements2(int[] arr, int k, int x)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            List<int> result = new List<int>();

            for (int i = 0; i < arr.Length; ++i)
                map[i] = Math.Abs(arr[i] - x);

            var sortedMap = map.OrderBy(e => e.Value).ThenBy(e => e.Key);

            foreach (KeyValuePair<int, int> keyValuePair in sortedMap)
            {
                result.Add(arr[keyValuePair.Key]);
                if (result.Count == k)
                    break;
            }
            result.Sort();

            return result;
        }



        public IList<int> FindClosestElements3(int[] arr, int k, int x)
        {
            List<int> result = new List<int>();

            Array.Sort(arr,
                      delegate (int a, int b)
                      {
                          if (a == b)
                              return a - b;
                          else
                          {
                              int diff1 = Math.Abs(a - x);
                              int diff2 = Math.Abs(b - x);

                              return diff1 - diff2;
                          }

                      });
            for (int i = 0; i < k; ++i)
            {
                result.Add(arr[i]);
            }

            result.Sort();

            return result;

        }

    }

}
