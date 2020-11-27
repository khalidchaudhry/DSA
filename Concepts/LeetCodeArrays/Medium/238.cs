using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _238
    {

        /// <summary>
        //! Basic intuition is that at given element , 
        //!if we know what's on its left side and on its right side
        //! then we multiply them to get product for that element
        /// </summary>
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] result = new int[nums.Length];
            int[] L = new int[nums.Length];
            int[] R = new int[nums.Length];
            // so L[0] would be 1
            L[0] = 1;
            for (int i = 1; i < L.Length; ++i)
            {
                L[i] = L[i - 1] * nums[i - 1];
            }
            R[R.Length - 1] = 1;
            for (int i = R.Length - 2; i >= 0; --i)
            {
                R[i] = R[i + 1] * nums[i + 1];
            }

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = L[i] * R[i];
            }

            return result;
        }

        public int[] ProductExceptSelf2(int[] nums)
        {
            int[] result = new int[nums.Length];

            //!Initially stores the left side product in result array
            result[0] = 1;
            for (int i = 1; i < nums.Length; ++i)
            {
                result[i] = result[i - 1] * nums[i - 1];
            }
            int R = 1;
            for (int i = nums.Length - 1; i >= 0; --i)
            {
                // For the index 'i', R would contain the 
                // product of all elements to the right. We update R accordingly
                result[i] = result[i] * R;
                R = R * nums[i];
            }

            return result;
        }

    }
}
