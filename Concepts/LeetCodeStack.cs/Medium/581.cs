using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _581
    {
        /// <summary>
        //! Using monotonically increasing and monotonically decreasing stack 
        /// </summary>
        public int FindUnsortedSubarray(int[] nums)
        {
            //! monotonically increasing stack
            int startIndex = CalculateStartIndex(nums);
            //! monotically decreasing stack
            int endIndex = CalculateEndIndex(nums);

            return startIndex == endIndex ? 0 : endIndex - startIndex + 1;
        }
        /// <summary>
        //! Sort an array and then do comparison 
        //! from left to right, the first index where they differ is the start index
        //! from right to left, the first index where they differ is the end  index
        /// </summary>
        public int FindUnsortedSubarray1(int[] nums)
        {
            int[] sortedNums = nums.OrderBy(i => i).ToArray();
            int startIndex = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] != sortedNums[i])
                {
                    startIndex = i;
                    break;
                }
            }

            int endIndex = 0;
            for (int i = nums.Length - 1; i >= 0; --i)
            {
                if (nums[i] != sortedNums[i])
                {
                    endIndex = i;
                    break;
                }
            }

            return startIndex == endIndex ? 0 : endIndex - startIndex + 1;
        }

        private int CalculateStartIndex(int[] nums)
        {
            Stack<int> stk = new Stack<int>();
            int startIndex = int.MaxValue;
            for (int i = 0; i < nums.Length; ++i)
            {
                while (stk.Count != 0 && nums[i] < nums[stk.Peek()])
                {
                    startIndex = Math.Min(startIndex, stk.Pop());
                }
                stk.Push(i);
            }

            return startIndex == int.MaxValue ? 0 : startIndex;
        }
        private int CalculateEndIndex(int[] nums)
        {
            Stack<int> stk = new Stack<int>();
            int endIndex = int.MinValue;
            for (int i = nums.Length - 1; i >= 0; --i)
            {
                while (stk.Count != 0 && nums[i] > nums[stk.Peek()])
                {
                    endIndex = Math.Max(endIndex, stk.Pop());
                }
                stk.Push(i);
            }
            return endIndex == int.MinValue ? 0 : endIndex;
        }
    }
}
