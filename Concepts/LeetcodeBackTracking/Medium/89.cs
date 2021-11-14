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
        private void GrayCode(int integer, int totalBits, HashSet<int> visited, List<int> result)
        {
            if (visited.Contains(integer))
                return;

            visited.Add(integer);

            result.Add(integer);
            //!Question asks us to return  n-bit gray code sequence.
            for (int i = 0; i < totalBits; ++i)
            {
                int next = Flip(integer, i);
                //! We will go into recursion by flipping  bit of number 
                GrayCode(next, totalBits, visited, result);
            }
        }

        private int Flip(int number, int bitpos)
        {
            return number ^ (1 << bitpos);
        }



    }
}
