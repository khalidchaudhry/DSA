using System;
using System.Collections.Generic;

namespace LeetcodeBackTracking.Medium
{
    public class _77
    {

        public static void _77Main()
        {

            _77 Combintions = new _77();
            var result = Combintions.Combine(4, 2);

            Console.ReadLine();

        }
        public IList<IList<int>> Combine0(int n, int k)
        {

            IList<IList<int>> result = new List<IList<int>>();

            Combine0(1, n, k, new List<int>(), result);
            return result;
        }
        private void Combine0(int start, int n, int k, List<int> path, IList<IList<int>> result)
        {
            if (path.Count == k)
            {
                result.Add(new List<int>(path));
                return;
            }
            for (int i = start; i <= n; ++i)
            {
                path.Add(i);
                Combine0(i + 1, n, k, path, result);
                path.RemoveAt(path.Count - 1);
            }
        }

        /// <summary>
        //! Approach followed in sam byte by byte course. 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine(int n, int k)
        {

            IList<IList<int>> result = new List<IList<int>>();

            Combine(1, n, k, new List<int>(), result);
            return result;
        }

        private void Combine(int start, int n, int k, List<int> path, IList<IList<int>> result)
        {

            if (path.Count > k || start > n)
            {
                return;
            }

            if (path.Count == k)
            {
                result.Add(new List<int>(path));
                return;
            }
            //include
            path.Add(start);
            Combine(start + 1, n, k, path, result);
            path.RemoveAt(path.Count - 1);
            //exclude
            Combine(start + 1, n, k, path, result);

        }
    }
}
