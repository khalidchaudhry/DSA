using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Easy
{
    public class _496
    {
        /// <summary>
        //! Using monotonically decreasing stack approach.
        //! REMEMBER, For next greater element go for monotonically decreasing. For next smaller element go for monotonically inreasing.  
        //! WE keep popping out from stack if current array element is greater than the stack top since we are maintaining decreasing stack.
        /// </summary>
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {

            if (nums2.Length == 0 || nums2.Length == 1)
            {
                return new int[] { };
            }
            Dictionary<int, int> map = new Dictionary<int, int>();
            PopulateMapping(nums2, map);
            return CalculateResult(nums1, map);

        }
        private void PopulateMapping(int[] nums2, Dictionary<int, int> map)
        {
            Stack<int> stk = new Stack<int>();
            for (int i = 0; i < nums2.Length; ++i)
            {
                while (stk.Count != 0 && stk.Peek() < nums2[i])
                {
                    map.Add(stk.Pop(), nums2[i]);
                }
                stk.Push(nums2[i]);
            }
        }

        private int[] CalculateResult(int[] nums1, Dictionary<int, int> map)
        {
            int[] result = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; ++i)
            {
                if (map.ContainsKey(nums1[i]))
                {
                    result[i] = map[nums1[i]];
                }
                else
                    result[i] = -1;
            }

            return result;
        }


    }
}
