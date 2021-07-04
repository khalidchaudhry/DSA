using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Hard
{
    public class _84
    {



        /// <summary>
        
        // /// # <image url="$(SolutionDir)\Images\84.png"  scale="0.6"/>

        /// </summary>
        public int LargestRectangleArea0(int[] heights)
        {

            int n = heights.Length;
            int maxArea = 0;
            //! Maintaining monotonicall increasing stack 
            Stack<int> stk = new Stack<int>();
            //!Setting -1 as the left limit
            stk.Push(-1);
            for (int i = 0; i <= n; ++i)
            {
                //! i == n if all values  are in increasing order 
                while (stk.Peek() != -1 && (i == n || heights[stk.Peek()] > heights[i]))
                {
                    int vd = heights[stk.Pop()];
                    int rightLimit = i - 1;
                    int leftLimit = stk.Peek() + 1;
                             //! right-left+1
                    int hd = rightLimit - leftLimit + 1;
                    maxArea = Math.Max(maxArea, vd * hd);
                }
                stk.Push(i);
            }
            return maxArea;
        }

        /// <summary>
        //! Brute Force Approach 
        //! O(N^2) time 
        //! O(N) space
        /// </summary>
        public int LargestRectangleArea(int[] heights)
        {

            int n = heights.Length;
            int maxArea = 0;

            for (int i = 0; i < n; ++i)
            {

                int hd = 0;
                int vd = heights[i];
                for (int j = i; j < n; ++j)
                {
                    vd = Math.Min(vd, heights[j]);
                    ++hd;
                    maxArea = Math.Max(maxArea, vd * hd);
                }
            }
            return maxArea;

        }


    }
}
