using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Medium
{
    public class _89
    {
        public IList<int> GrayCode(int n)
        {

            List<int> result = new List<int>();
            HashSet<int> hs = new HashSet<int>();

            GrayCode(0, n, hs, result);
            return result;
        }
        // # <image url="$(SolutionDir)\Images\89.jpg"  scale="0.5"/>
        private void GrayCode(int path, int n, HashSet<int> visited, List<int> result)
        {
            if (visited.Contains(path))
                return;

            visited.Add(path);

            result.Add(path);

            for (int i = 0; i < n; ++i)
            {
                int next = Flip(path, i);
                GrayCode(next, n, visited, result);
            }
        }

        private int Flip(int number, int bitpos)
        {
            return number ^ (1 << bitpos);
        }



    }
}
