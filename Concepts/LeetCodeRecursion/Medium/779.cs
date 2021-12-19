using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRecursion.Medium
{
    public class _779
    {

        public static void _779Main()
        {
            _779 Main = new _779();

            int ans=Main.KthGrammar(4, 4);
            Console.WriteLine();
        }

        /// <summary>
        // https://www.youtube.com/watch?v=5P84A0YCo_Y
        //! We need to reduce our input to smaller inputs to reach to the result.
        // // # <image url="$(SolutionDir)\Images\779(2).png"  scale="0.5"/>
        // // # <image url="$(SolutionDir)\Images\779.png"  scale="0.5"/>
        /// </summary>       
        /// <returns></returns>
        public int KthGrammar(int N, int K)
        {
            if (N == 1 && K == 1)
                return 0;
            //! Length(items) of current row is 2^N-1 of the previous row
            int currRowColsCnt = (int)Math.Pow(2, N - 1);
            
            int mid = currRowColsCnt / 2;

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
        /// <summary>       
        //! Brute Force
        //! Time limit excceded
        /// </summary>
        public int KthGrammar1(int N, int K)
        {
            List<List<int>> rows = new List<List<int>>();
            rows.Add(new List<int>() { 0 });
            for (int i = 1; i < N; ++i)
            {
                List<int> prevRow = rows[i - 1];
                List<int> nextRow = new List<int>();
                for (int j = 0; j < prevRow.Count; ++j)
                {
                    if (prevRow[j] == 0)
                    {
                        nextRow.Add(0);
                        nextRow.Add(1);
                    }
                    else
                    {
                        nextRow.Add(1);
                        nextRow.Add(0);
                    }
                }
                rows.Add(nextRow);
            }

            return rows[N - 1][K - 1];
        }
    }
}
