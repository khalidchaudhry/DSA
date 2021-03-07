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
        ///https://leetcode.com/problems/largest-rectangle-in-histogram/solution/

        // /// # <image url="$(SolutionDir)\Images\84.png"  scale="0.5"/>

        /// </summary>
        public int LargestRectangleArea0(int[] heights)
        {

            int n = heights.Length;
            int maxArea = 0;
            Stack<int> stk = new Stack<int>();
            //!Setting -1 as the left limit
            stk.Push(-1);
            for (int i = 0; i < n; ++i)
            {
                //! Maintaining monotonicall increasing stack                
                while (stk.Peek() != -1 && heights[i] <= heights[stk.Peek()])
                {
                    //! when we are popping the element(bar) from stack, at that moment we are calculating area for it 
                    int curr = stk.Pop();
                    int rightLimit = i;
                    int leftLimit = stk.Peek();

                    int vd = heights[curr];
                    int hd = rightLimit - leftLimit - 1;
                    maxArea = Math.Max(maxArea, vd * hd);
                }

                stk.Push(i);
            }
            //! process the elements left in the stack
            while (stk.Peek() != -1)
            {
                int curr = stk.Pop();
                int rightLimit = n;
                int leftLimit = stk.Peek();

                int vd = heights[curr];
                int hd = rightLimit - leftLimit - 1;
                maxArea = Math.Max(maxArea, vd * hd);
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
