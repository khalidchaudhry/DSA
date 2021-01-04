using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeHeap.Medium
{
    public class _378
    {

        //! Using sorted set but too slow. I guess the 
        //!time complexity is O(n^3) and 
        //!space complexity is O(n^2)
        public int KthSmallest(int[][] matrix, int k)
        {

            int n = matrix.Length;
            SortedSet<(int value, int i, int j)> ss = new SortedSet<(int value, int i, int j)>();
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    //! Adding to sorted set takes Amortized log(n) time as sorted set uses red black binary search tree
                    //https://docs.microsoft.com/en-us/dotnet/standard/collections/
                    ss.Add((matrix[i][j], i, j)); 
                }
            }

            int kthSmallest = 0;

            foreach ((int element, int i, int j) in ss)
            {
                --k;
                if (k == 0)
                {
                    return element;
                }
            }

            return kthSmallest;
        }
        /// <summary>
        //! Based on idea in Kuai's class  
        /// </summary>
        public int KthSmallest2(int[][] matrix, int k)
        {
            (int value, int x, int y) result=(-1,-1,-1);

            var rows = matrix.Length;
            var columns = matrix[0].Length;

            var s = new SortedSet<(int value,int x,int y)>();

            for (int r = 0; r < columns; r++)
            {
                //! Adding to sorted set takes Amortized log(n) time as sorted set uses red black binary search tree
                //https://docs.microsoft.com/en-us/dotnet/standard/collections/
                s.Add((matrix[r][0], r, 0));
            }

            while (k > 0)
            {
                result = s.First();

                (int key,int x,int y) = result;
                s.Remove(result);

                if (y < columns - 1)
                {   // go to next column 
                    s.Add((matrix[x][y + 1], x, y + 1));
                }

                k--;
            }

            return result.value;


        }
    }
}
