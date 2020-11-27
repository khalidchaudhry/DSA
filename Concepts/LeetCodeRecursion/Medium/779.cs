using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRecursion.Medium
{
    public class _779
    {
        /// <summary>
        // https://www.youtube.com/watch?v=5P84A0YCo_Y
        /// </summary>       
        /// <returns></returns>
        public int KthGrammar(int N, int K)
        {
            if (N == 1 && K == 1)
                return 0;
            //! range of N is between 1 and 30 hence int type is good
            int length = (int)Math.Pow(2, N - 1);

            int mid = length / 2;

            if (K <= mid)
            {
                return KthGrammar(N - 1, K);
            }
            else
            {
                //! we are flipping in case return value is 0 or 1
                return KthGrammar(N - 1, K - mid) == 0 ? 1 : 0;
            }
        }


    }
}
