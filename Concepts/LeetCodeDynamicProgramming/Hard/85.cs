using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Hard
{
    public class _85
    {

        public int MaximalRectangle(char[][] matrix)
        {
            if (matrix.Length == 0) return 0;

            int[,] dp = new int[matrix.Length + 1, matrix[0].Length + 1];

            int rows = dp.GetLength(0);
            int colums = dp.GetLength(1);
            //! Calculating vertical distance at every cell
            for (int r = 1; r < rows; ++r)
            {
                for (int c = 1; c < colums; ++c)
                {
                    if (matrix[r - 1][c - 1] == '1')
                    {
                        dp[r, c] = 1 + dp[r - 1, c];
                    }
                }
            }
            //! Below we are calculating horizonal distance and then calculating the area
            // # <image url="https://upload-images.jianshu.io/upload_images/5685046-7fe926497e813696.png?imageMogr2/auto-orient/strip|imageView2/2/w/557/format/webp" scale="0.4" />
            int maxArea = 0;
            for (int r = 1; r < rows; ++r)
            {
                for (int c = 1; c < colums; ++c)
                {
                    if (matrix[r - 1][c - 1] == '1')
                    {
                        int vd = dp[r, c];
                        int hd = 0;
                        for (int c2 = c; c2 < colums; ++c2)
                        {
                            if (dp[r, c2] == 0) break;

                            vd = Math.Min(vd, dp[r, c2]);
                            //int hd = c2 - c + 1;
                            ++hd;
                            maxArea = Math.Max(maxArea, vd * hd);
                        }
                    }
                }
            }
            return maxArea;
        }
    }
}
