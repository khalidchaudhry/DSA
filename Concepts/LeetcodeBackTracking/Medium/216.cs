using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Medium
{
    public class _216
    {
        public static void _216Main()
        {

            _216 CombinationSum = new _216();
            int k = 3;
            int n = 7;

            var result = CombinationSum.CombinationSum3(k, n);

            Console.ReadLine();

        }
        public IList<IList<int>> CombinationSum3(int k, int n)
        {

            List<IList<int>> result = new List<IList<int>>();
            CominbationSum3(k, n, 1, new List<int>(), result);
            return result;
        }

        private void CominbationSum3(int k, int target, int start,
                                     List<int> path,
                                     List<IList<int>> result)
        {

            if (target < 0)
                return;

            if (path.Count > k)
                return;

            if (path.Count == k && target == 0)
            {
                result.Add(new List<int>(path));
                return;
            }

            for (int i = start; i <= 9; ++i) //!choices
            {
                path.Add(i);
                CominbationSum3(k, target - i, i + 1, path, result);
                path.RemoveAt(path.Count - 1);
            }
        }




    }
}
